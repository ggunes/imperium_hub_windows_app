using HidSharp;
using ImperiumGearHUB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public class HidDeviceService : IDeviceService
    {
        // Imperium cihazlarının VID/PID değerleri
        private const int IMPERIUM_VID = 0x1234; // Örnek VID, gerçek değerle değiştirilmeli
        private const int IMPERIUM_I75_PID = 0x5678; // Örnek PID, gerçek değerle değiştirilmeli
        private const int IMPERIUM_SENTINEL_X1_PID = 0x5679; // Örnek PID, gerçek değerle değiştirilmeli

        private readonly Dictionary<string, HidDevice> _connectedDevices = new Dictionary<string, HidDevice>();
        private readonly Dictionary<string, HidStream> _deviceStreams = new Dictionary<string, HidStream>();

        // Cihaz yanıt bekleme süresi (ms)
        private const int RESPONSE_TIMEOUT = 1000;

        public async Task<List<Device>> GetDevicesAsync()
        {
            return await Task.Run(() =>
            {
                var devices = new List<Device>();
                var hidDeviceList = DeviceList.Local.GetHidDevices();

                foreach (var hidDevice in hidDeviceList)
                {
                    // Imperium cihazlarını filtrele
                    if (hidDevice.VendorID == IMPERIUM_VID)
                    {
                        var device = new Device
                        {
                            Id = $"{hidDevice.VendorID:X4}:{hidDevice.ProductID:X4}:{hidDevice.SerialNumber}",
                            VendorId = (ushort)hidDevice.VendorID,
                            ProductId = (ushort)hidDevice.ProductID,
                            SerialNumber = hidDevice.SerialNumber ?? "Unknown"
                        };

                        // Cihaz tipini belirle
                        if (hidDevice.ProductID == IMPERIUM_I75_PID)
                        {
                            device.Name = "Imperium I75 Klavye";
                            device.Type = DeviceType.Keyboard;
                        }
                        else if (hidDevice.ProductID == IMPERIUM_SENTINEL_X1_PID)
                        {
                            device.Name = "Imperium Sentinel X1 Mouse";
                            device.Type = DeviceType.Mouse;
                        }
                        else
                        {
                            device.Name = $"Bilinmeyen Imperium Cihazı (PID: 0x{hidDevice.ProductID:X4})";
                            device.Type = DeviceType.Unknown;
                        }

                        // Cihaz bağlantı durumunu kontrol et
                        device.IsConnected = _connectedDevices.ContainsKey(device.Id);

                        devices.Add(device);
                    }
                }

                return devices;
            });
        }

        public async Task<bool> ConnectToDeviceAsync(Device device)
        {
            if (_connectedDevices.ContainsKey(device.Id))
            {
                // Zaten bağlı
                return true;
            }

            return await Task.Run(() =>
            {
                try
                {
                    var hidDeviceList = DeviceList.Local.GetHidDevices()
                        .Where(d => d.VendorID == device.VendorId && d.ProductID == device.ProductId)
                        .ToList();

                    if (hidDeviceList.Count == 0)
                    {
                        return false;
                    }

                    var hidDevice = hidDeviceList.First();
                    
                    if (hidDevice.TryOpen(out HidStream stream))
                    {
                        _connectedDevices[device.Id] = hidDevice;
                        _deviceStreams[device.Id] = stream;
                        device.IsConnected = true;
                        return true;
                    }
                }
                catch (Exception)
                {
                    // Hata durumunda bağlantı başarısız
                }

                return false;
            });
        }

        public async Task<bool> DisconnectFromDeviceAsync(Device device)
        {
            if (!_connectedDevices.ContainsKey(device.Id))
            {
                // Zaten bağlı değil
                return true;
            }

            return await Task.Run(() =>
            {
                try
                {
                    if (_deviceStreams.TryGetValue(device.Id, out HidStream? stream))
                    {
                        stream.Close();
                        _deviceStreams.Remove(device.Id);
                    }

                    _connectedDevices.Remove(device.Id);
                    device.IsConnected = false;
                    return true;
                }
                catch (Exception)
                {
                    // Hata durumunda işlem başarısız
                    return false;
                }
            });
        }

        public async Task<bool> SendCommandAsync(Device device, byte[] command)
        {
            if (!_deviceStreams.TryGetValue(device.Id, out HidStream? stream))
            {
                return false;
            }

            return await Task.Run(() =>
            {
                try
                {
                    stream.Write(command);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        public async Task<byte[]> ReadDataAsync(Device device, int length)
        {
            if (!_deviceStreams.TryGetValue(device.Id, out HidStream? stream))
            {
                return Array.Empty<byte>();
            }

            return await Task.Run(() =>
            {
                try
                {
                    byte[] buffer = new byte[length];
                    int bytesRead = stream.Read(buffer, 0, length);
                    
                    if (bytesRead < length)
                    {
                        Array.Resize(ref buffer, bytesRead);
                    }
                    
                    return buffer;
                }
                catch (Exception)
                {
                    return Array.Empty<byte>();
                }
            });
        }

        /// <summary>
        /// Cihazdan bilgi alır (firmware versiyonu, vb.)
        /// </summary>
        public async Task<bool> GetDeviceInfoAsync(Device device)
        {
            if (!device.IsConnected)
            {
                await ConnectToDeviceAsync(device);
            }

            if (!device.IsConnected)
            {
                return false;
            }

            var command = DeviceCommands.CreateGetInfoCommand();
            if (!await SendCommandAsync(device, command))
            {
                return false;
            }

            // Yanıt bekle
            var response = await ReadDataAsync(device, 64);
            if (response.Length == 0)
            {
                return false;
            }

            // Yanıtı işle
            var (firmwareVersion, serialNumber) = DeviceResponseParser.ParseDeviceInfo(response);
            if (!string.IsNullOrEmpty(firmwareVersion))
            {
                device.FirmwareVersion = firmwareVersion;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Klavye RGB ayarlarını değiştirir
        /// </summary>
        public async Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness)
        {
            if (device.Type != DeviceType.Keyboard || !device.IsConnected)
            {
                return false;
            }

            var command = DeviceCommands.CreateSetRGBCommand(mode, red, green, blue, speed, brightness);
            return await SendCommandAsync(device, command);
        }

        /// <summary>
        /// Mouse DPI ayarlarını değiştirir
        /// </summary>
        public async Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue)
        {
            if (device.Type != DeviceType.Mouse || !device.IsConnected)
            {
                return false;
            }

            var command = DeviceCommands.CreateSetDPICommand(level, dpiValue, red, green, blue);
            return await SendCommandAsync(device, command);
        }

        /// <summary>
        /// Mouse Polling Rate ayarını değiştirir
        /// </summary>
        public async Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate rate)
        {
            if (device.Type != DeviceType.Mouse || !device.IsConnected)
            {
                return false;
            }

            var command = DeviceCommands.CreateSetPollingRateCommand(rate);
            return await SendCommandAsync(device, command);
        }

        /// <summary>
        /// Klavye Hall Effect ayarlarını değiştirir
        /// </summary>
        public async Task<bool> SetKeyboardHallEffectAsync(Device device, byte actuationPoint, bool rapidTrigger, byte dynamicKeystroke)
        {
            if (device.Type != DeviceType.Keyboard || !device.IsConnected)
            {
                return false;
            }

            var command = DeviceCommands.CreateSetHallEffectCommand(actuationPoint, rapidTrigger, dynamicKeystroke);
            return await SendCommandAsync(device, command);
        }

        /// <summary>
        /// Mouse LOD ayarını değiştirir
        /// </summary>
        public async Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lod)
        {
            if (device.Type != DeviceType.Mouse || !device.IsConnected)
            {
                return false;
            }

            var command = DeviceCommands.CreateSetLODCommand(lod);
            return await SendCommandAsync(device, command);
        }

        /// <summary>
        /// Mouse Angle Snapping ayarını değiştirir
        /// </summary>
        public async Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled)
        {
            if (device.Type != DeviceType.Mouse || !device.IsConnected)
            {
                return false;
            }

            var command = DeviceCommands.CreateSetAngleSnappingCommand(enabled);
            return await SendCommandAsync(device, command);
        }

        /// <summary>
        /// Mouse Debounce Time ayarını değiştirir
        /// </summary>
        public async Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime)
        {
            if (device.Type != DeviceType.Mouse || !device.IsConnected)
            {
                return false;
            }

            var command = DeviceCommands.CreateSetDebounceTimeCommand(debounceTime);
            return await SendCommandAsync(device, command);
        }

        /// <summary>
        /// Cihazı firmware güncelleme moduna alır
        /// </summary>
        public async Task<bool> EnterBootloaderModeAsync(Device device)
        {
            if (!device.IsConnected)
            {
                return false;
            }

            var command = DeviceCommands.CreateEnterBootloaderCommand();
            return await SendCommandAsync(device, command);
        }
    }
}
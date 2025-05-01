using ImperiumGearHUB.Models;
using System;
using System.Collections.Generic;

namespace ImperiumGearHUB.Services.HID
{
    /// <summary>
    /// Cihazlardan gelen yanıtları işleyen yardımcı sınıf
    /// </summary>
    public static class DeviceResponseParser
    {
        /// <summary>
        /// Cihaz bilgisi yanıtını işler
        /// </summary>
        public static (string firmwareVersion, byte[] serialNumber) ParseDeviceInfo(byte[] response)
        {
            if (response.Length < 8 || response[1] != (byte)DeviceCommands.CommandType.GetInfo)
            {
                return (string.Empty, Array.Empty<byte>());
            }

            // Firmware versiyonu: Major.Minor.Patch
            string firmwareVersion = $"{response[2]}.{response[3]}.{response[4]}";
            
            // Seri numarası (varsa)
            byte[] serialNumber = new byte[response.Length - 6];
            Array.Copy(response, 5, serialNumber, 0, serialNumber.Length);
            
            return (firmwareVersion, serialNumber);
        }

        /// <summary>
        /// RGB ayarları yanıtını işler
        /// </summary>
        public static (DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness) ParseRGBSettings(byte[] response)
        {
            if (response.Length < 8 || response[1] != (byte)DeviceCommands.CommandType.GetRGB)
            {
                return (DeviceCommands.RGBEffectMode.Static, 0, 0, 0, 0, 0);
            }

            return (
                (DeviceCommands.RGBEffectMode)response[2],
                response[3], // Red
                response[4], // Green
                response[5], // Blue
                response[6], // Speed
                response[7]  // Brightness
            );
        }

        /// <summary>
        /// DPI ayarları yanıtını işler
        /// </summary>
        public static List<(ushort dpiValue, byte red, byte green, byte blue)> ParseDPISettings(byte[] response)
        {
            if (response.Length < 7 || response[1] != (byte)DeviceCommands.CommandType.GetDPI)
            {
                return new List<(ushort, byte, byte, byte)>();
            }

            var dpiSettings = new List<(ushort, byte, byte, byte)>();
            int numLevels = response[2];
            
            int offset = 3;
            for (int i = 0; i < numLevels && offset + 5 <= response.Length; i++)
            {
                ushort dpiValue = (ushort)((response[offset + 1] << 8) | response[offset]);
                byte red = response[offset + 2];
                byte green = response[offset + 3];
                byte blue = response[offset + 4];
                
                dpiSettings.Add((dpiValue, red, green, blue));
                offset += 5;
            }
            
            return dpiSettings;
        }

        /// <summary>
        /// Polling Rate ayarı yanıtını işler
        /// </summary>
        public static DeviceCommands.PollingRate ParsePollingRate(byte[] response)
        {
            if (response.Length < 3 || response[1] != (byte)DeviceCommands.CommandType.GetPollingRate)
            {
                return DeviceCommands.PollingRate.Rate1000Hz;
            }

            return (DeviceCommands.PollingRate)response[2];
        }

        /// <summary>
        /// Hall Effect ayarları yanıtını işler
        /// </summary>
        public static (byte actuationPoint, bool rapidTrigger, byte dynamicKeystroke) ParseHallEffectSettings(byte[] response)
        {
            if (response.Length < 5 || response[1] != (byte)DeviceCommands.CommandType.GetHallEffectSettings)
            {
                return (0, false, 0);
            }

            return (
                response[2], // Actuation Point
                response[3] != 0, // Rapid Trigger
                response[4]  // Dynamic Keystroke
            );
        }
    }
}
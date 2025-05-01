using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
        
        // Klavye Komutları
        Task<bool> SetKeyboardRGBAsync(Device device, DeviceCommands.RGBEffectMode mode, byte red, byte green, byte blue, byte speed, byte brightness);
        Task<bool> SetKeyboardActuationPointAsync(Device device, byte actuationPoint);
        Task<bool> SetKeyboardRapidTriggerAsync(Device device, bool enabled);
        
        // Fare Komutları
        Task<bool> SetMouseDPIAsync(Device device, byte level, ushort dpiValue, byte red, byte green, byte blue);
        Task<bool> SetMousePollingRateAsync(Device device, DeviceCommands.PollingRate pollingRate);
        Task<bool> SetMouseLODAsync(Device device, DeviceCommands.LODSetting lodSetting);
        Task<bool> SetMouseAngleSnappingAsync(Device device, bool enabled);
        Task<bool> SetMouseDebounceTimeAsync(Device device, byte debounceTime);
        
        // Profil Komutları
        Task<bool> SaveProfileAsync(Device device, Profile profile);
        Task<bool> LoadProfileAsync(Device device, Profile profile);
    }
}
using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services.HID
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<bool> ConnectDeviceAsync(Device device);
        Task<bool> DisconnectDeviceAsync(Device device);
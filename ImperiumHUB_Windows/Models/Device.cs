using System;

namespace ImperiumGearHUB.Models
{
    public enum DeviceType
    {
        Keyboard,
        Mouse
    }

    public class Device
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string FirmwareVersion { get; set; }
        public DeviceType Type { get; set; }
        public bool IsConnected { get; set; }
        public ushort VendorId { get; set; }
        public ushort ProductId { get; set; }
        public string ConnectionType { get; set; } // USB, Bluetooth, etc.
    }
}
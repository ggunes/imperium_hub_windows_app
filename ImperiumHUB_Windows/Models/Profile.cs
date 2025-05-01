using System;
using System.Collections.Generic;

namespace ImperiumGearHUB.Models
{
    public class Profile
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string DeviceId { get; set; }
        public DeviceType DeviceType { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        
        // Klavye ayarları
        public KeyboardSettings KeyboardSettings { get; set; }
        
        // Fare ayarları
        public MouseSettings MouseSettings { get; set; }
    }

    public enum DeviceType
    {
        Keyboard,
        Mouse,
        Headset
    }

    public class KeyboardSettings
    {
        public byte ActuationPoint { get; set; } = 1;
        public bool RapidTrigger { get; set; } = false;
        public RGBSettings RGB { get; set; } = new RGBSettings();
        public Dictionary<string, KeyMapping> KeyMappings { get; set; } = new Dictionary<string, KeyMapping>();
    }

    public class MouseSettings
    {
        public List<DPILevel> DPILevels { get; set; } = new List<DPILevel>();
        public int PollingRate { get; set; } = 1000;
        public int LOD { get; set; } = 2;
        public bool AngleSnapping { get; set; } = false;
        public byte DebounceTime { get; set; } = 10;
        public RGBSettings RGB { get; set; } = new RGBSettings();
        public Dictionary<string, ButtonMapping> ButtonMappings { get; set; } = new Dictionary<string, ButtonMapping>();
    }

    public class DPILevel
    {
        public byte Level { get; set; }
        public ushort DPI { get; set; }
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
    }

    public class RGBSettings
    {
        public byte Mode { get; set; } = 0;
        public byte Red { get; set; } = 255;
        public byte Green { get; set; } = 0;
        public byte Blue { get; set; } = 0;
        public byte Speed { get; set; } = 3;
        public byte Brightness { get; set; } = 100;
    }

    public class KeyMapping
    {
        public string OriginalKey { get; set; }
        public string MappedKey { get; set; }
        public List<string> MacroKeys { get; set; } = new List<string>();
        public bool IsMacro { get; set; } = false;
    }

    public class ButtonMapping
    {
        public string OriginalButton { get; set; }
        public string MappedButton { get; set; }
        public List<string> MacroKeys { get; set; } = new List<string>();
        public bool IsMacro { get; set; } = false;
    }
}
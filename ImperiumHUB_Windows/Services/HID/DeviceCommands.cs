using System;
using System.Collections.Generic;

namespace ImperiumGearHUB.Services.HID
{
    public class DeviceCommands
    {
        public enum RGBEffectMode
        {
            Static = 0,
            Breathing = 1,
            Wave = 2,
            Cycle = 3,
            Rainbow = 4
        }

        public enum PollingRate : byte
        {
            Rate125Hz = 0,
            Rate250Hz = 1,
            Rate500Hz = 2,
            Rate1000Hz = 3,
            Rate2000Hz = 4,
            Rate4000Hz = 5,
            Rate8000Hz = 6
        }

        public enum LODSetting : byte
        {
            Low = 0,
            Medium = 1,
            High = 2
        }

        // Klavye komutları
        public const byte CMD_KEYBOARD_RGB = 0x01;
        public const byte CMD_KEYBOARD_ACTUATION = 0x02;
        public const byte CMD_KEYBOARD_RAPID_TRIGGER = 0x03;

        // Fare komutları
        public const byte CMD_MOUSE_DPI = 0x10;
        public const byte CMD_MOUSE_POLLING_RATE = 0x11;
        public const byte CMD_MOUSE_LOD = 0x12;
        public const byte CMD_MOUSE_ANGLE_SNAPPING = 0x13;
        public const byte CMD_MOUSE_DEBOUNCE = 0x14;

        // Profil komutları
        public const byte CMD_PROFILE_SAVE = 0x20;
        public const byte CMD_PROFILE_LOAD = 0x21;
    }
}
// ... existing code ...
public class MouseSettings
{
    public ObservableCollection<DpiSetting> DpiSettings { get; set; } = new ObservableCollection<DpiSetting>();
    public DeviceCommands.PollingRate PollingRate { get; set; }
    public DeviceCommands.LODSetting LodSetting { get; set; }
    public bool AngleSnappingEnabled { get; set; }
    public byte DebounceTime { get; set; }
    
    // RGB Ayarları
    public DeviceCommands.RGBEffectMode RgbMode { get; set; }
    public byte RgbRed { get; set; }
    public byte RgbGreen { get; set; }
    public byte RgbBlue { get; set; }
    public byte RgbSpeed { get; set; }
    public byte RgbBrightness { get; set; }
}
// ... existing code ...
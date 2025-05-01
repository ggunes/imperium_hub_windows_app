using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ImperiumGearHUB.Models;
using ImperiumGearHUB.Services;
using ImperiumGearHUB.Services.HID;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ImperiumGearHUB.ViewModels
{
    public class MouseViewModel : ObservableObject
    {
        private readonly IDeviceService _deviceService;
        private readonly IProfileService _profileService;
        private Device _currentDevice;

        // DPI Ayarları
        public ObservableCollection<DpiSetting> DpiSettings { get; } = new ObservableCollection<DpiSetting>();
        private DpiSetting _selectedDpiSetting;
        public DpiSetting SelectedDpiSetting
        {
            get => _selectedDpiSetting;
            set => SetProperty(ref _selectedDpiSetting, value);
        }

        // Polling Rate Ayarları
        private DeviceCommands.PollingRate _selectedPollingRate;
        public DeviceCommands.PollingRate SelectedPollingRate
        {
            get => _selectedPollingRate;
            set => SetProperty(ref _selectedPollingRate, value);
        }

        // LOD Ayarları
        private DeviceCommands.LODSetting _selectedLodSetting;
        public DeviceCommands.LODSetting SelectedLodSetting
        {
            get => _selectedLodSetting;
            set => SetProperty(ref _selectedLodSetting, value);
        }

        // Angle Snapping
        private bool _angleSnappingEnabled;
        public bool AngleSnappingEnabled
        {
            get => _angleSnappingEnabled;
            set => SetProperty(ref _angleSnappingEnabled, value);
        }

        // Debounce Time
        private byte _debounceTime;
        public byte DebounceTime
        {
            get => _debounceTime;
            set => SetProperty(ref _debounceTime, value);
        }

        // Profil Ayarları
        private ObservableCollection<Profile> _profiles = new ObservableCollection<Profile>();
        public ObservableCollection<Profile> Profiles
        {
            get => _profiles;
            set => SetProperty(ref _profiles, value);
        }

        private Profile _selectedProfile;
        public Profile SelectedProfile
        {
            get => _selectedProfile;
            set => SetProperty(ref _selectedProfile, value);
        }

        // Komutlar
        public IRelayCommand ApplyDpiSettingCommand { get; }
        public IRelayCommand ApplyPollingRateCommand { get; }
        public IRelayCommand ApplyLodSettingCommand { get; }
        public IRelayCommand ApplyAngleSnappingCommand { get; }
        public IRelayCommand ApplyDebounceTimeCommand { get; }
        public IRelayCommand SaveProfileCommand { get; }
        public IRelayCommand LoadProfileCommand { get; }
        public IRelayCommand AddDpiSettingCommand { get; }
        public IRelayCommand RemoveDpiSettingCommand { get; }
        public IRelayCommand ExportProfileCommand { get; }
        public IRelayCommand ImportProfileCommand { get; }
        public IRelayCommand ApplyRgbSettingsCommand { get; }
        public IRelayCommand CreateProfileCommand { get; }
        public IRelayCommand DeleteProfileCommand { get; }
        public IRelayCommand CloneProfileCommand { get; }

        public MouseViewModel(IDeviceService deviceService, IProfileService profileService)
        {
            _deviceService = deviceService;
            _profileService = profileService;

            // Komutları başlat
            ApplyDpiSettingCommand = new RelayCommand(ApplyDpiSetting);
            ApplyPollingRateCommand = new RelayCommand(ApplyPollingRate);
            ApplyLodSettingCommand = new RelayCommand(ApplyLodSetting);
            ApplyAngleSnappingCommand = new RelayCommand(ApplyAngleSnapping);
            ApplyDebounceTimeCommand = new RelayCommand(ApplyDebounceTime);
            SaveProfileCommand = new RelayCommand(SaveProfile);
            LoadProfileCommand = new RelayCommand(LoadProfile);
            AddDpiSettingCommand = new RelayCommand(AddDpiSetting);
            RemoveDpiSettingCommand = new RelayCommand(RemoveDpiSetting);
            ExportProfileCommand = new RelayCommand(ExportProfile);
            ImportProfileCommand = new RelayCommand(ImportProfile);
            ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
            CreateProfileCommand = new RelayCommand(CreateProfile);
            DeleteProfileCommand = new RelayCommand(DeleteProfile);
            CloneProfileCommand = new RelayCommand(CloneProfile);
            
            // RGB ayarları için varsayılan değerler
            SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
            RedValue = 255;
            GreenValue = 0;
            BlueValue = 0;
            SpeedValue = 5;
            BrightnessValue = 100;

            // Varsayılan DPI ayarlarını ekle
            InitializeDefaultDpiSettings();
            
            // Varsayılan değerleri ayarla
            SelectedPollingRate = DeviceCommands.PollingRate.Rate1000Hz;
            SelectedLodSetting = DeviceCommands.LODSetting.Low;
            AngleSnappingEnabled = false;
            DebounceTime = 10;
        }

        public void SetCurrentDevice(Device device)
        {
            _currentDevice = device;
            LoadDeviceSettings();
        }

        private async void LoadDeviceSettings()
        {
            if (_currentDevice == null)
                return;

            try
            {
                // Cihaz profillerini yükle
                var profiles = await _profileService.GetProfilesForDeviceAsync(_currentDevice.DeviceId);
                Profiles.Clear();
                foreach (var profile in profiles)
                {
                    Profiles.Add(profile);
                }

                // Varsayılan profili seç
                if (Profiles.Count > 0)
                {
                    SelectedProfile = Profiles.First();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cihaz ayarları yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void InitializeDefaultDpiSettings()
        {
            DpiSettings.Clear();
            DpiSettings.Add(new DpiSetting { Level = 1, DpiValue = 800, Color = Colors.Red });
            DpiSettings.Add(new DpiSetting { Level = 2, DpiValue = 1600, Color = Colors.Green });
            DpiSettings.Add(new DpiSetting { Level = 3, DpiValue = 3200, Color = Colors.Blue });
            DpiSettings.Add(new DpiSetting { Level = 4, DpiValue = 6400, Color = Colors.Purple });
            
            if (DpiSettings.Count > 0)
            {
                SelectedDpiSetting = DpiSettings[0];
            }
        }

        private async void ApplyDpiSetting()
        {
            if (_currentDevice == null || SelectedDpiSetting == null)
                return;

            try
            {
                var result = await _deviceService.SetMouseDPIAsync(
                    _currentDevice,
                    SelectedDpiSetting.Level,
                    SelectedDpiSetting.DpiValue,
                    SelectedDpiSetting.Color.R,
                    SelectedDpiSetting.Color.G,
                    SelectedDpiSetting.Color.B);

                if (result)
                {
                    MessageBox.Show("DPI ayarları başarıyla uygulandı.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("DPI ayarları uygulanırken bir hata oluştu.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"DPI ayarları uygulanırken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ApplyPollingRate()
        {
            if (_currentDevice == null)
                return;

            try
            {
                var result = await _deviceService.SetMousePollingRateAsync(_currentDevice, SelectedPollingRate);

                if (result)
                {
                    MessageBox.Show("Polling Rate ayarları başarıyla uygulandı.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Polling Rate ayarları uygulanırken bir hata oluştu.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Polling Rate ayarları uygulanırken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ApplyLodSetting()
        {
            if (_currentDevice == null)
                return;

            try
            {
                var result = await _deviceService.SetMouseLODAsync(_currentDevice, SelectedLodSetting);

                if (result)
                {
                    MessageBox.Show("LOD ayarları başarıyla uygulandı.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("LOD ayarları uygulanırken bir hata oluştu.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"LOD ayarları uygulanırken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ApplyAngleSnapping()
        {
            if (_currentDevice == null)
                return;

            try
            {
                var result = await _deviceService.SetMouseAngleSnappingAsync(_currentDevice, AngleSnappingEnabled);

                if (result)
                {
                    MessageBox.Show("Angle Snapping ayarları başarıyla uygulandı.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Angle Snapping ayarları uygulanırken bir hata oluştu.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Angle Snapping ayarları uygulanırken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ApplyDebounceTime()
        {
            if (_currentDevice == null)
                return;

            try
            {
                var result = await _deviceService.SetMouseDebounceTimeAsync(_currentDevice, DebounceTime);

                if (result)
                {
                    MessageBox.Show("Debounce Time ayarları başarıyla uygulandı.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Debounce Time ayarları uygulanırken bir hata oluştu.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Debounce Time ayarları uygulanırken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddDpiSetting()
        {
            if (DpiSettings.Count >= 5)
            {
                MessageBox.Show("En fazla 5 DPI ayarı ekleyebilirsiniz.", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            byte nextLevel = (byte)(DpiSettings.Count + 1);
            var newDpiSetting = new DpiSetting
            {
                Level = nextLevel,
                DpiValue = 1600,
                Color = Colors.White
            };

            DpiSettings.Add(newDpiSetting);
            SelectedDpiSetting = newDpiSetting;
        }

        private void RemoveDpiSetting()
        {
            if (DpiSettings.Count <= 1)
            {
                MessageBox.Show("En az bir DPI ayarı bulunmalıdır.", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (SelectedDpiSetting != null)
            {
                DpiSettings.Remove(SelectedDpiSetting);
                
                // Kalan DPI ayarlarının seviyelerini güncelle
                for (int i = 0; i < DpiSettings.Count; i++)
                {
                    DpiSettings[i].Level = (byte)(i + 1);
                }

                if (DpiSettings.Count > 0)
                {
                    SelectedDpiSetting = DpiSettings[0];
                }
            }
        }

        private async void SaveProfile()
        {
            if (_currentDevice == null || SelectedProfile == null)
                return;

            try
            {
                // Mevcut ayarları profile kaydet
                SelectedProfile.MouseSettings = new MouseSettings
                {
                    DpiSettings = new ObservableCollection<DpiSetting>(DpiSettings),
                    PollingRate = SelectedPollingRate,
                    LodSetting = SelectedLodSetting,
                    AngleSnappingEnabled = AngleSnappingEnabled,
                    DebounceTime = DebounceTime
                };

                var result = await _profileService.SaveProfileAsync(SelectedProfile);
                if (result)
                {
                    MessageBox.Show("Profil başarıyla kaydedildi.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Profil kaydedilirken bir hata oluştu.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Profil kaydedilirken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void LoadProfile()
        {
            if (_currentDevice == null || SelectedProfile == null)
                return;

            try
            {
                var profile = await _profileService.GetProfileAsync(SelectedProfile.Id);
                if (profile?.MouseSettings != null)
                {
                    // Profil ayarlarını yükle
                    DpiSettings.Clear();
                    foreach (var dpiSetting in profile.MouseSettings.DpiSettings)
                    {
                        DpiSettings.Add(dpiSetting);
                    }

                    if (DpiSettings.Count > 0)
                    {
                        SelectedDpiSetting = DpiSettings[0];
                    }

                    SelectedPollingRate = profile.MouseSettings.PollingRate;
                    SelectedLodSetting = profile.MouseSettings.LodSetting;
                    AngleSnappingEnabled = profile.MouseSettings.AngleSnappingEnabled;
                    DebounceTime = profile.MouseSettings.DebounceTime;

                    MessageBox.Show("Profil başarıyla yüklendi.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Profil yüklenemedi veya fare ayarları bulunamadı.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Profil yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExportProfile()
        {
            if (SelectedProfile == null)
                return;

            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "JSON Dosyaları (*.json)|*.json",
                    Title = "Profili Dışa Aktar",
                    FileName = $"{SelectedProfile.Name}.json"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    _profileService.ExportProfileAsync(SelectedProfile, saveFileDialog.FileName);
                    MessageBox.Show("Profil başarıyla dışa aktarıldı.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Profil dışa aktarılırken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ImportProfile()
        {
            if (_currentDevice == null)
                return;

            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "JSON Dosyaları (*.json)|*.json",
                    Title = "Profili İçe Aktar"
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    var profile = await _profileService.ImportProfileAsync(openFileDialog.FileName);
                    if (profile != null)
                    {
                        // İçe aktarılan profili mevcut cihaza bağla
                        profile.DeviceId = _currentDevice.DeviceId;
                        
                        // Profili kaydet
                        await _profileService.SaveProfileAsync(profile);
                        Profiles.Add(profile);
                        SelectedProfile = profile;
                        
                        MessageBox.Show("Profil başarıyla içe aktarıldı.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Profil içe aktarılamadı.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Profil içe aktarılırken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private Dictionary<string, object> CreateSettingsDictionary()
        {
            var settings = new Dictionary<string, object>();
            
            // DPI ayarları
            for (int i = 0; i < DpiSettings.Count; i++)
            {
                var dpi = DpiSettings[i];
                settings[$"DPI_{i}_Level"] = dpi.Level;
                settings[$"DPI_{i}_Value"] = dpi.DpiValue;
                settings[$"DPI_{i}_Red"] = dpi.Color.R;
                settings[$"DPI_{i}_Green"] = dpi.Color.G;
                settings[$"DPI_{i}_Blue"] = dpi.Color.B;
            }
            
            // Polling rate
            settings["PollingRate"] = (int)SelectedPollingRate;
            
            // LOD ayarı
            settings["LODSetting"] = (int)SelectedLodSetting;
            
            // Angle snapping
            settings["AngleSnapping"] = AngleSnappingEnabled;
            
            // Debounce time
            settings["DebounceTime"] = DebounceTime;
            
            // RGB ayarları
            settings["RGBMode"] = (int)SelectedRgbMode;
            settings["RGBRed"] = RedValue;
            settings["RGBGreen"] = GreenValue;
            settings["RGBBlue"] = BlueValue;
            settings["RGBSpeed"] = SpeedValue;
            settings["RGBBrightness"] = BrightnessValue;
            
            return settings;
        }

        private void ApplySettingsFromDictionary(Dictionary<string, object> settings)
        {
            if (settings == null || settings.Count == 0)
            {
                return;
            }
            
            try
            {
                // DPI ayarları
                DpiSettings.Clear();
                int dpiIndex = 0;
                while (settings.ContainsKey($"DPI_{dpiIndex}_Level"))
                {
                    byte level = Convert.ToByte(settings[$"DPI_{dpiIndex}_Level"]);
                    ushort value = Convert.ToUInt16(settings[$"DPI_{dpiIndex}_Value"]);
                    byte red = Convert.ToByte(settings[$"DPI_{dpiIndex}_Red"]);
                    byte green = Convert.ToByte(settings[$"DPI_{dpiIndex}_Green"]);
                    byte blue = Convert.ToByte(settings[$"DPI_{dpiIndex}_Blue"]);
                    
                    var color = Color.FromRgb(red, green, blue);
                    DpiSettings.Add(new DpiSetting { Level = level, DpiValue = value, Color = color });
                    dpiIndex++;
                }
                
                if (DpiSettings.Count > 0)
                {
                    SelectedDpiSetting = DpiSettings[0];
                }
                
                // Polling rate
                if (settings.ContainsKey("PollingRate"))
                {
                    SelectedPollingRate = (DeviceCommands.PollingRate)Convert.ToInt32(settings["PollingRate"]);
                }
                
                // LOD ayarı
                if (settings.ContainsKey("LODSetting"))
                {
                    SelectedLodSetting = (DeviceCommands.LODSetting)Convert.ToInt32(settings["LODSetting"]);
                }
                
                // Angle snapping
                if (settings.ContainsKey("AngleSnapping"))
                {
                    AngleSnappingEnabled = Convert.ToBoolean(settings["AngleSnapping"]);
                }
                
                // Debounce time
                if (settings.ContainsKey("DebounceTime"))
                {
                    DebounceTime = Convert.ToByte(settings["DebounceTime"]);
                }
                
                // RGB ayarları
                if (settings.ContainsKey("RGBMode"))
                {
                    SelectedRgbMode = (DeviceCommands.RGBEffectMode)Convert.ToInt32(settings["RGBMode"]);
                }
                
                if (settings.ContainsKey("RGBRed"))
                {
                    RedValue = Convert.ToByte(settings["RGBRed"]);
                }
                
                if (settings.ContainsKey("RGBGreen"))
                {
                    GreenValue = Convert.ToByte(settings["RGBGreen"]);
                }
                
                if (settings.ContainsKey("RGBBlue"))
                {
                    BlueValue = Convert.ToByte(settings["RGBBlue"]);
                }
                
                if (settings.ContainsKey("RGBSpeed"))
                {
                    SpeedValue = Convert.ToByte(settings["RGBSpeed"]);
                }
                
                if (settings.ContainsKey("RGBBrightness"))
                {
                    BrightnessValue = Convert.ToByte(settings["RGBBrightness"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ayarlar uygulanırken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        // RGB Ayarları
        private DeviceCommands.RGBEffectMode _selectedRgbMode;
        public DeviceCommands.RGBEffectMode SelectedRgbMode
        {
            get => _selectedRgbMode;
            set => SetProperty(ref _selectedRgbMode, value);
        }
        
        private byte _redValue;
        public byte RedValue
        {
            get => _redValue;
            set
            {
                if (SetProperty(ref _redValue, value))
                {
                    UpdateSelectedColor();
                }
            }
        }
        
        private byte _greenValue;
        public byte GreenValue
        {
            get => _greenValue;
            set
            {
                if (SetProperty(ref _greenValue, value))
                {
                    UpdateSelectedColor();
                }
            }
        }
        
        private byte _blueValue;
        public byte BlueValue
        {
            get => _blueValue;
            set
            {
                if (SetProperty(ref _blueValue, value))
                {
                    UpdateSelectedColor();
                }
            }
        }
        
        private byte _speedValue;
        public byte SpeedValue
        {
            get => _speedValue;
            set => SetProperty(ref _speedValue, value);
        }
        
        private byte _brightnessValue;
        public byte BrightnessValue
        {
            get => _brightnessValue;
            set => SetProperty(ref _brightnessValue, value);
        }
        
        private Color _selectedColor;
        public Color SelectedColor
        {
            get => _selectedColor;
            set
            {
                if (SetProperty(ref _selectedColor, value))
                {
                    RedValue = value.R;
                    GreenValue = value.G;
                    BlueValue = value.B;
                }
            }
        }
        
        private void UpdateSelectedColor()
        {
            SelectedColor = Color.FromRgb(RedValue, GreenValue, BlueValue);
        }
        
        private async void ApplyRgbSettings()
        {
            if (_currentDevice == null)
                return;

            try
            {
                var result = await _deviceService.SetMouseRGBAsync(
                    _currentDevice,
                    SelectedRgbMode,
                    RedValue,
                    GreenValue,
                    BlueValue,
                    SpeedValue,
                    BrightnessValue);

                if (result)
                {
                    MessageBox.Show("RGB ayarları başarıyla uygulandı.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("RGB ayarları uygulanırken bir hata oluştu.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"RGB ayarları uygulanırken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        private async void CreateProfile()
        {
            if (_currentDevice == null)
                return;

            try
            {
                // Yeni profil oluştur
                var newProfile = new Profile
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Yeni Profil",
                    Description = "Yeni oluşturulan profil",
                    DeviceId = _currentDevice.Id,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    IsDefault = false,
                    MouseSettings = new MouseSettings
                    {
                        DpiSettings = new ObservableCollection<Models.DpiSetting>(DpiSettings),
                        PollingRate = SelectedPollingRate,
                        LodSetting = SelectedLodSetting,
                        AngleSnappingEnabled = AngleSnappingEnabled,
                        DebounceTime = DebounceTime
                    }
                };

                // Profili kaydet
                var result = await _profileService.SaveProfileAsync((Profile)newProfile);
                if (result)
                {
                    Profiles.Add(newProfile);
                    SelectedProfile = newProfile;
                    MessageBox.Show("Yeni profil başarıyla oluşturuldu.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Profil oluşturulurken bir hata oluştu.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Profil oluşturulurken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        private async void DeleteProfile()
        {
            if (_currentDevice == null || SelectedProfile == null)
                return;

            try
            {
                // Kullanıcıya onay sor
                var result = MessageBox.Show($"'{SelectedProfile.Name}' profilini silmek istediğinize emin misiniz?", 
                    "Profil Silme Onayı", MessageBoxButton.YesNo, MessageBoxImage.Question);
                
                if (result == MessageBoxResult.Yes)
                {
                    // Profili sil
                    var deleteResult = await _profileService.DeleteProfileAsync(SelectedProfile.Id);
                    if (deleteResult)
                    {
                        Profiles.Remove(SelectedProfile);
                        
                        // Başka profil varsa seç, yoksa null yap
                        if (Profiles.Count > 0)
                        {
                            SelectedProfile = Profiles[0];
                        }
                        else
                        {
                            SelectedProfile = null;
                        }
                        
                        MessageBox.Show("Profil başarıyla silindi.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Profil silinirken bir hata oluştu.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Profil silinirken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        private async void CloneProfile()
        {
            if (_currentDevice == null || SelectedProfile == null)
                return;

            try
            {
                // Seçili profilin bir kopyasını oluştur
                var clonedProfile = new Profile
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = $"{SelectedProfile.Name} (Kopya)",
                    Description = SelectedProfile.Description,
                    DeviceId = _currentDevice.DeviceId,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now,
                    IsDefault = false,
                    MouseSettings = new MouseSettings
                    {
                        DpiSettings = new ObservableCollection<DpiSetting>(SelectedProfile.MouseSettings.DpiSettings),
                        PollingRate = SelectedProfile.MouseSettings.PollingRate,
                        LodSetting = SelectedProfile.MouseSettings.LodSetting,
                        AngleSnappingEnabled = SelectedProfile.MouseSettings.AngleSnappingEnabled,
                        DebounceTime = SelectedProfile.MouseSettings.DebounceTime
                    }
                };

                // Profili kaydet
                var result = await _profileService.SaveProfileAsync(clonedProfile);
                if (result)
                {
                    Profiles.Add(clonedProfile);
                    SelectedProfile = clonedProfile;
                    MessageBox.Show("Profil başarıyla kopyalandı.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Profil kopyalanırken bir hata oluştu.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Profil kopyalanırken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void ApplySettingsFromDictionary(Dictionary<string, object> settings)
        {
            if (settings == null || settings.Count == 0)
            {
                return;
            }
            
            try
            {
                // DPI ayarları
                DpiSettings.Clear();
                int dpiIndex = 0;
                while (settings.ContainsKey($"DPI_{dpiIndex}_Level"))
                {
                    byte level = Convert.ToByte(settings[$"DPI_{dpiIndex}_Level"]);
                    ushort value = Convert.ToUInt16(settings[$"DPI_{dpiIndex}_Value"]);
                    byte red = Convert.ToByte(settings[$"DPI_{dpiIndex}_Red"]);
                    byte green = Convert.ToByte(settings[$"DPI_{dpiIndex}_Green"]);
                    byte blue = Convert.ToByte(settings[$"DPI_{dpiIndex}_Blue"]);
                    
                    var color = Color.FromRgb(red, green, blue);
                    DpiSettings.Add(new DpiSetting { Level = level, DpiValue = value, Color = color });
                    dpiIndex++;
                }
                
                if (DpiSettings.Count > 0)
                {
                    SelectedDpiSetting = DpiSettings[0];
                }
                
                // Polling rate
                if (settings.ContainsKey("PollingRate"))
                {
                    SelectedPollingRate = (DeviceCommands.PollingRate)Convert.ToInt32(settings["PollingRate"]);
                }
                
                // LOD ayarı
                if (settings.ContainsKey("LODSetting"))
                {
                    SelectedLodSetting = (DeviceCommands.LODSetting)Convert.ToInt32(settings["LODSetting"]);
                }
                
                // Angle snapping
                if (settings.ContainsKey("AngleSnapping"))
                {
                    AngleSnappingEnabled = Convert.ToBoolean(settings["AngleSnapping"]);
                }
                
                // Debounce time
                if (settings.ContainsKey("DebounceTime"))
                {
                    DebounceTime = Convert.ToByte(settings["DebounceTime"]);
                }
                
                // RGB ayarları
                if (settings.ContainsKey("RGBMode"))
                {
                    SelectedRgbMode = (DeviceCommands.RGBEffectMode)Convert.ToInt32(settings["RGBMode"]);
                }
                
                if (settings.ContainsKey("RGBRed"))
                {
                    RedValue = Convert.ToByte(settings["RGBRed"]);
                }
                
                if (settings.ContainsKey("RGBGreen"))
                {
                    GreenValue = Convert.ToByte(settings["RGBGreen"]);
                }
                
                if (settings.ContainsKey("RGBBlue"))
                {
                    BlueValue = Convert.ToByte(settings["RGBBlue"]);
                }
                
                if (settings.ContainsKey("RGBSpeed"))
                {
                    SpeedValue = Convert.ToByte(settings["RGBSpeed"]);
                }
                
                if (settings.ContainsKey("RGBBrightness"))
                {
                    BrightnessValue = Convert.ToByte(settings["RGBBrightness"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ayarlar uygulanırken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        // RGB Ayarları
        private DeviceCommands.RGBEffectMode _selectedRgbMode;
        public DeviceCommands.RGBEffectMode SelectedRgbMode
        {
            get => _selectedRgbMode;
            set => SetProperty(ref _selectedRgbMode, value);
        }
        
        private byte _redValue;
        public byte RedValue
        {
            get => _redValue;
            set
            {
                if (SetProperty(ref _redValue, value))
                {
                    UpdateSelectedColor();
                }
            }
        }
        
        private byte _greenValue;
        public byte GreenValue
        {
            get => _greenValue;
            set
            {
                if (SetProperty(ref _greenValue, value))
                {
                    UpdateSelectedColor();
                }
            }
        }
        
        private byte _blueValue;
        public byte BlueValue
        {
            get => _blueValue;
            set
            {
                if (SetProperty(ref _blueValue, value))
                {
                    UpdateSelectedColor();
                }
            }
        }
        
        private byte _speedValue;
        public byte SpeedValue
        {
            get => _speedValue;
            set => SetProperty(ref _speedValue, value);
        }
        
        private byte _brightnessValue;
        public byte BrightnessValue
        {
            get => _brightnessValue;
            set => SetProperty(ref _brightnessValue, value);
        }
        
        private Color _selectedColor;
        public Color SelectedColor
        {
            get => _selectedColor;
            set
            {
                if (SetProperty(ref _selectedColor, value))
                {
                    RedValue = value.R;
                    GreenValue = value.G;
                    BlueValue = value.B;
                }
            }
        }
        
        private void UpdateSelectedColor()
        {
            SelectedColor = Color.FromRgb(RedValue, GreenValue, BlueValue);
        }
        
        private async void ApplyRgbSettings()
        {
            if (_currentDevice == null)
                return;

            try
            {
                var result = await _deviceService.SetMouseRGBAsync(
                    _currentDevice,
                    SelectedRgbMode,
                    RedValue,
                    GreenValue,
                    BlueValue,
                    SpeedValue,
                    BrightnessValue);

                if (result)
                {
                    MessageBox.Show("RGB ayarları başarıyla uygulandı.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("RGB ayarları uygulanırken bir hata oluştu.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"RGB ayarları uygulanırken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        public IRelayCommand ApplyRgbSettingsCommand { get; }
        public IRelayCommand CreateProfileCommand { get; }
        public IRelayCommand DeleteProfileCommand { get; }
        public IRelayCommand CloneProfileCommand { get; }
        
        // Constructor içine eklenecek komutlar
        // public MouseViewModel(IDeviceService deviceService, IProfileService profileService)
        // {
        //     // ... existing code ...
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5;
        //     BrightnessValue = 100;
        //     ApplyRgbSettingsCommand = new RelayCommand(ApplyRgbSettings);
        //     CreateProfileCommand = new RelayCommand(CreateProfile);
        //     DeleteProfileCommand = new RelayCommand(DeleteProfile);
        //     CloneProfileCommand = new RelayCommand(CloneProfile);
        //     
        //     // RGB ayarları için varsayılan değerler
        //     SelectedRgbMode = DeviceCommands.RGBEffectMode.Static;
        //     RedValue = 255;
        //     GreenValue = 0;
        //     BlueValue = 0;
        //     SpeedValue = 5
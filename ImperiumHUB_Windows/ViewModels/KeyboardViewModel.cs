using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ImperiumGearHUB.Models;
using ImperiumGearHUB.Services.HID;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ImperiumGearHUB.ViewModels
{
    public class KeyboardViewModel : BaseViewModel
    {
        private readonly IDeviceService _deviceService;
        private Device _device;

        // RGB Ayarları
        private DeviceCommands.RGBEffectMode _selectedRgbMode;
        private byte _redValue;
        private byte _greenValue;
        private byte _blueValue;
        private byte _speedValue;
        private byte _brightnessValue;
        private Color _selectedColor;

        // Hall Effect Ayarları
        private byte _actuationPoint;
        private bool _rapidTriggerEnabled;
        private byte _dynamicKeystrokeValue;

        // Tuş Atamaları ve Makrolar
        private ObservableCollection<KeyMapping> _keyMappings;
        private KeyMapping _selectedKeyMapping;
        private ObservableCollection<MacroProfile> _macroProfiles;
        private MacroProfile _selectedMacroProfile;
        private bool _isEditingMacro;

        // Profil Yönetimi
        private ObservableCollection<Profile> _profiles;
        private Profile _selectedProfile;
        private string _newProfileName;

        public Device Device
        {
            get => _device;
            set => SetProperty(ref _device, value);
        }

        // RGB Ayarları Özellikleri
        public DeviceCommands.RGBEffectMode SelectedRgbMode
        {
            get => _selectedRgbMode;
            set => SetProperty(ref _selectedRgbMode, value);
        }

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

        public byte SpeedValue
        {
            get => _speedValue;
            set => SetProperty(ref _speedValue, value);
        }

        public byte BrightnessValue
        {
            get => _brightnessValue;
            set => SetProperty(ref _brightnessValue, value);
        }

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

        public byte ActuationPoint
        {
            get => _actuationPoint;
            set => SetProperty(ref _actuationPoint, value);
        }

        public bool RapidTriggerEnabled
        {
            get => _rapidTriggerEnabled;
            set => SetProperty(ref _rapidTriggerEnabled, value);
        }

        public byte DynamicKeystrokeValue
        {
            get => _dynamicKeystrokeValue;
            set => SetProperty(ref _dynamicKeystrokeValue, value);
        }

        // Tuş Atamaları ve Makrolar Özellikleri
        public ObservableCollection<KeyMapping> KeyMappings
        {
            get => _keyMappings;
            set => SetProperty(ref _keyMappings, value);
        }

        public KeyMapping SelectedKeyMapping
        {
            get => _selectedKeyMapping;
            set => SetProperty(ref _selectedKeyMapping, value);
        }

        public ObservableCollection<MacroProfile> MacroProfiles
        {
            get => _macroProfiles;
            set => SetProperty(ref _macroProfiles, value);
        }

        public MacroProfile SelectedMacroProfile
        {
            get => _selectedMacroProfile;
            set => SetProperty(ref _selectedMacroProfile, value);
        }

        public bool IsEditingMacro
        {
            get => _isEditingMacro;
            set => SetProperty(ref _isEditingMacro, value);
        }

        // Profil Yönetimi Özellikleri
        public ObservableCollection<Profile> Profiles
        {
            get => _profiles;
            set => SetProperty(ref _profiles, value);
        }

        public Profile SelectedProfile
        {
            get => _selectedProfile;
            set => SetProperty(ref _selectedProfile, value);
        }

        public string NewProfileName
        {
            get => _newProfileName;
            set => SetProperty(ref _newProfileName, value);
        }

        // Komutlar
        public IRelayCommand ApplyRgbSettingsCommand { get; }
        public IRelayCommand ApplyHallEffectSettingsCommand { get; }
        public IRelayCommand SaveKeyMappingCommand { get; }
        public IRelayCommand ResetKeyMappingCommand { get; }
        public IRelayCommand StartMacroRecordingCommand { get; }
        public IRelayCommand StopMacroRecordingCommand { get; }
        public IRelayCommand SaveMacroCommand { get; }
        public IRelayCommand DeleteMacroCommand { get; }
        public IRelayCommand CreateProfileCommand { get; }
        public IRelayCommand SaveProfileCommand { get; }
        public IRelayCommand LoadProfileCommand { get; }
        public IRelayCommand DeleteProfileCommand { get; }
        public IRelayCommand ExportProfileCommand { get; }
        public IRelayCommand ImportProfileCommand { get; }

        public KeyboardViewModel(IDeviceService deviceService)
        {
            _deviceService = deviceService ?? throw new ArgumentNullException(nameof(deviceService));
            
            // Varsayılan değerler
            _selectedRgbMode = DeviceCommands.RGBEffectMode.Static;
            _redValue = 255;
            _greenValue = 0;
            _blueValue = 0;
            _speedValue = 128;
            _brightnessValue = 255;
            _selectedColor = Color.FromRgb(_redValue, _greenValue, _blueValue);
            
            _actuationPoint = 10; // 1.0mm
            _rapidTriggerEnabled = false;
            _dynamicKeystrokeValue = 0;
            
            // Tuş Atamaları ve Makrolar için başlangıç değerleri
            _keyMappings = new ObservableCollection<KeyMapping>();
            _macroProfiles = new ObservableCollection<MacroProfile>();
            _isEditingMacro = false;
            
            // Profil Yönetimi için başlangıç değerleri
            _profiles = new ObservableCollection<Profile>();
            _newProfileName = "Yeni Profil";
            
            // Komutlar
            ApplyRgbSettingsCommand = new AsyncRelayCommand(ApplyRgbSettingsAsync, () => Device != null && Device.IsConnected);
            ApplyHallEffectSettingsCommand = new AsyncRelayCommand(ApplyHallEffectSettingsAsync, () => Device != null && Device.IsConnected);
            SaveKeyMappingCommand = new AsyncRelayCommand(SaveKeyMappingAsync, () => Device != null && Device.IsConnected && SelectedKeyMapping != null);
            ResetKeyMappingCommand = new AsyncRelayCommand(ResetKeyMappingAsync, () => Device != null && Device.IsConnected && SelectedKeyMapping != null);
            StartMacroRecordingCommand = new RelayCommand(StartMacroRecording, () => Device != null && Device.IsConnected && !IsEditingMacro);
            StopMacroRecordingCommand = new RelayCommand(StopMacroRecording, () => Device != null && Device.IsConnected && IsEditingMacro);
            SaveMacroCommand = new AsyncRelayCommand(SaveMacroAsync, () => Device != null && Device.IsConnected && SelectedMacroProfile != null);
            DeleteMacroCommand = new AsyncRelayCommand(DeleteMacroAsync, () => Device != null && Device.IsConnected && SelectedMacroProfile != null);
            CreateProfileCommand = new RelayCommand(CreateProfile, () => !string.IsNullOrWhiteSpace(NewProfileName));
            SaveProfileCommand = new AsyncRelayCommand(SaveProfileAsync, () => Device != null && Device.IsConnected && SelectedProfile != null);
            LoadProfileCommand = new AsyncRelayCommand(LoadProfileAsync, () => Device != null && Device.IsConnected && SelectedProfile != null);
            DeleteProfileCommand = new RelayCommand(DeleteProfile, () => SelectedProfile != null);
            ExportProfileCommand = new AsyncRelayCommand(ExportProfileAsync, () => SelectedProfile != null);
            ImportProfileCommand = new AsyncRelayCommand(ImportProfileAsync);
            
            // Başlangıçta tuş haritasını ve profilleri yükle
            Task.Run(() => LoadKeyMappingsAsync());
            Task.Run(() => LoadProfilesAsync());
        }

        private void UpdateSelectedColor()
        {
            _selectedColor = Color.FromRgb(_redValue, _greenValue, _blueValue);
            OnPropertyChanged(nameof(SelectedColor));
        }

        private async Task ApplyRgbSettingsAsync()
        {
            if (Device == null || !Device.IsConnected) return;

            await RunBusyAsync(async () =>
            {
                try
                {
                    bool result = await _deviceService.SetKeyboardRGBAsync(
                        Device, 
                        SelectedRgbMode, 
                        RedValue, 
                        GreenValue, 
                        BlueValue, 
                        SpeedValue, 
                        BrightnessValue);
                    
                    if (!result)
                    {
                        MessageBox.Show("RGB ayarları uygulanamadı.", "Hata", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        MessageBox.Show("RGB ayarları başarıyla uygulandı.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"RGB ayarları uygulanırken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }

        private async Task ApplyHallEffectSettingsAsync()
        {
            if (Device == null || !Device.IsConnected) return;

            await RunBusyAsync(async () =>
            {
                try
                {
                    bool result = await _deviceService.SetKeyboardHallEffectAsync(
                        Device, 
                        ActuationPoint, 
                        RapidTriggerEnabled, 
                        DynamicKeystrokeValue);
                    
                    if (!result)
                    {
                        MessageBox.Show("Hall Effect ayarları uygulanamadı.", "Hata", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Hall Effect ayarları başarıyla uygulandı.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hall Effect ayarları uygulanırken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }

        // Tuş Atamaları ve Makrolar Metodları
        private async Task LoadKeyMappingsAsync()
        {
            if (Device == null || !Device.IsConnected) return;

            await RunBusyAsync(async () =>
            {
                try
                {
                    // Burada cihazdan tuş haritasını yükleme işlemi yapılacak
                    // Şimdilik örnek tuş haritası oluşturalım
                    KeyMappings.Clear();
                    
                    // Örnek tuşlar ekleyelim
                    for (int i = 1; i <= 104; i++)
                    {
                        KeyMappings.Add(new KeyMapping
                        {
                            KeyId = i,
                            KeyName = $"Key{i}",
                            OriginalFunction = $"Original{i}",
                            CurrentFunction = $"Original{i}",
                            IsMapped = false
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Tuş haritası yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }

        private async Task SaveKeyMappingAsync()
        {
            if (Device == null || !Device.IsConnected || SelectedKeyMapping == null) return;

            await RunBusyAsync(async () =>
            {
                try
                {
                    // Burada seçili tuş atamasını cihaza kaydetme işlemi yapılacak
                    // Şimdilik sadece başarılı mesajı gösterelim
                    SelectedKeyMapping.IsMapped = !string.Equals(SelectedKeyMapping.OriginalFunction, SelectedKeyMapping.CurrentFunction);
                    
                    MessageBox.Show($"{SelectedKeyMapping.KeyName} tuşu için atama başarıyla kaydedildi.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Tuş ataması kaydedilirken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }

        private async Task ResetKeyMappingAsync()
        {
            if (Device == null || !Device.IsConnected || SelectedKeyMapping == null) return;

            await RunBusyAsync(async () =>
            {
                try
                {
                    // Tuş atamasını varsayılana sıfırla
                    SelectedKeyMapping.CurrentFunction = SelectedKeyMapping.OriginalFunction;
                    SelectedKeyMapping.IsMapped = false;
                    
                    // Burada cihazdan sıfırlama komutu gönderilecek
                    
                    MessageBox.Show($"{SelectedKeyMapping.KeyName} tuşu varsayılan işlevine sıfırlandı.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Tuş ataması sıfırlanırken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }

        private void StartMacroRecording()
        {
            IsEditingMacro = true;
            
            // Yeni bir makro profili oluştur
            var newMacro = new MacroProfile
            {
                Name = "Yeni Makro",
                CreatedAt = DateTime.Now
            };
            
            MacroProfiles.Add(newMacro);
            SelectedMacroProfile = newMacro;
            
            MessageBox.Show("Makro kaydı başlatıldı. Tuşlara basarak makronuzu oluşturun ve bitirmek için 'Kaydı Durdur' düğmesine tıklayın.", "Makro Kaydı", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void StopMacroRecording()
        {
            IsEditingMacro = false;
            MessageBox.Show("Makro kaydı durduruldu. Makroyu kaydetmek için 'Makroyu Kaydet' düğmesine tıklayın.", "Makro Kaydı", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private async Task SaveMacroAsync()
        {
            if (Device == null || !Device.IsConnected || SelectedMacroProfile == null) return;

            await RunBusyAsync(async () =>
            {
                try
                {
                    // Burada makroyu cihaza kaydetme işlemi yapılacak
                    SelectedMacroProfile.ModifiedAt = DateTime.Now;
                    
                    MessageBox.Show($"{SelectedMacroProfile.Name} makrosu başarıyla kaydedildi.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Makro kaydedilirken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }

        private async Task DeleteMacroAsync()
        {
            if (SelectedMacroProfile == null) return;

            MessageBoxResult result = MessageBox.Show($"{SelectedMacroProfile.Name} makrosunu silmek istediğinizden emin misiniz?", "Makro Silme", MessageBoxButton.YesNo, MessageBoxImage.Question);
            
            if (result == MessageBoxResult.Yes)
            {
                await RunBusyAsync(async () =>
                {
                    try
                    {
                        // Makroyu listeden kaldır
                        MacroProfiles.Remove(SelectedMacroProfile);
                        SelectedMacroProfile = null;
                        
                        // Burada cihazdan makroyu silme işlemi yapılacak
                        
                        MessageBox.Show("Makro başarıyla silindi.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Makro silinirken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
            }
        }

        // Profil Yönetimi Metodları
        private async Task LoadProfilesAsync()
        {
            await RunBusyAsync(async () =>
            {
                try
                {
                    // Burada kaydedilmiş profilleri yükleme işlemi yapılacak
                    // Şimdilik örnek profiller oluşturalım
                    Profiles.Clear();
                    
                    Profiles.Add(new Profile
                    {
                        Name = "Varsayılan Profil",
                        DeviceId = Device?.Id ?? string.Empty,
                        CreatedAt = DateTime.Now.AddDays(-30),
                        ModifiedAt = DateTime.Now.AddDays(-5)
                    });
                    
                    Profiles.Add(new Profile
                    {
                        Name = "Oyun Profili",
                        DeviceId = Device?.Id ?? string.Empty,
                        CreatedAt = DateTime.Now.AddDays(-15),
                        ModifiedAt = DateTime.Now.AddDays(-2)
                    });
                    
                    Profiles.Add(new Profile
                    {
                        Name = "Ofis Profili",
                        DeviceId = Device?.Id ?? string.Empty,
                        CreatedAt = DateTime.Now.AddDays(-7),
                        ModifiedAt = DateTime.Now.AddDays(-1)
                    });
                    
                    if (Profiles.Count > 0)
                    {
                        SelectedProfile = Profiles[0];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Profiller yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }

        private void CreateProfile()
        {
            if (string.IsNullOrWhiteSpace(NewProfileName)) return;

            var newProfile = new Profile
            {
                Name = NewProfileName,
                DeviceId = Device?.Id ?? string.Empty,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };
            
            Profiles.Add(newProfile);
            SelectedProfile = newProfile;
            NewProfileName = "Yeni Profil";
            
            MessageBox.Show($"{newProfile.Name} profili oluşturuldu. Profili kaydetmek için 'Profili Kaydet' düğmesine tıklayın.", "Profil Oluşturuldu", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private async Task SaveProfileAsync()
        {
            if (Device == null || !Device.IsConnected || SelectedProfile == null) return;

            await RunBusyAsync(async () =>
            {
                try
                {
                    // Burada profili kaydetme işlemi yapılacak
                    SelectedProfile.ModifiedAt = DateTime.Now;
                    
                    // Burada cihazdan profil ayarlarını gönderme işlemi yapılacak
                    
                    MessageBox.Show($"{SelectedProfile.Name} profili başarıyla kaydedildi.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Profil kaydedilirken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }

        private async Task LoadProfileAsync()
        {
            if (Device == null || !Device.IsConnected || SelectedProfile == null) return;

            await RunBusyAsync(async () =>
            {
                try
                {
                    // Burada profili yükleme işlemi yapılacak
                    
                    // Burada cihazdan profil ayarlarını alma işlemi yapılacak
                    
                    MessageBox.Show($"{SelectedProfile.Name} profili başarıyla yüklendi.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Profil yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }

        private void DeleteProfile()
        {
            if (SelectedProfile == null) return;

            MessageBoxResult result = MessageBox.Show($"{SelectedProfile.Name} profilini silmek istediğinizden emin misiniz?", "Profil Silme", MessageBoxButton.YesNo, MessageBoxImage.Question);
            
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    // Profili listeden kaldır
                    Profiles.Remove(SelectedProfile);
                    
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
                catch (Exception ex)
                {
                    MessageBox.Show($"Profil silinirken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private async Task ExportProfileAsync()
        {
            if (SelectedProfile == null) return;

            await RunBusyAsync(async () =>
            {
                try
                {
                    // Burada profili dışa aktarma işlemi yapılacak
                    // Şimdilik sadece başarılı mesajı gösterelim
                    
                    MessageBox.Show($"{SelectedProfile.Name} profili başarıyla dışa aktarıldı.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Profil dışa aktarılırken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }

        private async Task ImportProfileAsync()
        {
            await RunBusyAsync(async () =>
            {
                try
                {
                    // Burada profili içe aktarma işlemi yapılacak
                    // Şimdilik örnek bir profil oluşturalım
                    
                    var importedProfile = new Profile
                    {
                        Name = "İçe Aktarılan Profil",
                        DeviceId = Device?.Id ?? string.Empty,
                        CreatedAt = DateTime.Now,
                        ModifiedAt = DateTime.Now
                    };
                    
                    Profiles.Add(importedProfile);
                    SelectedProfile = importedProfile;
                    
                    MessageBox.Show($"{importedProfile.Name} profili başarıyla içe aktarıldı.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Profil içe aktarılırken hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }
    }

    // Yardımcı sınıflar
    public class KeyMapping : BaseModel
    {
        private int _keyId;
        private string _keyName;
        private string _originalFunction;
        private string _currentFunction;
        private bool _isMapped;

        public int KeyId
        {
            get => _keyId;
            set => SetProperty(ref _keyId, value);
        }

        public string KeyName
        {
            get => _keyName;
            set => SetProperty(ref _keyName, value);
        }

        public string OriginalFunction
        {
            get => _originalFunction;
            set => SetProperty(ref _originalFunction, value);
        }

        public string CurrentFunction
        {
            get => _currentFunction;
            set => SetProperty(ref _currentFunction, value);
        }

        public bool IsMapped
        {
            get => _isMapped;
            set => SetProperty(ref _isMapped, value);
        }

        public KeyMapping()
        {
            _keyName = string.Empty;
            _originalFunction = string.Empty;
            _currentFunction = string.Empty;
        }
    }

    public class MacroProfile : BaseModel
    {
        private string _id;
        private string _name;
        private ObservableCollection<MacroAction> _actions;
        private DateTime _createdAt;
        private DateTime _modifiedAt;

        public string Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public ObservableCollection<MacroAction> Actions
        {
            get => _actions;
            set => SetProperty(ref _actions, value);
        }

        public DateTime CreatedAt
        {
            get => _createdAt;
            set => SetProperty(ref _createdAt, value);
        }

        public DateTime ModifiedAt
        {
            get => _modifiedAt;
            set => SetProperty(ref _modifiedAt, value);
        }

        public MacroProfile()
        {
            _id = Guid.NewGuid().ToString();
            _name = "Yeni Makro";
            _actions = new ObservableCollection<MacroAction>();
            _createdAt = DateTime.Now;
            _modifiedAt = DateTime.Now;
        }
    }

    public class MacroAction : BaseModel
    {
        private MacroActionType _type;
        private string _keyName;
        private int _keyCode;
        private int _delay;

        public enum MacroActionType
        {
            KeyDown,
            KeyUp,
            Delay
        }

        public MacroActionType Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }

        public string KeyName
        {
            get => _keyName;
            set => SetProperty(ref _keyName, value);
        }

        public int KeyCode
        {
            get => _keyCode;
            set => SetProperty(ref _keyCode, value);
        }

        public int Delay
        {
            get => _delay;
            set => SetProperty(ref _delay, value);
        }

        public MacroAction()
        {
            _keyName = string.Empty;
        }
    }
}
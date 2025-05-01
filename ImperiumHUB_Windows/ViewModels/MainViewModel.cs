using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ImperiumGearHUB.Models;
using ImperiumGearHUB.Services;
using ImperiumGearHUB.Services.HID;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ImperiumGearHUB.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IDeviceService _deviceService;
        private readonly IProfileService _profileService;
        private readonly KeyboardViewModel _keyboardViewModel;
        private readonly MouseViewModel _mouseViewModel;
        
        private object _currentView;
        private Device _selectedDevice;
        private bool _isDeviceConnecting;
        private string _statusMessage;
        private string _appVersion;
        
        public ObservableCollection<Device> Devices { get; } = new ObservableCollection<Device>();
        public ObservableCollection<Profile> Profiles { get; } = new ObservableCollection<Profile>();
        
        public object CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }
        
        public Device SelectedDevice
        {
            get => _selectedDevice;
            set
            {
                if (SetProperty(ref _selectedDevice, value))
                {
                    // Cihaz tipine göre uygun görünümü göster
                    if (value != null)
                    {
                        switch (value.Type)
                        {
                            case DeviceType.Keyboard:
                                _keyboardViewModel.Device = value;
                                CurrentView = _keyboardViewModel;
                                break;
                            case DeviceType.Mouse:
                                _mouseViewModel.Device = value;
                                CurrentView = _mouseViewModel;
                                break;
                            default:
                                CurrentView = null;
                                break;
                        }
                    }
                    else
                    {
                        CurrentView = null;
                    }
                }
            }
        }
        
        public bool IsDeviceConnecting
        {
            get => _isDeviceConnecting;
            set => SetProperty(ref _isDeviceConnecting, value);
        }
        
        public string StatusMessage
        {
            get => _statusMessage;
            set => SetProperty(ref _statusMessage, value);
        }
        
        public string AppVersion
        {
            get => _appVersion;
            set => SetProperty(ref _appVersion, value);
        }
        
        public IRelayCommand RefreshDevicesCommand { get; }
        public IRelayCommand ConnectDeviceCommand { get; }
        public IRelayCommand DisconnectDeviceCommand { get; }
        public IRelayCommand CheckForUpdatesCommand { get; }
        
        public MainViewModel(
            IDeviceService deviceService,
            IProfileService profileService,
            KeyboardViewModel keyboardViewModel,
            MouseViewModel mouseViewModel)
        {
            _deviceService = deviceService;
            _profileService = profileService;
            _keyboardViewModel = keyboardViewModel;
            _mouseViewModel = mouseViewModel;
            
            // Uygulama sürümünü ayarla
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            AppVersion = $"v{version.Major}.{version.Minor}.{version.Build}";
            
            // Komutları oluştur
            RefreshDevicesCommand = new RelayCommand(RefreshDevicesAsync);
            ConnectDeviceCommand = new RelayCommand(ConnectDeviceAsync, () => SelectedDevice != null && !SelectedDevice.IsConnected);
            DisconnectDeviceCommand = new RelayCommand(DisconnectDeviceAsync, () => SelectedDevice != null && SelectedDevice.IsConnected);
            CheckForUpdatesCommand = new RelayCommand(CheckForUpdatesAsync);
            
            // Başlangıçta cihazları yükle
            _ = RefreshDevicesAsync();
            _ = LoadProfilesAsync();
        }
        
        private async Task RefreshDevicesAsync()
        {
            await RunBusyAsync(async () =>
            {
                Devices.Clear();
                var devices = await _deviceService.GetDevicesAsync();
                foreach (var device in devices)
                {
                    Devices.Add(device);
                }
                
                if (Devices.Count > 0)
                {
                    SelectedDevice = Devices.FirstOrDefault();
                }
                else
                {
                    StatusMessage = "Hiçbir cihaz bulunamadı. Cihazlarınızın bağlı olduğundan emin olun.";
                }
            }, "Cihazlar taranıyor...");
        }
        
        private async Task LoadProfilesAsync()
        {
            await RunBusyAsync(async () =>
            {
                Profiles.Clear();
                var profiles = await _profileService.GetProfilesAsync();
                foreach (var profile in profiles)
                {
                    Profiles.Add(profile);
                }
            }, "Profiller yükleniyor...");
        }
        
        private async Task ConnectDeviceAsync()
        {
            if (SelectedDevice != null)
            {
                await RunBusyAsync(async () =>
                {
                    try
                    {
                        var result = await _deviceService.ConnectDeviceAsync(SelectedDevice);
                        if (result)
                        {
                            SelectedDevice.IsConnected = true;
                            StatusMessage = $"{SelectedDevice.Name} başarıyla bağlandı.";
                        }
                        else
                        {
                            StatusMessage = $"{SelectedDevice.Name} bağlanamadı.";
                        }
                    }
                    catch (Exception ex)
                    {
                        StatusMessage = $"Bağlantı hatası: {ex.Message}";
                    }
                }, $"{SelectedDevice.Name} bağlanıyor...");
            }
        }
        
        private async Task DisconnectDeviceAsync()
        {
            if (SelectedDevice != null)
            {
                await RunBusyAsync(async () =>
                {
                    try
                    {
                        var result = await _deviceService.DisconnectDeviceAsync(SelectedDevice);
                        if (result)
                        {
                            SelectedDevice.IsConnected = false;
                            StatusMessage = $"{SelectedDevice.Name} bağlantısı kesildi.";
                        }
                        else
                        {
                            StatusMessage = $"{SelectedDevice.Name} bağlantısı kesilemedi.";
                        }
                    }
                    catch (Exception ex)
                    {
                        StatusMessage = $"Bağlantı kesme hatası: {ex.Message}";
                    }
                }, $"{SelectedDevice.Name} bağlantısı kesiliyor...");
            }
        }
        
        private async Task CheckForUpdatesAsync()
        {
            await RunBusyAsync(async () =>
            {
                // Burada güncelleme kontrolü yapılacak
                await Task.Delay(2000); // Simülasyon için
                
                // Şimdilik güncel olduğunu varsayalım
                MessageBox.Show("Uygulamanız güncel.", "Güncelleme Kontrolü", MessageBoxButton.OK, MessageBoxImage.Information);
            }, "Güncellemeler kontrol ediliyor...");
        }
    }
}
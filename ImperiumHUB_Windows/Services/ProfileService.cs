using ImperiumGearHUB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services
{
    public interface IProfileService
    {
        Task<List<Profile>> GetProfilesAsync(string deviceId);
        Task<Profile> GetProfileAsync(string profileId);
        Task<Profile> GetDefaultProfileAsync(string deviceId);
        Task<bool> SaveProfileAsync(Profile profile);
        Task<bool> DeleteProfileAsync(string profileId);
        Task<bool> SetDefaultProfileAsync(string profileId);
        Task<bool> ExportProfileAsync(string profileId, string filePath);
        Task<Profile> ImportProfileAsync(string filePath, string deviceId);
    }

    public class ProfileService : IProfileService
    {
        private readonly string _profilesDirectory;
        private readonly List<Profile> _profiles;

        public ProfileService()
        {
            // Profil dizinini oluştur
            _profilesDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "ImperiumGearHUB",
                "Profiles");
            
            // Dizin yoksa oluştur
            if (!Directory.Exists(_profilesDirectory))
            {
                Directory.CreateDirectory(_profilesDirectory);
            }
            
            // Profilleri yükle
            _profiles = LoadProfiles();
        }

        public Task<List<Profile>> GetProfilesAsync(string deviceId)
        {
            var profiles = _profiles.Where(p => p.DeviceId == deviceId).ToList();
            return Task.FromResult(profiles);
        }

        public Task<Profile> GetProfileAsync(string profileId)
        {
            var profile = _profiles.FirstOrDefault(p => p.Id == profileId);
            return Task.FromResult(profile);
        }

        public Task<bool> SaveProfileAsync(Profile profile)
        {
            try
            {
                // Profil ID'si yoksa oluştur
                if (string.IsNullOrEmpty(profile.Id))
                {
                    profile.Id = Guid.NewGuid().ToString();
                }
                
                // Oluşturma ve güncelleme tarihlerini ayarla
                if (profile.CreatedAt == default)
                {
                    profile.CreatedAt = DateTime.Now;
                }
                
                profile.ModifiedAt = DateTime.Now;
                
                // Mevcut profili bul
                var existingProfile = _profiles.FirstOrDefault(p => p.Id == profile.Id);
                
                // Mevcut profil yoksa ekle
                if (existingProfile == null)
                {
                    _profiles.Add(profile);
                }
                else
                {
                    // Mevcut profili güncelle
                    var index = _profiles.IndexOf(existingProfile);
                    _profiles[index] = profile;
                }
                
                // Profilleri kaydet
                SaveProfiles();
                
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> DeleteProfileAsync(string profileId)
        {
            try
            {
                // Profili bul
                var profile = _profiles.FirstOrDefault(p => p.Id == profileId);
                
                // Profil yoksa false döndür
                if (profile == null)
                {
                    return Task.FromResult(false);
                }
                
                // Profili sil
                _profiles.Remove(profile);
                
                // Profilleri kaydet
                SaveProfiles();
                
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> SetDefaultProfileAsync(string profileId)
        {
            try
            {
                // Profili bul
                var profile = _profiles.FirstOrDefault(p => p.Id == profileId);
                
                // Profil yoksa false döndür
                if (profile == null)
                {
                    return Task.FromResult(false);
                }
                
                // Aynı cihaza ait tüm profillerin varsayılan özelliğini kaldır
                foreach (var p in _profiles.Where(p => p.DeviceId == profile.DeviceId))
                {
                    p.IsDefault = false;
                }
                
                // Seçilen profili varsayılan yap
                profile.IsDefault = true;
                
                // Profilleri kaydet
                SaveProfiles();
                
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> ExportProfileAsync(Profile profile, string filePath)
        {
            try
            {
                // Profili JSON formatına dönüştür
                var json = JsonConvert.SerializeObject(profile, Formatting.Indented);
                
                // JSON'ı dosyaya yaz
                File.WriteAllText(filePath, json);
                
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }

        public Task<Profile> ImportProfileAsync(string filePath)
        {
            try
            {
                // Dosyadan JSON oku
                var json = File.ReadAllText(filePath);
                
                // JSON'ı Profile nesnesine dönüştür
                var profile = JsonConvert.DeserializeObject<Profile>(json);
                
                // Yeni bir ID oluştur
                profile.Id = Guid.NewGuid().ToString();
                
                return Task.FromResult(profile);
            }
            catch (Exception)
            {
                return Task.FromResult<Profile>(null);
            }
        }

        private List<Profile> LoadProfiles()
        {
            var profiles = new List<Profile>();
            
            try
            {
                // Profil dosyalarını bul
                var profileFiles = Directory.GetFiles(_profilesDirectory, "*.json");
                
                // Her profil dosyasını oku
                foreach (var file in profileFiles)
                {
                    try
                    {
                        // Dosyadan JSON oku
                        var json = File.ReadAllText(file);
                        
                        // JSON'ı Profile nesnesine dönüştür
                        var profile = JsonConvert.DeserializeObject<Profile>(json);
                        
                        // Profili listeye ekle
                        profiles.Add(profile);
                    }
                    catch
                    {
                        // Hatalı profil dosyasını atla
                        continue;
                    }
                }
            }
            catch
            {
                // Hata durumunda boş liste döndür
            }
            
            return profiles;
        }

        private void SaveProfiles()
        {
            try
            {
                // Her profili ayrı bir dosyaya kaydet
                foreach (var profile in _profiles)
                {
                    // Profil dosya adını oluştur
                    var fileName = $"{profile.Id}.json";
                    var filePath = Path.Combine(_profilesDirectory, fileName);
                    
                    // Profili JSON formatına dönüştür
                    var json = JsonConvert.SerializeObject(profile, Formatting.Indented);
                    
                    // JSON'ı dosyaya yaz
                    File.WriteAllText(filePath, json);
                }
            }
            catch
            {
                // Hata durumunda işlemi atla
            }
        }
    }
}
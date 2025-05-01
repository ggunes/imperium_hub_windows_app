using ImperiumGearHUB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImperiumGearHUB.Services
{
    public interface IProfileService
    {
        Task<List<Profile>> GetProfilesAsync(string deviceId);
        Task<Profile> GetProfileAsync(string profileId);
        Task<bool> SaveProfileAsync(Profile profile);
        Task<bool> DeleteProfileAsync(string profileId);
        Task<bool> SetDefaultProfileAsync(string profileId);
        Task<bool> ExportProfileAsync(Profile profile, string filePath);
        Task<Profile> ImportProfileAsync(string filePath);
    }
}
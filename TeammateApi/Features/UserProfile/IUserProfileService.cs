using TeammateApi.Data;

namespace TeammateApi.Features.UserProfile
{
    public interface IUserProfileService
    {
        Task<UserProfileEntity> GetAsync(string uid);
        Task UpdateAsync(UserProfileEntity userProfile);
    }
}
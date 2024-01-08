using TeammateApi.Data;

namespace TeammateApi.Features.UserProfile;

public class UserProfileService : IUserProfileService
{
    private readonly TeammateContext _context;
    public UserProfileService(TeammateContext teammateContext)
    {
        _context = teammateContext;
    }

    public async Task<UserProfileEntity> GetAsync(string uid)
    {
        var dbProfile = await _context.UserProfiles.FindAsync(uid);
        return dbProfile;
    }

    public async Task UpdateAsync(UserProfileEntity userProfile)
    {
        var dbProfile = await _context.UserProfiles.FindAsync(userProfile.UserUid);
        if (dbProfile == null)
        {
            await _context.UserProfiles.AddAsync(userProfile);
        }
        else
        {
            _context.UserProfiles.Update(userProfile);
        }
        await _context.SaveChangesAsync();
    }
}

namespace TeammateApi.Data;

public partial class UserProfileEntity
{
    public string UserUid { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }
}

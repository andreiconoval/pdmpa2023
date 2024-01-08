using System;
using System.Collections.Generic;

namespace TeammateApi.Data;

public partial class UserAdressEntity
{
    public string? UserUid { get; set; }

    public string? MapLatitude { get; set; }

    public string? MapLongitude { get; set; }

    public string? Label { get; set; }
}

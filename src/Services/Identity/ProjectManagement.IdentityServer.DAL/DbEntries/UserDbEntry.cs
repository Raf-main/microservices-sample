using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ProjectManagement.IdentityServer.DAL.DbEntries;

public class UserDbEntry : IdentityUser
{
    [InverseProperty(nameof(RefreshTokenDbEntry.User))]
    public virtual ICollection<RefreshTokenDbEntry> RefreshTokens { get; set; } = new HashSet<RefreshTokenDbEntry>();
}
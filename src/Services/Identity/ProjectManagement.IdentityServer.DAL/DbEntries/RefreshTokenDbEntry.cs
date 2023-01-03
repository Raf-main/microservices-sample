using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectManagement.Domain.Shared.Interfaces;

namespace ProjectManagement.IdentityServer.DAL.DbEntries;

public class RefreshTokenDbEntry : IHasKey<int>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Token { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public bool IsUsed { get; set; }
    public bool IsExpired => ExpirationTime > DateTimeOffset.UtcNow;
    public DateTimeOffset ExpirationTime { get; set; }

    [ForeignKey(nameof(UserId))]
    [InverseProperty(nameof(UserDbEntry.RefreshTokens))]
    public virtual UserDbEntry User { get; set; } = null!;
}
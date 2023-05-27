using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Identity_login01.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity_login01.Models;

[Table("T_MUSERKANRI")]
public partial class T_MUSERKANRI : IdentityUser
{
    [Key]
    [StringLength(15)]
    [Unicode(false)]
    public string E_USERID { get; set; } = null!;

    [StringLength(40)]
    [Unicode(false)]
    public string? E_USERMEI { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string? E_PASSWORD { get; set; }

    [Precision(2)]
    public byte? E_PASSWORDGONYUURYOKUKAISUU { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string? E_LOGINKANOUKIKANFROM { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string? E_LOGINKANOUKIKANTO { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? E_POPUPHINTOHYOUJIFLAG { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? E_EMAILADDRESS { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? E_SIYOUFUKAFLAG { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? E_SAKUJOFLAG { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string E_TOUROKUKOUSINSHA { get; set; } = null!;

    [Column(TypeName = "DATE")]
    public DateTime E_TOUROKUKOUSINNITIJI { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? E_GROUPMDMGETSYSFLAG { get; set; }

    [NotMapped] public override string Id { get; set; }
    [NotMapped] public override string UserName { get; set; }
    [NotMapped] public override string NormalizedUserName { get; set; }
    [NotMapped] public override string Email { get; set; }
    [NotMapped] public override string NormalizedEmail { get; set; }
    [NotMapped] public override bool EmailConfirmed { get; set; }
    [NotMapped] public override string PasswordHash { get; set; }
    [NotMapped] public override string SecurityStamp { get; set; }
    [NotMapped] public override string ConcurrencyStamp { get; set; }
    [NotMapped] public override string PhoneNumber { get; set; }
    [NotMapped] public override bool PhoneNumberConfirmed { get; set; }
    [NotMapped] public override bool TwoFactorEnabled { get; set; }
    [NotMapped] public override DateTimeOffset? LockoutEnd { get; set; }
    [NotMapped] public override bool LockoutEnabled { get; set; }
    [NotMapped] public override int AccessFailedCount { get; set; }
}

///
///ユーザー情報の管理やパスワードの管理をするクラス
///

public class AppUserStore : IUserStore<T_MUSERKANRI>, IUserPasswordStore<T_MUSERKANRI>
{
    async Task<T_MUSERKANRI> IUserStore<T_MUSERKANRI>.FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        using (var context = new UserDbContext())
        {
            if (string.IsNullOrEmpty(userId))
            {
                return new T_MUSERKANRI();
            }
            var user = context.T_MUSERKANRIs.FirstOrDefaultAsync(x => x.E_USERID == userId, cancellationToken);
            return await user;
        }
    }
    Task<string> IUserPasswordStore<T_MUSERKANRI>.GetPasswordHashAsync(T_MUSERKANRI user, CancellationToken cancellationToken)
    {
        //パスワード(ハッシュ化されたもの)をそのまま返す
        return Task.FromResult(user.E_PASSWORD);
    }

    Task<IdentityResult> IUserStore<T_MUSERKANRI>.CreateAsync(T_MUSERKANRI user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    Task<IdentityResult> IUserStore<T_MUSERKANRI>.DeleteAsync(T_MUSERKANRI user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    Task<T_MUSERKANRI> IUserStore<T_MUSERKANRI>.FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
        T_MUSERKANRI user = new T_MUSERKANRI
        {
            E_USERID = "vender1",
            E_PASSWORD = "vendor1"

        };
        var MyPasswordHasher = new LoginService.MyPasswordHasher();

        var HashPass = MyPasswordHasher.HashPassword(user, "vendor1");

        T_MUSERKANRI users = new T_MUSERKANRI
        {
            E_USERID = "vender1",
            E_PASSWORD = HashPass

        };
        return Task.FromResult(users);
        //throw new NotImplementedException();
    }

    Task<string> IUserStore<T_MUSERKANRI>.GetNormalizedUserNameAsync(T_MUSERKANRI user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    Task<string> IUserStore<T_MUSERKANRI>.GetUserIdAsync(T_MUSERKANRI user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.E_USERID);
        //throw new NotImplementedException();
    }

    Task<string> IUserStore<T_MUSERKANRI>.GetUserNameAsync(T_MUSERKANRI user, CancellationToken cancellationToken)
    {
        return Task.FromResult(user.E_USERID);
        //throw new NotImplementedException();
    }

    Task<bool> IUserPasswordStore<T_MUSERKANRI>.HasPasswordAsync(T_MUSERKANRI user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    Task IUserStore<T_MUSERKANRI>.SetNormalizedUserNameAsync(T_MUSERKANRI user, string normalizedName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    Task IUserPasswordStore<T_MUSERKANRI>.SetPasswordHashAsync(T_MUSERKANRI user, string passwordHash, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    Task IUserStore<T_MUSERKANRI>.SetUserNameAsync(T_MUSERKANRI user, string userName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    Task<IdentityResult> IUserStore<T_MUSERKANRI>.UpdateAsync(T_MUSERKANRI user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    public void Dispose() { }


}



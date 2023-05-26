using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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



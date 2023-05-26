using Identity_login01.Models;
using Microsoft.AspNetCore.Identity;
using System.Text;
using XSystem.Security.Cryptography;

namespace Identity_login01.LoginService
{
    //
    //入力されたパスワードをハッシュ化するクラス
    //
    public class MyPasswordHasher : IPasswordHasher<T_MUSERKANRI>
    {
        public string HashPassword(T_MUSERKANRI user, string password)
        {
            var ret = new StringBuilder();

            var unicodePassword = Encoding.UTF8.GetBytes(password);
#pragma warning disable SYSLIB0021 // 型またはメンバーが旧型式です
            var Sha1Manager = new SHA1Managed();
#pragma warning restore SYSLIB0021 // 型またはメンバーが旧型式です
            var sha1Password = Sha1Manager.ComputeHash(unicodePassword);
            foreach (byte item in sha1Password)
            {
                ret.Append(string.Format("{0:X2}", item));
            }
            return ret.ToString();
        }

        public PasswordVerificationResult VerifyHashedPassword(T_MUSERKANRI user, string hashedPassword, string providedPassword)
        {
            if (hashedPassword == this.HashPassword(user, providedPassword))
            {
                return PasswordVerificationResult.Success;
            }
            else
            {
                return PasswordVerificationResult.Failed;
            }
        }
    }
}

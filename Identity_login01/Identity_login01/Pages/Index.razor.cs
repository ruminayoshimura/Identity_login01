using Identity_login01.Models;
using Identity_login01.LoginService;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Identity_login01.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Identity_login01.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        public NavigationManager Navigation { get; set; }
        [Inject]
        public IHostEnvironmentAuthenticationStateProvider? _HostAuthentication { get; set; }
        [Inject]
        public AuthenticationStateProvider? _AuthenticationStateProvider { get; set; }
        [Inject]
        public SignInManager<T_MUSERKANRI> signInManager { get; set; }

        [Inject]
        public IDbContextFactory<UserDbContext> userkanriDbContextFactory { get; set; }

        private UserDbContext _userKanriDbContext = default!;

        [Inject]
        public AppUserStore appUserStore { get; set; }
        [Parameter]
        public string userId { get; set; }
        [Parameter]
        public string passWord { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _HostAuthentication = HostAuthentication;
            _AuthenticationStateProvider = AuthenticationStateProvider;
            _userKanriDbContext = userkanriDbContextFactory.CreateDbContext() ?? throw new ArgumentNullException(nameof(userkanriDbContextFactory));
        }

        public async Task Signin()
        {
            var userIdinfo = _userKanriDbContext.T_MUSERKANRIs.Where(x => x.E_USERID == userId).FirstOrDefault();
            if (userIdinfo is null)
            {

            }
            else
            {

                //入力されたパスワードをハッシュ化する
                var MyPasswordHasher = new MyPasswordHasher();

                var HashPass = MyPasswordHasher.HashPassword(userIdinfo, passWord);

                var user = _userKanriDbContext.T_MUSERKANRIs.Where(x => x.E_USERID == userId && x.E_PASSWORD == HashPass).FirstOrDefault();

                if (!(user is null))
                {
                    //ログイン条件すべてに当てはまったユーザー情報を認証登録する
                    ClaimsPrincipal principal = await signInManager.CreateUserPrincipalAsync(user);

                    ClaimsIdentity identity = new ClaimsIdentity(principal.Claims,
                            CookieAuthenticationDefaults.AuthenticationScheme);

                    signInManager.Context.User = principal;

                    _HostAuthentication!.SetAuthenticationState(
                        Task.FromResult(new AuthenticationState(principal)));

                    AuthenticationState authState = await _AuthenticationStateProvider!.GetAuthenticationStateAsync();

                    Navigation.NavigateTo("/Counter");
                }

            }
        }
    }
}

using System;
using Microsoft.AspNetCore.Identity;

namespace JobTrackingApp.WebUI.Options
{
    public static class CustomIdentityOptions
    {
        public static Action<IdentityOptions> GetIdentityOptions()
        {
            return options => { options.Password = GetPasswordOptions(); };
        }

        private static PasswordOptions GetPasswordOptions()
        {
            return new PasswordOptions()
            {
                RequireDigit = false,
                RequireUppercase = false,
                RequiredLength = 6,
                RequireLowercase = false,
                RequireNonAlphanumeric = false
            };
        }
    }
}
using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace JobTrackingApp.WebUI.Options
{
    public static class CustomCookieAuthenticationOptions
    {
        public static Action<CookieAuthenticationOptions> GetCookieAuthOptions()
        {
            return options =>
            {
                options.Cookie = GetCookieBuildOptions();
                options.LoginPath = new PathString("/Home/Login");
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(20);
            };
        }

        private static CookieBuilder GetCookieBuildOptions()
        {
            return new CookieBuilder()
            {
                Name = "JobTrackingCookie",
                SameSite = SameSiteMode.Strict,
                HttpOnly = true,
                SecurePolicy = CookieSecurePolicy.SameAsRequest
            };
        }
    }
}
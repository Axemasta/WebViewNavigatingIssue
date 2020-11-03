using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WebViewCancelExample.Services
{
    public class SiteValidatorAsync : ISiteValidatorAsync
    {
        private readonly ISiteValidator _siteValidator;
        private readonly Random _random;

        public SiteValidatorAsync(ISiteValidator siteValidator)
        {
            _siteValidator = siteValidator;

            _random = new Random();
        }

        public async Task<bool> IsSiteAllowed(string url)
        {
            var delay = _random.Next(250, 2000);

            Debug.WriteLine($"Async task is going to take: {delay}ms");

            await Task.Delay(delay);

            return _siteValidator.IsSiteAllowed(url);
        }
    }
}

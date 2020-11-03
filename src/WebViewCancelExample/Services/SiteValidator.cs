using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WebViewCancelExample.Services
{
    public class SiteValidator : ISiteValidator
    {
        private List<string> _blockedSites { get; } = new List<string>
        {
            "facebook.com",
            "twitter.com",
            "reddit.com"
        };

        public bool IsSiteAllowed(string url)
        {
            var allowed = !_blockedSites.Any(b => url.Contains(b));

            Debug.WriteLine($"Site {url} is allowed: {allowed}");

            return allowed;
        }
    }
}

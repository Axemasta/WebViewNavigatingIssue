using System;
namespace WebViewCancelExample.Services
{
    public interface ISiteValidator
    {
        bool IsSiteAllowed(string url);
    }
}

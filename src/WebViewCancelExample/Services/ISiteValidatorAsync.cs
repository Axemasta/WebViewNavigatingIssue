using System;
using System.Threading.Tasks;

namespace WebViewCancelExample.Services
{
    public interface ISiteValidatorAsync
    {
        Task<bool> IsSiteAllowed(string url);
    }
}

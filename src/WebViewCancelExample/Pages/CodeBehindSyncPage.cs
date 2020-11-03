using System;
using WebViewCancelExample.Services;
using Xamarin.Forms;

namespace WebViewCancelExample.Pages
{
    public class CodeBehindSyncPage : ContentPage
    {
        private readonly ISiteValidator _siteValidator;

        private WebView MyWebView { get; } = new WebView()
        {
            Source = "https://google.co.uk"
        };

        public CodeBehindSyncPage(ISiteValidator siteValidator)
        {
            _siteValidator = siteValidator;

            Title = "Code Behind Sync";
            IconImageSource = FileImageSource.FromFile("sync_alt_solid");

            Content = MyWebView;

            MyWebView.Navigating += OnNavigating;
            MyWebView.Navigated += OnNavigated;
        }

        private void OnNavigating(object sender, WebNavigatingEventArgs e)
        {
            var allowed = _siteValidator.IsSiteAllowed(e.Url);

            e.Cancel = !allowed;
        }

        private async void OnNavigated(object sender, WebNavigatedEventArgs e)
        {
            var allowed = _siteValidator.IsSiteAllowed(e.Url);

            if (!allowed)
            {
                await DisplayAlert("Site Blocked 😧", "It looks like you were allowed to browse to a blocked site!", "😰 I won't do it again");
            }
        }
    }
}


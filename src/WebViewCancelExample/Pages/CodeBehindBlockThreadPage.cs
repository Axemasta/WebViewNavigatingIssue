using System;
using System.Diagnostics;
using WebViewCancelExample.Services;
using Xamarin.Forms;

namespace WebViewCancelExample.Pages
{
    public class CodeBehindBlockThreadPage : ContentPage
    {
        private readonly ISiteValidatorAsync _siteValidator;

        private WebView MyWebView { get; } = new WebView()
        {
            Source = "https://google.co.uk"
        };

        public CodeBehindBlockThreadPage(ISiteValidatorAsync asyncValidator)
        {
            _siteValidator = asyncValidator;

            Title = "Code Behind Block Thread";
            //IconImageSource = FileImageSource.FromFile("code_branch_solid");

            Content = MyWebView;

            MyWebView.Navigating += OnNavigating;
            MyWebView.Navigated += OnNavigated;
        }

        private void OnNavigating(object sender, WebNavigatingEventArgs e)
        {
            var t = _siteValidator.IsSiteAllowed(e.Url);
            t.Wait();
            var allowed = t.Result;

            e.Cancel = !allowed;
        }

        private async void OnNavigated(object sender, WebNavigatedEventArgs e)
        {
            Debug.WriteLine($"CodeBehindBlockThreadPage - Navigated to site: {e.Url}");

            var allowed = await _siteValidator.IsSiteAllowed(e.Url);

            if (!allowed)
            {
                await DisplayAlert("Site Blocked 😧", "It looks like you were allowed to browse to a blocked site!", "😰 I won't do it again");
            }
        }
    }
}


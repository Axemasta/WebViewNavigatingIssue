﻿using System;
using System.Diagnostics;
using WebViewCancelExample.Services;
using Xamarin.Forms;

namespace WebViewCancelExample.Pages
{
    public class CodeBehindAsyncPage : ContentPage
    {
        private readonly ISiteValidatorAsync _siteValidator;

        private WebView MyWebView { get; } = new WebView()
        {
            Source = "https://google.co.uk"
        };

        public CodeBehindAsyncPage(ISiteValidatorAsync asyncValidator)
        {
            _siteValidator = asyncValidator;

            Title = "Code Behind Async";
            IconImageSource = FileImageSource.FromFile("code_branch_solid");

            Content = MyWebView;

            MyWebView.Navigating += OnNavigating;
            MyWebView.Navigated += OnNavigated;
        }

        private async void OnNavigating(object sender, WebNavigatingEventArgs e)
        {
            var allowed = await _siteValidator.IsSiteAllowed(e.Url);

            e.Cancel = !allowed;
        }

        private async void OnNavigated(object sender, WebNavigatedEventArgs e)
        {
            Debug.WriteLine($"CodeBehindAsyncPage - Navigated to site: {e.Url}");

            var allowed = await _siteValidator.IsSiteAllowed(e.Url);

            if (!allowed)
            {
                await DisplayAlert("Site Blocked 😧", "It looks like you were allowed to browse to a blocked site!", "😰 I won't do it again");
            }
        }
    }
}


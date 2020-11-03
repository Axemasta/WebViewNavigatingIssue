using System;
using WebViewCancelExample.Pages;
using WebViewCancelExample.Platform;
using WebViewCancelExample.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebViewCancelExample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = GetMainPage();
        }

        private MultiPage<Page> GetMainPage()
        {
            ISiteValidator siteValidator = new SiteValidator();
            ISiteValidatorAsync asyncValidator = new SiteValidatorAsync(siteValidator);

            var tabbedPage = new TabbedPage()
            {
                BarBackgroundColor = Color.FromHex("#2196F3"),
                BarTextColor = Color.White
            };

            tabbedPage.Children.Add(new CodeBehindSyncPage(siteValidator));
            tabbedPage.Children.Add(new CodeBehindAsyncPage(asyncValidator));

            PlatformHelper.SetPlatformStyling(tabbedPage);
            tabbedPage.SelectedTabColor = Color.White;
            tabbedPage.UnselectedTabColor = Color.FromHex("#0063C0");

            return tabbedPage;
        }
    }
}

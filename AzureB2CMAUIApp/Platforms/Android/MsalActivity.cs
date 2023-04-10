using Android.App;
using Android.Content;
using Microsoft.Identity.Client;

namespace PaceMaker.Platforms.Android 
{
    [Activity(Exported = true)]
    [IntentFilter(new[] { Intent.ActionView },
       Categories = new[] { Intent.CategoryBrowsable, Intent.CategoryDefault },
       DataHost = "auth",
       DataScheme = "msal{INSERT-CLIENT-SOCIAL-ID-HERE}")]
    public class MsalActivity : BrowserTabActivity {
    }
}

using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content.PM;
using Android.Views;

namespace MyExtensionsApp.Droid;

[Activity(
	MainLauncher = true,
	ConfigurationChanges = global::Uno.UI.ActivityHelper.AllConfigChanges,
	WindowSoftInputMode = SoftInput.AdjustNothing | SoftInput.StateHidden
)]
public class MainActivity : Microsoft.UI.Xaml.ApplicationActivity
{
}

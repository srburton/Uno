#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.UI.Xaml.Automation.Peers
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class AppBarToggleButtonAutomationPeer : global::Windows.UI.Xaml.Automation.Peers.ToggleButtonAutomationPeer
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __MACOS__
		[global::Uno.NotImplemented]
		public AppBarToggleButtonAutomationPeer( global::Windows.UI.Xaml.Controls.AppBarToggleButton owner) : base(owner)
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.AppBarToggleButtonAutomationPeer", "AppBarToggleButtonAutomationPeer.AppBarToggleButtonAutomationPeer(AppBarToggleButton owner)");
		}
		#endif
		// Forced skipping of method Windows.UI.Xaml.Automation.Peers.AppBarToggleButtonAutomationPeer.AppBarToggleButtonAutomationPeer(Windows.UI.Xaml.Controls.AppBarToggleButton)
	}
}

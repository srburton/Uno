#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.UI.Xaml.Controls
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class TreeViewItemInvokedEventArgs 
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __MACOS__
		[global::Uno.NotImplemented]
		public  bool Handled
		{
			get
			{
				throw new global::System.NotImplementedException("The member bool TreeViewItemInvokedEventArgs.Handled is not implemented in Uno.");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Controls.TreeViewItemInvokedEventArgs", "bool TreeViewItemInvokedEventArgs.Handled");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __MACOS__
		[global::Uno.NotImplemented]
		public  object InvokedItem
		{
			get
			{
				throw new global::System.NotImplementedException("The member object TreeViewItemInvokedEventArgs.InvokedItem is not implemented in Uno.");
			}
		}
		#endif
		// Forced skipping of method Windows.UI.Xaml.Controls.TreeViewItemInvokedEventArgs.InvokedItem.get
		// Forced skipping of method Windows.UI.Xaml.Controls.TreeViewItemInvokedEventArgs.Handled.set
		// Forced skipping of method Windows.UI.Xaml.Controls.TreeViewItemInvokedEventArgs.Handled.get
	}
}

#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.Media.PlayTo
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class MuteChangeRequestedEventArgs 
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __MACOS__
		[global::Uno.NotImplemented]
		public  bool Mute
		{
			get
			{
				throw new global::System.NotImplementedException("The member bool MuteChangeRequestedEventArgs.Mute is not implemented in Uno.");
			}
		}
		#endif
		// Forced skipping of method Windows.Media.PlayTo.MuteChangeRequestedEventArgs.Mute.get
	}
}

using System;
using Uno.UI.Controls;

namespace Windows.UI.ViewManagement
{
	public partial class InputPaneVisibilityEventArgs
	{
		internal InputPaneVisibilityEventArgs(Foundation.Rect occludedRect)
		{
			OccludedRect = occludedRect;
#if __ANDROID__
			var navigationBarHeight = NavigationBarHelper.IsNavigationBarVisible && !NavigationBarHelper.IsNavigationBarTranslucent
				? NavigationBarHelper.LogicalNavigationBarHeight
				: 0;
			KeyboardHeight = Math.Max(0, OccludedRect.Height - navigationBarHeight);
#endif
		}

		public bool EnsuredFocusedElementInView { get; set; }

		public Foundation.Rect OccludedRect { get; private set; }

#if __ANDROID__
		public double KeyboardHeight { get; }
#endif
	}
}

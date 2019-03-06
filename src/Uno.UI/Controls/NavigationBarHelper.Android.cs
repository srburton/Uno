#if __ANDROID__
using Android.App;
using Android.Util;
using Android.Views;
using Window = Windows.UI.Xaml.Window;

namespace Uno.UI.Controls
{
	public static class NavigationBarHelper
	{
		public static bool IsNavigationBarTranslucent
		{
			get
			{
				var activity = ContextHelper.Current as Activity;
				var windowFlags = activity.Window.Attributes.Flags;

				return ((int)windowFlags & (int)WindowManagerFlags.TranslucentNavigation) != 0
					|| ((int)windowFlags & (int)WindowManagerFlags.LayoutNoLimits) != 0;
			}
		}

		public static bool IsNavigationBarVisible
		{
			get
			{
				var activity = ContextHelper.Current as Activity;
				var systemUiVisibility = activity.Window.DecorView.SystemUiVisibility;
				var resources = activity.Resources;
				int id = resources.GetIdentifier("config_showNavigationBar", "bool", "android");

				return (Window.Current.SystemUiVisibility & (int)SystemUiFlags.HideNavigation) == 0
					|| ((int)systemUiVisibility & (int)SystemUiFlags.HideNavigation) == 0
					|| (id > 0 && resources.GetBoolean(id));
			}
		}

		public static double LogicalNavigationBarHeight
		{
			get
			{
				var metrics = new DisplayMetrics();
				var defaultDisplay = (ContextHelper.Current as Activity)?.WindowManager?.DefaultDisplay;

				if (defaultDisplay == null)
				{
					return 0;
				}

				defaultDisplay.GetMetrics(metrics);
				var usableHeight = metrics.HeightPixels;

				defaultDisplay.GetRealMetrics(metrics);
				var realHeight = metrics.HeightPixels;

				return realHeight > usableHeight
					? ViewHelper.PhysicalToLogicalPixels(realHeight - usableHeight)
					: 0;
			}
		}

		public static double PhysicalNavigationBarHeight => NavigationBarHelper.LogicalNavigationBarHeight * ViewHelper.Scale;
	}
}
#endif

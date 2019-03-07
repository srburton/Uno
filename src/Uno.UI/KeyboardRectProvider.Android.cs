﻿using System;
using Android.App;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Uno.UI
{
	/// <summary>
	/// A <see cref="PopupWindow"/> that provides the size and location of the keyboard by being resized using <see cref="SoftInput.AdjustResize"/>.
	/// </summary>
	internal class KeyboardRectProvider : PopupWindow, ViewTreeObserver.IOnGlobalLayoutListener, View.IOnSystemUiVisibilityChangeListener
	{
		public delegate void LayoutChangedListener(Rect union);
		
		private readonly LayoutChangedListener _onLayoutChanged;
		private readonly Activity _activity;
		private readonly View _popupView;

		public KeyboardRectProvider(Activity activity, LayoutChangedListener onLayoutChanged) : base(activity)
		{
			_activity = activity;
			_popupView = new LinearLayout(_activity.BaseContext)
			{
				LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent)
			};
			_onLayoutChanged = onLayoutChanged;

			ContentView = _popupView;
			SoftInputMode = SoftInput.AdjustResize | SoftInput.StateAlwaysVisible;
			InputMethodMode = InputMethod.Needed;
			Width = 0;
			Height = ViewGroup.LayoutParams.MatchParent;
			SetBackgroundDrawable(new ColorDrawable(Color.Transparent));
		}

		/// <summary>
		/// Shows the <see cref="PopupWindow"/> and starts listening to keyboard rect changes.
		/// </summary>
		/// <param name="view">A view to get the Android.Views.View.WindowToken token from. It must be attached to a Window for it to work.</param>
		public void Start(View view)
		{
			if (!IsShowing && view != null && view.WindowToken != null)
			{
				ShowAtLocation(view, GravityFlags.NoGravity, 0, 0);
				_popupView.ViewTreeObserver.AddOnGlobalLayoutListener(this);
				_popupView.SetOnSystemUiVisibilityChangeListener(this);
			}
		}

		/// <summary>
		/// Dismisses the <see cref="PopupWindow"/> and stops listening to keyboard rect changes.
		/// </summary>
		public void Stop()
		{
			if (IsShowing)
			{
				Dismiss();
				_popupView.ViewTreeObserver.RemoveOnGlobalLayoutListener(this);
			}
		}

		public void OnSystemUiVisibilityChange([GeneratedEnum] StatusBarVisibility visibility)
		{
			MeasureOccludedRect();
		}

		/// <summary>
		/// Called whenever the size of the <see cref="_popupView"/> changes.
		/// The size and location of the keyboard can be inferred from the
		/// remaining area of the screen (below the <see cref="_popupView"/>).
		/// </summary>
		void ViewTreeObserver.IOnGlobalLayoutListener.OnGlobalLayout()
		{
			MeasureOccludedRect();
		}

		private void MeasureOccludedRect()
		{
			// we assume that the keyboard and the navigation bar always occupy the bottom area, with the keyboard being above the navigation bar
			// their placements can be calculated based on the follow observation:
			// [size] realMetrics	: screen
			// [rect] displayRect	: display area = screen - (bottom: nav_bar)
			// [rect] usableRect	: usable area = screen - (top: status_bar) - (bottom: keyboard + nav_bar)
			var realMetrics = Get<DisplayMetrics>(_activity.WindowManager.DefaultDisplay.GetRealMetrics);
			//var displayRect = Get<Rect>(_activity.WindowManager.DefaultDisplay.GetRectSize);
			var usableRect = Get<Rect>(_popupView.GetWindowVisibleDisplayFrame);

			var occupiedRect = new Rect(0, usableRect.Bottom, realMetrics.WidthPixels, realMetrics.HeightPixels);

			_onLayoutChanged?.Invoke(occupiedRect);

			T Get<T>(Action<T> getter) where T : new()
			{
				var result = new T();
				getter(result);

				return result;
			}
		}
	}
}

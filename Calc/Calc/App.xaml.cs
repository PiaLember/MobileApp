#if MAC
using Microsoft.UI;
using Windows Graphics;
#endif

namespace Calc;

public partial class App : Application
{
	const int WindowWidth = 540;
	const int WindowHeight = 1000;
	public App()
	{
		InitializeComponent();

		#if MAC
		Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow),(handler, view)=>
		{
			var MauiWindow = handler.VirtualView;
			var nativeWindow = handler.PlatformView;
			nativeWindow.Activate();
			InPtr windowHandle = WinRT.Interop.WindowNative.GetWindowhandle(nativeWindow);
			WindowId windowId = Microsoft.UI.Wint32Interop.GetWindowIdFromWindow(windowHandle);
			AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
			appWindow.Rezise(new SizeInt32(WindowWidth,WindowHeight));
		});
		#endif

		MainPage = new AppShell();
	}
}

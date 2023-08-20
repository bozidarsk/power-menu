using System;
using System.Collections.Generic;
using Gtk;

/*

****** Window (window)**************
*                                  *
*  ****** VBox (box) ************  *
*  *                            *  *
*  *  Button (button-shutdown)  *  *
*  *  Button (button-reboot)    *  *
*  *  Button (button-lock)      *  *
*  *  Button (button-logout)    *  *
*  *  Button (button-sleep)     *  *
*  *                            *  *
*  ******************************  *
*                                  *
************************************

*/

public static class Window 
{
	public static void Run() 
	{
		Application.Init();

		CssProvider provider = new CssProvider();
		provider.LoadFromData(Config.Css);
		StyleContext.AddProviderForScreen(Gdk.Screen.Default, provider, 800);

		var window = new Gtk.Window("power-menu");
		window.Name = "window";
		var box = new Gtk.VBox();
		box.Name = "box";
		var button_shutdown = new Gtk.Button(Config.ShutdownText);
		button_shutdown.Name = "button-shutdown";
		var button_reboot = new Gtk.Button(Config.RebootText);
		button_reboot.Name = "button-reboot";
		var button_lock = new Gtk.Button(Config.LockText);
		button_lock.Name = "button-lock";
		var button_logout = new Gtk.Button(Config.LogoutText);
		button_logout.Name = "button-logout";
		var button_sleep = new Gtk.Button(Config.SleepText);
		button_sleep.Name = "button-sleep";

		window.Add(box);
		box.PackStart(button_shutdown, false, false, 0);
		box.PackStart(button_reboot, false, false, 0);
		box.PackStart(button_lock, false, false, 0);
		box.PackStart(button_logout, false, false, 0);
		box.PackStart(button_sleep, false, false, 0);

		button_shutdown.Clicked += (object sender, EventArgs e) => Program.Shell(Config.ShutdownCommand);
		((Gtk.Label)button_shutdown.Child).UseMarkup = true;
		button_shutdown.SetAlignment(0, 0.5f);
		button_reboot.Clicked += (object sender, EventArgs e) => Program.Shell(Config.RebootCommand);
		((Gtk.Label)button_reboot.Child).UseMarkup = true;
		button_reboot.SetAlignment(0, 0.5f);
		button_lock.Clicked += (object sender, EventArgs e) => Program.Shell(Config.LockCommand);
		((Gtk.Label)button_lock.Child).UseMarkup = true;
		button_lock.SetAlignment(0, 0.5f);
		button_logout.Clicked += (object sender, EventArgs e) => Program.Shell(Config.LogoutCommand);
		((Gtk.Label)button_logout.Child).UseMarkup = true;
		button_logout.SetAlignment(0, 0.5f);
		button_sleep.Clicked += (object sender, EventArgs e) => Program.Shell(Config.SleepCommand);
		((Gtk.Label)button_sleep.Child).UseMarkup = true;
		button_sleep.SetAlignment(0, 0.5f);

		LayerShell.InitWindow(window);
		LayerShell.SetLayer(window, LayerShell.Layer.Overlay);
		LayerShell.SetKeyboardInteractivity(window, true);
		LayerShell.SetKeyboardMode(window, LayerShell.KeyboardMode.Exclusive);
		LayerShell.SetMargin(window, LayerShell.Edge.Top, Config.WindowMarginTop);
		LayerShell.SetMargin(window, LayerShell.Edge.Right, Config.WindowMarginRight);
		LayerShell.SetMargin(window, LayerShell.Edge.Bottom, Config.WindowMarginBottom);
		LayerShell.SetMargin(window, LayerShell.Edge.Left, Config.WindowMarginLeft);
		for (int i = 0; Config.WindowAnchor != null && i < Config.WindowAnchor.Length; i++) { LayerShell.SetAnchor(window, Config.WindowAnchor[i], true); }

		window.Resizable = false;
		window.KeepAbove = true;
		window.FocusOutEvent += (object sender, FocusOutEventArgs e) => Application.Quit();
		window.KeyPressEvent += (object sender, KeyPressEventArgs e) => Application.Quit();
		window.ButtonPressEvent += (object sender, ButtonPressEventArgs e) => Application.Quit();
		window.SetDefaultSize(Config.WindowWidth, Config.WindowHeight);
		window.ShowAll();

		Application.Run();
	}
}
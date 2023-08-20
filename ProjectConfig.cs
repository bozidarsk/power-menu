using System;

public static partial class Config 
{
	public static int WindowWidth { private set; get; } = 50;
	public static int WindowHeight { private set; get; } = 200;
	public static int WindowMarginTop { private set; get; } = 10;
	public static int WindowMarginRight { private set; get; } = 10;
	public static int WindowMarginBottom { private set; get; } = 0;
	public static int WindowMarginLeft { private set; get; } = 0;
	public static Gtk.LayerShell.Edge[] WindowAnchor { private set; get; } = { Gtk.LayerShell.Edge.Top, Gtk.LayerShell.Edge.Right };
	public static string ShutdownText { private set; get; } = "<span font-family=\"Font Awesome 6 Sharp\" font-size=\"small\">⏻</span> Shutdown";
	public static string ShutdownCommand { private set; get; } = @"poweroff";
	public static string RebootText { private set; get; } = "<span font-family=\"Font Awesome 6 Sharp\"></span>  Reboot";
	public static string RebootCommand { private set; get; } = @"reboot";
	public static string LockText { private set; get; } = "<span font-family=\"Font Awesome 6 Sharp\" font-size=\"small\"></span> Lock";
	public static string LockCommand { private set; get; } = @"dm-tool lock";
	public static string LogoutText { private set; get; } = "<span font-family=\"Font Awesome 6 Sharp\"></span> Logout";
	public static string LogoutCommand { private set; get; } = @"loginctl kill-user $USER";
	public static string SleepText { private set; get; } = "<span font-family=\"Font Awesome 6 Sharp\"></span> Sleep";
	public static string SleepCommand { private set; get; } = @"keypress sleep";

	public static string Css { private set; get; } = "* {\n	font-family: \"Source Code Pro Bold\";\n	font-weight: bold;\n	transition: 0.2s;\n}\n\n#window {\n	border: 2px solid @theme_selected_bg_color;\n	border-radius: 8px;\n}\n\n#box {\n	margin: 10px;\n}\n\n/*#button-shutdown,*/\n#button-reboot,\n#button-lock,\n#button-logout,\n#button-sleep {	\n	margin-top: 5px;\n}";
	public static string ConfigDir { private set; get; } = Environment.GetEnvironmentVariable("HOME") + "/.config/power-menu";

	private static readonly Option[] OptionsDefinition = 
	{
		new Option("--config-dir", 'c', true, null),
	};
}
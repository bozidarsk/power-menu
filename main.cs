using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public static class Program 
{
	private static readonly string SHELL = Environment.GetEnvironmentVariable("SHELL");
	public static void Shell(string command) 
	{
		Console.WriteLine($"{SHELL} -c \"{command}\"");
		// Process.Start(SHELL, $"-c \"{command}\"");

		// ProcessStartInfo info = new ProcessStartInfo();
		// info.FileName = SHELL;
		// info.Arguments = $"-c \"{command}\"";
		// info.UseShellExecute = false;
		// info.RedirectStandardOutput = true;
		// info.RedirectStandardError = false;

		// Process proc = new Process();
		// proc.StartInfo = info;
		// proc.Start();
		// proc.WaitForExit();

		// return proc.StandardOutput.ReadToEnd();
	}

	private static int Main(string[] args) 
	{
		if (args.Length == 0 || (args.Length == 1 && (args[0] == "-h" || args[0] == "--help" || args[0] == "help"))) 
		{
			Console.WriteLine("Usage:\n\tpower-menu <command> [options]");
			Console.WriteLine("\nCommands:");
			Console.WriteLine("\twindow              Opens a gtk3 gui window.");
			Console.WriteLine("\tdefaults            Creates default configuration and style files.");
			Console.WriteLine("\nOptions:");
			Console.WriteLine("\t--config-dir <dir>  Directory which contains configuration and style files.");
			return 0;
		}

		Config.Initialize(ref args);

		if (args.Length == 0) { Console.WriteLine("No commands provided."); return 1; }
		switch (args[0]) 
		{
			case "window":
				Window.Run();
				break;
			case "defaults":
				Config.CreateDefaults();
				break;
			default:
				Console.WriteLine("Unknown command.");
				return 1;
		}		

		return 0;
	}
}
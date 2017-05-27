using System;
using System.Diagnostics;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


namespace Test.Helpers
{
	public class End2EndTest
	{
		protected ChromeDriver Browser;
		protected const int Port = 5050;
		private Process Process { get; set; }

		[SetUp]
		public void setup_web_app_and_browser()
		{
			LaunchWebApp();
			SetupWebDriver();
			Browser = new ChromeDriver();
			Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(50);
		}

		[TearDown]
		public void Cleanup()
		{
			KillWebApp();
			Browser.Quit();
		}

		private void LaunchWebApp()
		{
			var solutionFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
			var applicationPath = Path.Combine(solutionFolder, "Controller");
			var programFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
			Process = new Process
			{
				StartInfo =
				{
					FileName = Path.Combine(programFilesPath, @"IIS Express\iisexpress.exe"),
					Arguments = $"/path:{applicationPath} /port:{Port}"
				}
			};
			Process.Start();
		}

		private void KillWebApp()
		{
			if (!Process.HasExited) Process.Kill();
		}

		private static void SetupWebDriver()
		{
			new DriverManager().SetUpDriver(new ChromeConfig());
		}
	}
}
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


namespace Test.End2End
{
	[TestFixture]
	class CreateFolders
	{
		private ChromeDriver Browser;

		[SetUp]
		public void given_a_browser()
		{
			SetupWebDriver();
			Browser = new ChromeDriver();
		}

		[Test]
		public void As_a_user_I_want_to_create_folders_in_the_Vocabulary_section_of_my_Workspace()
		{
			const string vocabularyTableName = "Parrot Words";

			Browser.Navigate().GoToUrl("http://localhost:57143");
			Browser.Url.Should().Be("http://localhost:57143/login?returnUrl=/");

			Browser.FindElementByName("username").SendKeys("CrazyParrot");
			Browser.FindElementByName("password").SendKeys("parroty_pass");
			Browser.FindElementByTagName("form").Submit();

			Browser.FindElementByCssSelector("#workspace #vocabulary .add").Click();
			Browser.FindElementByName("vocabulary-table-title").SendKeys(vocabularyTableName);
			Browser.FindElementByName("create-vocabulary-table").Click();

			var folders = Browser.FindElementsByCssSelector("#workspace #vocabulary .folder");
			folders.First().Text.Should().Be(vocabularyTableName);
		}

		private static void SetupWebDriver()
		{
			new DriverManager().SetUpDriver(new ChromeConfig());
		}
	}
}

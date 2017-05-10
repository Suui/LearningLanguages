using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using Test.Helpers;


namespace Test.End2End
{
	[TestFixture]
	class CreateFolders : End2EndTest
	{
		[Test]
		public void As_a_user_I_want_to_create_folders_in_the_Vocabulary_section_of_my_Workspace()
		{
			const string vocabularyFolderName = "Parrot Words";

			PerformLogin();
			CreateVocabularyFolder(vocabularyFolderName);

			var folders = Browser.FindElementsByCssSelector("#workspace #vocabulary .folder");
			folders.First().Text.Should().Be(vocabularyFolderName);
		}

		private void PerformLogin()
		{
			Browser.Navigate().GoToUrl($"http://localhost:{Port}");
			Browser.Url.Should().Be($"http://localhost:{Port}/login?returnUrl=/");

			Browser.FindElementByName("username").SendKeys("CrazyParrot");
			Browser.FindElementByName("password").SendKeys("parroty_pass");
			Browser.FindElementByTagName("form").Submit();
		}

		private void CreateVocabularyFolder(string vocabularyTableName)
		{
			Browser.FindElementById("add-vocabulary-folder").Click();
			Browser.SwitchTo().ActiveElement();
			Browser.FindElementByName("vocabulary-table-title").SendKeys(vocabularyTableName);
			Browser.FindElementByName("create-vocabulary-table").Click();
		}
	}
}

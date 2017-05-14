using System.Collections.ObjectModel;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using Test.Helpers;


namespace Test.End2End
{
	[TestFixture]
	class CreateFolders : End2EndTest
	{
		private static readonly By UsernameInputField = By.Name("username");
		private static readonly By PasswordInputField = By.Name("password");
		private static readonly By FormSubmit = By.TagName("form");
		private static readonly By AddVocabularyFolderIcon = By.Id("add-vocabulary-folder");
		private static readonly By VocabularyFolderNameInputField = By.Name("vocabularyFolderName");
		private static readonly By VocabularyTableSubmit = By.Name("createVocabularyFolder");
		private ReadOnlyCollection<IWebElement> TheVocabularyFolders => Browser.FindElements(By.CssSelector(".vocabulary-folder"));

		[Test]
		public void As_a_user_I_want_to_create_folders_in_the_Vocabulary_section_of_my_Workspace()
		{
			const string vocabularyFolderName = "Parrot Words";

			PerformLogin();
			CreateVocabularyFolder(vocabularyFolderName);

			TheVocabularyFolders.ShouldContainASingleFolderNamed(vocabularyFolderName);
		}

		private void PerformLogin()
		{
			Browser.Navigate().GoToUrl($"http://localhost:{Port}");
			Browser.Url.Should().Be($"http://localhost:{Port}/login?returnUrl=/");

			Browser.FindElement(UsernameInputField).SendKeys("CrazyParrot");
			Browser.FindElement(PasswordInputField).SendKeys("parroty_pass");
			Browser.FindElement(FormSubmit).Submit();
		}

		private void CreateVocabularyFolder(string vocabularyTableName)
		{
			Browser.FindElement(AddVocabularyFolderIcon).Click();
			Browser.SwitchTo().ActiveElement();
			Browser.FindElement(VocabularyFolderNameInputField).SendKeys(vocabularyTableName);
			Browser.FindElement(VocabularyTableSubmit).Click();
		}
	}

	internal static class AssertionExtensions
	{
		public static void ShouldContainASingleFolderNamed(this ReadOnlyCollection<IWebElement> vocabularyFolders, string folderName)
		{
			vocabularyFolders.Single().Text.Should().Be(folderName);
		}
	}
}

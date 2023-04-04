using CalculatorTestsPOM.Pages;
using NUnit.Framework;

namespace CalculatorTestsPOM.Tests
{
    //inheritance
    public class CalcNumbersPageTests : BaseTest
    {
        //private WebDriver driver;
        private CalcNumbersPage page;

        [SetUp]
        public void Setup()
        {
            //this.driver = new ChromeDriver();
            //driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            this.page = new CalcNumbersPage(driver);
            page.Open();
        }
        //[TearDown]
        //public void CloseBrowser()
        //{
        //    driver.Quit();
        //}

        [Test]
        public void Test_CheckTitle()
        {
            Assert.That(page.GetPageTitle(), Is.EqualTo("Number Calculator"));
        }
        [Test]
        public void Test_SumTwoPositiveNumbers()
        {
            var actualResult = page.CalculateNumbers("5", "+", "5");
            Assert.That(actualResult, Is.EqualTo("Result: 10"));
        }
        [Test]
        public void Test_MultiplyTwoPositiveNumbers()
        {
            var actualResult = page.CalculateNumbers("5", "*", "5");
            Assert.That(actualResult, Is.EqualTo("Result: 25"));

        }
        [TestCase("5", "*", "5", "Result: 25")]
        [TestCase("5", "+", "5", "Result: 10")]
        [TestCase("5", "-", "5", "Result: 0")]
        [TestCase("5", "/", "5", "Result: 1")]
        [TestCase("5", "%", "aaa", "Result: invalid input")]
        public void TestCalcTwoPositiveNumbers(
                     string firstValue, string operation, string secondValue, string result)
        {
            var actualResult = page.CalculateNumbers(firstValue, operation, secondValue);//3 arguments
            Assert.That(actualResult, Is.EqualTo(result));
        }

        [Test]
        public void Test_CheckResetButton()
        {
            page.CalculateNumbers("5", "+", "8");
            page.ResetForm();

            Assert.True(page.IsFormEmpty());
        }
    }
}

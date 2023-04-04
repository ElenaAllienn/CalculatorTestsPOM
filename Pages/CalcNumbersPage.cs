using OpenQA.Selenium;

namespace CalculatorTestsPOM.Pages
{
    public class CalcNumbersPage
    {
        private WebDriver driver;
        private const string baseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";

        //constructor
        public CalcNumbersPage(WebDriver driver)
        {
            this.driver = driver;
        }


        //properties
        public IWebElement Field1 => driver.FindElement(By.Id("number1"));
        //public IWebElement Filed1 { get { return driver.FindElement(By.Id("number1")); } }
        public IWebElement OperationField => driver.FindElement(By.Id("operation"));
        public IWebElement Field2 => driver.FindElement(By.Id("number2"));
        public IWebElement CalcButton => driver.FindElement(By.Id("calcButton"));
        public IWebElement ResultLabel => driver.FindElement(By.Id("result"));
        public IWebElement ResetButton => driver.FindElement(By.Id("resetButton"));


        //methods
        public void Open()
        {
            driver.Navigate().GoToUrl(baseUrl);
        }
        public string GetPageTitle()
        {
            return driver.Title;
        }
        public bool IsPageOpen()
        {
            return driver.Url == baseUrl;
        }

        public string CalculateNumbers(string firtsValue, string operation, string secondValue)
        {
            Field1.SendKeys(firtsValue);
            OperationField.SendKeys(operation);
            Field2.SendKeys(secondValue);

            CalcButton.Click();
            return ResultLabel.Text;
        }

        public bool IsFormEmpty()
        {
            bool empty = (Field1.Text == "" && Field2.Text == "");
            return empty;
        }

        public void ResetForm()
        {
            ResetButton.Click();
        }
    }
}

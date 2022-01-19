using Amazon.DynamoDBv2;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AutomationCSharpTraining
{
    class TableSortPage
    {
        private readonly IWebDriver _driver;
        //public List<IWebElement> LiTags;
        private readonly string HomeUrl = "https://demo.seleniumeasy.com/table-sort-search-demo.html";
        private readonly By _entriesDropdownLocator = By.Name("example_length");
        private readonly By _allPages = By.XPath("//span[not(@*)]/*");
        private readonly By _allRows = By.XPath("//tbody[not(@*)]/*");

        public IWebElement DropDownElement => _driver.FindElement(_entriesDropdownLocator);

        public SelectElement EntriesDropdown => new SelectElement(DropDownElement);

        public TableSortPage(IWebDriver driver)
        {
            _driver = driver;
            _driver.Url = HomeUrl;            
        }    

        public List<String> ByMinAgeMaxSalary(int minAge, int maxSalary)
        {
            
            List<Human> FullData = new List<Human>();
            //list with page tiles to find the number of pages
            List<IWebElement> PageLocators = _driver.FindElements(_allPages).ToList();
            int i;
            //iteration that surfs within pages
            try
            {
                for (i = 1; i <= PageLocators.Count(); i++)
                {
                    //list with rows elements to find the number of rows
                    List<IWebElement> RowsLocators = _driver.FindElements(_allRows).ToList();
                    //iteration that collects data => creates Human instances and put them in the list
                    int index;
                    for (index = 0; index < RowsLocators.Count(); index++)
                    {
                        var NameElement = _driver.FindElement(By.XPath("//tbody[not(@*)]/tr[" + (index + 1) + "]/td[1]"));
                        string Name = NameElement.GetAttribute("data-search"); //NameElement.Text;
                        var PositionElement = _driver.FindElement(By.XPath("//tbody[not(@*)]/tr[" + (index + 1) + "]/td[2]"));
                        string Position = PositionElement.Text;
                        var OfficeElement = _driver.FindElement(By.XPath("//tbody[not(@*)]/tr[" + (index + 1) + "]/td[3]"));
                        string Office = OfficeElement.Text;
                        var AgeElement = _driver.FindElement(By.XPath("//tbody[not(@*)]/tr[" + (index + 1) + "]/td[4]"));
                        int Age = Convert.ToInt32(AgeElement.Text);
                        var StartDateElement = _driver.FindElement(By.XPath("//tbody[not(@*)]/tr[" + (index + 1) + "]/td[5]"));
                        string StartDate = StartDateElement.GetAttribute("data-order");
                        var SalaryElement = _driver.FindElement(By.XPath("//tbody[not(@*)]/tr[" + (index + 1) + "]/td[6]"));
                        int Salary = Convert.ToInt32(SalaryElement.GetAttribute("data-order"));
                        FullData.Add(new Human(Name, Position, Office, Age, StartDate, Salary));
                    }
                    //prevents redirect to last+1 page
                    if(i == PageLocators.Count())
                    {
                        break;
                    }
                    else
                    {
                        string nextPageLocator = "//span[not(@*)]/a[" + (i + 1).ToString() + "]";
                        IWebElement PageElement = _driver.FindElement(By.XPath(nextPageLocator));
                        PageElement.Click();                        
                    }                                                          
                }
            }
            catch (NoSuchElementException){}    
            //filter Humans by age and salary
            var filterByMinAgeAndMaxSalary = FullData.Where(x => x.Age > minAge && x.Salary <= maxSalary).ToList();
            //take needed parameters, parse to strings
            List<String> ParsedToStringsList = new List<string>();
            foreach (var item in filterByMinAgeAndMaxSalary)
            {
                ParsedToStringsList.Add(new string(item.Name + ", " + item.Position + ", " + item.Office + "."));                
            }            
            return ParsedToStringsList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationCSharpTraining
{
    class Human
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Office { get; set; }
        public int Age { get; set; }
        public string StartDate { get; set; }
        public int Salary { get; set; }

        public Human (string name, string position, string office, int age, string startDate, int salary) 
        {
            Name = name;
            Position = position;
            Office = office;
            Age = age;
            StartDate = startDate;
            Salary = salary;
        }

    }
}

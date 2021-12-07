using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest
{
    abstract class Person
    {
        private string _firstName;
        private string _lastName;
        private int _SSN;
        
        public Person (string fname, string lname, int ssn)
        {
            _firstName = fname;
            _lastName = lname;
            _SSN = ssn;
        }

        public virtual string GetFullInfo()
        {
            return String.Format("First Name - {0}, Last Name - {1}, SSN - {2}", _firstName, _lastName, _SSN);
        }

    }
}

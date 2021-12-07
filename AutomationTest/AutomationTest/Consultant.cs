using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest
{
    class Consultant:Person
    {
        

        public Consultant (string fname, string lname, int ssn) : base(fname, lname, ssn)
        { }

        public override string GetFullInfo ()
        {
            return base.GetFullInfo();
        }
    }
}

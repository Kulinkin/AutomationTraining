using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest
{
    class LinkTypeEnumerator : IEnumerator
    {
        string[] types;
        int position;
        public LinkTypeEnumerator(string[] types)
        {
            this.types = types;
        }
        public object Current
        {
            get
            {
                Random rnd = new Random();
                position = rnd.Next(0, 4);
                return types[position];
            }
        }

        public bool MoveNext()
        {
            return true;
        }

        public void Reset()
        {

            throw new NotImplementedException();
        }
    }
}

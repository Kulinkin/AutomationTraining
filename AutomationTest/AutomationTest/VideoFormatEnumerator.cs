using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest
{
    class VideoFormatEnumerator : IEnumerator

    {
        string[] formats;
        int position;
        public VideoFormatEnumerator(string[] formats)
        {
            this.formats = formats;
        }
        public object Current
        {
            get
            {
                Random rnd = new Random();
                position = rnd.Next(0, 3);
                return formats[position];
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

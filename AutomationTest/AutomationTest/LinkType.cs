using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest
{
    class LinkType : IEnumerable
    {

       string[] types = { "Unknown", "Html", "Image", "Audio", "Video" };

        public IEnumerator GetEnumerator()
        {
            return new LinkTypeEnumerator(types);
        }

    }

}

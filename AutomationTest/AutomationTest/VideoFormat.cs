using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest
{
    class VideoFormat: IEnumerable
    {
        string[] formats = {"Unknown", "Avi", "Mp4", "Flv" };

        public IEnumerator GetEnumerator()
        {            
            return new VideoFormatEnumerator(formats);
        }
         
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest
{
    class Block : BuildingMaterial
    {
        private string _type;
       

        public Block(int height, int width, int length, string type):base (height,width, length)
        {
            
            _type = type;
        }

        
        public  override string ToString ()
        {
            
            return base.ToString () + String.Format("Type of block - {0}",_type);
        }

    }
}

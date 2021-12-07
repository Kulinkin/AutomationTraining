using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest
{
    class BlockItemRecord: Block
    {
        
        private int _count;
        private int _price;
       
        public BlockItemRecord(int width, int length,int height, string type, int count, int price):base (width, length, height, type)
        {
            
            _count = count;
            _price = price;
           
        }

        public bool RemoveBlockItem (int count)
        {
            if (count > _count)
                return false;

            _count -= count;
            return true;
        }

        public bool AddBlockItem ( int count)
        {
            _count += count;
            return true;
        }

        public override string ToString ()
        {
            return base.ToString() + String.Format(" Count: {0}, Price: {1}", _count, _price);

        }

    }
}

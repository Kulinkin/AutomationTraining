using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest
{
    class Plank: BuildingMaterial
    {
        private string _description;
        public string Description {
            get
            {
                return _description;
            }
            set {
                if (value.Length < 6)
                {
                    _description = value; 
                }
            }
        }
        private string _wood;
    

        public Plank (int height, int weight, int length, string description, string wood):base(height, weight, length)
        {
        _wood = wood;
        Description = description;
        }

        public string Material { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is Plank)
            {
                Plank plank = obj as Plank;
                return plank.Description == Description &&
                    plank._wood == _wood &&
                    base.Equals(obj);
            }
            return false;
        }
    

    public override string ToString ()
        {
            return base.ToString() + String.Format("Wood - {0}, Description - {1}", _wood, Description);
        }

    }
}

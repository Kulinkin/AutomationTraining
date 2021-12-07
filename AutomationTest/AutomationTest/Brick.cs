using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest
{
    class Brick : BuildingMaterial
    {
        private string _color;
        private string _description;
        public string Color { get; set; }
        public string Description { get; set; }
        public Brick(int height, int width, int length, string description, string color) : base(height, width, length)
        {
            Color = color;
            Description = description;
        }

        public override string ToString()
        {
            return base.ToString() + String.Format("Color - {0}, Description - {1}", Color, Description);
        }

        public override bool Equals(object obj)
        {
            if (obj is Brick)
            {
                Brick brick = obj as Brick;
                return brick.Description == Description &&
                    brick.Color == Color &&
                    base.Equals(obj);
            }
            return false;
        }


    }
}

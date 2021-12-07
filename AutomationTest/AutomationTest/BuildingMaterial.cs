using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest
{
    abstract class BuildingMaterial
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }

        public BuildingMaterial(int height, int width, int length)
        {
            Height = height;
            Width = width;
            Length = length;
           
        }
        public override string ToString()
        {
            return String.Format("Size - {0} x {1} x {2} ", Length, Width, Height);
        }

        public override bool Equals(object obj)
        {
            if (obj is BuildingMaterial)
            {
                BuildingMaterial material = obj as BuildingMaterial;
                return Height == material.Height &&
                    Length == material.Length &&
                    Width == material.Width;
            }
            return base.Equals(obj);
        }
    }
}

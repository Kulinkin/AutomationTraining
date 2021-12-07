using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest
{
    class TextContent:TrainingMaterial
    {
        private string _textMaterial;
        public string TextMaterial
        {
            get
            {
                return TextMaterial;
            }
            set
            {
                if (value.Length > 10000)
                {
                    _textMaterial = value.Substring(0, 10000);
                }
                else if (value.Length > 0 && value.Length < 10001)
                {
                    _textMaterial = value;
                }
                else if (String.IsNullOrEmpty(value))
                {
                    _textMaterial = "Random text for empty value";
                }
            }
        }

        public Guid TextId { get; set; }
        public string _textDescription;
        public string TextDescription
        {
            get
            {
                return _textDescription;
            }
            set
            {
                if (value.Length > 256)
                {
                    _textDescription = value.Substring(0, 256);
                }
                _textDescription = value;
            }
        }
        public TextContent(string textMaterial, string description): base(description)
        {
            TextMaterial = textMaterial;
            TextId = Guid.NewGuid();
            TextDescription = textMaterial;
        }

        public override string ToString()
        {
            return TextDescription + " " + base.ToString();
        }

        public override bool Equals(Object obj)
        {

            if (obj.AddId() == TextId)
            {
                return true;
            }
            return false;
        }
    }
}

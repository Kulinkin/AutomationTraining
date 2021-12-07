using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AutomationTest
{
    abstract class TrainingMaterial
    {
        public Guid ContentId { get; set; }
        public string _contentDescription;
        public string ContentDescription
        {
            get
            {
                return _contentDescription;
            }
            set
            {
                
                    if (value.Length > 26)
                    {
                        throw new ArgumentException();

                    }
                    else
                    {
                        _contentDescription = value;
                    }
                
                
            }
        }

        public TrainingMaterial(string description)
        {
            ContentDescription = description;
            ContentId = Guid.NewGuid();
        }

        

        public override string ToString()
        {
            return ContentDescription.ToString();
        }

        public override bool Equals(Object obj)
        {

            if (obj.AddId() == ContentId)
            {
                return true;
            }
            return false;
        }
    }
}

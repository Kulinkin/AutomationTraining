using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest
{
    class ResourceLink: TrainingMaterial
    {
        private string _contentURI;
        public string ContentURI
        {
            get
            {
                return _contentURI;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _contentURI = "content.com";
                }
                _contentURI = value;
            }
        }
        public string LinkType { get; set; }
        public string LinkToMaterial { get; set; }
        public Guid ResourceId { get; set; }
        public string _resourceDescription;
        public string ResourceDescription
        {
            get
            {
                return _resourceDescription;
            }
            set
            {
                if (value.Length > 256)
                {
                    _resourceDescription = value.Substring(0, 255);
                }
                _resourceDescription = value;
            }
        }

        public ResourceLink(string contentURI, string linkToMaterial, string description): base (description)
        {          
            
            LinkType linkType = new LinkType();
            var enumerator = linkType.GetEnumerator();
            LinkType = enumerator.Current.ToString();            
            ContentURI = contentURI;
            LinkToMaterial = linkToMaterial;
            ResourceId = Guid.NewGuid();
            ResourceDescription = string.Format("Content URI - {0}, Link - {1}, ID = {2}, Type - {3}", ContentURI, LinkToMaterial, ResourceId, LinkType);
        }
        public override string ToString()
        {
            return ResourceDescription;
        }
        public override bool Equals(Object obj)
        {

            if (obj.AddId() == ResourceId)
            {
                return true;
            }
            return false;
        }
    }
}

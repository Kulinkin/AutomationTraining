using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest
{
    class VideoContent : TrainingMaterial, IVersionable
    {
        public string _videoURI;
        public string VideoURI
        {
            get
            {
                return _videoURI;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _videoURI = "youtube.com";
                }
                _videoURI = value;
            }
        }
        public string PictureURI { get; set; }
        public string VideoFormat { get; set; }
        public Guid VideoId { get; set; }
        public string _videoDescription;
        public string VideoDescription
        {
            get
            {
                return _videoDescription;
            }
            set
            {
                try
                {
                    if (value.Length > 256)
                    {
                        throw new ArgumentException();

                    }
                    else
                    {
                        _videoDescription = value;
                    }
                }
                catch (ArgumentException aex)
                {
                    _videoDescription = value.Substring(0, 256);
                }
            }
        }

        public  VideoContent (string videoURI, string pictureURI, string description) : base(description)
        {
            VideoFormat videoFormat = new VideoFormat();            
            VideoURI = videoURI;
            PictureURI = pictureURI;
            var enumerator = videoFormat.GetEnumerator();
            VideoFormat = enumerator.Current.ToString(); 
            VideoId = Guid.NewGuid();
            VideoDescription = string.Format("Video URI - {0}, Picture URI - {1}, Video Format - {2}, ID = {3}", VideoURI, PictureURI, VideoFormat, VideoId);
            InitialVersion = new byte[] { 0, 0, 0, 0, 0, 0, 0, 1 };
            Version = InitialVersion;
        }

        public override string ToString()
        {
            return VideoDescription + " " + base.ToString();
        }
        public override bool Equals(Object obj)
        {
            try
            {
                if (obj.AddId() == VideoId)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            
        }

        byte[] InitialVersion = { 0, 0, 0, 0, 0, 0, 0, 1 };
        byte [] Version { get; set; }
        string versConstructor;
        public void GetVersion()
        {

            try
            {
                foreach (byte i in Version)
                {
                    versConstructor += i;
                }                
                Console.WriteLine(versConstructor);
                versConstructor = null;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        public void SetVersion(byte[] newVersion)
        {
            try
            {
                if (newVersion.Length == 8)
                {
                    Version = newVersion;
                    foreach (byte i in Version)
                    {
                        versConstructor += i;                        
                    }
                    versConstructor = null;
                }
                else
                {
                    Console.WriteLine("new version should be 8 digits");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}

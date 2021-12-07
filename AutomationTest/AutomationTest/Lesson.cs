using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest
{
    class Lesson: IVersionable, ICloneable
    {

        public Guid LessonId { get; set; }
        public string _lessonDescription;
        const int descrptionMaxLength = 256;
        public string LessonDescription
        {
            get
            {
                return _lessonDescription;
            }
            set
            {
                if (value.Length > descrptionMaxLength)
                {
                    _lessonDescription = value.Substring(0, descrptionMaxLength);
                }
                _lessonDescription=value;
            }
        }

        public List <TrainingMaterial> ContentList { get; set; }     
        
        public Lesson()
        {
            ContentList = new List<TrainingMaterial> ();
            LessonId = Guid.NewGuid();
            InitialVersion = new byte[] { 0, 0, 0, 0, 0, 0, 0, 1 };
            Version = InitialVersion;
            
        }
        
        public enum LessonType
        {
            VideoLesson,
            TextLesson
        }


        public string GetLessonType()
        {
            var getType = ContentList.Select(x => (x as VideoContent)).ToList();
            int i = getType.Count;
            if (i != 1)
            {
                return LessonType.VideoLesson.ToString();
            }
            return LessonType.TextLesson.ToString();
        }

        string lessonDescription;
        public override string ToString()
        {
            
            foreach (object obj in ContentList)
            {

                lessonDescription = string.Concat(lessonDescription, obj.ToString()," ");
            }

            LessonDescription = lessonDescription;
            
            return LessonDescription + "- Lesson DESCR, Lesson type - " + GetLessonType();
        }

        public override bool Equals(Object obj)
        {

            if (obj.AddId() == LessonId)
            {
                return true;
            }
            return false;
        }

        byte[] InitialVersion { get; set; }
        byte[] Version { get; set; }
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
            catch (Exception ex)
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

        public object Clone()
        {
            List<TrainingMaterial> content = new List<TrainingMaterial>(this.ContentList);
            
            return new Lesson()
            {
                ContentList = content,
                LessonId = Guid.NewGuid(),                
                Version = this.InitialVersion
            };
        }
    }
}

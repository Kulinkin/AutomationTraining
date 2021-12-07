using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomationTest
{
    class Program
    {

        /*static int[] GetReversedArray(int[] temp)
        {
            int[] Reversed = new int[temp.Length];
            int index;
            for (index = 0; index < temp.Length; index++)
            {
                Reversed[(index - (temp.Length - 1)) * -1] = temp[index];
            }
            return Reversed;
        }
        static int GetMinValueFromArrays(int[] temp1, int[] temp2)
        {

            int[] CompositeArray = new int[temp1.Length + temp2.Length];
            int counter;

            for (counter = 0; counter < CompositeArray.Length; counter++)
            {
                if (counter <= temp1.Length - 1)
                {
                    CompositeArray[counter] = temp1[counter];
                }
                else
                {
                    CompositeArray[counter] = temp2[counter - temp1.Length];
                }
            }

            int MinValueFromArray = CompositeArray[0];

            for (counter = 1; counter < CompositeArray.Length; counter++)
            {
                if (MinValueFromArray > CompositeArray[counter])
                {
                    MinValueFromArray = CompositeArray[counter];
                }
            }
            return MinValueFromArray;
        }

        //delegate bool IsSatisfy(BuildingMaterial material);
        //Func, Action

        static List<BuildingMaterial> GetListByCondition(List<BuildingMaterial> inputList, Func<BuildingMaterial, bool> condition)
        {
            var outputMaterials = new List<BuildingMaterial>();

            foreach (var item in inputList)
            {
                if (condition(item))
                {
                    outputMaterials.Add(item);
                }

            }
            return outputMaterials;
        }*/


        static void Main(string[] args)
        {
            /*int[] Array1 = {10, -6, 5, -10, 6, 2, -99};
            int[] Array2 = {100, -1, 55, -101};

            //Console.WriteLine(GetMinValueFromArrays(Array1, Array2));
            int[] Reversed = GetReversedArray(Array1);
            foreach (int index in Reversed)
            {
                Console.WriteLine(index);
            }*/


            /*var block1 = new Block(200, 200, 500, "Gazosilikat");
            Block block2 = new Block(250, 300, 600, "Concrete");
            Block block3 = new Block(400, 400, 750, "Silicat");

            BlockItemRecord blockItem1 = new BlockItemRecord(200, 200, 500, "Gazosilikat", 1000, 200);
            BlockItemRecord blockItem2 = new BlockItemRecord(200, 200, 500, "Gazosilikat", 1500, 220);

            var brick1 = new Brick(100, 100, 200, "Red", "description for red brick");
            var brick2 = new Brick(150, 150, 300, "White", "description for white brick");
            Brick brick3 = new Brick(50, 50, 150, "Yellow", "description for yellow brick");
            Brick brick4 = new Brick(50, 100, 300, "red", "broken");
            Brick brick5 = new Brick(50, 50, 150, "Yellow", "description for yellow brick");
            var brick6 = new Brick(150, 150, 200, "White", "description for white brick");

            var plank1 = new Plank(30, 100, 1000, "Pine", "description for Pine plank");
            Plank plank2 = new Plank(40, 200, 1500, "Oak", "description for Oak plank");
            Plank plank3 = new Plank(50, 300, 2000, "Wood", "description for Wood plank");

            Seller seller1 = new Seller("Anna", "Anina", 123123123);

            Consultant consultant1 = new Consultant("Anton", "Antonov", 234234234);

            Cashier cashier1 = new Cashier("Pavel", "Pavlov", 234234234);

            Manager manager1 = new Manager("Egor", "Letov", 234234234);

            Person[] employees = { seller1, consultant1, cashier1, manager1 };

            /*foreach (BuildingMaterial item in materials)
            {
                string outputInfo = item.GetFullInfo();
                if (item is Brick)
                {
                    outputInfo = (item as Brick).GetFullInfo();
                }

                else if (item is Plank)
                {
                    outputInfo = (item as Plank).GetFullInfo();
                }
                Console.WriteLine(outputInfo);
            }*/
            VideoContent videoForLesson1 = null;
            try
            {
                videoForLesson1 = new VideoContent("https://www.youtube.com/watch?v=IwNQP1JA3gw", "https://i.ytimg.com/vi/IwNQP1JA3gw/hq720.jpg?sqp=-oaymwEcCNAFEJQDSFXyq4qpAw4IARUAAIhCGAFwAcABBg==&rs=AOn4CLBPCOiYGY54ieHGnqA7DtLDyHUEMA", ", description from base Class: ");
            }
            catch
            {
                Console.WriteLine("error");
            }
            var videoForLesson2 = new VideoContent("https://www.youtube.com/watch?v=mTJEKTMOPxI", "https://i.ytimg.com/vi/mTJEKTMOPxI/hq720.jpg?sqp=-oaymwEcCNAFEJQDSFXyq4qpAw4IARUAAIhCGAFwAcABBg==&rs=AOn4CLBGc2ySdHGjWtSfKdWjiE6uAE3rVQ", ", description from base Class: ");
            
            var textForLesson1 = new TextContent("short text for lesson 1, ", "description from base class: ");
            var textForLesson2 = new TextContent("short text for lesson 2", "");

            var linkForLesson1 = new ResourceLink("ContentURI.com/home/content/lesson1", "link to material1","");
            var linkForLesson2 = new ResourceLink("ContentURI.com/home/content/lesson2", "link to material2",", base description");

            TrainingMaterial[] contentForLesson1 = { videoForLesson1, textForLesson1 };
            try
            {
                //videoForLesson1.ContentDescription = "123sdvf123sdvf123sdvf123sdvf123sdvf123sdvf123sdvf123sdvf123sdvf123sdvf123sdvf123sdvf123sdvf123sdvf123sdvf123sdvf123sdvf123sdvf123sdvf123sdvf123sdvf123sdvf123sdvf123sdvf123sdvf123sdvf123sdvf123sdvf123sdvf123sdvf123sdvf123sdvf123sdvf";
            }
            catch
            {
                //videoForLesson1.ContentDescription = "no content";
            }
            Lesson lesson1 = new Lesson();
            var lesson2 = new Lesson();
            lesson1.ContentList.AddRange(contentForLesson1);
            lesson2.ContentList.Add(textForLesson2);
            lesson2.ContentList.Add(linkForLesson2); 

            string getTypeOfLesson1 = lesson1.GetLessonType();
            string getTypeOfLesson2 = lesson2.GetLessonType();

            bool lessonComparer = lesson1.Equals(lesson2);

            byte[] version1 = { 1, 2, 3, 1, 2, 3, 1, 2 };
            byte[] version2 = { 2, 2, 2, 2, 2, 2, 2, 2 };

            videoForLesson1.SetVersion(version1);
            videoForLesson1.GetVersion();
            videoForLesson2.GetVersion();
            lesson1.GetVersion();

            Lesson lessonClone = (Lesson)lesson1.Clone();
            lessonClone.SetVersion(version2);
            Console.WriteLine("\n");

            lessonClone.GetVersion();
            lesson1.GetVersion();
            Console.WriteLine("\n");
            
            lessonClone.ContentList.Add(videoForLesson2);
            videoForLesson2.GetVersion();
            Console.WriteLine("\n");

            Console.WriteLine(lessonClone.ToString());
            bool copiedLessonsComparer2 = lesson1.Equals(lesson2);
            Console.WriteLine("\n");

            lesson2.ToString();





            /*var materialsList = new List<BuildingMaterial>();

            BuildingMaterial[] materials = { block1, block2, block3, blockItem1, blockItem2, brick1, brick2, brick3, brick6, plank1, plank2, plank3 };
            materialsList.AddRange(materials);
            materialsList.Add(new Brick(50, 100, 300, "red", "broken"));

            bool result = brick3.Equals(brick5);
            bool result1 = materialsList.Contains(brick3);*/

            /*List <BuildingMaterial> exactLengthList = GetListByCondition (materialsList, 
                delegate (BuildingMaterial material) 
                {
                return material.Height > 10;
                });== next string*/
            /*var resultList  = GetListByCondition(materialsList,
                material => material.Height > 10);
            var exactLengthList = GetListByCondition(materialsList, x => x.Length == 2);


            var changeType = materialsList.Transform(x => x.ToString());

            //LINQ
            var searchResults = materialsList.Where(x => x.Height > 10).ToList();
            var searchResult = materialsList.Contains(new Brick (10, 2, 40, "Red", "Broken"));
            var searchResult1 = materialsList.Select(x => (x as Brick)?.Description ).Where (x => x == "White").ToList();
            var searchResult2 = materialsList.Count(x => x.Height > 40);

            var personsList = new List<Person>();
            personsList.AddRange(employees);



            foreach (Person item in employees)
            {
                string outputInfo = item.GetFullInfo();
                Console.WriteLine(outputInfo + ", " + item.GetType().Name);
            }*/
            /*

            
            BlockItemRecord blockItem1 = new BlockItemRecord(block1, 1000, 200);
            BlockItemRecord blockItem2 = new BlockItemRecord(block2, 1500, 220);
            
            Block[] blocks = { block1, block2 };
            BlockItemRecord[] blocksDB = { blockItem1, blockItem2 };

            blocksDB[1].RemoveBlockItem(2);
            blocksDB[1].AddBlockItem(22);

            /*foreach (Block block in blocks)
            {
                Console.WriteLine(block.GetFullInfo());
              
            }
            foreach (BlockItemRecord item in blocksDB)
            {
                Console.WriteLine(item.GetBlockItemInfo());
            }
            */
        }
    }
}

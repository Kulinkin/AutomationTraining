using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest
{
    static class Helper
    {
        public static Guid NewId { get; private set; }

        public static bool IsContainsDigit(this string str)
        {
            return str.Contains('1') || str.Contains('2');
        }

        public static List<TResult> Transform <T,TResult> (this List <T> data, Func <T,TResult> transform)
        {
            List<TResult> newList = new List<TResult>();
            foreach (var item in data)
            {
                newList.Add(transform(item));
            }
            return newList;
        }

        public static Guid AddId (this Object obj)
        {
            return NewId = Guid.NewGuid();
        }        
    }
}

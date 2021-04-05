using System;
using System.Collections.Generic;

namespace TestSortedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var cities = new Dictionary<int, string>(){
            {0, "London, Manchester, Birmingham"},
            {1, "Chicago, New York, Washington"},
            {2, "Mumbai, New Delhi, Pune"}
            };
            cities[1] = "Boston";
            foreach (var item in cities)
            {
                Console.WriteLine(item.Key + ", ", item.Value);
            }
        }
    }
}

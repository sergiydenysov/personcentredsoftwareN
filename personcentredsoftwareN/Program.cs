using System;
using System.Collections.Generic;
using System.Linq;

namespace personcentredsoftwareN
{
    class Program
    {
        static void Main(string[] args)
        {
            //AS I am doing this excersise from memory I am asyming that in the string "4:2" 
            //4 represennts amount og Gas on this station
            //and 2 is represents amount of gas needed to get to this station from prevous station

            string[] stringArray = {"4:0", "2:1", "3:2", "5:12", "3:1"};
            int inputArrayLength = stringArray.Length;
            // lets create a dictuanary where index fill be index of station in stringArray and second number will be represended by diffrence beween amount of gas on prev station and amount of gas needed to this station 
            var dict = GeneralHelper.GetDictionaryFromArray(stringArray);

            // finding potential station that we may not reach
            var indexes = dict.Where(x => x.Value < 0).Select(x => x.Key).ToList();

            var indexesOfStationsThatCircularJorneyCanFinish = new List<int>();
            
            //cheking each jorney where we may run out of gas
            foreach (var index in indexes)
            {
                indexesOfStationsThatCircularJorneyCanFinish.AddRange(GeneralHelper.CheckCircularJorneyForIndex(index, dict));
            }

            var uniqueStaions = indexesOfStationsThatCircularJorneyCanFinish.Distinct();
            Console.WriteLine("Indexes of the staion that you can start jorney to finish full circle " + String.Join(", ", uniqueStaions.ToArray()));
        }

      
    }
}

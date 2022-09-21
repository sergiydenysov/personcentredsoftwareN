using System;
using System.Collections.Generic;
using System.Text;

namespace personcentredsoftwareN
{
    public class GeneralHelper
    {
        public static int GetPrevIndex(int currentIndex, int listLength)
        {
            var prevIndex = currentIndex == 0 ? listLength - 1 : currentIndex - 1;
            return prevIndex;
        }

        public static Dictionary<int, int> GetDictionaryFromArray(string[] stringArray)
        {
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < stringArray.Length; i++)
            {
                var indexofThisStation = i;
                var indexOfPrevStaion = GetPrevIndex(i, stringArray.Length);

                var thisStation = stringArray[indexofThisStation];
                var prevStaion = stringArray[indexOfPrevStaion];

                var thisStationSplit = thisStation.Split(":");
                var prevStationSplit = prevStaion.Split(":");

                var difrence = Int32.Parse(thisStationSplit[0]) - Int32.Parse(prevStationSplit[1]);

                dict.Add(indexofThisStation, difrence);
            }

            return dict;
        }

        public static List<int> CheckCircularJorneyForIndex(int index, Dictionary<int, int> dict)
        {
            var listOfItemsThatCanPass = new List<int>();
            var prevIndex = GetPrevIndex(index, dict.Count);
            var amountOfGas = dict[index];
            
            for (int i = 0; i < dict.Count; i++)
            {
                amountOfGas += dict[prevIndex];
                if (amountOfGas > 0)
                {
                    listOfItemsThatCanPass.Add(prevIndex);
                }
                prevIndex = GetPrevIndex(prevIndex, dict.Count);
            }

            return listOfItemsThatCanPass;
        }
    }
}

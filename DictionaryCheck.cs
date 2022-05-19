using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace WordRandomizerUI
{
    public class DictionaryCheck
    {
        /// <summary>
        /// Compares the given string against a plaintext English Dictionary line by line, returns either null for nothing found, or the given word if it is found.
        /// </summary>
        /// <param name="engWordDic"></param>
        /// <returns></returns>
        public string EngDictionary(string engWordDic)
        {
            string[] engDic; //Make the array
            //string folderLoc = Assembly.GetExecutingAssembly().Location;
            string folderLoc = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(folderLoc, "EnglishDic.txt");
            engDic = File.ReadAllLines(filePath);
            int dicLength = engDic.Count();
            string correctWord = "";

            for (int i = 0; i <= dicLength;)
            {
                if (i == dicLength)
                {
                    engWordDic = "";
                    return engWordDic;
                }
                if (engWordDic == engDic[i])
                {
                    correctWord = engDic[i];
                    //i = dicLength;

                    engWordDic = correctWord;
                    return engWordDic;
                }
                //else if (i == dicLength)
                //{
                //    return "";
                //}
                else
                {
                    i++;
                }
            }

            engWordDic = correctWord;
            return engWordDic;
        }
    }
}

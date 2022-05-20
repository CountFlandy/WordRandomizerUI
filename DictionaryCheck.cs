using System;
using System.Linq;
using System.IO;

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
                    engWordDic = correctWord;
                    return engWordDic;
                }
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

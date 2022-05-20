using System;
using System.IO;

namespace WordRandomizerUI
{
    public class GetExecutableLocation
    {
        /// <summary>
        /// Finds the location of the executable, for the purposes of making a text file
        /// </summary>
        /// <returns></returns>
        public string ExecutableLocation()
        {
            string executableLoc = "";
            executableLoc = AppDomain.CurrentDomain.BaseDirectory;
            if (File.Exists(executableLoc))
            {
                File.Delete(executableLoc);
            }
            return executableLoc; 
        }
    }
}

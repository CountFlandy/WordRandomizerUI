using System;
using System.IO;
using System.Reflection;

//TODO: Test to see if works

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
            //executableLoc = Assembly.GetExecutingAssembly().Location;
            executableLoc = AppDomain.CurrentDomain.BaseDirectory;
            if (File.Exists(executableLoc))
            {
                File.Delete(executableLoc);
            }
            //StreamWriter writeFile = new StreamWriter(executableLoc + ".txt");

            return executableLoc; 
        }

    }
}

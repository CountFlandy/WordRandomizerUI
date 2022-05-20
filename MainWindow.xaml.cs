using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//TODO:
//
// Improve write to file loop

namespace WordRandomizerUI
{
    /// <summary>
    ///// Interaction logic for MainWindow.xaml
    ///// </summary>
    ///

    public partial class MainWindow : Window
    {
        bool RealWordsCheck = false;
        string getExeLoc = "";
        GetExecutableLocation getex = new();
        int minWordLength = 3;
        int wordLength = 0;
        int realWordCount = 0;
        int fakeWordCount = 0;
        string userWord = "";
        bool generatedOnce = false;
        DictionaryCheck dicCheck = new();
        List<String> shuffleWordList = new();
        List<String> compareList = new();
        List<String> realWordList = new();
        List<String> fakeWordList = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Returns all variables back to their starting values
        /// </summary>
        public void Cleanup()
        {
            userWord = "";
            wordLength = 0;
            realWordCount = 0;
            fakeWordCount = 0;
            minWordLength = 3;
            RealWordsCheck = false;
            TextBoxOutputFakeWords.Text = "";
            TextBoxOutputRealWords.Text = "";
            LabelLocation.Content = "";
            RadioYes.IsEnabled = true;
            RadioNo.IsEnabled = true;
            TextBoxUserInput.IsEnabled = true;
            TextBoxUserInput.Text = "";
            LabelProgress.Content = "Waiting for user input";
            LabelLocation.Content = "";
            LabelRealWords.Content = "Real Words:";
            LabelFakeWords.Content = "Fake Words:";
            generatedOnce = false;

            realWordList.Clear();
            fakeWordList.Clear();
            compareList.Clear();
        }

        public async void WordGen(string userWord)
        {
            try
            {
                await Task.Run(() =>
                {
                    List<String> wordCharList = new(); //basically a char string
                    int wordLength = userWord.Length; //Get length of word above
                    int timer = 0;
                    bool suddenlyBreak = false;
                    int wL = wordLength;
                    int mWL = minWordLength;
                    int maxPassesEqu = ((userWord.Length - mWL + 1) * userWord.Length * 26);
                    string compareString = "";
                    Random rnd = new();

                    compareList.Add(userWord); //To be done in MainWindow.xaml.cs
                    int k = (rnd.Next(0, 100));

                    for (int i = 0; i <= maxPassesEqu;)
                    {
                        if (wordCharList.Count != wordLength)
                        {
                            wordCharList.Clear();
                            for (int e = 0; e < wordLength; e++) //Add the user generated word to the list
                            {
                                wordCharList.Add(userWord.Substring(e, 1));
                            }
                        }
                        for (int q = 0; q < 1;) //This part finds the "words"
                        {
                            if (wordCharList.Count != wordLength)
                            {
                                wordCharList.Clear();
                                for (int e = 0; e < wordLength; e++) //Add the user generated word to the list
                                {
                                    wordCharList.Add(userWord.Substring(e, 1));
                                }
                            }
                            wL = wordLength;
                            mWL = minWordLength;
                            timer++;
                            if (timer > maxPassesEqu)
                        { //just in case my math is wrong this is a safeway to abort it.
                            suddenlyBreak = true;
                            i = maxPassesEqu + 1;
                            q = 2;
                        }

                            while (wL > 1)
                            {
                                k = (rnd.Next(0, wL));
                                wL--;
                                string value = wordCharList[k];
                                wordCharList[k] = wordCharList[wL];
                                wordCharList[wL] = value;
                            }
                            wL = wordLength;
                            int r = rnd.Next(mWL, wL);
                            while (wL > r)
                            {
                                if (wordCharList.Count < mWL)
                                {
                                    q = 2;
                                    suddenlyBreak = true;
                                }
                                else
                                {
                                    wordCharList.RemoveAt(r);
                                    wL--;
                                }
                            }
                            if (!compareList.Contains(wordCharList.ToString()))
                            {
                                q++;
                            }
                        }
                        //Keep checking the generated word against the dictionary in WordGeneration.cs
                        if (suddenlyBreak == false)
                        {
                            //Creates a string that is used when compared against compareWordList
                            foreach (var item in wordCharList)
                            {
                                compareString += item;
                            }

                            if (compareString.Length <= wordLength && compareString.Length >= minWordLength && !compareList.Contains(compareString))
                            {
                                string dupeWord = "";
                                dupeWord = compareString;
                                DictionaryCheck localDict = new();
                                dupeWord = localDict.EngDictionary(dupeWord);

                                if (dupeWord == compareString)
                                {
                                    realWordList.Add(compareString);
                                    this.Dispatcher.Invoke(() =>
                                    {
                                        TextBoxOutputRealWords.AppendText(compareString + "\n");
                                        LabelRealWords.Content = "Real Words(" + realWordCount + "):";
                                    });
                                    realWordCount++;
                                }
                                else
                                {
                                    fakeWordList.Add(compareString);
                                    this.Dispatcher.Invoke(() =>
                                    {
                                        TextBoxOutputFakeWords.AppendText(compareString + "\n");
                                        LabelFakeWords.Content = "Fake Words (" + fakeWordCount + "):";
                                    });
                                    fakeWordCount++;
                                }
                                //Add the string that passed the above comparision to the list so that it may no longer be taken.
                                compareList.Add(compareString);
                                i++;
                            }
                            compareString = "";
                        }
                    }
                });
            }
            catch(Exception ex)
            { 
            
            }

            LabelProgress.Content = "Lists Generated. See below.";
            LabelFakeWords.Content = "Fake Words (" + fakeWordCount + "):";
            LabelRealWords.Content = "Real Words(" + realWordCount + "):";
            generatedOnce = true;
            RadioYes.IsEnabled = true;
            RadioNo.IsEnabled = true;
            TextBoxUserInput.IsEnabled = true;
            ButtonStart.IsEnabled = true;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            LabelLocation.Content = "";
            LabelProgress.Content = "Waiting for user input";
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            if (generatedOnce == true)
            {
                Cleanup();
            }
            LabelProgress.Content = "Generating word lists, please wait";
            LabelLocation.Content = ""; //Change this to root directory
            userWord = TextBoxUserInput.Text;

            //Do stuff below

            if(RadioYes.IsChecked == true)
            {               
                getExeLoc = getex.ExecutableLocation();
            }
            else if(RadioYes.IsChecked == false && RadioNo.IsChecked == false)
            {
                RadioNo.IsChecked = true;
            }
            if (userWord.Length < 5)
            {
                LabelProgress.Content = "Error: Given word is smaller than 5. Try again.";
            }
            else
            {
                TextBoxOutputFakeWords.Text = "";
                TextBoxOutputRealWords.Text = "";
                RadioYes.IsEnabled = false;
                RadioNo.IsEnabled = false;
                TextBoxUserInput.IsEnabled = false;
                ButtonStart.IsEnabled = false;

                LabelProgress.Content = "Generating word lists, please wait";
                wordLength = userWord.Length;

                string loc = getex.ExecutableLocation();
                if (File.Exists(userWord + ".txt"))
                {
                    File.Delete(userWord + ".txt");
                }
                StreamWriter writeFile = new StreamWriter(userWord + ".txt");
                LabelLocation.Content = loc + userWord + ".txt";

                //Runs on different thread than UI
                WordGen(userWord);

                //TODO: could be improved
                foreach(var item in compareList)
                {
                    writeFile.WriteLine(item.ToString());
                }
            }
        }

        private void RadioYes_Checked(object sender, RoutedEventArgs e)
        {
            RealWordsCheck = true;
            RadioNo.IsChecked = false;
        }

        private void RadioNo_Checked(object sender, RoutedEventArgs e)
        {
            RealWordsCheck = false;
            RadioYes.IsChecked = false;
        }
    }
}

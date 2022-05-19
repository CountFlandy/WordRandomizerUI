# WordRandomizer
WHAT IT DOES:


Enter in ANY word of any length (preferably larger than 2 letters, otherwise results are boring) and it will spit out every possible word that can be made 
from the letters of your inputted word. Currently it only keeps the length the same, so it won't output a 3 letter word if you give it a 9 letter word.

WHY THOUGH?:


Because this was originally a student program I made my first year of university. I completly rewrote the way that it generates the randomized words
as well as adding an option to filter out duplicates. I wanted something simple to improve as opposed to my grand ideas that I don't have time for, 
and I found this on my hard drive.

CAN IT BE IMPROVED?:


Yes.

1: Textfile outputs could be actually organized, you know for sanity's sake.

2: I'm sure my algorithims are bad. My math is possibly wrong. Not good at math, so double check it if you suspect something is off..

3: Fix the freeze on pressing of the generate button (I assume this is because I'm doing all the calculations on some sort of UI thread?)

4: Improve the write to file loop somehow

5: Generate button can be clicked twice if the user is quick enough, causing the list to disapear and Cleanup() to be engaged. Could be fixed/improved to prevent this.

6: Better UI elements could be added

7: An actual Icon could be included, will get to that eventually.

8: Word itteration process could likely be improved to take advantage of multiple threads, though I have zero idea how to do that.


If you find any bugs please report them under issues, I'll try to get to them as I'm able to.




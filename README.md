# Word-Analyzer-Threads-Version
Homework PU BIT2

This is a console program that reads a book and parses the words in it. The analyzes are the following 6:
1. The number of words
2. The shortest word
3. The longest word
4. Average word length
5. Five most common words
6. Five least common words

Code Explanation:
First, we save in a string variable the path to the book file that was downloaded as plain text. We check if file found or not. If the file is not found, a message is displayed and the program is closed. If everything is fine with the file, we move on.
We read the file as a string, then remove the empty lines using a regular expression. We split the string into a clean array that contains only the words from the text. All words smaller than 3 characters are not counted as words. We clear these words using foreach and write the already filtered words to List.

We make 6 methods for different analyses.
As the last two are more complex and there we use Dictionary to keep word frequency. And then in a new List we record the five results we are interested in (5 most frequently used and 5 least used).
We make 6 threads, each of which accepts one of the six methods.
We start the threads where the methods are executed and return result directly to the console because the methods are void.


BONUS: I add the basic version of the program. Enjoy!

using System.Text.RegularExpressions;

namespace WordAnalyzerThreadVersion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "Douglas-Kennedy_-_Ubijstven_biznes_-_6415-b.txt"; //Path to the file
            string[] data = { };
            Console.WriteLine("Reading File.....");

            if (File.Exists(file))
            {
                string readedFile = File.ReadAllText(file);
                string resultString = Regex.Replace(readedFile, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);
                data = resultString.Split(new char[] { ' ', ',', '.', '!', '?', '-', ';', '/', ':', '„', '“', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                Console.WriteLine("File is not found. Try to edit the path of the file");
                Environment.Exit(1);
            }

            List<string> validWords = new List<string>();
            foreach (string word in data)
            {
                if (word.Length >= 3)
                {
                    validWords.Add(word);
                }
            }

            Thread numberOfWordsThread = new Thread(() => NumberOfWords(validWords));
            Thread shortesWordThread = new Thread(() => ShortestWord(validWords));
            Thread longestWordThread = new Thread(() => LongestWord(validWords));
            Thread averageWordLengthThread = new Thread(() => AverageWordLength(validWords));
            Thread mostCommonWordsThread = new Thread(() => MostCommonWords(validWords, 5));
            Thread leastCommonWordsThread = new Thread(() => LeastCommonWords(validWords, 5));

            numberOfWordsThread.Start();
            shortesWordThread.Start();
            longestWordThread.Start();
            averageWordLengthThread.Start();
            mostCommonWordsThread.Start();
            mostCommonWordsThread.Join();
            leastCommonWordsThread.Start();
        }
        static void NumberOfWords(List<string> data)
        {
            int numberOfWords = 0;
            foreach (string word in data)
            {
                numberOfWords++;
            }
            Console.WriteLine("Number of words: " + numberOfWords);
        }
        static void ShortestWord(List<string> data)
        {
            string shortestWord = data[0];

            foreach (string word in data)
            {
                if (word.Length >= 3)
                {
                    if (shortestWord.Length > word.Length)
                    {
                        shortestWord = word;
                    }
                }
            }
            Console.WriteLine("Shortest word: " + shortestWord);
        }
        static void LongestWord(List<string> data)
        {
            string longestWord = data[0];

            foreach (string word in data)
            {
                if (word.Length >= 3)
                {
                    if (longestWord.Length < word.Length)
                    {
                        longestWord = word;
                    }
                }
            }
            Console.WriteLine("Longest word: " + longestWord);
        }
        static void AverageWordLength(List<string> data)
        {
            double averageWordLength = 0;
            int divisor = 0;
            foreach (string word in data)
            {
                averageWordLength += word.Length;
                divisor++;

            }
            Console.WriteLine("Average word length: " + Math.Round(averageWordLength / divisor, 2));
        }
        static void MostCommonWords(List<string> words, int count)
        {
            Dictionary<string, int> wordFrequency = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (wordFrequency.ContainsKey(word))
                {
                    wordFrequency[word]++;
                }
                else
                {
                    wordFrequency[word] = 1;
                }
            }

            List<KeyValuePair<string, int>> mostCommonWords = new List<KeyValuePair<string, int>>();
            foreach (var item in wordFrequency)
            {
                mostCommonWords.Add(item);
            }
            mostCommonWords.Sort((a, b) => b.Value.CompareTo(a.Value));
            mostCommonWords = mostCommonWords.GetRange(0, Math.Min(count, mostCommonWords.Count));
            Console.WriteLine("Five most common words:");
            foreach (var item in mostCommonWords)
            {
                Console.WriteLine($"{item.Key}: {item.Value} times");
            }
        }
        static void LeastCommonWords(List<string> words, int count)
        {
            Dictionary<string, int> wordFrequency = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (wordFrequency.ContainsKey(word))
                {
                    wordFrequency[word]++;
                }
                else
                {
                    wordFrequency[word] = 1;
                }
            }

            List<KeyValuePair<string, int>> leastCommonWords = new List<KeyValuePair<string, int>>();
            foreach (var item in wordFrequency)
            {
                leastCommonWords.Add(item);
            }
            leastCommonWords.Sort((a, b) => a.Value.CompareTo(b.Value));
            leastCommonWords = leastCommonWords.GetRange(0, Math.Min(count, leastCommonWords.Count));
            Console.WriteLine("Five least common words:");
            foreach (var item in leastCommonWords)
            {
                Console.WriteLine($"{item.Key}: {item.Value} times");
            }
        }
    }
}

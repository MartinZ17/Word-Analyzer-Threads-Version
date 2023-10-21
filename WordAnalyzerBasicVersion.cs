using System;
using System.IO;
using System.Text.RegularExpressions;

namespace WordAnalyzer
{
    internal class WordAnalyzerBasicVersion
    {
      

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the path to the book you want to analyze");
            Console.WriteLine("Example: C:\\Users\\user\\Desktop\\ПУ\\C# TBL\\Homework1\\WordAnalyzer\\TestFile.txt");
            string file = Console.ReadLine();

            string[] data = { };

            Console.WriteLine();
            Console.WriteLine("Reading File.....");

            if (File.Exists(file))
            {
                Console.WriteLine("Reading complete");
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
            Console.WriteLine();

            NumberOfWords(validWords);
            ShortestWord(validWords);
            LongestWord(validWords);
            AverageWordLenght(validWords);
            MostCommonWords(validWords, 5);
            LeastCommonWords(validWords, 5);

        }
        public static void NumberOfWords(List<string> data)
        {
            int numberOfWords = 0;
            foreach(string word in data) 
            {
                numberOfWords++;
            }
            Console.WriteLine("Number of words: " + numberOfWords);
        }
        public static void ShortestWord(List<string> data)
        {
            string shortestWord = data[0];

            foreach(string word in data)
            {
                if(word.Length >= 3)
                {
                    if(shortestWord.Length > word.Length)
                    {
                        shortestWord = word;
                    }
                }
            }
            Console.WriteLine("Shortest Word: " + shortestWord);

        }
        public static void LongestWord(List<string> data)
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
            Console.WriteLine("Longest Word: " + longestWord);
        }
        public static void AverageWordLenght(List<string> data)
        {
            double averageWordLenght = 0;
            int divisor = 0;
            foreach (string word in data)
            {
                 averageWordLenght += word.Length;
                 divisor++;
             
            }
            Console.WriteLine("Average Word Lenght: " + Math.Round(averageWordLenght / divisor, 2));
        }
        public static void MostCommonWords(List<string> words, int count)
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
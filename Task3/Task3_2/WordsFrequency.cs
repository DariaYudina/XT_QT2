using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_2
{
    class WordsFrequency
    {
        private Dictionary<string, int> words;

        public Dictionary<string, int> Words
        {
            get { return words; }
        }
        public WordsFrequency(string text)
        {
            text = text.ToLower();
            char[] splitters = new char[] { '.', ' ' };
            string[] arrWords = text.Split(splitters, StringSplitOptions.RemoveEmptyEntries);
            words = new Dictionary<string, int>();
            foreach (string word in arrWords)
            {
                if (words.ContainsKey(word))
                {
                    words[word]++;
                }
                else
                {
                    words[word] = 1;
                }
            }
        }
        public void printWordsFrequency()
        {
            foreach (KeyValuePair<string, int> keyValue in words)
                {
                    Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }
        }
        public int GetCountOfWords()
        {
            int totalWord = 0;
            foreach (var word in words)
            {
                totalWord += word.Value;
            }
            return totalWord;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Basic string manipulation exercises
    /// </summary>
    public class StringTests : ITest
    {
        public void Run()
        {
            // TODO:
            // Complete the methods below

            AnagramTest();
            GetUniqueCharsAndCount();
        }

        private void AnagramTest()
        {
            var word = "stop";
            var possibleAnagrams = new string[] { "test", "tops", "spin", "post", "mist", "step" };
                
            foreach (var possibleAnagram in possibleAnagrams)
            {
                Console.WriteLine(string.Format("{0} > {1}: {2}", word, possibleAnagram, possibleAnagram.IsAnagram(word)));
            }
            Console.WriteLine(new String('x', 40));
        }

        private void GetUniqueCharsAndCount()
        {
            var word = "xxzwxzyzzyxwxzyxyzyxzyxzyzyxzzz";

            // TODO:
            // Write an algoritm that gets the unique characters of the word below 
            // and counts the number of occurences for each character found
            Dictionary<char, int> CharCounts =  word.GroupBy(x => x).ToDictionary(gr => gr.Key, gr => gr.Count());
            foreach(var chrcnt in CharCounts)
            {
                Console.WriteLine("Char(" + chrcnt.Key + ") is repeated " + chrcnt.Value + " times");
            }
            Console.WriteLine(new String('x', 40));
        }
    }

    public static class StringExtensions
    {
        public static bool IsAnagram(this string a, string b)
        {
            // TODO: 
            // Write logic to determine whether a is an anagram of b
            return String.Concat(a.OrderBy(c => c)).Equals(String.Concat(b.OrderBy(c => c)));
            //return false;
        }
    }
}

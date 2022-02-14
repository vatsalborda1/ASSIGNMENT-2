﻿/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace ISM6225_Assignment_2_Spring_2022
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is {0}:", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
        }


        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                //Write your Code here.
                int min = 0;
                int max = nums.Length - 1;
                while (min <= max)
                {
                    if (min == max & target < nums[min])
                    {
                        return min;
                    }


                    else if (min == max & target > nums[min])
                    {
                        return (min + 1);
                    }
                    
                    
                    
                    int mid = (min + max) / 2;
                    if (target == nums[mid])
                    {
                        return mid;
                    }


                    else if (target < nums[mid])
                    {
                        max = mid - 1;
                    }


                    else
                    {
                        min = mid + 1;
                    }


                }
                return -1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         
        Question 2
       
        Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned. It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        The words in paragraph are case-insensitive and the answer should be returned in lowercase.
        Example 1:
        Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
        Output: "ball"
        Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
        Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), and that "hit" isn't the answer even though it occurs more because it is banned.
        Example 2:
        Input: paragraph = "a.", banned = []
        Output: "a"
        */

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {

                //write your code here.
                
               
                String permittedchars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz !?',;.";
                if (paragraph.Length < 1 || paragraph.Length > 1000)
                {
                    throw new Exception("String length should be between 1 and 1000");
                }
                foreach (char c in paragraph)
                {
                    if (!permittedchars.Contains(c.ToString()))
                        throw new Exception("String contains unacceptable characters");
                }
                if (banned.Length < 1 || banned.Length > 100)
                {
                    throw new Exception("banned array length is invalid");
                }
                foreach (string s in banned)
                {
                    if (s.Length < 1 || s.Length > 10)
                    {
                        throw new Exception("banned string length is invalid");
                    }
                }
                
                string[] words = paragraph.ToLower().Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
                

                Dictionary<string, int> RepeatedWordCount = new Dictionary<string, int>();
                

                for (int i = 0; i < words.Length; i++)   
                {
                    if (RepeatedWordCount.ContainsKey(words[i]))   
                    {
                        int value = RepeatedWordCount[words[i]];
                        RepeatedWordCount[words[i]] = value + 1;
                    }
                    else
                    {
                        RepeatedWordCount.Add(words[i], 1);     
                    }
                }
                
                Dictionary<string, int> sortedDict = new Dictionary<string, int>(from entry in RepeatedWordCount orderby entry.Value descending select entry);

                foreach (KeyValuePair<string, int> kvp in sortedDict)
                {
                    if (banned.Contains(kvp.Key)) 
                    {
                        continue;
                    }
                    else
                    {
                        return kvp.Key; 
                    }
                }

                return "";
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.
        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.
        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        public static int FindLucky(int[] arr)
        {
            try
            {
                //write your code here.
                
                if (arr.Length < 1 || arr.Length > 500)
                {
                    throw new Exception("array length is not in specified range of 1 and 500");
                }
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] < 1 || arr[i] > 500)
                    {
                        throw new Exception("element is not in specified range of 1 and 500");

                    }
                }
               
                Dictionary<int, int> RepeatedWordCount = new Dictionary<int, int>();
                
                for (int i = 0; i < arr.Length; i++) 
                {
                    if (RepeatedWordCount.ContainsKey(arr[i]))   
                    {
                        int val = RepeatedWordCount[arr[i]];
                        RepeatedWordCount[arr[i]] = val + 1;
                    }
                    else
                    {
                        RepeatedWordCount.Add(arr[i], 1);     
                    }
                }

                
                Dictionary<int, int> sortedDict = new Dictionary<int, int>(from entry in RepeatedWordCount orderby entry.Value descending select entry);

                foreach (KeyValuePair<int, int> kvp in sortedDict)
                {
                    if (kvp.Key == kvp.Value) 
                    {
                        return kvp.Key;
                    }

                }
                return 0;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
          |
        "7810"
        */

        public static string GetHint(string secret, string guess)
        {
            try
            {
                //write your code here.
                string allowablechars = "1234567890";
                if (secret.Length < 1 || secret.Length > 1000)
                {
                    throw new Exception("Length of secret should be between 1 and 1000");
                }
                if (guess.Length < 1 || guess.Length > 1000)
                {
                    throw new Exception("Length of guess should be between 1 and 1000");
                }
                if (guess.Length != secret.Length)
                {
                    throw new Exception("Length of guess and secret should be the same");
                }
                foreach (char c in secret)
                {
                    if (!allowablechars.Contains(c.ToString()))
                        throw new Exception("secret contains unacceptable characters");
                }
                foreach (char c in guess)
                {
                    if (!allowablechars.Contains(c.ToString()))
                        throw new Exception("guess contains unacceptable characters");
                }
                
                int bullcount = 0;
                int cowcount = 0;
                int count = 0;

                for (int i = 0; i < secret.Length; i++)
                {
                    count = 0;
                    for (int j = 0; j < guess.Length; j++)
                    {
                        if (secret[i] == guess[j] & i != j)
                        {
                            cowcount++;
                            count++;
                        }
                        if (secret[i] == guess[j] & i == j)
                        {
                            bullcount++;
                            break;
                        }
                        if (count > 1)
                        {
                            cowcount--;
                        }
                    }
                }
                return bullcount + "A" + cowcount + "B";
            }
            catch (Exception)
            {

                throw;
            }
        }


        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.
        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.
        */

        public static List<int> PartitionLabels(string s)
        {
            try
            {
                int[] last = new int[26];
                for (int i = 0; i < s.Length; ++i)
                    last[s.ElementAt(i) - 'a'] = i;

                int j = 0, anchor = 0;
                List<int> ans = new List<int>();
                for (int i = 0; i < s.Length; ++i)
                {
                    j = Math.Max(j, last[s.ElementAt(i) - 'a']);
                    if (i == j)
                    {
                        ans.Add(i - anchor + 1);
                        anchor = i + 1;
                    }
                }
                return ans;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6
        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.
         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa"
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.
         */

        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                //write your code here.

                if (widths.Length != 26)
                {
                    throw new Exception("Please enter correct 26 widths");
                }
                for (int i = 0; i < widths.Length; ++i)
                {
                    if (widths[i] < 2 || widths[i] > 10)
                    {
                        throw new Exception("widths length should be between 2 and 10");
                    }
                }
                if (s.Length < 1 || s.Length > 1000)
                {
                    throw new Exception("s length should be between 1 and 1000");
                }

                foreach (char c in s)
                {
                    if (Char.IsUpper(c))
                    {
                        throw new Exception("Only lowercase allowed in s");
                    }
                }
                
                String alph = "abcdefghijklmnopqrstuvwxyz";
                char[] alph_char = alph.ToCharArray();
                List<int> ans = new List<int>();
                int count = 0;
                int line_count = 1;
                int pos;
                foreach (char c in s)
                {
                    pos = alph.IndexOf(c);
                    if (count + widths[pos] <= 100)
                    {
                        count = count + widths[pos];
                    }

                    else
                    {
                        count = 0;
                        count = count + widths[pos];
                        line_count++;
                    }
                }
                ans.Add(line_count);
                ans.Add(count);
                return ans;
            }
            catch (Exception)
            {
                throw;
            }

        }


        /*
        
        Question 7:
        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true
        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true
        Example 3:
        Input: bulls_string  = "(]"
        Output: false
        */

        public static bool IsValid(string bulls_string10)
        {
            try
            {
                if (bulls_string10.Length < 1 || bulls_string10.Length > 10000)
                {
                    throw new Exception("bulls_string length should be between 1 and 10000");
                }
                foreach (char c in bulls_string10)
                {
                    if (c == '(' || c == ')' || c == '[' || c == ']' || c == '{' || c == '}')
                    {

                    }
                    else
                    {
                        throw new Exception("only (){}[] allowed");
                    }
                }
                
                Stack<char> AcceptableSymbols = new Stack<char>();
                foreach (char c in bulls_string10)
                {
                    if (c == '(' || c == '{' || c == '[')
                    {
                        AcceptableSymbols.Push(c);
                    }
                    else if (c == ')' & AcceptableSymbols.Count != 0 & AcceptableSymbols.Peek() == '(')
                                                                                                       
                    {
                        AcceptableSymbols.Pop();
                    }
                    else if (c == '}' & AcceptableSymbols.Count != 0 & AcceptableSymbols.Peek() == '{')
                    {
                        AcceptableSymbols.Pop();
                    }
                    else if (c == ']' & AcceptableSymbols.Count != 0 & AcceptableSymbols.Peek() == '[')
                    {
                        AcceptableSymbols.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }

                return AcceptableSymbols.Count == 0; ;
            }
            catch (Exception)
            {
                throw;
            }


        }



        /*
         Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.
        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
            •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
        Return the number of different transformations among all words we have.
 
        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".
        */

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                //write your code here.
                if (words.Length < 1 || words.Length > 100)
                {
                    throw new Exception("words length should be between 1 and 100");
                }
                foreach (string s in words)
                {
                    if (s.Length < 1 || s.Length > 12)
                    {
                        throw new Exception("length of individual word  should be between 1 and 12");
                    }
                    foreach (char c in s)
                    {
                        if (Char.IsUpper(c))
                        {
                            throw new Exception("only lower case allowed");
                        }
                    }
                }

                
                String[] morse = new String[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
                String albts = "abcdefghijklmnopqrstuvwxyz";
                List<string> list = new List<string>();
                String st = "";
                int loc;
                foreach (string str in words)
                {
                    foreach (char ch in str)
                    {
                        loc = albts.IndexOf(ch);
                        st = st + morse[loc];
                    }
                    list.Add(st);
                    st = "";
                }


                var distinct_morse_conv = list.Distinct().ToArray();
                return distinct_morse_conv.Length;
            }
            catch (Exception)
            {
                throw;
            }

        }




        /*
        
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time. Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).
        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.
        */

        public static int SwimInWater(int[,] grid)
        {
            try
            {
                //write your code here.
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
         
        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:
        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.
        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')
        */

        public static int MinDistance(string word1, string word2)
        {
            try
            {
                //write your code here.
                
                int rows = word1.Length + 1;
                int colms = word2.Length + 1;

                
                if (rows == 0)
                {
                    return colms;
                }
                else if (colms == 0)
                {
                    return rows;
                }

                
                int[,] dist = new int[rows + 1, colms + 1];
                for (int row = 0; row < rows; ++row)
                {
                    for (int i = 0; i < colms; ++i)
                    {
                        
                        if (row == 0)
                        {
                            dist[row, i] = i;
                        }
                        else if (i == 0)
                        {
                            dist[row, i] = row;
                        }
                        
                        else
                        {
                            
                            if (word1.ElementAt(row - 1) == word2.ElementAt(i - 1))
                            {
                                dist[row, i] = dist[row - 1, i - 1];
                            }
                            
                            else
                            {
                                dist[row, i] = Int32.MaxValue;                                
                                dist[row, i] = Math.Min(dist[row, i], dist[row - 1, i - 1] + 1);                                
                                dist[row, i] = Math.Min(dist[row, i], dist[row - 1, i] + 1);                                
                                dist[row, i] = Math.Min(dist[row, i], dist[row, i - 1] + 1);
                            }
                        }
                    }
                }

                return dist[rows - 1, colms - 1];


                

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

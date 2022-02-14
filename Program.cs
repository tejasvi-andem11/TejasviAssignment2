/*
 * Name: Andem Tejasvi Reddy
 * Date: 02/09/2022
 * Description: Solution for questions in Assignment 2
 * Self Reflection: I have taken around 30 hours to finish the assignment. With this assignment I got the opportunity to explore the usage of different datastructures in C# such as dictionaries, arraylists,etc.
*/


using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace TejasviAssignment2
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
                int mid = 0;
                int max = nums.Length - 1;
                int output = -1;
                while (min <= max)
                {
                    mid = (min + max) / 2; //fetch the middle number index
                    if (target == nums[mid]) //checking if the value matches the middle number
                    {
                        return mid;
                    }
                    if (target < nums[mid]) //if target is less than the middle number, the iterate to fetch the index where the target fits
                    {
                        max = mid - 1;
                        output = mid;
                    }
                    else
                    {
                        min = mid + 1;
                        output = mid + 1;
                    }
                }
                return output;
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
                paragraph = paragraph.ToLower(); //convert the input to lower
                //replace the special characters with spaces
                paragraph = paragraph.Replace(',', ' ');
                paragraph = paragraph.Replace('.', ' ');
                paragraph = paragraph.Replace('\'', ' ');
                paragraph = paragraph.Replace('!', ' ');
                paragraph = paragraph.Replace('?', ' ');
                paragraph = paragraph.Replace(';', ' ');
                //trim the extra spaces in the input
                paragraph = paragraph.Trim();
                //split the input paragraph
                string[] inputSplit = paragraph.Split(' ');
                int inputSplitLength = inputSplit.Length;
                //create dictionary to store the words are keys and their count as values
                IDictionary<string, int> countDict = new Dictionary<string, int>();
                for(int i=0; i<inputSplitLength; i++)
                {
                    if (countDict.ContainsKey(inputSplit[i]))
                    {
                        countDict[inputSplit[i]]++; //increment the values for keys if the words are repeated
                    }
                    else
                    {
                        countDict.Add(inputSplit[i], 1); //if the key is not present in the dictionary, then add the key to the dictionary
                    }
                    for (int j=0; j<banned.Length; j++)
                    {
                        if (inputSplit[i] == banned[j]) 
                        {
                            countDict.Remove(inputSplit[i]); //remove the banned words from the dictionary
                        }
                    }
                }
                int maxDict = 0;
                string maxKey = "";
                foreach (KeyValuePair<string, int> kvp in countDict)
                {
                    if (maxDict < kvp.Value) //fetch the key with maximum count from the dictionary
                    {
                        maxDict = kvp.Value;
                        maxKey = kvp.Key;
                    }
                }
                    return maxKey;
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
                //create a dictionary to store the numbers as keys and their counts as values
                IDictionary<int, int> countDict = new Dictionary<int, int>();
                for(int i=0; i<arr.Length; i++)
                {
                    if (countDict.ContainsKey(arr[i]))
                    {
                        countDict[arr[i]]++; //if the number is already present in the dictionary, increment the count value when the number is repeated
                    }
                    else
                    {
                        countDict.Add(arr[i], 1); //add the numbers to the dictionary with default count 1
                    }
                }
                int maxKey = 0;
                foreach (KeyValuePair<int, int> kvp in countDict)
                {
                    if (kvp.Key == kvp.Value) //if the key matches the value, check for the maximum key and return it
                    {
                        if (maxKey < kvp.Key)
                        {
                            maxKey = kvp.Key;
                        }
                    }
                }
                return maxKey;
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
                int count = 0; //number of bulls
                int sum = 0; //number of cows
                string secretString = "";
                string guessedString = "";
                for (int i = 0; i < guess.Length; i++)
                {
                    if (secret[i] == guess[i])
                    {
                        // increment the count if the guess matches
                        count = count + 1;
                    }
                    else
                    {
                        // adding the elements to the resultant string
                        secretString = secretString + secret[i];
                        guessedString = guessedString + guess[i];
                    }
                }
                foreach (char c in secretString) //loop over the secret string to check how many matches are made
                {
                    int flag = 0;
                    for (int i = 0; i < guessedString.Length; i++)
                    {
                        if (guessedString[i] == c && flag == 0)
                        {
                            sum = sum + 1; //increment the cows count if the condition is satisfied
                            guessedString = guessedString.Remove(i, 1);
                            flag = 1;
                        }
                    }
                }
                string output = count.ToString() + "A" + sum.ToString() + "B";
                return output;
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
                //write your code here.
                int len = s.Length;
                int n = 0; //overall loop count
                List<int> output = new List<int>(); //output list
                while (n < len) //looping the input string
                {
                    int l2 = s.LastIndexOf(s[n]); //storing the last occurrence of the character
                    char x = s[n];
                    for (int i = 0; i <= l2; i++)
                    {
                        char y = s[i];
                        if (y != x)
                        {
                            if (s.LastIndexOf(y) > l2)
                            {
                                l2 = s.LastIndexOf(y); //updating the index to the character after the first substring
                            }
                        }
                        n = i + 1; //storing index of last value in "n" which will be used to fetch the next character after this loop ends
                    }
                    int diff = n - output.Sum(); //getting the difference between the current a value and string length
                    output.Add(diff); //adding the length of the substring to output list
                }
                return output;
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
                int len1 = widths.Length;
                int len2 = s.Length;
                Dictionary<char, int> lookupDict = new Dictionary<char, int>();
                for (int i = 0; i < len1; i++) //adding the keys to the dictionary
                {
                    int temp = i + 97;
                    char c = Convert.ToChar(temp);
                    lookupDict.Add(c, widths[i]);
                }
                int sum = 0;
                int count = 0;
                for (int i = 0; i < len2; i++)
                {
                    int temp = lookupDict[s[i]];
                    if (sum + temp > 100)
                    {
                        sum = temp;
                        count = count + 1;
                    }
                    else if (sum + temp == 100 & i != (len2 - 1))
                    {
                        sum = 0;
                        count = count + 1;
                    }
                    else if (sum + temp == 100 & i == (len2 - 1))
                    {
                        sum = sum + temp;
                        count = count + 1;
                    }
                    else
                    {
                        sum = sum + temp;
                    }
                }
                if (sum < 100) //increment the count if the line is 100 pixels
                {
                    count = count + 1;
                }
                List<int> output = new List<int>(); //output list
                output.Add(count);
                output.Add(sum);
                return output;
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
                //write your code here.
                int len = bulls_string10.Length;
                ArrayList check = new ArrayList();
                Dictionary<string, string> lookupDict = new Dictionary<string, string>(); //dictionary to store the left and right brackets as keys and values
                lookupDict.Add("}", "{");
                lookupDict.Add("]", "[");
                lookupDict.Add(")", "(");
                int size = -1; //variable for the size of arraylist
                for (int i = 0; i < len; i++)
                {
                    string str = bulls_string10[i].ToString();
                    if (lookupDict.ContainsValue(str)) //Check if the character is present in the lookup dictionary
                    {
                        check.Add(str); //add the character to the arraylist
                        size = size + 1;
                    }
                    else if (lookupDict.ContainsKey(str) & size != -1)
                    {
                        if (lookupDict[str] == check[size].ToString())
                        {
                            check.RemoveAt(size); //remove the character at that index from arraylist
                            size = size - 1;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (size == -1)
                    {
                        return false;
                    }
                }
                if (size != -1)
                {
                    return false;
                }
                return true;
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
                string[] arr = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." }; //array showing the morse code of the alphabets
                int len1 = words.Length; //total input length
                string[] outputString = new string[len1];
                for (int i = 0; i < len1; i++) //loop all the words
                {
                    string word = words[i];
                    int len2 = word.Length; //each word length
                    string morseWord = "";
                    for (int j = 0; j < len2; j++) //loop all the characters in the word
                    {
                        int index = word[j] - 97;
                        morseWord = morseWord + arr[index];
                    }
                    outputString[i] = morseWord; //morse combination
                }
                int count = outputString.Distinct().Count(); //count of distinct combinations
                return count;
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
                return 0;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

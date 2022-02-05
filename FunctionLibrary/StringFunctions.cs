using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLibrary
{
    public class StringFunctions
    {
        public string LongestPalindromeBrute(string s)
        {
            if (s.Length == 1)
                return s;
            int maxLength = 1;
            string maxSubsPal = s[0].ToString();
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j < s.Length; j++)
                {
                    string subs = s.Substring(i, s.Length - j);
                    bool palindrome = true;
                    int first = 0, last = subs.Length - 1;

                    while (first <= last)
                    {
                        if (subs[first] != subs[last])
                        {
                            palindrome = false;
                            break;
                        }
                        first++;
                        last--;
                    }
                    if (palindrome && subs.Length > maxLength)
                    {
                        maxSubsPal = subs;
                        maxLength = subs.Length;
                    }
                }
            }
            return maxSubsPal;
        }
        public string LongestPalindrome(string s)
        {
            int n = s.Length;
            if (n == 1)
                return s;

            //start and end index
            bool[,] isPalindrome = new bool[n, n];
            //fill for ones
            int maxLength = 1;
            int start = 0;

            for (int i = 0; i < n; i++)
            {
                isPalindrome[i, i] = true;
            }
            //fill for twos
            for (int i = 0; i < n - 1; i++)
            {
                if (s[i] == s[i + 1])
                {
                    isPalindrome[i, i + 1] = true;
                    maxLength = 2;
                    start = i;
                }
            }
            //check for rest
            //k will have number of characters = length
            for (int k = 3; k <= n; k++)
            {
                //i is indexing
                for (int i = 0; i < n - k + 1; i++)
                {
                    //calculate end index
                    int end = i + k - 1;
                    if (s[i] == s[end] && isPalindrome[i + 1, end - 1])
                    {
                        isPalindrome[i, end] = true;
                        if (k > maxLength)
                        {
                            maxLength = k;
                            start = i;
                        }
                    }
                }
            }
            return s.Substring(start, maxLength);
        }

        public string PrintZigZagBAD(string s, int numRows)
        {
            if (numRows == 1)
                return s;
            char[,] arr = new char[numRows, s.Length / 2 + 1];
            int charIndexer = 0;
            int rowIndexer = 0;
            int colIndexer = 0;
            bool goZigZag = false;
            char ch = '\0';

            while (charIndexer < s.Length)
            {
                arr[rowIndexer, colIndexer] = s[charIndexer];
                rowIndexer++;
                if (rowIndexer == numRows)
                {
                    rowIndexer--;
                    while (rowIndexer > 0 && charIndexer < s.Length - 1)
                    {
                        rowIndexer--;
                        colIndexer++;
                        charIndexer++;
                        arr[rowIndexer, colIndexer] = s[charIndexer];
                    }
                    rowIndexer++;
                }
                charIndexer++;
            }

            string str = "";
            //return as is
            //for (int i = 0; i < arr.GetLength(0); i++)
            //{
            //    for (int j = 0; j < arr.GetLength(1); j++)
            //    {
            //        if (arr[i, j] != '\0')
            //            str = str + arr[i, j];
            //        else
            //            str = str + " ";
            //    }
            //    if (i != numRows - 1)
            //        str = str + "\n";
            //}
            //read by line
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] != '\0')
                        str = str + arr[i, j];
                }
            }
            return str;
        }

        public string PrintZigZag(string s, int numRows)
        {
            if (numRows == 1)
                return s;
            string[] stringsInEachRow = new string[numRows];
            for (int i = 0; i < numRows; i++)
            {
                stringsInEachRow[i] = string.Empty;
            }
            int row = 0;
            bool goDown = true;

            for (int i = 0; i < s.Length; i++)
            {
                stringsInEachRow[row] += s[i];

                if (row == 0)
                    goDown = true;
                if (row == numRows - 1)
                    goDown = false;

                if (goDown)
                    row++;
                else
                    row--;
            }

            string str = "";
            foreach (string rowString in stringsInEachRow)
            {
                str = str + rowString;
            }
            return str;
        }

        //public bool isMatch(string s, string p)
        //{
        //    if (p.Length == 0)
        //        return s.Length == 0;

        //    if (p.Length > 1 && p[1] == '*')
        //    {
        //        if (isMatch(s, p.Substring(2))) // consider zero number of c as existing cause of c* and see if it is true
        //            return true;
        //        if (s.Length > 0 && (s[0] == p[0] || p[0] == '.'))
        //            return isMatch(s.Substring(1), p); //consider many number of c as exisitng cause of c* and if this is not true then bad luck
        //        return false;
        //    }
        //    else
        //    {
        //        if (s.Length > 0 && (s[0] == p[0] || p[0] == '.'))
        //            return isMatch(s.Substring(1), p.Substring(1));
        //        return false;
        //    }
        //}

        public bool isMatch(string s, string p)
        {
            //bool?[,] cache = new bool?[s.Length+1, p.Length+1];

            Dictionary<KeyValuePair<int, int>, bool> cache = new System.Collections.Generic.Dictionary<KeyValuePair<int, int>, bool>();
            return topDownDFS(s, p, 0, 0, cache);
        }

        //public bool topDownDFS(string s, string p, int i,int j, bool?[,] cache)
        //{
        //    if (cache[i, j].HasValue)
        //        return cache[i, j].GetValueOrDefault();

        //    if (i >= s.Length && j >= p.Length)
        //        return true;
        //    if (j >= p.Length)
        //        return false;

        //    bool match = i < s.Length && (s[i] == p[j] || p[j] == '.');

        //    if (j + 1 < p.Length && p[j + 1] == '*') //if we have star
        //    {
        //        cache[i,j] = topDownDFS(s, p, i, j + 2,cache) || //don't use star
        //              (match && topDownDFS(s, p, i + 1, j, cache)); //use one character then recursively call
        //        return cache[i, j].GetValueOrDefault();
        //    }
        //    if (match) //if no star
        //    { 
        //        cache[i,j] = topDownDFS(s, p, i + 1, j + 1, cache);
        //        return cache[i, j].GetValueOrDefault();
        //    }

        //    return false;
        //}
        public bool topDownDFS(string s, string p, int i, int j, Dictionary<KeyValuePair<int, int>, bool> cache)
        {
            var ij = new KeyValuePair<int, int>(i, j);
            if (cache.ContainsKey(ij))
                return cache[ij];

            if (i >= s.Length && j >= p.Length)
                return true;
            if (j >= p.Length)
                return false;

            bool match = i < s.Length && (s[i] == p[j] || p[j] == '.');

            if (j + 1 < p.Length && p[j + 1] == '*') //if we have star
            {
                cache[ij] = topDownDFS(s, p, i, j + 2, cache) || //don't use star
                      (match && topDownDFS(s, p, i + 1, j, cache)); //use one character then recursively call
                return cache[ij];
            }
            if (match) //if no star
            {
                cache[ij] = topDownDFS(s, p, i + 1, j + 1, cache);
                return cache[ij];
            }

            return false;
        }

        public string LargestCommonPrefix(string[] strs)
        {
            int minLength = int.MaxValue;
            int minIndex = 0;
            for (int i = 0; i < strs.Length; i++)
            {
                if (strs[i].Length < minLength)
                {
                    minLength = strs[i].Length;
                    minIndex = i;
                }
            }
            string prefix = "";
            for (int i = 0; i < minLength; i++)
            {
                bool flag = true;
                for (int j = 0; j < strs.Length; j++)
                {
                    if (strs[j][i] != strs[minIndex][i])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    prefix = prefix + strs[minIndex][i];
                }
                else
                    break;
            }
            return prefix;
        }

        public IList<string> LetterCombinations(string digits)
        {
            if (digits.Length == 0)
                return new List<string>();
            return CombineRecursive(digits, 0);
        }

        private List<string> CombineRecursive(string s, int index)
        {
            char ch = s[index];
            var list = LettersForDigitUsingChar(ch);
            if (index == s.Length - 1)
                return list;

            var strs = CombineRecursive(s, index + 1);
            List<string> listToreturn = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                string currentChar = list[i];
                foreach (var str in strs)
                {
                    listToreturn.Add(currentChar + str);
                }
            }
            return listToreturn;
        }
        private List<string> LettersForDigitUsingChar(int ch)
        {
            switch (ch)
            {
                case '2':
                    return new List<string> { "a", "b", "c" };
                case '3':
                    return new List<string> { "d", "e", "f" };
                case '4':
                    return new List<string> { "g", "h", "i" };
                case '5':
                    return new List<string> { "j", "k", "l" };
                case '6':
                    return new List<string> { "m", "n", "o" };
                case '7':
                    return new List<string> { "p", "q", "r", "s" };
                case '8':
                    return new List<string> { "t", "u", "v" };
                case '9':
                    return new List<string> { "w", "x", "y", "z" };
                default:
                    break;
            }
            return null;
        }
        private List<string> LettersForDigit(int ch)
        {
            switch (ch)
            {
                case 2:
                    return new List<string> { "a", "b", "c" };
                case 3:
                    return new List<string> { "d", "e", "f" };
                case 4:
                    return new List<string> { "g", "h", "i" };
                case 5:
                    return new List<string> { "j", "k", "l" };
                case 6:
                    return new List<string> { "m", "n", "o" };
                case 7:
                    return new List<string> { "p", "q", "r", "s" };
                case 8:
                    return new List<string> { "t", "u", "v" };
                case 9:
                    return new List<string> { "w", "x", "y", "z" };
                default:
                    break;
            }
            return null;
        }

        public IList<string> GenerateParanthesis(int n)
        {
            if (n == 1)
                return new string[] { "()" };
            List<string> list = new List<string>();
            Stack<string> stack = new Stack<string>();
            GetParanthesisCombination(n,list,stack);
            return list;
        }
        private void GetParanthesisCombination(int n, List<string> list, Stack<string> stack, int open=0, int close=0)
        {
            if (open == n && close == n) // we have balanced the brackets
                list.Add(string.Join("",stack.Reverse()));
            if(open < n)
            {
                stack.Push("(");
                GetParanthesisCombination(n, list, stack, open + 1, close);
                stack.Pop();
            }
            if(close < open)
            {
                stack.Push(")");
                GetParanthesisCombination(n, list, stack, open, close + 1);
                stack.Pop();
            }
        }

        public int StrStr(string haystack, string needle)
        {
            if (needle.Length > haystack.Length)
                return -1;
            if (string.IsNullOrEmpty(needle))
                return 0;

            for (int i = 0; i < haystack.Length; i++)
            {
                if(needle[0] == haystack[i])
                {
                    int possibleStart = i;
                    if (CheckValidity(needle, haystack, i+1))
                        return possibleStart;
                }
            }
            return -1;
        }

        private bool CheckValidity(string needle, string haystack, int index)
        {
            int needleIndex = 1;

            while(needleIndex < needle.Length && index < haystack.Length)
            {
                if (needle[needleIndex] == haystack[index])
                {
                    needleIndex++;
                    index++;
                }
                else
                    return false;
            }
            if (index == haystack.Length && needleIndex != needle.Length)
                return false;
            return true;
        }

        public string CountAndSay(int n)
        {
            if (n == 1)
                return "1";
            return CountSay("1", n, 1);
    }

        private string CountSay(string str, int n, int c)
        {
            if (c == n)
                return str;
            string s = "";

            for (int index = 0; index < str.Length; index++)
            {
                char ch = str[index];
                int count = 0;
                while (index < str.Length && ch == str[index])
                {
                    count++;
                    index++;
                }
                if (count > 0)
                    s += count.ToString() + ch.ToString();
                if (index == str.Length)
                    break;
                else
                    index--;
            }
            return CountSay(s, n, c + 1);
        }

        public bool IsMatch2(string s, string p)
        {
            if (s.Length > 0 && p.Length == 0)
                return false;
            if (s.Length == 0 && p.Length == 0)
                return true;
            if(s.Length == 0)
            {
                pOnlyHasStars(0, p);
            }

            bool?[,] cache = new bool?[s.Length+1, p.Length+1];

            return FindWildCard(s, p, 0, 0, cache);
        }

        public bool FindWildCard(string s, string p, int i, int j, bool?[,] cache)
        {
            if (cache[i, j].HasValue)
                return cache[i, j].GetValueOrDefault();
            if (j == p.Length)
            {
                cache[i,j] = i == s.Length;
                return cache[i, j].GetValueOrDefault();
            }

            if (i == s.Length)
            {
                cache[i,j] = j == p.Length || pOnlyHasStars(j, p);
                return cache[i, j].GetValueOrDefault();
            }
                

            //Console.WriteLine($"Comparing {s.Substring(i,s.Length-i)} with {p.Substring(j,p.Length-j)}");

            if (p[j] == '*')
            {
                cache[i,j] = FindWildCard(s, p, i + 1, j, cache) || FindWildCard(s, p, i, j + 1, cache);
                return cache[i, j].GetValueOrDefault();
            }
                

            if (s[i] == p[j] || p[j] == '?')
            {
                cache[i,j] = FindWildCard(s, p, i + 1, j + 1, cache);
                return cache[i, j].GetValueOrDefault();
            }
            return false;
        }

        private bool pOnlyHasStars(int j, string p)
        {
            for (int i = j; i < p.Length; i++)
            {
                if (p[i] != '*')
                    return false;
            }
            return true;
        }

        public IList<IList<string>> GroupAnagramsss(string[] strs)
        {
            int n = strs.Length;
            bool[] grouped = new bool[n];

            List<List<string>> allGroups = new List<List<string>>();
            for (int i = 0; i < n; i++)
            {
                string current = strs[i];
                List<string> currentGroup = new List<string>();
                for (int j = 0; j < n; j++)
                {
                    if (grouped[j])
                        continue;
                    if (CompareStrings(current, strs[j]))
                    {
                        currentGroup.Add(strs[j]);
                        grouped[j] = true;
                    }
                }
                if (currentGroup.Count > 0)
                    allGroups.Add(currentGroup);
            }

            return allGroups.ToArray();

        }


        private bool CompareStrings(string s1, string s2)
        {
            if (s1 == s2)
                return true;
            if (s1.Length != s2.Length)
                return false;
            for (int i = 0; i < s1.Length; i++)
            {
                char ch = s1[i];
                if (!s2.Contains(ch))
                    return false;
                if (s2.Count(x => x.Equals(ch)) != s1.Count(x => x.Equals(ch)))
                    return false;
            }
            return true;
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            List<IList<string>> groups = new List<IList<string>>();

            if (strs == null || strs.Length == 0)
                return groups;

            int n = strs.Length;

            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            for (int i = 0; i < n; i++)
            {
                var charArray = strs[i].ToCharArray();
                Array.Sort(charArray);
                string key = new string(charArray);

                if (dictionary.ContainsKey(key))
                    dictionary[key].Add(strs[i]);
                else
                    dictionary.Add(key, new List<string>() { strs[i] });
            }
            foreach (var key in dictionary.Keys)
            {
                groups.Add(dictionary[key]);
            }
            return groups;
        }

        public string MinWindow(string s, string t)
        {
            if (t == "")
                return "";
            int conditionsMet = 0;
            
            Dictionary<char, int> charCountT = new Dictionary<char, int>();
            for (int i = 0; i < t.Length; i++)
            {
                char ch = t[i];
                if (charCountT.ContainsKey(ch))
                    charCountT[ch]++;
                else
                    charCountT.Add(ch, 1);
            }

            int conditionsNeeded = charCountT.Keys.Count;
            Dictionary<char, int> charCountS = new Dictionary<char, int>();

            int start = -1;
            int end = -1;
            int left = 0;
            int resLen = int.MaxValue;
            for (int right = 0; right < s.Length; right++)
            {
                char ch = s[right];
                //add all characters to map
                if (charCountS.ContainsKey(ch))
                    charCountS[ch]++;
                else
                    charCountS.Add(ch, 1);

                if (charCountT.ContainsKey(ch) && charCountT[ch] == charCountS[ch])
                {
                    conditionsMet++;
                }

                //if conditions are met then loop to remove extra characters
                while(conditionsMet == conditionsNeeded)
                {
                    if(right-left+1 < resLen)
                    {
                        start = left;
                        end = right;
                        resLen = right - left + 1;
                    }

                    //now shrink our string
                    charCountS[s[left]] -= 1;
                    //check if the character we removed affected our conditions
                    if (charCountT.ContainsKey(s[left]) && charCountS[s[left]] < charCountT[s[left]])
                        conditionsMet -= 1;
                    //shift our left pointer
                    left++;
                }
            }

            return resLen < int.MaxValue ? s.Substring(start, resLen) : "";

        }

        public int NumDecodings(string s)
        {
            int[] cache = new int[s.Length+1];
            cache[s.Length] = 1;
            //return Decode(s);
            DecodeWithDP(s, cache);
            return cache[0];
        }

        private int Decode(string s, int index=0)
        {
            if (index == s.Length)
                return 1;

            if (s[index] == '0')
                return 0;
            //take one
            int one = Decode(s, index + 1);
            int two = 0;
            //take two
            if (index + 1 < s.Length && int.Parse(s.Substring(index, 2)) <= 26)
                two = Decode(s, index + 2);
            return one + two;
        }

        private void DecodeWithDP(string s, int[] cache)
        {
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '0')
                    cache[i] = 0;
                else
                {

                    cache[i] = cache[i + 1]; //take one
                    if (i + 1 < s.Length && (s[i] == '1' || (s[i] == '2' && s[i+1] <= 54)))  //take two
                        cache[i] += cache[i + 2];
                }
            }
        }

        //public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        //{
        //    int index = wordList.IndexOf(endWord);
        //    if (index == -1)
        //        return 0;

        //    int count = 0;
        //    for (int i = 0; i < beginWord.Length; i++)
        //    {
        //        if (beginWord[i] != endWord[i])
        //            count++;
        //    }

        //    if (count >= wordList.Count)
        //        return 0;

        //    int ind = wordList.IndexOf(beginWord);
        //    if (ind > -1)
        //        return wordList.Count - ind -1;
        //    List<string> combinations = new List<string>();
        //    for (int i = 0; i < beginWord.Length; i++)
        //    {
        //        for (char c = 'a'; c <= 'z'; c++)
        //        {
        //            string str = beginWord.Substring(0, beginWord.Length - i - 1) + c.ToString() + beginWord.Substring(beginWord.Length - i);
        //            combinations.Add(str);
        //        }
        //    }

        //    int min = int.MaxValue;
        //    foreach (var comb in combinations)
        //    {
        //        index = wordList.IndexOf(comb);
        //        if (index > -1)
        //            min = Math.Min(wordList.Count - index -1, min);
        //    }

        //    return min;
        //}

        private static int min = int.MaxValue;
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            int count = 0;
            for (int i = 0; i < beginWord.Length; i++)
            {
                if (beginWord[i] != endWord[i])
                    count++;
            }

            if (count >= wordList.Count)
                return 0;

            var res = FindEnd(beginWord, endWord, wordList, new List<string> { beginWord });
            if (res == 0)
                return 0;

            return res + 1;
        }

        private int FindEnd(string beginWord, string endWord, IList<string> wordList, List<string> remove)
        {
            if (wordList.IndexOf(endWord) < 0)
                return 0;
            var combinations = CreateCombinations(beginWord);

            if (combinations.Contains(endWord))
                return 1;

            int min = int.MaxValue;
            foreach (var comb in combinations)
            {
                if (wordList.IndexOf(comb) > -1 && !remove.Contains(comb))
                {
                    remove.Add(comb);
                    int res = FindEnd(comb, endWord, wordList, remove);
                    if (res == 0)
                        res = 0;
                    else
                    {
                        res = res + 1;
                        min = Math.Min(res, min);
                    }
                }
            }
            return min == int.MaxValue? 0: min;
        }

        private List<string> CreateCombinations(string s)
        {
            List<string> combinations = new List<string>();
            for (int i = 0; i < s.Length; i++)
            {
                for (char c = 'a'; c <= 'z'; c++)
                {
                    string str = s.Substring(0, s.Length - i - 1) + c.ToString() + s.Substring(s.Length - i);
                    combinations.Add(str);
                }
            }
            return combinations;
        }

        public IList<IList<string>> Partition(string s)
        {
            List<IList<string>> list = new List<IList<string>>();
            GetPartitions(s,0,list);
            return list;
        }

        private void GetPartitions(string s, int index, List<IList<string>> list, List<string> l=null)
        {
            if (index >= s.Length)
            {
                var arr = new string[l.Count];
                l.CopyTo(arr);
                list.Add(arr);
                return;
            }

            if (l == null)
                l = new List<string>();

            for (int i = index; i < s.Length; i++)
            {
                var str = s.Substring(index, i - index + 1);
                if(IsPalindrome(s,index,i))
                {
                    l.Add(str);
                    GetPartitions(s, i + 1, list, l);
                    l.RemoveAt(l.Count-1); //make sure it "POPS"
                }
            }
        }

        public IList<string> WordBreak2(string s, IList<string> wordDict)
        {
            List<string> list = new List<string>();
            Break2(s, wordDict, 0, list);
            return list;
        }

        private void Break2(string s, IList<string> wordDict, int index, List<string> list, string str="")
        {
            if (index == s.Length)
                list.Add(str.Trim());

            foreach (var word in wordDict)
            {
                if (index + word.Length <= s.Length && s.Substring(index, word.Length) == word)
                {
                    var st = str + word + " ";
                    Break2(s, wordDict, index + word.Length, list, st);
                }
            }
        }

        public bool WordBreak(string s, IList<string> wordDict)
        {
            //bool?[] cache = new bool?[s.Length];
            bool[] dp = new bool[s.Length + 1];
            dp[s.Length] = true;
            //return Break(s, wordDict, cache);
            return BreakDP(s, wordDict, dp);
        }

        //this will exceed time limit so cache
        private bool Break(string s, IList<string> wordDict,bool?[] cache, int index=0)
        {
            if (index == s.Length)
                return true;

            if (cache[index].HasValue)
                return cache[index].GetValueOrDefault();

            foreach (var word in wordDict)
            {
                if(word.Length + index <= s.Length && s.Substring(index,word.Length) == word)
                {
                    var res = Break(s, wordDict, cache, index + word.Length);
                    if (res)
                        return true;
                }
            }

            cache[index] = false;
            return false;
        }

        private bool BreakDP(string s, IList<string> wordDict, bool[] dp)
        {
            for (int i = s.Length - 1; i >= 0; i--)
            {
                foreach (var word in wordDict)
                {
                    if(i+word.Length <= s.Length && s.Substring(i,word.Length) == word)
                    {
                        dp[i] = dp[i + word.Length];
                    }
                    if (dp[i]) //we found a way to break the word
                        break;
                }
            }
            return dp[0];
        }

        private bool IsPalindrome(string s, int left, int right)
        {
            while(left <= right)
            {
                if (s[left] != s[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }

        public int TitleToNumber(string columnTitle)
        {
            int sum = 0;
            int n = columnTitle.Length;
            int pow = 0;

            for (int i = n - 1; i >= 0; i--)
            {
                char ch = columnTitle[i];
                int num = (int)(ch) - 64;
                int m = (int)Math.Pow(26, pow);
                sum = sum + (num * m);
                pow++;
            }
            return sum;
        }

        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            var sArr = s.ToCharArray();
            Array.Sort(sArr);
            var tArr = t.ToCharArray();
            Array.Sort(tArr);
            var str = new string(sArr);
            var ttr = new string(tArr);
            return str == ttr;
        }

        public void ReverseString(char[] s)
        {
            int l = 0;
            int r = s.Length - 1;
            while(l<r)
            {
                char tmp = s[l];
                s[l] = s[r];
                s[r] = tmp;
                l++;
                r--;
            }
        }

        public int FirstUniqChar(string s)
        {
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            bool[] ans = new bool[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                if (dictionary.ContainsKey(s[i]))
                {
                    int j = dictionary[s[i]];
                    ans[i] = false;
                    ans[j] = false;
                }
                else
                {
                    dictionary.Add(s[i], i);
                    ans[i] = true;
                }
            }

            int index = ans.TakeWhile(x => x == false).Count();

            return index >= ans.Length ? -1 : index;
        }

        public int LongestSubstring(string s, int k)
        {
            if (s.Length < k)
                return 0;

            Dictionary<char, int> charCount = new Dictionary<char, int>();
            
            foreach (var c in s)
            {
                if (charCount.ContainsKey(c))
                    charCount[c]++;
                else
                    charCount.Add(c, 1);
            }

            List<char> invalidChars = new List<char>();
            foreach (var key in charCount.Keys)
            {
                if (charCount[key] < k)
                    invalidChars.Add(key);
            }
            if (invalidChars.Count == 0)
                return s.Length;

            if (invalidChars.Count == s.Length)
                return 0;

            var str = s.Split(invalidChars.ToArray(),StringSplitOptions.RemoveEmptyEntries);

            int maxLength = 0;
            foreach (var st in str)
            {
                maxLength = Math.Max(maxLength, LongestSubstring(st, k));
            }

            return maxLength;

        }

        public int LengthOfLongestSubstringKDistinct(string s, int k)
        {
            int count = 0;
            int maxLength = 0;
            var hashMap = new HashSet<char>();
            Queue<int> indexes = new Queue<int>();
            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                if(!hashMap.Contains(ch))
                {
                    if(hashMap.Count + 1 > k)
                    {
                        int index = indexes.Dequeue();
                        maxLength = Math.Max(maxLength, i - index);
                        hashMap.Remove(s[index]);
                    }
                    hashMap.Add(ch);
                    indexes.Enqueue(i);
                }
            }
            if (maxLength == 0)
                return s.Length;
            return maxLength;
        }
    }

    


}

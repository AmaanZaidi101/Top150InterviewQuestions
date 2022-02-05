﻿using System;
using System.Collections.Generic;
using FunctionLibrary;

namespace Top150InterviewQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //OtherOperations();
            //ArrayOperations();
            StringOperations();
            //MathOperations();
            //LinkedListOperations();
            //TreeOperations();
            //GraphOperations();
        }

        private static void GraphOperations()
        {
            string[][] alienWordsArr =
            {
                new string[]{"wrt","wrf","er","ett","rftt"},
                new string[]{ "wrt", "wrf", "er", "ett" },
                new string[]{ "a", "ba", "bc", "c" },
                new string[]{ "we", "ew", "we"},
            };
            foreach (var alienWords in alienWordsArr)
            {
                var gf = new GraphFunctions();
                Console.WriteLine(gf.AlienOrder(alienWords));
            }
            return;

            List<KeyValuePair<int, int[][]>> coursesArr = new List<KeyValuePair<int, int[][]>>();
            coursesArr.Add(new KeyValuePair<int, int[][]>(4, new int[][]{
                    new int[]{1, 0},
                    new int[]{2, 0},
                    new int[]{3, 1},
                    new int[]{3, 2},
                }));
            coursesArr.Add(new KeyValuePair<int, int[][]>(5, new int[][]{
                    new int[]{0, 1},
                    new int[]{0, 2},
                    new int[]{1, 3},
                    new int[]{1, 4},
                    new int[]{3, 4},
                }));
            coursesArr.Add(new KeyValuePair<int, int[][]>(2, new int[][]{
                    new int[]{1, 0}
                }));
            coursesArr.Add(new KeyValuePair<int, int[][]>(2, new int[][]{
                    new int[]{1, 0},
                    new int[]{0, 1}
                }));
            foreach (var courses in coursesArr)
            {
                Console.WriteLine();
                var gf = new GraphFunctions();
                var res = gf.FindOrder(courses.Key, courses.Value);
                foreach (var r in res)
                {
                    Console.Write(r + " ");
                }
            }
            return;

            foreach (var courses in coursesArr)
            {
                var gf = new GraphFunctions();
                Console.WriteLine(gf.CanFinish(courses.Key, courses.Value));
            }
            return;
            List<KeyValuePair<string, string[]>> wordLadder = new List<KeyValuePair<string, string[]>>();
            wordLadder.Add(new KeyValuePair<string, string[]>("hot:dog", new string[] { "hot", "cog", "dog", "tot", "hog", "hop", "pot", "dot" }));//
            //wordLadder.Add(new KeyValuePair<string, string[]>("qa:sq", new string[] { "si", "go", "se", "cm", "so", "ph", "mt", "db", "mb", "sb", "kr", "ln", "tm", "le", "av", "sm", "ar", "ci", "ca", "br", "ti", "ba", "to", "ra", "fa", "yo", "ow", "sn", "ya", "cr", "po", "fe", "ho", "ma", "re", "or", "rn", "au", "ur", "rh", "sr", "tc", "lt", "lo", "as", "fr", "nb", "yb", "if", "pb", "ge", "th", "pm", "rb", "sh", "co", "ga", "li", "ha", "hz", "no", "bi", "di", "hi", "qa", "pi", "os", "uh", "wm", "an", "me", "mo", "na", "la", "st", "er", "sc", "ne", "mn", "mi", "am", "ex", "pt", "io", "be", "fm", "ta", "tb", "ni", "mr", "pa", "he", "lr", "sq", "ye" }));
            //wordLadder.Add(new KeyValuePair<string, string[]>("hit:cog", new string[] { "hot", "dot", "tog", "cog" }));//0
            //wordLadder.Add(new KeyValuePair<string, string[]>("hit:cog", new string[] { "hot", "cog", "dot", "dog", "hit", "lot", "log" }));//
            //wordLadder.Add(new KeyValuePair<string, string[]>("hot:dog", new string[] { "hot", "dog", "dot" }));//
            //wordLadder.Add(new KeyValuePair<string, string[]>("a:c", new string[] { "a", "b", "c" }));//
            wordLadder.Add(new KeyValuePair<string, string[]>("hit:cog", new string[] { "hot", "dot", "dog", "lot", "log", "cog" }));//

            foreach (var wl in wordLadder)
            {
                var gf = new GraphFunctions();
                string[] beginEnd = wl.Key.Split(':');
                Console.WriteLine(gf.LadderLength(beginEnd[0], beginEnd[1], wl.Value));
            }
            return;
        }

        private static void TreeOperations()
        {
            
            int[] ps = new int[] { 6, 8, 12, 25, 27, 10 };
            foreach (var p in ps)
            {
                var tf = new TreeFunctions();
                var root = tf.CreateTreeForInorderSuccessor();
                var successor = tf.InOrderSuccessor(root, new TreeNode(p));
                if (successor != null)
                    Console.WriteLine($"For {p} - {successor.val}");
                else
                    Console.WriteLine($"For {p} - null");
            }
            return;

            Codec C = new Codec();
            var r = C.CreateTree();
            var s = C.serialize(r);
            Console.WriteLine(s);
            var res = C.deserialize(s);
            return;
            List<KeyValuePair<int[], int[]>> preAndIn = new List<KeyValuePair<int[], int[]>>();
            preAndIn.Add(new KeyValuePair<int[], int[]>(
                new int[] { 3, 9, 20, 15, 7 },
                new int[] { 9, 3, 15, 20, 7 }
                ));

            foreach (var pin in preAndIn)
            {
                var tf = new TreeFunctions();
                tf.BuildTree(pin.Key, pin.Value);
            }
        }

        private static void OtherOperations()
        {
            Trie trie = new Trie();
            trie.Insert("dog");
            trie.Insert("door");
            Console.WriteLine(trie.Search("dog"));
            Console.WriteLine(trie.Search("do"));
            Console.WriteLine(trie.Search("bowwow"));
            Console.WriteLine(trie.StartsWith("do"));
            return;


            List<KeyValuePair<int, int[][]>> lrus = new List<KeyValuePair<int, int[][]>>();
            lrus.Add(new KeyValuePair<int, int[][]>(2,
                new int[][]
                {
                    new int[]{1,1},
                    new int[]{2,2},
                    new int[]{1},
                    new int[]{3,3},
                    new int[]{2},
                    new int[]{4,4},
                    new int[]{1},
                    new int[]{3},
                    new int[]{4},
                }));

            foreach (var lru in lrus)
            {
                var l = new LRUCache(lru.Key);
                foreach (var val in lru.Value)
                {
                    if (val.Length == 2)
                    {
                        Console.WriteLine($"Putting {val[0]} , {val[1]}");
                        l.Put(val[0], val[1]);
                    }
                    else
                    {
                        Console.WriteLine($"Getting {val[0]}");
                        Console.WriteLine(l.Get(val[0]));
                    }
                }

            }
            return;
            char[][] board = new char[][]
            {
                new char[] { '.', '8', '7', '6', '5', '4', '3', '2', '1' },
                new char[]{ '2', '.', '.', '.', '.', '.', '.', '.', '.' },
                new char[]{ '3', '.', '.', '.', '.', '.', '.', '.', '.' },
                new char[]{ '4', '.', '.', '.', '.', '.', '.', '.', '.' },
                new char[]{ '5', '.', '.', '.', '.', '.', '.', '.', '.' },
                new char[]{ '6', '.', '.', '.', '.', '.', '.', '.', '.' },
                new char[]{ '7', '.', '.', '.', '.', '.', '.', '.', '.' },
                new char[]{ '8', '.', '.', '.', '.', '.', '.', '.', '.' },
                new char[]{ '9', '.', '.', '.', '.', '.', '.', '.', '.' }
            };
            var of = new OtherFunctions();
            Console.WriteLine(of.IsValidSudoku(board));
        }

        private static void LinkedListOperations()
        {
            var lf = new LinkedListFunctions();
            //lf.CreateAndMergeLists();
            lf.CreateList();
        }

        private static void MathOperations()
        {
            List<(int, int)> sums = new List<(int, int)>();
            sums.Add((-1, 1));
            sums.Add((1, 2));
            sums.Add((2, 3));
            foreach (var sum in sums)
            {
                var mf = new MathFunctions();
                Console.WriteLine(mf.GetSum(sum.Item1,sum.Item2));
            }
            return;

            int[] powerof3 = { 243 };
            foreach (var power in powerof3)
            {
                var mf = new MathFunctions();
                Console.WriteLine(mf.IsPowerOfThree(power));
            }
            return;
            string[] expressions = { " 3+5 / 2  ", "1*2-3/4+5*6-7*8+9/10","42","3+2*2", " 3/2 ", " 3+5 / 2 " };
            foreach (var expression in expressions)
            {
                var mf = new MathFunctions();
                Console.WriteLine(mf.Calculate(expression));
            }
            return;

            int[] primes = { 10, 0, 1 };
            foreach (var prime in primes)
            {
                var mf = new MathFunctions();
                Console.WriteLine(mf.CountPrimesFaster(prime));
            }
            return;

            int[] happyNumbers = { 2, 19};
            foreach (var number in happyNumbers)
            {
                var mf = new MathFunctions();
                Console.WriteLine(mf.IsHappy(number));
            }
            return;

            int[][] houses =
            {
                new int[]{ 2, 1, 1, 2 },
                new int[]{ 1, 2, 3, 1 },
                new int[]{ 2, 7, 9, 3, 1 },
                
            };
            foreach (var money in houses)
            {
                var mf = new MathFunctions();
                Console.WriteLine(mf.Rob(money));
            }
            return;

            string[] uints = { "00000010100101000001111010011100" };
            foreach (var u in uints)
            {
                var mf = new MathFunctions();
                Console.WriteLine(mf.reverseBits(Convert.ToUInt32(u, 2)));
            }
            return;

            int[] factsZeroes = { 150,30,13 };
            foreach (var facts in factsZeroes)
            {
                var mf = new MathFunctions();
                Console.WriteLine(mf.TrailingZeroes(facts));
            }
            return;


            int[][] numDenom =
            {
                new int[]{int.MinValue,1},
                new int[]{-1,int.MinValue},
                new int[]{1,6},
                new int[]{1,2},
                new int[]{2,1},
                new int[]{2,3},
                new int[]{4,333},
                new int[]{1,5},
            };

            foreach (var nd in numDenom)
            {
                var mf = new MathFunctions();
                Console.WriteLine(mf.FractionToDecimal(nd[0],nd[1]));
            }
            return;

            string[][] tokensArr = new string[][]
            {
                new string[]{ "4", "-2", "/", "2", "-3", "-", "-" }, //-7
                new string[]{ "2", "1", "+", "3", "*" }, //9
                new string[]{ "4", "13", "5", "/", "+" }, //6
                new string[]{ "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" }, //22
                new string[]{"3","11","+","5","-" }
            };

            foreach (var tokens in tokensArr)
            {
                var mf = new MathFunctions();
                Console.WriteLine(mf.EvalRPN(tokens));
            }

            return;


            int[][][] pointsArr = new int[][][]
            {
                new int[][]
                {
                    new int[]{-184,-551},
                    new int[]{-105,-467},
                    new int[]{-90,-394},
                    new int[]{-60,-248},
                    new int[]{115,359},
                    new int[]{138,429},
                    new int[]{60,336},
                    new int[]{150,774},
                    new int[]{207,639},
                    new int[]{-150,-686},
                    new int[]{-135,-613},
                    new int[]{92,289},
                    new int[]{23,79},
                    new int[]{135,701},
                    new int[]{0,9},
                    new int[]{-230,-691},
                    new int[]{-115,-341},
                    new int[]{-161,-481},
                    new int[]{230,709},
                    new int[]{-30,-102},
                },
                new int[][]
                {
                    new int[]{4,5 },
                    new int[]{4,-1 },
                    new int[]{4,0 }
                },
                new int[][]
                {
                    new int[]{1,1 },
                    new int[]{2,2 },
                    new int[]{3,3 }
                },
                new int[][]
                {
                    new int[]{1,1 },
                    new int[]{3,2 },
                    new int[]{5,3 },
                    new int[]{4,1 },
                    new int[]{2,3 },
                    new int[]{1,4 }
                }
            };

            foreach (var points in pointsArr)
            {
                var mf = new MathFunctions();
                Console.WriteLine(mf.MaxPointsFaster(points));
            }

            return;
            int[] numRows = { 5, 3, 1, 2, 7 };
            foreach (var numRow in numRows)
            {
                var mf = new MathFunctions();
                mf.Generate(numRow);
            }

            return;

            int[] steps = { 45, 2, 3 };

            foreach (var step in steps)
            {
                var mf = new MathFunctions();
                Console.WriteLine($"Ways to climb {step} is {mf.ClimbStairs(step)}");
            }

            return;

            int[] squares = {int.MaxValue };
            foreach (var square in squares)
            {
                var mf = new MathFunctions();
                Console.WriteLine($"Square root of {square} is {mf.MySqrt(square)}");
            }

            return;
            List<KeyValuePair<double, int>> xns = new List<KeyValuePair<double, int>>();
            xns.Add(new KeyValuePair<double, int>(0.00001, 2147483647));
            xns.Add(new KeyValuePair<double, int>(2, 10));
            xns.Add(new KeyValuePair<double, int>(3, 2));
            xns.Add(new KeyValuePair<double, int>(5, -7));

            foreach (var xn in xns)
            {
                var mf = new MathFunctions();
                Console.WriteLine(mf.MyPow(xn.Key,xn.Value));
            }
            return;

            List<KeyValuePair<int, int>> divisions = new List<KeyValuePair<int, int>>();
            divisions.Add(new KeyValuePair<int, int>(-2147483648, -1017100424));//2
            divisions.Add(new KeyValuePair<int, int>(1100540749,-1090366779));//-1
            divisions.Add(new KeyValuePair<int, int>(-1010369383, -2147483648));//0
            divisions.Add(new KeyValuePair<int, int>(432789, 256));//1690
            divisions.Add(new KeyValuePair<int, int>(2147483647, 2));
            divisions.Add(new KeyValuePair<int, int>(-2147483648, -1));//2147..
            divisions.Add(new KeyValuePair<int, int>(10, 3));//3
            divisions.Add(new KeyValuePair<int, int>(7, -3));//-2
            divisions.Add(new KeyValuePair<int, int>(0, 1));//0
            divisions.Add(new KeyValuePair<int, int>(1, 1));//1
            divisions.Add(new KeyValuePair<int, int>(-6, -2));//3



            foreach (var division in divisions)
            {
                var mf = new MathFunctions();
                Console.WriteLine(mf.Divide(division.Key,division.Value));
            }
            return;

            List<KeyValuePair<int, int[]>> numList = new List<KeyValuePair<int, int[]>>();
            numList.Add(new KeyValuePair<int, int[]>(1,new int[]{ -1, 2, 1, -4 }));
            numList.Add(new KeyValuePair<int, int[]>(1, new int[] { 0,0,0 }));

            foreach (var num in numList)
            {
                var mf = new MathFunctions();
                Console.WriteLine(mf.ThreeSumClosest(num.Value,num.Key));
            }
            return;

            int[][] nums =
             {
                new int[]{0,0,0,0},
                new int[]{-1,0,1,2,-1,-4 },
                new int[]{ }
            };

            foreach (var num in nums)
            {
                var mf = new MathFunctions();
                var list = mf.ThreeSum(num);
                foreach (var item in list)
                {
                    foreach (var el in item)
                    {
                        Console.Write(el + " ");
                    }
                    Console.WriteLine();
                }
            }

            return;

            string[] s = { "III", "IV", "IX", "LVIII", "MCMXCIV" };
            foreach (var str in s)
            {
                var mf = new MathFunctions();
                Console.WriteLine(mf.RomanToInt(str));
            }
            //int[] nums = {1000,100, 41,1000, 2000, 1994, 3,4,9,58,20,10 };
            //foreach (var num in nums)
            //{
            //    var mf = new MathFunctions();
            //    Console.WriteLine(mf.IntToRoman(num));
            //}
        }

        private static void StringOperations()
        {
            (string, int)[] longestSubsKMax = { ("aabbaaabbbaaaabbbbcccccccccccccccccccccccccccccccccccccS", 2), ("eceba", 2), ("aa", 1) };
            foreach (var subs in longestSubsKMax)
            {
                var sf = new StringFunctions();
                Console.WriteLine(sf.LengthOfLongestSubstringKDistinct(subs.Item1, subs.Item2));
            }
            return;

            (string, int)[] longestSubsK = {("ababacb",3),("weitong",2), ("aaabb", 3), ("ababbc", 2) };
            foreach (var subs in longestSubsK)
            {
                var sf = new StringFunctions();
                Console.WriteLine(sf.LongestSubstring(subs.Item1,subs.Item2));
            }
            return;

            string[] firstUniqueCharArr = { "loveleetcode" };
            foreach (var s in firstUniqueCharArr)
            {
                var sf = new StringFunctions();
                Console.WriteLine(sf.FirstUniqChar(s));
            }
            return;

            string[] excelColumns = { "AB", "A", "ZY" };
            foreach (var col in excelColumns)
            {
                var sf = new StringFunctions();
                Console.WriteLine(sf.TitleToNumber(col));
            }
            return;

            List<KeyValuePair<string, string[]>> wordDicts = new List<KeyValuePair<string, string[]>>();
            wordDicts.Add(new KeyValuePair<string, string[]>("pineapplepenapple", new string[] { "apple", "pen", "applepen", "pine", "pineapple" })); //true
            wordDicts.Add(new KeyValuePair<string, string[]>("ccaccc", new string[] { "cc", "ac" })); //true
            wordDicts.Add(new KeyValuePair<string, string[]>("ccbb", new string[] { "bc", "cb" })); //false
            wordDicts.Add(new KeyValuePair<string, string[]>("cars", new string[] { "car", "ca", "rs"})); //true
            wordDicts.Add(new KeyValuePair<string, string[]>("bb", new string[] { "a", "b", "bbb", "bbbb" })); //true
            wordDicts.Add(new KeyValuePair<string, string[]>("applepenapple", new string[] { "apple", "pen" })); //true
            wordDicts.Add(new KeyValuePair<string, string[]>("catsandog", new string[] { "cats", "dog", "sand", "and", "cat" })); //false

            foreach (var wd in wordDicts)
            {
                var sf = new StringFunctions();
                var res = sf.WordBreak2(wd.Key, wd.Value);
                foreach (var item in res)
                {
                    Console.WriteLine(item+" ");
                }
                Console.WriteLine();
            }

            return;
            foreach (var wd  in wordDicts)
            {
                var sf = new StringFunctions();
                Console.WriteLine(sf.WordBreak(wd.Key,wd.Value));
            }

            return;


            string[] palins = new string[]
            {
                "aab",
                "a"
            };

            foreach (var palin in palins)
            {
                var sf = new StringFunctions();
                var res = sf.Partition(palin);
                foreach (var r in res)
                {
                    foreach (var item in r)
                    {
                        Console.Write(item+" ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            return;
            string[] encodes = { "06","12", "226", "0", "06" };
            foreach (var encode in encodes)
            {
                var sf = new StringFunctions();
                Console.WriteLine(sf.NumDecodings(encode));
            }

            return;


            string[][] strss = new string[][]
            {
                new string[]{ "eat", "tea", "tan", "ate", "nat", "bat" }
            };

            foreach (var str in strss)
            {
                var sf = new StringFunctions();
                var res = sf.GroupAnagrams(str);
                foreach (var group in res)
                {
                    foreach (var item in group)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                }
            }

            return;

            List<KeyValuePair<string, string>> sps = new List<KeyValuePair<string, string>>();
            sps.Add(new KeyValuePair<string, string>("abcabczzzde","*abc???de*"));//true
            sps.Add(new KeyValuePair<string, string>("","******"));//true
            sps.Add(new KeyValuePair<string, string>("a", "aa"));//false
            sps.Add(new KeyValuePair<string, string>("acdcb", "a*c?b"));//false
            sps.Add(new KeyValuePair<string, string>("adceb", "*a*b"));//true
            sps.Add(new KeyValuePair<string, string>("cb", "?a"));//false
            sps.Add(new KeyValuePair<string, string>("aa", "*"));//true



            foreach (var sp in sps)
            {
                var sf = new StringFunctions();
                Console.WriteLine(sf.IsMatch2(sp.Key,sp.Value));
            }
            return;

            int[] countAndSay = new int[] { 4 };
            foreach (var cs in countAndSay)
            {
                var sf = new StringFunctions();
                Console.WriteLine(sf.CountAndSay(cs));
            }
            return;

            for (int i = 3; i >= 1; i--)
            {
                var sf = new StringFunctions();
                var paranthesisCombination = sf.GenerateParanthesis(i);
                Console.WriteLine("For " + i);
                int count = 0;
                foreach (var paranthesis in paranthesisCombination)
                {
                    count++;
                    Console.WriteLine(paranthesis);
                }
                Console.WriteLine("Total "+count);
                Console.WriteLine();
            }

            string[] strArray = { "23", "", "2", "234" };
            
            foreach (var item in strArray)
            {
                var sf = new StringFunctions();
                var str = sf.LetterCombinations(item);
                foreach (var strItem in str)
                {
                    Console.Write(strItem+" ");
                }
                Console.WriteLine();
            }
            return;

            string[][] strs = { 
                new string[]{"cir","car" },
                new string[]{ "flower", "flow", "flight" },
                new string[]{ "dog","racecar","car" },

            };
            foreach (var str in strs)
            {
                var sf = new StringFunctions();
                Console.WriteLine(sf.LargestCommonPrefix(str));
            }
            return;
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            list.Add(new KeyValuePair<string, string>("aaa", "ab*a*c*a")); //true
            list.Add(new KeyValuePair<string, string>("aa", "a")); //false
            list.Add(new KeyValuePair<string, string>("aa", "a*")); //true
            list.Add(new KeyValuePair<string, string>("ab", ".*")); //true
            list.Add(new KeyValuePair<string, string>("aab", "c*a*b")); //true
            list.Add(new KeyValuePair<string, string>("mississippi", "mis*is*p*.")); //false
            list.Add(new KeyValuePair<string, string>("ab", ".*c")); //false
            list.Add(new KeyValuePair<string, string>("aaa", "aaaa")); //false

            foreach (var item in list)
            {
                StringFunctions sf = new StringFunctions();
                Console.WriteLine(sf.isMatch(item.Key,item.Value));
            }

            //string s = "PAYPALISHIRING";
            //int[] numRows = {1,2,3,4,5,6,7,8,9,10,11,12,13,14 };
            //foreach (var numRow in numRows)
            //{
            //    StringFunctions sf = new StringFunctions();
            //    Console.WriteLine("New string is");
            //    Console.WriteLine(sf.PrintZigZag(s, numRow));
            //}


            //string s = "babad";
            //string[] s = {"aaaaa" ,
            //    "lipwawibllrziekxgwudqghfpvsafguorthpsdihcinuasyzmttzxdluhrnfdrawabwxdgpoqabfhutzowqfhkynrhobyuygesngyxpjyilqhwyeemklicinmatyishobtitukbkpqtxwioqnztlewilnewokfqkycfuvgqmogwuvkrxphyjvhbkhpcwywfnazsoulmgdoaxyngoynmfexdcpanoyidutpzcicibjnzmybvggqbpbejsvliocotewgrfcwyebisiywjsugjxxwupryxglvkgdugbejsibuscjofrvaeexqweieldfhriftlczbuzmuizjqzxovziflaigwxrxowmhdlvrbxzeaaqxmicvigolodopbukjvkzwvxexnnweodsoscnpmuwgjhmlurwdqbwrzavjjubsueahunqwemmewqnuhaeusbujjvazrwbqdwrulmhjgwumpncsosdoewnnxexvwzkvjkubpodologivcimxqaaezxbrvldhmwoxrxwgialfizvoxzqjziumzubzcltfirhfdleiewqxeeavrfojcsubisjebgudgkvlgxyrpuwxxjgusjwyisibeywcfrgwetocoilvsjebpbqggvbymznjbiciczptudiyonapcdxefmnyognyxaodgmluoszanfwywcphkbhvjyhpxrkvuwgomqgvufcykqfkowenliweltznqoiwxtqpkbkutitbohsiytamnicilkmeeywhqliyjpxygnsegyuybohrnykhfqwoztuhfbaqopgdxwbawardfnrhuldxzttmzysaunichidsphtrougfasvpfhgqduwgxkeizrllbiwawpil",
            //    "ccc","eabcb","babad", "abb", "cbbd" };
            //foreach (var str in s)
            //{
            //    StringFunctions sf = new StringFunctions();
            //    Console.WriteLine($"Longest substring palindrome is {sf.LongestPalindrome(str)}");
            //}

        }

        public static void ArrayOperations()
        {
            List<int[][]> meetingIntervals = new List<int[][]>();
            meetingIntervals.Add(new int[][]
            {
                new int[]{0,30},
                new int[]{5,10},
                new int[]{15,20}
            });
            foreach (var interval in meetingIntervals)
            {
                var af = new ArrayFunctions();
                Console.WriteLine(af.MinMeetingRooms(interval));
            }
            return;
            List<(int, int, int[])> missingRanges = new List<(int, int, int[])>();
            missingRanges.Add((0, 99, new int[] { 0, 1, 3, 50, 75 }));
            foreach (var mr in missingRanges)
            {
                var af = new ArrayFunctions();
                var res = af.FindMissingRanges(mr.Item3, mr.Item1, mr.Item2);
                foreach (var r in res)
                {
                    Console.Write(r + " ");
                }
                Console.WriteLine();
            }
            return;

            List<(int, int[][])> sortedMatrices = new List<(int, int[][])>();
            sortedMatrices.Add((5, new int[][]
            {
                new int[]{1,3,5},
                new int[]{6,7,12},
                new int[]{11,14,14},
            }));
            sortedMatrices.Add((8, new int[][]
            {
                new int[]{1,5,9},
                new int[]{10,11,13},
                new int[]{12,13,15},
            }));
            foreach (var matrix in sortedMatrices)
            {
                var af = new ArrayFunctions();
                Console.WriteLine(af.KthSmallest(matrix.Item2,matrix.Item1));
            }
            return;

            List<(int[], int[])> intersectingArr = new List<(int[], int[])>();
            intersectingArr.Add((new int[] { 1, 2, 2, 1 }, new int[] { 2, 2, }));
            foreach (var arr in intersectingArr)
            {
                var af = new ArrayFunctions();
                var res = af.Intersect(arr.Item1, arr.Item2);
                foreach (var r in res)
                {
                    Console.Write(r + " ");
                }
                Console.WriteLine();
            }
            return;



            List<(int, int[])> countsKArr = new List<(int, int[])>();
            countsKArr.Add((1, new int[] { 3, 0, 1, 0 }));
            foreach (var arr in countsKArr)
            {
                var af = new ArrayFunctions();
                var res = af.TopKFrequent(arr.Item2, arr.Item1);
                foreach (var r in res)
                {
                    Console.Write(r + " ");
                }
                Console.WriteLine();
            }
            return;

            int[][] tripletsArr =
            {
                new int[]{6,7,1,2},
                new int[]{5,4,3,2,1},
                new int[]{1,2,3,4,5,6}
            };
            foreach (var triplet in tripletsArr)
            {
                var af = new ArrayFunctions();
                Console.WriteLine(af.IncreasingTriplet(triplet));
            }
            return;


            int[][][] matricesArr =
            {
                new int[][]
                {
                    new int[]{9,9,4},
                    new int[]{6,6,8},
                    new int[]{2,1,1}
                }
            };
            foreach (var matrix in matricesArr)
            {
                var af = new ArrayFunctions();
                Console.WriteLine(af.LongestIncreasingPath(matrix));
            }
            return;

            int[][] wiggles =
            {
                new int[]{ 1, 5, 1, 1, 6, 4 }
            };
            foreach (var wiggle in wiggles)
            {
                var af = new ArrayFunctions();
                af.WiggleSort2(wiggle);
                foreach (var r in wiggle)
                {
                    Console.Write(r + " ");
                }
                Console.WriteLine();
            }
            return;


            int[][] countSmallerAfter =
            {
                new int[]{2,0,1},
                new int[]{5,2,6,1}
            };
            foreach (var arr in countSmallerAfter)
            {
                var af = new ArrayFunctions();
                var res = af.CountSmaller(arr);
                foreach (var r in res)
                {
                    Console.Write(r + " ");
                }
                Console.WriteLine();
            }
            return;

            int[][][] gameOfLife =
            {
                new int[][]
                {
                    new int[]{0,1,0 },
                    new int[]{0,0,1 },
                    new int[]{1,1,1 },
                    new int[]{0,0,0 },
                }
            };

            foreach (var board in gameOfLife)
            {
                var af = new ArrayFunctions();
                af.GameOfLife(board);
            }
            return;

            List<(int[][], int)> searchInMatrices = new List<(int[][], int)>();
            searchInMatrices.Add((new int[][]{
            new int[]{1,1}
            }, 2));
            foreach (var matrices in searchInMatrices)
            {
                var af = new ArrayFunctions();
                Console.WriteLine(af.SearchMatrix(matrices.Item1,matrices.Item2));
            }
            return;

            List<(int, int[])> maxSlidingWindows = new List<(int, int[])>();
            maxSlidingWindows.Add((3, new int[] { 1, 3, 1, 2, 0, 5 }));
            maxSlidingWindows.Add((2, new int[] { 7, 2, 4 }));


            foreach (var msw in maxSlidingWindows)
            {
                var af = new ArrayFunctions();
                var res = af.MaxSlidingWindow(msw.Item2, msw.Item1);
                foreach (var r in res)
                {
                    Console.Write(r + " ");
                }
                Console.WriteLine();
            }
            return;

            int[][][] buildingsArr =
            {
                new int[][]
                {
                    new int[]{1,3,3},
                    new int[]{2,4,4},
                    new int[]{5,8,2},
                    new int[]{6,7,4},
                    new int[]{8,9,4},
                },
                new int[][]
                {
                    new int[]{2,9,10},
                    new int[]{3,7,15},
                    new int[]{5,12,12},
                    new int[]{15,20,10},
                    new int[]{19,24,8},
                },
                new int[][]
                {
                    new int[]{0,2,3},
                    new int[]{2,5,3},
                },
            };

            foreach (var buildings in buildingsArr)
            {
                var af = new ArrayFunctions();
                var res = af.GetSkyline(buildings);
                foreach (var r in res)
                {
                    Console.WriteLine(r[0]+" "+r[1]);
                }
                Console.WriteLine(new string('-',100));
            }
            return;

            Dictionary<int, int[]> kthLargestArr = new Dictionary<int, int[]>();
            kthLargestArr.Add(2, new int[] { 3, 2, 1, 5, 6, 4 });
            kthLargestArr.Add(4, new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 });

            foreach (var kArr in kthLargestArr)
            {
                var af = new ArrayFunctions();
                Console.WriteLine(af.FindKthLargest(kArr.Value,kArr.Key));
            }
            return;

            Dictionary<string[], char[][]> wordBoardsArr = new Dictionary<string[], char[][]>();
            wordBoardsArr.Add(new string[] { "a" }, new char[][]{
                new char[]{'a'}
            });

            wordBoardsArr.Add(new string[] { "aaa" }, new char[][]{
                new char[]{'a', 'a',}
            });

            wordBoardsArr.Add(new string[] { "oath", "pea", "eat", "rain" }, new char[][]{
                new char[]{'o', 'a', 'a', 'n' },
                new char[]{'e', 't', 'a', 'e' },
                new char[]{'i', 'h', 'k', 'r' },
                new char[]{'i', 'f', 'l', 'v' }
            });

            wordBoardsArr.Add(new string[] { "abcb" }, new char[][]{
                new char[]{'a', 'b',},
                new char[]{'c', 'd',}
            });

            foreach (var wordBoard in wordBoardsArr)
            {
                var af = new ArrayFunctions();
                var res = af.FindWordsWithTrie(wordBoard.Value, wordBoard.Key);
                foreach (var r in res)
                {
                    Console.WriteLine(r+" ");
                }
                Console.WriteLine();
            }
            return;

            char[][][] islandsArr =
            {
                new char[][]{
                    new char[]{ '1','1','1','1','0'},
                    new char[]{ '1', '1', '0', '1', '0' },
                    new char[]{ '1', '1', '0', '0', '0' },
                    new char[]{ '0', '0', '0', '0', '0' },
                },
                new char[][]
                {
                    new char[]{ '1', '1', '0', '0', '0' },
                    new char[]{ '1', '1', '0', '0', '0' },
                    new char[]{ '0', '0', '1', '0', '0' },
                    new char[]{ '0', '0', '0', '1', '1' },
                }
            };

            foreach (var island in islandsArr)
            {
                var af = new ArrayFunctions();
                Console.WriteLine(af.NumIslandsLessMemory(island));
            }
            return;

            List<KeyValuePair<int, int[]>> rotateArr = new List<KeyValuePair<int, int[]>>();
            rotateArr.Add(new KeyValuePair<int, int[]>(3, new int[] { 1, 2, 3, 4, 5, 6, 7 }));
            
            foreach (var arr in rotateArr)
            {
                var af = new ArrayFunctions();
                af.Rotate(arr.Value, arr.Key);
            }
            return;


            int[][] largesetNumber =
            {
                new int[]{3,30,34,5,9},
                new int[]{ 10, 2 },
                new int[]{1}
            };
            foreach (var ln in largesetNumber)
            {
                var af = new ArrayFunctions();
                Console.WriteLine(af.LargestNumber(ln));
            }
            return;


            int[][] maxProductsArr =
            {
                new int[]{ 2, 3, -2, 4 },//6
                new int[]{ -2, 0, -1 },//0
            };

            foreach (var mp in maxProductsArr)
            {
                var af = new ArrayFunctions();
                Console.WriteLine(af.MaxProduct(mp));
            }
            return;

            List<KeyValuePair<int[], int[]>> gasCosts = new List<KeyValuePair<int[], int[]>>();
            gasCosts.Add(new KeyValuePair<int[], int[]>(new int[] { 5, 1, 2, 3, 4 },new int[] { 4, 4, 1, 5, 1 }));
            gasCosts.Add(new KeyValuePair<int[], int[]>(new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5, 1, 2 }));
            gasCosts.Add(new KeyValuePair<int[], int[]>(new int[] {  2, 3, 4}, new int[] { 3, 4, 3}));

            foreach (var gasCost in gasCosts)
            {
                var af = new ArrayFunctions();
                Console.WriteLine(af.CanCompleteCircuit(gasCost.Key,gasCost.Value));
            }
            return;

            char[][][] XOs = new char[][][]
            {
                new char[][]
                {
                    new char[]{'X','O','X','O','X','O' },
                    new char[]{'O', 'X', 'O', 'X', 'O', 'X' },
                    new char[]{'X', 'O', 'X', 'O', 'X', 'O' },
                    new char[]{'O', 'X', 'O', 'X', 'O', 'X' }
                },
                //new char[][]
                //{
                //    new char[]{'X','X','X','X' },
                //    new char[]{'X','O','O','X' },
                //    new char[]{'X', 'X', 'O', 'X' },
                //    new char[]{'X', 'O', 'X', 'X'}
                //},
                //new char[][]
                //{
                //    new char[]{'O','X','X','O','X' },
                //    new char[]{'X', 'O', 'O', 'X', 'O'},
                //    new char[]{'X', 'O', 'X', 'O', 'X' },
                //    new char[]{'O', 'X', 'O', 'O', 'O' },
                //    new char[]{'X', 'X', 'O', 'X', 'O' }
                //}
            };

            foreach (var xo in XOs)
            {
                var af = new ArrayFunctions();
                af.Solve(xo);
            }
            return;

            List<KeyValuePair<int[], int[]>> arrayPairs = new List<KeyValuePair<int[], int[]>>();
            arrayPairs.Add(new KeyValuePair<int[], int[]>(new int[] { 1, 2, 3, 0, 0, 0 }, new int[] { 2, 5, 6 }));
            foreach (var arraypair in arrayPairs)
            {
                var af = new ArrayFunctions();
                af.Merge(arraypair.Key, arraypair.Key.Length- arraypair.Value.Length, arraypair.Value, arraypair.Value.Length);
            }

            return;

            int[][] heights = new int[][]
            {
                new int[]{5,5,1,7,1,1,5,2,7,6},//12
                new int[]{2,1,0,2}, //2
                new int[]{0,2,0},//2
                new int[]{ 2, 1, 5, 6, 2, 3 }, //10
                new int[]{4,2,0,3,2,4,3,4}//10
            };

            foreach (var height in heights)
            {
                var af = new ArrayFunctions();
                Console.WriteLine(af.LargestRectangleAreaByStack(height));
            }
            return;

            Dictionary<string, char[][]> boards = new Dictionary<string, char[][]>();
            boards.Add("a", new char[][]
                {
                    new char[]{ 'b', 'b'},
                    new char[]{ 'a', 'b'},
                    new char[]{ 'b', 'a'},
                });
            boards.Add("abcd", new char[][]
                {
                    new char[]{ 'a', 'b'},
                    new char[]{ 'c', 'd'}
                });
            boards.Add("ABCCED", new char[][]
                {
                    new char[]{ 'A', 'B', 'C', 'E'},
                    new char[]{ 'S', 'F', 'C', 'S' },
                    new char[]{ 'A', 'D', 'E', 'E' }
                });
            boards.Add("SEE", new char[][]
                {
                    new char[]{ 'A', 'B', 'C', 'E'},
                    new char[]{ 'S', 'F', 'C', 'S' },
                    new char[]{ 'A', 'D', 'E', 'E' }
                });
            boards.Add("ABCB", new char[][]
                {
                    new char[]{ 'A', 'B', 'C', 'E'},
                    new char[]{ 'S', 'F', 'C', 'S' },
                    new char[]{ 'A', 'D', 'E', 'E' }
                });
            
            foreach (var board in boards)
            {
                var af = new ArrayFunctions();
                Console.WriteLine(af.Exist(board.Value,board.Key));
            }

            return;
            int[][] sets = new int[][]
            {
                new int[]{1,2,3}
            };

            foreach (var set in sets)
            {
                var af = new ArrayFunctions();
                var res = af.Subsets(set);
                foreach (var r in res)
                {
                    foreach (var item in r)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                }
            }

            return; 
            int[][][] zeroMatrices = new int[][][]
            {
                //new int[][]
                //{
                //    new int[]{1,1,1},
                //    new int[]{1,0,1},
                //    new int[]{1,1,1}
                //},
                new int[][]{
                    new int[]{0,1,2,0 },
                    new int[]{3, 4, 5, 2 },
                    new int[]{1, 3, 1, 5 }
                }
            };

            foreach (var zeroMatrix in zeroMatrices)
            {
                var af = new ArrayFunctions();
                af.SetZeroes(zeroMatrix);
            }

            return;

            int[][] rowcols = new int[][]
            {
                new int[]{3,3 },
                new int[]{3,7 },
                new int[]{3,2 },
                
            };

            foreach (var rowcol in rowcols)
            {
                var af = new ArrayFunctions();
                Console.WriteLine($"For {rowcol[0]}, {rowcol[1]}");
                Console.WriteLine(af.UniquePaths(rowcol[0],rowcol[1]));
            }
            return;


            int[][][] intervalsArr = new int[][][]
            {
                new int[][]
                {
                    new int[]{2,3 },
                    new int[]{4, 5 },
                    new int[]{6, 7 },
                    new int[]{8, 9 },
                    new int[]{1, 10 }
                },
                new int[][]
                {
                    new int[]{1,4},
                    new int[]{0,2},
                    new int[]{3,5}
                },
                new int[][]
                {
                    new int[]{1,4},
                    new int[]{0,1}
                },
                new int[][]
                {
                    new int[]{1,4},
                    new int[]{0,0}
                },
                new int[][]
                {
                    new int[]{ 1,3 },
                    new int[]{2, 6 },
                    new int[]{8, 10 },
                    new int[]{15, 18 }
                },
                //new int[][]
                //{
                //    new int[]{1,4},
                //    new int[]{4,5}
                //}
            };
            foreach (var intervals in intervalsArr)
            {
                var af = new ArrayFunctions();
                var res = af.MergeAfterSort(intervals);
                Console.WriteLine("------------------------------------------------");
                foreach (var r in res)
                {
                    Console.WriteLine("------------------------------");
                    foreach (var item in r)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();

                }
            }
            return; 
            int[][] jumpArrs = new int[][]
            {
                //new int[]{9997,9997,9996,9995,9994,9993,9992,9991,9990,9989,9988,9987,9986,9985,9984,9983,9982,9981,9980,9979,9978,9977,9976,9975,9974,9973,9972,9971,9970,9969,9968,9967,9966,9965,9964,9963,9962,9961,9960,9959,9958,9957,9956,9955,9954,9953,9952,9951,9950,9949,9948,9947,9946,9945,9944,9943,9942,9941,9940,9939,9938,9937,9936,9935,9934,9933,9932,9931,9930,9929,9928,9927,9926,9925,9924,9923,9922,9921,9920,9919,9918,9917,9916,9915,9914,9913,9912,9911,9910,9909,9908,9907,9906,9905,9904,9903,9902,9901,9900,9899,9898,9897,9896,9895,9894,9893,9892,9891,9890,9889,9888,9887,9886,9885,9884,9883,9882,9881,9880,9879,9878,9877,9876,9875,9874,9873,9872,9871,9870,9869,9868,9867,9866,9865,9864,9863,9862,9861,9860,9859,9858,9857,9856,9855,9854,9853,9852,9851,9850,9849,9848,9847,9846,9845,9844,9843,9842,9841,9840,9839,9838,9837,9836,9835,9834,9833,9832,9831,9830,9829,9828,9827,9826,9825,9824,9823,9822,9821,9820,9819,9818,9817,9816,9815,9814,9813,9812,9811,9810,9809,9808,9807,9806,9805,9804,9803,9802,9801,9800,9799,9798,9797,9796,9795,9794,9793,9792,9791,9790,9789,9788,9787,9786,9785,9784,9783,9782,9781,9780,9779,9778,9777,9776,9775,9774,9773,9772,9771,9770,9769,9768,9767,9766,9765,9764,9763,9762,9761,9760,9759,9758,9757,9756,9755,9754,9753,9752,9751,9750,9749,9748,9747,9746,9745,9744,9743,9742,9741,9740,9739,9738,9737,9736,9735,9734,9733,9732,9731,9730,9729,9728,9727,9726,9725,9724,9723,9722,9721,9720,9719,9718,9717,9716,9715,9714,9713,9712,9711,9710,9709,9708,9707,9706,9705,9704,9703,9702,9701,9700,9699,9698,9697,9696,9695,9694,9693,9692,9691,9690,9689,9688,9687,9686,9685,9684,9683,9682,9681,9680,9679,9678,9677,9676,9675,9674,9673,9672,9671,9670,9669,9668,9667,9666,9665,9664,9663,9662,9661,9660,9659,9658,9657,9656,9655,9654,9653,9652,9651,9650,9649,9648,9647,9646,9645,9644,9643,9642,9641,9640,9639,9638,9637,9636,9635,9634,9633,9632,9631,9630,9629,9628,9627,9626,9625,9624,9623,9622,9621,9620,9619,9618,9617,9616,9615,9614,9613,9612,9611,9610,9609,9608,9607,9606,9605,9604,9603,9602,9601,9600,9599,9598,9597,9596,9595,9594,9593,9592,9591,9590,9589,9588,9587,9586,9585,9584,9583,9582,9581,9580,9579,9578,9577,9576,9575,9574,9573,9572,9571,9570,9569,9568,9567,9566,9565,9564,9563,9562,9561,9560,9559,9558,9557,9556,9555,9554,9553,9552,9551,9550,9549,9548,9547,9546,9545,9544,9543,9542,9541,9540,9539,9538,9537,9536,9535,9534,9533,9532,9531,9530,9529,9528,9527,9526,9525,9524,9523,9522,9521,9520,9519,9518,9517,9516,9515,9514,9513,9512,9511,9510,9509,9508,9507,9506,9505,9504,9503,9502,9501,9500,9499,9498,9497,9496,9495,9494,9493,9492,9491,9490,9489,9488,9487,9486,9485,9484,9483,9482,9481,9480,9479,9478,9477,9476,9475,9474,9473,9472,9471,9470,9469,9468,9467,9466,9465,9464,9463,9462,9461,9460,9459,9458,9457,9456,9455,9454,9453,9452,9451,9450,9449,9448,9447,9446,9445,9444,9443,9442,9441,9440,9439,9438,9437,9436,9435,9434,9433,9432,9431,9430,9429,9428,9427,9426,9425,9424,9423,9422,9421,9420,9419,9418,9417,9416,9415,9414,9413,9412,9411,9410,9409,9408,9407,9406,9405,9404,9403,9402,9401,9400,9399,9398,9397,9396,9395,9394,9393,9392,9391,9390,9389,9388,9387,9386,9385,9384,9383,9382,9381,9380,9379,9378,9377,9376,9375,9374,9373,9372,9371,9370,9369,9368,9367,9366,9365,9364,9363,9362,9361,9360,9359,9358,9357,9356,9355,9354,9353,9352,9351,9350,9349,9348,9347,9346,9345,9344,9343,9342,9341,9340,9339,9338,9337,9336,9335,9334,9333,9332,9331,9330,9329,9328,9327,9326,9325,9324,9323,9322,9321,9320,9319,9318,9317,9316,9315,9314,9313,9312,9311,9310,9309,9308,9307,9306,9305,9304,9303,9302,9301,9300,9299,9298,9297,9296,9295,9294,9293,9292,9291,9290,9289,9288,9287,9286,9285,9284,9283,9282,9281,9280,9279,9278,9277,9276,9275,9274,9273,9272,9271,9270,9269,9268,9267,9266,9265,9264,9263,9262,9261,9260,9259,9258,9257,9256,9255,9254,9253,9252,9251,9250,9249,9248,9247,9246,9245,9244,9243,9242,9241,9240,9239,9238,9237,9236,9235,9234,9233,9232,9231,9230,9229,9228,9227,9226,9225,9224,9223,9222,9221,9220,9219,9218,9217,9216,9215,9214,9213,9212,9211,9210,9209,9208,9207,9206,9205,9204,9203,9202,9201,9200,9199,9198,9197,9196,9195,9194,9193,9192,9191,9190,9189,9188,9187,9186,9185,9184,9183,9182,9181,9180,9179,9178,9177,9176,9175,9174,9173,9172,9171,9170,9169,9168,9167,9166,9165,9164,9163,9162,9161,9160,9159,9158,9157,9156,9155,9154,9153,9152,9151,9150,9149,9148,9147,9146,9145,9144,9143,9142,9141,9140,9139,9138,9137,9136,9135,9134,9133,9132,9131,9130,9129,9128,9127,9126,9125,9124,9123,9122,9121,9120,9119,9118,9117,9116,9115,9114,9113,9112,9111,9110,9109,9108,9107,9106,9105,9104,9103,9102,9101,9100,9099,9098,9097,9096,9095,9094,9093,9092,9091,9090,9089,9088,9087,9086,9085,9084,9083,9082,9081,9080,9079,9078,9077,9076,9075,9074,9073,9072,9071,9070,9069,9068,9067,9066,9065,9064,9063,9062,9061,9060,9059,9058,9057,9056,9055,9054,9053,9052,9051,9050,9049,9048,9047,9046,9045,9044,9043,9042,9041,9040,9039,9038,9037,9036,9035,9034,9033,9032,9031,9030,9029,9028,9027,9026,9025,9024,9023,9022,9021,9020,9019,9018,9017,9016,9015,9014,9013,9012,9011,9010,9009,9008,9007,9006,9005,9004,9003,9002,9001,9000,8999,8998,8997,8996,8995,8994,8993,8992,8991,8990,8989,8988,8987,8986,8985,8984,8983,8982,8981,8980,8979,8978,8977,8976,8975,8974,8973,8972,8971,8970,8969,8968,8967,8966,8965,8964,8963,8962,8961,8960,8959,8958,8957,8956,8955,8954,8953,8952,8951,8950,8949,8948,8947,8946,8945,8944,8943,8942,8941,8940,8939,8938,8937,8936,8935,8934,8933,8932,8931,8930,8929,8928,8927,8926,8925,8924,8923,8922,8921,8920,8919,8918,8917,8916,8915,8914,8913,8912,8911,8910,8909,8908,8907,8906,8905,8904,8903,8902,8901,8900,8899,8898,8897,8896,8895,8894,8893,8892,8891,8890,8889,8888,8887,8886,8885,8884,8883,8882,8881,8880,8879,8878,8877,8876,8875,8874,8873,8872,8871,8870,8869,8868,8867,8866,8865,8864,8863,8862,8861,8860,8859,8858,8857,8856,8855,8854,8853,8852,8851,8850,8849,8848,8847,8846,8845,8844,8843,8842,8841,8840,8839,8838,8837,8836,8835,8834,8833,8832,8831,8830,8829,8828,8827,8826,8825,8824,8823,8822,8821,8820,8819,8818,8817,8816,8815,8814,8813,8812,8811,8810,8809,8808,8807,8806,8805,8804,8803,8802,8801,8800,8799,8798,8797,8796,8795,8794,8793,8792,8791,8790,8789,8788,8787,8786,8785,8784,8783,8782,8781,8780,8779,8778,8777,8776,8775,8774,8773,8772,8771,8770,8769,8768,8767,8766,8765,8764,8763,8762,8761,8760,8759,8758,8757,8756,8755,8754,8753,8752,8751,8750,8749,8748,8747,8746,8745,8744,8743,8742,8741,8740,8739,8738,8737,8736,8735,8734,8733,8732,8731,8730,8729,8728,8727,8726,8725,8724,8723,8722,8721,8720,8719,8718,8717,8716,8715,8714,8713,8712,8711,8710,8709,8708,8707,8706,8705,8704,8703,8702,8701,8700,8699,8698,8697,8696,8695,8694,8693,8692,8691,8690,8689,8688,8687,8686,8685,8684,8683,8682,8681,8680,8679,8678,8677,8676,8675,8674,8673,8672,8671,8670,8669,8668,8667,8666,8665,8664,8663,8662,8661,8660,8659,8658,8657,8656,8655,8654,8653,8652,8651,8650,8649,8648,8647,8646,8645,8644,8643,8642,8641,8640,8639,8638,8637,8636,8635,8634,8633,8632,8631,8630,8629,8628,8627,8626,8625,8624,8623,8622,8621,8620,8619,8618,8617,8616,8615,8614,8613,8612,8611,8610,8609,8608,8607,8606,8605,8604,8603,8602,8601,8600,8599,8598,8597,8596,8595,8594,8593,8592,8591,8590,8589,8588,8587,8586,8585,8584,8583,8582,8581,8580,8579,8578,8577,8576,8575,8574,8573,8572,8571,8570,8569,8568,8567,8566,8565,8564,8563,8562,8561,8560,8559,8558,8557,8556,8555,8554,8553,8552,8551,8550,8549,8548,8547,8546,8545,8544,8543,8542,8541,8540,8539,8538,8537,8536,8535,8534,8533,8532,8531,8530,8529,8528,8527,8526,8525,8524,8523,8522,8521,8520,8519,8518,8517,8516,8515,8514,8513,8512,8511,8510,8509,8508,8507,8506,8505,8504,8503,8502,8501,8500,8499,8498,8497,8496,8495,8494,8493,8492,8491,8490,8489,8488,8487,8486,8485,8484,8483,8482,8481,8480,8479,8478,8477,8476,8475,8474,8473,8472,8471,8470,8469,8468,8467,8466,8465,8464,8463,8462,8461,8460,8459,8458,8457,8456,8455,8454,8453,8452,8451,8450,8449,8448,8447,8446,8445,8444,8443,8442,8441,8440,8439,8438,8437,8436,8435,8434,8433,8432,8431,8430,8429,8428,8427,8426,8425,8424,8423,8422,8421,8420,8419,8418,8417,8416,8415,8414,8413,8412,8411,8410,8409,8408,8407,8406,8405,8404,8403,8402,8401,8400,8399,8398,8397,8396,8395,8394,8393,8392,8391,8390,8389,8388,8387,8386,8385,8384,8383,8382,8381,8380,8379,8378,8377,8376,8375,8374,8373,8372,8371,8370,8369,8368,8367,8366,8365,8364,8363,8362,8361,8360,8359,8358,8357,8356,8355,8354,8353,8352,8351,8350,8349,8348,8347,8346,8345,8344,8343,8342,8341,8340,8339,8338,8337,8336,8335,8334,8333,8332,8331,8330,8329,8328,8327,8326,8325,8324,8323,8322,8321,8320,8319,8318,8317,8316,8315,8314,8313,8312,8311,8310,8309,8308,8307,8306,8305,8304,8303,8302,8301,8300,8299,8298,8297,8296,8295,8294,8293,8292,8291,8290,8289,8288,8287,8286,8285,8284,8283,8282,8281,8280,8279,8278,8277,8276,8275,8274,8273,8272,8271,8270,8269,8268,8267,8266,8265,8264,8263,8262,8261,8260,8259,8258,8257,8256,8255,8254,8253,8252,8251,8250,8249,8248,8247,8246,8245,8244,8243,8242,8241,8240,8239,8238,8237,8236,8235,8234,8233,8232,8231,8230,8229,8228,8227,8226,8225,8224,8223,8222,8221,8220,8219,8218,8217,8216,8215,8214,8213,8212,8211,8210,8209,8208,8207,8206,8205,8204,8203,8202,8201,8200,8199,8198,8197,8196,8195,8194,8193,8192,8191,8190,8189,8188,8187,8186,8185,8184,8183,8182,8181,8180,8179,8178,8177,8176,8175,8174,8173,8172,8171,8170,8169,8168,8167,8166,8165,8164,8163,8162,8161,8160,8159,8158,8157,8156,8155,8154,8153,8152,8151,8150,8149,8148,8147,8146,8145,8144,8143,8142,8141,8140,8139,8138,8137,8136,8135,8134,8133,8132,8131,8130,8129,8128,8127,8126,8125,8124,8123,8122,8121,8120,8119,8118,8117,8116,8115,8114,8113,8112,8111,8110,8109,8108,8107,8106,8105,8104,8103,8102,8101,8100,8099,8098,8097,8096,8095,8094,8093,8092,8091,8090,8089,8088,8087,8086,8085,8084,8083,8082,8081,8080,8079,8078,8077,8076,8075,8074,8073,8072,8071,8070,8069,8068,8067,8066,8065,8064,8063,8062,8061,8060,8059,8058,8057,8056,8055,8054,8053,8052,8051,8050,8049,8048,8047,8046,8045,8044,8043,8042,8041,8040,8039,8038,8037,8036,8035,8034,8033,8032,8031,8030,8029,8028,8027,8026,8025,8024,8023,8022,8021,8020,8019,8018,8017,8016,8015,8014,8013,8012,8011,8010,8009,8008,8007,8006,8005,8004,8003,8002,8001,8000,7999,7998,7997,7996,7995,7994,7993,7992,7991,7990,7989,7988,7987,7986,7985,7984,7983,7982,7981,7980,7979,7978,7977,7976,7975,7974,7973,7972,7971,7970,7969,7968,7967,7966,7965,7964,7963,7962,7961,7960,7959,7958,7957,7956,7955,7954,7953,7952,7951,7950,7949,7948,7947,7946,7945,7944,7943,7942,7941,7940,7939,7938,7937,7936,7935,7934,7933,7932,7931,7930,7929,7928,7927,7926,7925,7924,7923,7922,7921,7920,7919,7918,7917,7916,7915,7914,7913,7912,7911,7910,7909,7908,7907,7906,7905,7904,7903,7902,7901,7900,7899,7898,7897,7896,7895,7894,7893,7892,7891,7890,7889,7888,7887,7886,7885,7884,7883,7882,7881,7880,7879,7878,7877,7876,7875,7874,7873,7872,7871,7870,7869,7868,7867,7866,7865,7864,7863,7862,7861,7860,7859,7858,7857,7856,7855,7854,7853,7852,7851,7850,7849,7848,7847,7846,7845,7844,7843,7842,7841,7840,7839,7838,7837,7836,7835,7834,7833,7832,7831,7830,7829,7828,7827,7826,7825,7824,7823,7822,7821,7820,7819,7818,7817,7816,7815,7814,7813,7812,7811,7810,7809,7808,7807,7806,7805,7804,7803,7802,7801,7800,7799,7798,7797,7796,7795,7794,7793,7792,7791,7790,7789,7788,7787,7786,7785,7784,7783,7782,7781,7780,7779,7778,7777,7776,7775,7774,7773,7772,7771,7770,7769,7768,7767,7766,7765,7764,7763,7762,7761,7760,7759,7758,7757,7756,7755,7754,7753,7752,7751,7750,7749,7748,7747,7746,7745,7744,7743,7742,7741,7740,7739,7738,7737,7736,7735,7734,7733,7732,7731,7730,7729,7728,7727,7726,7725,7724,7723,7722,7721,7720,7719,7718,7717,7716,7715,7714,7713,7712,7711,7710,7709,7708,7707,7706,7705,7704,7703,7702,7701,7700,7699,7698,7697,7696,7695,7694,7693,7692,7691,7690,7689,7688,7687,7686,7685,7684,7683,7682,7681,7680,7679,7678,7677,7676,7675,7674,7673,7672,7671,7670,7669,7668,7667,7666,7665,7664,7663,7662,7661,7660,7659,7658,7657,7656,7655,7654,7653,7652,7651,7650,7649,7648,7647,7646,7645,7644,7643,7642,7641,7640,7639,7638,7637,7636,7635,7634,7633,7632,7631,7630,7629,7628,7627,7626,7625,7624,7623,7622,7621,7620,7619,7618,7617,7616,7615,7614,7613,7612,7611,7610,7609,7608,7607,7606,7605,7604,7603,7602,7601,7600,7599,7598,7597,7596,7595,7594,7593,7592,7591,7590,7589,7588,7587,7586,7585,7584,7583,7582,7581,7580,7579,7578,7577,7576,7575,7574,7573,7572,7571,7570,7569,7568,7567,7566,7565,7564,7563,7562,7561,7560,7559,7558,7557,7556,7555,7554,7553,7552,7551,7550,7549,7548,7547,7546,7545,7544,7543,7542,7541,7540,7539,7538,7537,7536,7535,7534,7533,7532,7531,7530,7529,7528,7527,7526,7525,7524,7523,7522,7521,7520,7519,7518,7517,7516,7515,7514,7513,7512,7511,7510,7509,7508,7507,7506,7505,7504,7503,7502,7501,7500,7499,7498,7497,7496,7495,7494,7493,7492,7491,7490,7489,7488,7487,7486,7485,7484,7483,7482,7481,7480,7479,7478,7477,7476,7475,7474,7473,7472,7471,7470,7469,7468,7467,7466,7465,7464,7463,7462,7461,7460,7459,7458,7457,7456,7455,7454,7453,7452,7451,7450,7449,7448,7447,7446,7445,7444,7443,7442,7441,7440,7439,7438,7437,7436,7435,7434,7433,7432,7431,7430,7429,7428,7427,7426,7425,7424,7423,7422,7421,7420,7419,7418,7417,7416,7415,7414,7413,7412,7411,7410,7409,7408,7407,7406,7405,7404,7403,7402,7401,7400,7399,7398,7397,7396,7395,7394,7393,7392,7391,7390,7389,7388,7387,7386,7385,7384,7383,7382,7381,7380,7379,7378,7377,7376,7375,7374,7373,7372,7371,7370,7369,7368,7367,7366,7365,7364,7363,7362,7361,7360,7359,7358,7357,7356,7355,7354,7353,7352,7351,7350,7349,7348,7347,7346,7345,7344,7343,7342,7341,7340,7339,7338,7337,7336,7335,7334,7333,7332,7331,7330,7329,7328,7327,7326,7325,7324,7323,7322,7321,7320,7319,7318,7317,7316,7315,7314,7313,7312,7311,7310,7309,7308,7307,7306,7305,7304,7303,7302,7301,7300,7299,7298,7297,7296,7295,7294,7293,7292,7291,7290,7289,7288,7287,7286,7285,7284,7283,7282,7281,7280,7279,7278,7277,7276,7275,7274,7273,7272,7271,7270,7269,7268,7267,7266,7265,7264,7263,7262,7261,7260,7259,7258,7257,7256,7255,7254,7253,7252,7251,7250,7249,7248,7247,7246,7245,7244,7243,7242,7241,7240,7239,7238,7237,7236,7235,7234,7233,7232,7231,7230,7229,7228,7227,7226,7225,7224,7223,7222,7221,7220,7219,7218,7217,7216,7215,7214,7213,7212,7211,7210,7209,7208,7207,7206,7205,7204,7203,7202,7201,7200,7199,7198,7197,7196,7195,7194,7193,7192,7191,7190,7189,7188,7187,7186,7185,7184,7183,7182,7181,7180,7179,7178,7177,7176,7175,7174,7173,7172,7171,7170,7169,7168,7167,7166,7165,7164,7163,7162,7161,7160,7159,7158,7157,7156,7155,7154,7153,7152,7151,7150,7149,7148,7147,7146,7145,7144,7143,7142,7141,7140,7139,7138,7137,7136,7135,7134,7133,7132,7131,7130,7129,7128,7127,7126,7125,7124,7123,7122,7121,7120,7119,7118,7117,7116,7115,7114,7113,7112,7111,7110,7109,7108,7107,7106,7105,7104,7103,7102,7101,7100,7099,7098,7097,7096,7095,7094,7093,7092,7091,7090,7089,7088,7087,7086,7085,7084,7083,7082,7081,7080,7079,7078,7077,7076,7075,7074,7073,7072,7071,7070,7069,7068,7067,7066,7065,7064,7063,7062,7061,7060,7059,7058,7057,7056,7055,7054,7053,7052,7051,7050,7049,7048,7047,7046,7045,7044,7043,7042,7041,7040,7039,7038,7037,7036,7035,7034,7033,7032,7031,7030,7029,7028,7027,7026,7025,7024,7023,7022,7021,7020,7019,7018,7017,7016,7015,7014,7013,7012,7011,7010,7009,7008,7007,7006,7005,7004,7003,7002,7001,7000,6999,6998,6997,6996,6995,6994,6993,6992,6991,6990,6989,6988,6987,6986,6985,6984,6983,6982,6981,6980,6979,6978,6977,6976,6975,6974,6973,6972,6971,6970,6969,6968,6967,6966,6965,6964,6963,6962,6961,6960,6959,6958,6957,6956,6955,6954,6953,6952,6951,6950,6949,6948,6947,6946,6945,6944,6943,6942,6941,6940,6939,6938,6937,6936,6935,6934,6933,6932,6931,6930,6929,6928,6927,6926,6925,6924,6923,6922,6921,6920,6919,6918,6917,6916,6915,6914,6913,6912,6911,6910,6909,6908,6907,6906,6905,6904,6903,6902,6901,6900,6899,6898,6897,6896,6895,6894,6893,6892,6891,6890,6889,6888,6887,6886,6885,6884,6883,6882,6881,6880,6879,6878,6877,6876,6875,6874,6873,6872,6871,6870,6869,6868,6867,6866,6865,6864,6863,6862,6861,6860,6859,6858,6857,6856,6855,6854,6853,6852,6851,6850,6849,6848,6847,6846,6845,6844,6843,6842,6841,6840,6839,6838,6837,6836,6835,6834,6833,6832,6831,6830,6829,6828,6827,6826,6825,6824,6823,6822,6821,6820,6819,6818,6817,6816,6815,6814,6813,6812,6811,6810,6809,6808,6807,6806,6805,6804,6803,6802,6801,6800,6799,6798,6797,6796,6795,6794,6793,6792,6791,6790,6789,6788,6787,6786,6785,6784,6783,6782,6781,6780,6779,6778,6777,6776,6775,6774,6773,6772,6771,6770,6769,6768,6767,6766,6765,6764,6763,6762,6761,6760,6759,6758,6757,6756,6755,6754,6753,6752,6751,6750,6749,6748,6747,6746,6745,6744,6743,6742,6741,6740,6739,6738,6737,6736,6735,6734,6733,6732,6731,6730,6729,6728,6727,6726,6725,6724,6723,6722,6721,6720,6719,6718,6717,6716,6715,6714,6713,6712,6711,6710,6709,6708,6707,6706,6705,6704,6703,6702,6701,6700,6699,6698,6697,6696,6695,6694,6693,6692,6691,6690,6689,6688,6687,6686,6685,6684,6683,6682,6681,6680,6679,6678,6677,6676,6675,6674,6673,6672,6671,6670,6669,6668,6667,6666,6665,6664,6663,6662,6661,6660,6659,6658,6657,6656,6655,6654,6653,6652,6651,6650,6649,6648,6647,6646,6645,6644,6643,6642,6641,6640,6639,6638,6637,6636,6635,6634,6633,6632,6631,6630,6629,6628,6627,6626,6625,6624,6623,6622,6621,6620,6619,6618,6617,6616,6615,6614,6613,6612,6611,6610,6609,6608,6607,6606,6605,6604,6603,6602,6601,6600,6599,6598,6597,6596,6595,6594,6593,6592,6591,6590,6589,6588,6587,6586,6585,6584,6583,6582,6581,6580,6579,6578,6577,6576,6575,6574,6573,6572,6571,6570,6569,6568,6567,6566,6565,6564,6563,6562,6561,6560,6559,6558,6557,6556,6555,6554,6553,6552,6551,6550,6549,6548,6547,6546,6545,6544,6543,6542,6541,6540,6539,6538,6537,6536,6535,6534,6533,6532,6531,6530,6529,6528,6527,6526,6525,6524,6523,6522,6521,6520,6519,6518,6517,6516,6515,6514,6513,6512,6511,6510,6509,6508,6507,6506,6505,6504,6503,6502,6501,6500,6499,6498,6497,6496,6495,6494,6493,6492,6491,6490,6489,6488,6487,6486,6485,6484,6483,6482,6481,6480,6479,6478,6477,6476,6475,6474,6473,6472,6471,6470,6469,6468,6467,6466,6465,6464,6463,6462,6461,6460,6459,6458,6457,6456,6455,6454,6453,6452,6451,6450,6449,6448,6447,6446,6445,6444,6443,6442,6441,6440,6439,6438,6437,6436,6435,6434,6433,6432,6431,6430,6429,6428,6427,6426,6425,6424,6423,6422,6421,6420,6419,6418,6417,6416,6415,6414,6413,6412,6411,6410,6409,6408,6407,6406,6405,6404,6403,6402,6401,6400,6399,6398,6397,6396,6395,6394,6393,6392,6391,6390,6389,6388,6387,6386,6385,6384,6383,6382,6381,6380,6379,6378,6377,6376,6375,6374,6373,6372,6371,6370,6369,6368,6367,6366,6365,6364,6363,6362,6361,6360,6359,6358,6357,6356,6355,6354,6353,6352,6351,6350,6349,6348,6347,6346,6345,6344,6343,6342,6341,6340,6339,6338,6337,6336,6335,6334,6333,6332,6331,6330,6329,6328,6327,6326,6325,6324,6323,6322,6321,6320,6319,6318,6317,6316,6315,6314,6313,6312,6311,6310,6309,6308,6307,6306,6305,6304,6303,6302,6301,6300,6299,6298,6297,6296,6295,6294,6293,6292,6291,6290,6289,6288,6287,6286,6285,6284,6283,6282,6281,6280,6279,6278,6277,6276,6275,6274,6273,6272,6271,6270,6269,6268,6267,6266,6265,6264,6263,6262,6261,6260,6259,6258,6257,6256,6255,6254,6253,6252,6251,6250,6249,6248,6247,6246,6245,6244,6243,6242,6241,6240,6239,6238,6237,6236,6235,6234,6233,6232,6231,6230,6229,6228,6227,6226,6225,6224,6223,6222,6221,6220,6219,6218,6217,6216,6215,6214,6213,6212,6211,6210,6209,6208,6207,6206,6205,6204,6203,6202,6201,6200,6199,6198,6197,6196,6195,6194,6193,6192,6191,6190,6189,6188,6187,6186,6185,6184,6183,6182,6181,6180,6179,6178,6177,6176,6175,6174,6173,6172,6171,6170,6169,6168,6167,6166,6165,6164,6163,6162,6161,6160,6159,6158,6157,6156,6155,6154,6153,6152,6151,6150,6149,6148,6147,6146,6145,6144,6143,6142,6141,6140,6139,6138,6137,6136,6135,6134,6133,6132,6131,6130,6129,6128,6127,6126,6125,6124,6123,6122,6121,6120,6119,6118,6117,6116,6115,6114,6113,6112,6111,6110,6109,6108,6107,6106,6105,6104,6103,6102,6101,6100,6099,6098,6097,6096,6095,6094,6093,6092,6091,6090,6089,6088,6087,6086,6085,6084,6083,6082,6081,6080,6079,6078,6077,6076,6075,6074,6073,6072,6071,6070,6069,6068,6067,6066,6065,6064,6063,6062,6061,6060,6059,6058,6057,6056,6055,6054,6053,6052,6051,6050,6049,6048,6047,6046,6045,6044,6043,6042,6041,6040,6039,6038,6037,6036,6035,6034,6033,6032,6031,6030,6029,6028,6027,6026,6025,6024,6023,6022,6021,6020,6019,6018,6017,6016,6015,6014,6013,6012,6011,6010,6009,6008,6007,6006,6005,6004,6003,6002,6001,6000,5999,5998,5997,5996,5995,5994,5993,5992,5991,5990,5989,5988,5987,5986,5985,5984,5983,5982,5981,5980,5979,5978,5977,5976,5975,5974,5973,5972,5971,5970,5969,5968,5967,5966,5965,5964,5963,5962,5961,5960,5959,5958,5957,5956,5955,5954,5953,5952,5951,5950,5949,5948,5947,5946,5945,5944,5943,5942,5941,5940,5939,5938,5937,5936,5935,5934,5933,5932,5931,5930,5929,5928,5927,5926,5925,5924,5923,5922,5921,5920,5919,5918,5917,5916,5915,5914,5913,5912,5911,5910,5909,5908,5907,5906,5905,5904,5903,5902,5901,5900,5899,5898,5897,5896,5895,5894,5893,5892,5891,5890,5889,5888,5887,5886,5885,5884,5883,5882,5881,5880,5879,5878,5877,5876,5875,5874,5873,5872,5871,5870,5869,5868,5867,5866,5865,5864,5863,5862,5861,5860,5859,5858,5857,5856,5855,5854,5853,5852,5851,5850,5849,5848,5847,5846,5845,5844,5843,5842,5841,5840,5839,5838,5837,5836,5835,5834,5833,5832,5831,5830,5829,5828,5827,5826,5825,5824,5823,5822,5821,5820,5819,5818,5817,5816,5815,5814,5813,5812,5811,5810,5809,5808,5807,5806,5805,5804,5803,5802,5801,5800,5799,5798,5797,5796,5795,5794,5793,5792,5791,5790,5789,5788,5787,5786,5785,5784,5783,5782,5781,5780,5779,5778,5777,5776,5775,5774,5773,5772,5771,5770,5769,5768,5767,5766,5765,5764,5763,5762,5761,5760,5759,5758,5757,5756,5755,5754,5753,5752,5751,5750,5749,5748,5747,5746,5745,5744,5743,5742,5741,5740,5739,5738,5737,5736,5735,5734,5733,5732,5731,5730,5729,5728,5727,5726,5725,5724,5723,5722,5721,5720,5719,5718,5717,5716,5715,5714,5713,5712,5711,5710,5709,5708,5707,5706,5705,5704,5703,5702,5701,5700,5699,5698,5697,5696,5695,5694,5693,5692,5691,5690,5689,5688,5687,5686,5685,5684,5683,5682,5681,5680,5679,5678,5677,5676,5675,5674,5673,5672,5671,5670,5669,5668,5667,5666,5665,5664,5663,5662,5661,5660,5659,5658,5657,5656,5655,5654,5653,5652,5651,5650,5649,5648,5647,5646,5645,5644,5643,5642,5641,5640,5639,5638,5637,5636,5635,5634,5633,5632,5631,5630,5629,5628,5627,5626,5625,5624,5623,5622,5621,5620,5619,5618,5617,5616,5615,5614,5613,5612,5611,5610,5609,5608,5607,5606,5605,5604,5603,5602,5601,5600,5599,5598,5597,5596,5595,5594,5593,5592,5591,5590,5589,5588,5587,5586,5585,5584,5583,5582,5581,5580,5579,5578,5577,5576,5575,5574,5573,5572,5571,5570,5569,5568,5567,5566,5565,5564,5563,5562,5561,5560,5559,5558,5557,5556,5555,5554,5553,5552,5551,5550,5549,5548,5547,5546,5545,5544,5543,5542,5541,5540,5539,5538,5537,5536,5535,5534,5533,5532,5531,5530,5529,5528,5527,5526,5525,5524,5523,5522,5521,5520,5519,5518,5517,5516,5515,5514,5513,5512,5511,5510,5509,5508,5507,5506,5505,5504,5503,5502,5501,5500,5499,5498,5497,5496,5495,5494,5493,5492,5491,5490,5489,5488,5487,5486,5485,5484,5483,5482,5481,5480,5479,5478,5477,5476,5475,5474,5473,5472,5471,5470,5469,5468,5467,5466,5465,5464,5463,5462,5461,5460,5459,5458,5457,5456,5455,5454,5453,5452,5451,5450,5449,5448,5447,5446,5445,5444,5443,5442,5441,5440,5439,5438,5437,5436,5435,5434,5433,5432,5431,5430,5429,5428,5427,5426,5425,5424,5423,5422,5421,5420,5419,5418,5417,5416,5415,5414,5413,5412,5411,5410,5409,5408,5407,5406,5405,5404,5403,5402,5401,5400,5399,5398,5397,5396,5395,5394,5393,5392,5391,5390,5389,5388,5387,5386,5385,5384,5383,5382,5381,5380,5379,5378,5377,5376,5375,5374,5373,5372,5371,5370,5369,5368,5367,5366,5365,5364,5363,5362,5361,5360,5359,5358,5357,5356,5355,5354,5353,5352,5351,5350,5349,5348,5347,5346,5345,5344,5343,5342,5341,5340,5339,5338,5337,5336,5335,5334,5333,5332,5331,5330,5329,5328,5327,5326,5325,5324,5323,5322,5321,5320,5319,5318,5317,5316,5315,5314,5313,5312,5311,5310,5309,5308,5307,5306,5305,5304,5303,5302,5301,5300,5299,5298,5297,5296,5295,5294,5293,5292,5291,5290,5289,5288,5287,5286,5285,5284,5283,5282,5281,5280,5279,5278,5277,5276,5275,5274,5273,5272,5271,5270,5269,5268,5267,5266,5265,5264,5263,5262,5261,5260,5259,5258,5257,5256,5255,5254,5253,5252,5251,5250,5249,5248,5247,5246,5245,5244,5243,5242,5241,5240,5239,5238,5237,5236,5235,5234,5233,5232,5231,5230,5229,5228,5227,5226,5225,5224,5223,5222,5221,5220,5219,5218,5217,5216,5215,5214,5213,5212,5211,5210,5209,5208,5207,5206,5205,5204,5203,5202,5201,5200,5199,5198,5197,5196,5195,5194,5193,5192,5191,5190,5189,5188,5187,5186,5185,5184,5183,5182,5181,5180,5179,5178,5177,5176,5175,5174,5173,5172,5171,5170,5169,5168,5167,5166,5165,5164,5163,5162,5161,5160,5159,5158,5157,5156,5155,5154,5153,5152,5151,5150,5149,5148,5147,5146,5145,5144,5143,5142,5141,5140,5139,5138,5137,5136,5135,5134,5133,5132,5131,5130,5129,5128,5127,5126,5125,5124,5123,5122,5121,5120,5119,5118,5117,5116,5115,5114,5113,5112,5111,5110,5109,5108,5107,5106,5105,5104,5103,5102,5101,5100,5099,5098,5097,5096,5095,5094,5093,5092,5091,5090,5089,5088,5087,5086,5085,5084,5083,5082,5081,5080,5079,5078,5077,5076,5075,5074,5073,5072,5071,5070,5069,5068,5067,5066,5065,5064,5063,5062,5061,5060,5059,5058,5057,5056,5055,5054,5053,5052,5051,5050,5049,5048,5047,5046,5045,5044,5043,5042,5041,5040,5039,5038,5037,5036,5035,5034,5033,5032,5031,5030,5029,5028,5027,5026,5025,5024,5023,5022,5021,5020,5019,5018,5017,5016,5015,5014,5013,5012,5011,5010,5009,5008,5007,5006,5005,5004,5003,5002,5001,5000,4999,4998,4997,4996,4995,4994,4993,4992,4991,4990,4989,4988,4987,4986,4985,4984,4983,4982,4981,4980,4979,4978,4977,4976,4975,4974,4973,4972,4971,4970,4969,4968,4967,4966,4965,4964,4963,4962,4961,4960,4959,4958,4957,4956,4955,4954,4953,4952,4951,4950,4949,4948,4947,4946,4945,4944,4943,4942,4941,4940,4939,4938,4937,4936,4935,4934,4933,4932,4931,4930,4929,4928,4927,4926,4925,4924,4923,4922,4921,4920,4919,4918,4917,4916,4915,4914,4913,4912,4911,4910,4909,4908,4907,4906,4905,4904,4903,4902,4901,4900,4899,4898,4897,4896,4895,4894,4893,4892,4891,4890,4889,4888,4887,4886,4885,4884,4883,4882,4881,4880,4879,4878,4877,4876,4875,4874,4873,4872,4871,4870,4869,4868,4867,4866,4865,4864,4863,4862,4861,4860,4859,4858,4857,4856,4855,4854,4853,4852,4851,4850,4849,4848,4847,4846,4845,4844,4843,4842,4841,4840,4839,4838,4837,4836,4835,4834,4833,4832,4831,4830,4829,4828,4827,4826,4825,4824,4823,4822,4821,4820,4819,4818,4817,4816,4815,4814,4813,4812,4811,4810,4809,4808,4807,4806,4805,4804,4803,4802,4801,4800,4799,4798,4797,4796,4795,4794,4793,4792,4791,4790,4789,4788,4787,4786,4785,4784,4783,4782,4781,4780,4779,4778,4777,4776,4775,4774,4773,4772,4771,4770,4769,4768,4767,4766,4765,4764,4763,4762,4761,4760,4759,4758,4757,4756,4755,4754,4753,4752,4751,4750,4749,4748,4747,4746,4745,4744,4743,4742,4741,4740,4739,4738,4737,4736,4735,4734,4733,4732,4731,4730,4729,4728,4727,4726,4725,4724,4723,4722,4721,4720,4719,4718,4717,4716,4715,4714,4713,4712,4711,4710,4709,4708,4707,4706,4705,4704,4703,4702,4701,4700,4699,4698,4697,4696,4695,4694,4693,4692,4691,4690,4689,4688,4687,4686,4685,4684,4683,4682,4681,4680,4679,4678,4677,4676,4675,4674,4673,4672,4671,4670,4669,4668,4667,4666,4665,4664,4663,4662,4661,4660,4659,4658,4657,4656,4655,4654,4653,4652,4651,4650,4649,4648,4647,4646,4645,4644,4643,4642,4641,4640,4639,4638,4637,4636,4635,4634,4633,4632,4631,4630,4629,4628,4627,4626,4625,4624,4623,4622,4621,4620,4619,4618,4617,4616,4615,4614,4613,4612,4611,4610,4609,4608,4607,4606,4605,4604,4603,4602,4601,4600,4599,4598,4597,4596,4595,4594,4593,4592,4591,4590,4589,4588,4587,4586,4585,4584,4583,4582,4581,4580,4579,4578,4577,4576,4575,4574,4573,4572,4571,4570,4569,4568,4567,4566,4565,4564,4563,4562,4561,4560,4559,4558,4557,4556,4555,4554,4553,4552,4551,4550,4549,4548,4547,4546,4545,4544,4543,4542,4541,4540,4539,4538,4537,4536,4535,4534,4533,4532,4531,4530,4529,4528,4527,4526,4525,4524,4523,4522,4521,4520,4519,4518,4517,4516,4515,4514,4513,4512,4511,4510,4509,4508,4507,4506,4505,4504,4503,4502,4501,4500,4499,4498,4497,4496,4495,4494,4493,4492,4491,4490,4489,4488,4487,4486,4485,4484,4483,4482,4481,4480,4479,4478,4477,4476,4475,4474,4473,4472,4471,4470,4469,4468,4467,4466,4465,4464,4463,4462,4461,4460,4459,4458,4457,4456,4455,4454,4453,4452,4451,4450,4449,4448,4447,4446,4445,4444,4443,4442,4441,4440,4439,4438,4437,4436,4435,4434,4433,4432,4431,4430,4429,4428,4427,4426,4425,4424,4423,4422,4421,4420,4419,4418,4417,4416,4415,4414,4413,4412,4411,4410,4409,4408,4407,4406,4405,4404,4403,4402,4401,4400,4399,4398,4397,4396,4395,4394,4393,4392,4391,4390,4389,4388,4387,4386,4385,4384,4383,4382,4381,4380,4379,4378,4377,4376,4375,4374,4373,4372,4371,4370,4369,4368,4367,4366,4365,4364,4363,4362,4361,4360,4359,4358,4357,4356,4355,4354,4353,4352,4351,4350,4349,4348,4347,4346,4345,4344,4343,4342,4341,4340,4339,4338,4337,4336,4335,4334,4333,4332,4331,4330,4329,4328,4327,4326,4325,4324,4323,4322,4321,4320,4319,4318,4317,4316,4315,4314,4313,4312,4311,4310,4309,4308,4307,4306,4305,4304,4303,4302,4301,4300,4299,4298,4297,4296,4295,4294,4293,4292,4291,4290,4289,4288,4287,4286,4285,4284,4283,4282,4281,4280,4279,4278,4277,4276,4275,4274,4273,4272,4271,4270,4269,4268,4267,4266,4265,4264,4263,4262,4261,4260,4259,4258,4257,4256,4255,4254,4253,4252,4251,4250,4249,4248,4247,4246,4245,4244,4243,4242,4241,4240,4239,4238,4237,4236,4235,4234,4233,4232,4231,4230,4229,4228,4227,4226,4225,4224,4223,4222,4221,4220,4219,4218,4217,4216,4215,4214,4213,4212,4211,4210,4209,4208,4207,4206,4205,4204,4203,4202,4201,4200,4199,4198,4197,4196,4195,4194,4193,4192,4191,4190,4189,4188,4187,4186,4185,4184,4183,4182,4181,4180,4179,4178,4177,4176,4175,4174,4173,4172,4171,4170,4169,4168,4167,4166,4165,4164,4163,4162,4161,4160,4159,4158,4157,4156,4155,4154,4153,4152,4151,4150,4149,4148,4147,4146,4145,4144,4143,4142,4141,4140,4139,4138,4137,4136,4135,4134,4133,4132,4131,4130,4129,4128,4127,4126,4125,4124,4123,4122,4121,4120,4119,4118,4117,4116,4115,4114,4113,4112,4111,4110,4109,4108,4107,4106,4105,4104,4103,4102,4101,4100,4099,4098,4097,4096,4095,4094,4093,4092,4091,4090,4089,4088,4087,4086,4085,4084,4083,4082,4081,4080,4079,4078,4077,4076,4075,4074,4073,4072,4071,4070,4069,4068,4067,4066,4065,4064,4063,4062,4061,4060,4059,4058,4057,4056,4055,4054,4053,4052,4051,4050,4049,4048,4047,4046,4045,4044,4043,4042,4041,4040,4039,4038,4037,4036,4035,4034,4033,4032,4031,4030,4029,4028,4027,4026,4025,4024,4023,4022,4021,4020,4019,4018,4017,4016,4015,4014,4013,4012,4011,4010,4009,4008,4007,4006,4005,4004,4003,4002,4001,4000,3999,3998,3997,3996,3995,3994,3993,3992,3991,3990,3989,3988,3987,3986,3985,3984,3983,3982,3981,3980,3979,3978,3977,3976,3975,3974,3973,3972,3971,3970,3969,3968,3967,3966,3965,3964,3963,3962,3961,3960,3959,3958,3957,3956,3955,3954,3953,3952,3951,3950,3949,3948,3947,3946,3945,3944,3943,3942,3941,3940,3939,3938,3937,3936,3935,3934,3933,3932,3931,3930,3929,3928,3927,3926,3925,3924,3923,3922,3921,3920,3919,3918,3917,3916,3915,3914,3913,3912,3911,3910,3909,3908,3907,3906,3905,3904,3903,3902,3901,3900,3899,3898,3897,3896,3895,3894,3893,3892,3891,3890,3889,3888,3887,3886,3885,3884,3883,3882,3881,3880,3879,3878,3877,3876,3875,3874,3873,3872,3871,3870,3869,3868,3867,3866,3865,3864,3863,3862,3861,3860,3859,3858,3857,3856,3855,3854,3853,3852,3851,3850,3849,3848,3847,3846,3845,3844,3843,3842,3841,3840,3839,3838,3837,3836,3835,3834,3833,3832,3831,3830,3829,3828,3827,3826,3825,3824,3823,3822,3821,3820,3819,3818,3817,3816,3815,3814,3813,3812,3811,3810,3809,3808,3807,3806,3805,3804,3803,3802,3801,3800,3799,3798,3797,3796,3795,3794,3793,3792,3791,3790,3789,3788,3787,3786,3785,3784,3783,3782,3781,3780,3779,3778,3777,3776,3775,3774,3773,3772,3771,3770,3769,3768,3767,3766,3765,3764,3763,3762,3761,3760,3759,3758,3757,3756,3755,3754,3753,3752,3751,3750,3749,3748,3747,3746,3745,3744,3743,3742,3741,3740,3739,3738,3737,3736,3735,3734,3733,3732,3731,3730,3729,3728,3727,3726,3725,3724,3723,3722,3721,3720,3719,3718,3717,3716,3715,3714,3713,3712,3711,3710,3709,3708,3707,3706,3705,3704,3703,3702,3701,3700,3699,3698,3697,3696,3695,3694,3693,3692,3691,3690,3689,3688,3687,3686,3685,3684,3683,3682,3681,3680,3679,3678,3677,3676,3675,3674,3673,3672,3671,3670,3669,3668,3667,3666,3665,3664,3663,3662,3661,3660,3659,3658,3657,3656,3655,3654,3653,3652,3651,3650,3649,3648,3647,3646,3645,3644,3643,3642,3641,3640,3639,3638,3637,3636,3635,3634,3633,3632,3631,3630,3629,3628,3627,3626,3625,3624,3623,3622,3621,3620,3619,3618,3617,3616,3615,3614,3613,3612,3611,3610,3609,3608,3607,3606,3605,3604,3603,3602,3601,3600,3599,3598,3597,3596,3595,3594,3593,3592,3591,3590,3589,3588,3587,3586,3585,3584,3583,3582,3581,3580,3579,3578,3577,3576,3575,3574,3573,3572,3571,3570,3569,3568,3567,3566,3565,3564,3563,3562,3561,3560,3559,3558,3557,3556,3555,3554,3553,3552,3551,3550,3549,3548,3547,3546,3545,3544,3543,3542,3541,3540,3539,3538,3537,3536,3535,3534,3533,3532,3531,3530,3529,3528,3527,3526,3525,3524,3523,3522,3521,3520,3519,3518,3517,3516,3515,3514,3513,3512,3511,3510,3509,3508,3507,3506,3505,3504,3503,3502,3501,3500,3499,3498,3497,3496,3495,3494,3493,3492,3491,3490,3489,3488,3487,3486,3485,3484,3483,3482,3481,3480,3479,3478,3477,3476,3475,3474,3473,3472,3471,3470,3469,3468,3467,3466,3465,3464,3463,3462,3461,3460,3459,3458,3457,3456,3455,3454,3453,3452,3451,3450,3449,3448,3447,3446,3445,3444,3443,3442,3441,3440,3439,3438,3437,3436,3435,3434,3433,3432,3431,3430,3429,3428,3427,3426,3425,3424,3423,3422,3421,3420,3419,3418,3417,3416,3415,3414,3413,3412,3411,3410,3409,3408,3407,3406,3405,3404,3403,3402,3401,3400,3399,3398,3397,3396,3395,3394,3393,3392,3391,3390,3389,3388,3387,3386,3385,3384,3383,3382,3381,3380,3379,3378,3377,3376,3375,3374,3373,3372,3371,3370,3369,3368,3367,3366,3365,3364,3363,3362,3361,3360,3359,3358,3357,3356,3355,3354,3353,3352,3351,3350,3349,3348,3347,3346,3345,3344,3343,3342,3341,3340,3339,3338,3337,3336,3335,3334,3333,3332,3331,3330,3329,3328,3327,3326,3325,3324,3323,3322,3321,3320,3319,3318,3317,3316,3315,3314,3313,3312,3311,3310,3309,3308,3307,3306,3305,3304,3303,3302,3301,3300,3299,3298,3297,3296,3295,3294,3293,3292,3291,3290,3289,3288,3287,3286,3285,3284,3283,3282,3281,3280,3279,3278,3277,3276,3275,3274,3273,3272,3271,3270,3269,3268,3267,3266,3265,3264,3263,3262,3261,3260,3259,3258,3257,3256,3255,3254,3253,3252,3251,3250,3249,3248,3247,3246,3245,3244,3243,3242,3241,3240,3239,3238,3237,3236,3235,3234,3233,3232,3231,3230,3229,3228,3227,3226,3225,3224,3223,3222,3221,3220,3219,3218,3217,3216,3215,3214,3213,3212,3211,3210,3209,3208,3207,3206,3205,3204,3203,3202,3201,3200,3199,3198,3197,3196,3195,3194,3193,3192,3191,3190,3189,3188,3187,3186,3185,3184,3183,3182,3181,3180,3179,3178,3177,3176,3175,3174,3173,3172,3171,3170,3169,3168,3167,3166,3165,3164,3163,3162,3161,3160,3159,3158,3157,3156,3155,3154,3153,3152,3151,3150,3149,3148,3147,3146,3145,3144,3143,3142,3141,3140,3139,3138,3137,3136,3135,3134,3133,3132,3131,3130,3129,3128,3127,3126,3125,3124,3123,3122,3121,3120,3119,3118,3117,3116,3115,3114,3113,3112,3111,3110,3109,3108,3107,3106,3105,3104,3103,3102,3101,3100,3099,3098,3097,3096,3095,3094,3093,3092,3091,3090,3089,3088,3087,3086,3085,3084,3083,3082,3081,3080,3079,3078,3077,3076,3075,3074,3073,3072,3071,3070,3069,3068,3067,3066,3065,3064,3063,3062,3061,3060,3059,3058,3057,3056,3055,3054,3053,3052,3051,3050,3049,3048,3047,3046,3045,3044,3043,3042,3041,3040,3039,3038,3037,3036,3035,3034,3033,3032,3031,3030,3029,3028,3027,3026,3025,3024,3023,3022,3021,3020,3019,3018,3017,3016,3015,3014,3013,3012,3011,3010,3009,3008,3007,3006,3005,3004,3003,3002,3001,3000,2999,2998,2997,2996,2995,2994,2993,2992,2991,2990,2989,2988,2987,2986,2985,2984,2983,2982,2981,2980,2979,2978,2977,2976,2975,2974,2973,2972,2971,2970,2969,2968,2967,2966,2965,2964,2963,2962,2961,2960,2959,2958,2957,2956,2955,2954,2953,2952,2951,2950,2949,2948,2947,2946,2945,2944,2943,2942,2941,2940,2939,2938,2937,2936,2935,2934,2933,2932,2931,2930,2929,2928,2927,2926,2925,2924,2923,2922,2921,2920,2919,2918,2917,2916,2915,2914,2913,2912,2911,2910,2909,2908,2907,2906,2905,2904,2903,2902,2901,2900,2899,2898,2897,2896,2895,2894,2893,2892,2891,2890,2889,2888,2887,2886,2885,2884,2883,2882,2881,2880,2879,2878,2877,2876,2875,2874,2873,2872,2871,2870,2869,2868,2867,2866,2865,2864,2863,2862,2861,2860,2859,2858,2857,2856,2855,2854,2853,2852,2851,2850,2849,2848,2847,2846,2845,2844,2843,2842,2841,2840,2839,2838,2837,2836,2835,2834,2833,2832,2831,2830,2829,2828,2827,2826,2825,2824,2823,2822,2821,2820,2819,2818,2817,2816,2815,2814,2813,2812,2811,2810,2809,2808,2807,2806,2805,2804,2803,2802,2801,2800,2799,2798,2797,2796,2795,2794,2793,2792,2791,2790,2789,2788,2787,2786,2785,2784,2783,2782,2781,2780,2779,2778,2777,2776,2775,2774,2773,2772,2771,2770,2769,2768,2767,2766,2765,2764,2763,2762,2761,2760,2759,2758,2757,2756,2755,2754,2753,2752,2751,2750,2749,2748,2747,2746,2745,2744,2743,2742,2741,2740,2739,2738,2737,2736,2735,2734,2733,2732,2731,2730,2729,2728,2727,2726,2725,2724,2723,2722,2721,2720,2719,2718,2717,2716,2715,2714,2713,2712,2711,2710,2709,2708,2707,2706,2705,2704,2703,2702,2701,2700,2699,2698,2697,2696,2695,2694,2693,2692,2691,2690,2689,2688,2687,2686,2685,2684,2683,2682,2681,2680,2679,2678,2677,2676,2675,2674,2673,2672,2671,2670,2669,2668,2667,2666,2665,2664,2663,2662,2661,2660,2659,2658,2657,2656,2655,2654,2653,2652,2651,2650,2649,2648,2647,2646,2645,2644,2643,2642,2641,2640,2639,2638,2637,2636,2635,2634,2633,2632,2631,2630,2629,2628,2627,2626,2625,2624,2623,2622,2621,2620,2619,2618,2617,2616,2615,2614,2613,2612,2611,2610,2609,2608,2607,2606,2605,2604,2603,2602,2601,2600,2599,2598,2597,2596,2595,2594,2593,2592,2591,2590,2589,2588,2587,2586,2585,2584,2583,2582,2581,2580,2579,2578,2577,2576,2575,2574,2573,2572,2571,2570,2569,2568,2567,2566,2565,2564,2563,2562,2561,2560,2559,2558,2557,2556,2555,2554,2553,2552,2551,2550,2549,2548,2547,2546,2545,2544,2543,2542,2541,2540,2539,2538,2537,2536,2535,2534,2533,2532,2531,2530,2529,2528,2527,2526,2525,2524,2523,2522,2521,2520,2519,2518,2517,2516,2515,2514,2513,2512,2511,2510,2509,2508,2507,2506,2505,2504,2503,2502,2501,2500,2499,2498,2497,2496,2495,2494,2493,2492,2491,2490,2489,2488,2487,2486,2485,2484,2483,2482,2481,2480,2479,2478,2477,2476,2475,2474,2473,2472,2471,2470,2469,2468,2467,2466,2465,2464,2463,2462,2461,2460,2459,2458,2457,2456,2455,2454,2453,2452,2451,2450,2449,2448,2447,2446,2445,2444,2443,2442,2441,2440,2439,2438,2437,2436,2435,2434,2433,2432,2431,2430,2429,2428,2427,2426,2425,2424,2423,2422,2421,2420,2419,2418,2417,2416,2415,2414,2413,2412,2411,2410,2409,2408,2407,2406,2405,2404,2403,2402,2401,2400,2399,2398,2397,2396,2395,2394,2393,2392,2391,2390,2389,2388,2387,2386,2385,2384,2383,2382,2381,2380,2379,2378,2377,2376,2375,2374,2373,2372,2371,2370,2369,2368,2367,2366,2365,2364,2363,2362,2361,2360,2359,2358,2357,2356,2355,2354,2353,2352,2351,2350,2349,2348,2347,2346,2345,2344,2343,2342,2341,2340,2339,2338,2337,2336,2335,2334,2333,2332,2331,2330,2329,2328,2327,2326,2325,2324,2323,2322,2321,2320,2319,2318,2317,2316,2315,2314,2313,2312,2311,2310,2309,2308,2307,2306,2305,2304,2303,2302,2301,2300,2299,2298,2297,2296,2295,2294,2293,2292,2291,2290,2289,2288,2287,2286,2285,2284,2283,2282,2281,2280,2279,2278,2277,2276,2275,2274,2273,2272,2271,2270,2269,2268,2267,2266,2265,2264,2263,2262,2261,2260,2259,2258,2257,2256,2255,2254,2253,2252,2251,2250,2249,2248,2247,2246,2245,2244,2243,2242,2241,2240,2239,2238,2237,2236,2235,2234,2233,2232,2231,2230,2229,2228,2227,2226,2225,2224,2223,2222,2221,2220,2219,2218,2217,2216,2215,2214,2213,2212,2211,2210,2209,2208,2207,2206,2205,2204,2203,2202,2201,2200,2199,2198,2197,2196,2195,2194,2193,2192,2191,2190,2189,2188,2187,2186,2185,2184,2183,2182,2181,2180,2179,2178,2177,2176,2175,2174,2173,2172,2171,2170,2169,2168,2167,2166,2165,2164,2163,2162,2161,2160,2159,2158,2157,2156,2155,2154,2153,2152,2151,2150,2149,2148,2147,2146,2145,2144,2143,2142,2141,2140,2139,2138,2137,2136,2135,2134,2133,2132,2131,2130,2129,2128,2127,2126,2125,2124,2123,2122,2121,2120,2119,2118,2117,2116,2115,2114,2113,2112,2111,2110,2109,2108,2107,2106,2105,2104,2103,2102,2101,2100,2099,2098,2097,2096,2095,2094,2093,2092,2091,2090,2089,2088,2087,2086,2085,2084,2083,2082,2081,2080,2079,2078,2077,2076,2075,2074,2073,2072,2071,2070,2069,2068,2067,2066,2065,2064,2063,2062,2061,2060,2059,2058,2057,2056,2055,2054,2053,2052,2051,2050,2049,2048,2047,2046,2045,2044,2043,2042,2041,2040,2039,2038,2037,2036,2035,2034,2033,2032,2031,2030,2029,2028,2027,2026,2025,2024,2023,2022,2021,2020,2019,2018,2017,2016,2015,2014,2013,2012,2011,2010,2009,2008,2007,2006,2005,2004,2003,2002,2001,2000,1999,1998,1997,1996,1995,1994,1993,1992,1991,1990,1989,1988,1987,1986,1985,1984,1983,1982,1981,1980,1979,1978,1977,1976,1975,1974,1973,1972,1971,1970,1969,1968,1967,1966,1965,1964,1963,1962,1961,1960,1959,1958,1957,1956,1955,1954,1953,1952,1951,1950,1949,1948,1947,1946,1945,1944,1943,1942,1941,1940,1939,1938,1937,1936,1935,1934,1933,1932,1931,1930,1929,1928,1927,1926,1925,1924,1923,1922,1921,1920,1919,1918,1917,1916,1915,1914,1913,1912,1911,1910,1909,1908,1907,1906,1905,1904,1903,1902,1901,1900,1899,1898,1897,1896,1895,1894,1893,1892,1891,1890,1889,1888,1887,1886,1885,1884,1883,1882,1881,1880,1879,1878,1877,1876,1875,1874,1873,1872,1871,1870,1869,1868,1867,1866,1865,1864,1863,1862,1861,1860,1859,1858,1857,1856,1855,1854,1853,1852,1851,1850,1849,1848,1847,1846,1845,1844,1843,1842,1841,1840,1839,1838,1837,1836,1835,1834,1833,1832,1831,1830,1829,1828,1827,1826,1825,1824,1823,1822,1821,1820,1819,1818,1817,1816,1815,1814,1813,1812,1811,1810,1809,1808,1807,1806,1805,1804,1803,1802,1801,1800,1799,1798,1797,1796,1795,1794,1793,1792,1791,1790,1789,1788,1787,1786,1785,1784,1783,1782,1781,1780,1779,1778,1777,1776,1775,1774,1773,1772,1771,1770,1769,1768,1767,1766,1765,1764,1763,1762,1761,1760,1759,1758,1757,1756,1755,1754,1753,1752,1751,1750,1749,1748,1747,1746,1745,1744,1743,1742,1741,1740,1739,1738,1737,1736,1735,1734,1733,1732,1731,1730,1729,1728,1727,1726,1725,1724,1723,1722,1721,1720,1719,1718,1717,1716,1715,1714,1713,1712,1711,1710,1709,1708,1707,1706,1705,1704,1703,1702,1701,1700,1699,1698,1697,1696,1695,1694,1693,1692,1691,1690,1689,1688,1687,1686,1685,1684,1683,1682,1681,1680,1679,1678,1677,1676,1675,1674,1673,1672,1671,1670,1669,1668,1667,1666,1665,1664,1663,1662,1661,1660,1659,1658,1657,1656,1655,1654,1653,1652,1651,1650,1649,1648,1647,1646,1645,1644,1643,1642,1641,1640,1639,1638,1637,1636,1635,1634,1633,1632,1631,1630,1629,1628,1627,1626,1625,1624,1623,1622,1621,1620,1619,1618,1617,1616,1615,1614,1613,1612,1611,1610,1609,1608,1607,1606,1605,1604,1603,1602,1601,1600,1599,1598,1597,1596,1595,1594,1593,1592,1591,1590,1589,1588,1587,1586,1585,1584,1583,1582,1581,1580,1579,1578,1577,1576,1575,1574,1573,1572,1571,1570,1569,1568,1567,1566,1565,1564,1563,1562,1561,1560,1559,1558,1557,1556,1555,1554,1553,1552,1551,1550,1549,1548,1547,1546,1545,1544,1543,1542,1541,1540,1539,1538,1537,1536,1535,1534,1533,1532,1531,1530,1529,1528,1527,1526,1525,1524,1523,1522,1521,1520,1519,1518,1517,1516,1515,1514,1513,1512,1511,1510,1509,1508,1507,1506,1505,1504,1503,1502,1501,1500,1499,1498,1497,1496,1495,1494,1493,1492,1491,1490,1489,1488,1487,1486,1485,1484,1483,1482,1481,1480,1479,1478,1477,1476,1475,1474,1473,1472,1471,1470,1469,1468,1467,1466,1465,1464,1463,1462,1461,1460,1459,1458,1457,1456,1455,1454,1453,1452,1451,1450,1449,1448,1447,1446,1445,1444,1443,1442,1441,1440,1439,1438,1437,1436,1435,1434,1433,1432,1431,1430,1429,1428,1427,1426,1425,1424,1423,1422,1421,1420,1419,1418,1417,1416,1415,1414,1413,1412,1411,1410,1409,1408,1407,1406,1405,1404,1403,1402,1401,1400,1399,1398,1397,1396,1395,1394,1393,1392,1391,1390,1389,1388,1387,1386,1385,1384,1383,1382,1381,1380,1379,1378,1377,1376,1375,1374,1373,1372,1371,1370,1369,1368,1367,1366,1365,1364,1363,1362,1361,1360,1359,1358,1357,1356,1355,1354,1353,1352,1351,1350,1349,1348,1347,1346,1345,1344,1343,1342,1341,1340,1339,1338,1337,1336,1335,1334,1333,1332,1331,1330,1329,1328,1327,1326,1325,1324,1323,1322,1321,1320,1319,1318,1317,1316,1315,1314,1313,1312,1311,1310,1309,1308,1307,1306,1305,1304,1303,1302,1301,1300,1299,1298,1297,1296,1295,1294,1293,1292,1291,1290,1289,1288,1287,1286,1285,1284,1283,1282,1281,1280,1279,1278,1277,1276,1275,1274,1273,1272,1271,1270,1269,1268,1267,1266,1265,1264,1263,1262,1261,1260,1259,1258,1257,1256,1255,1254,1253,1252,1251,1250,1249,1248,1247,1246,1245,1244,1243,1242,1241,1240,1239,1238,1237,1236,1235,1234,1233,1232,1231,1230,1229,1228,1227,1226,1225,1224,1223,1222,1221,1220,1219,1218,1217,1216,1215,1214,1213,1212,1211,1210,1209,1208,1207,1206,1205,1204,1203,1202,1201,1200,1199,1198,1197,1196,1195,1194,1193,1192,1191,1190,1189,1188,1187,1186,1185,1184,1183,1182,1181,1180,1179,1178,1177,1176,1175,1174,1173,1172,1171,1170,1169,1168,1167,1166,1165,1164,1163,1162,1161,1160,1159,1158,1157,1156,1155,1154,1153,1152,1151,1150,1149,1148,1147,1146,1145,1144,1143,1142,1141,1140,1139,1138,1137,1136,1135,1134,1133,1132,1131,1130,1129,1128,1127,1126,1125,1124,1123,1122,1121,1120,1119,1118,1117,1116,1115,1114,1113,1112,1111,1110,1109,1108,1107,1106,1105,1104,1103,1102,1101,1100,1099,1098,1097,1096,1095,1094,1093,1092,1091,1090,1089,1088,1087,1086,1085,1084,1083,1082,1081,1080,1079,1078,1077,1076,1075,1074,1073,1072,1071,1070,1069,1068,1067,1066,1065,1064,1063,1062,1061,1060,1059,1058,1057,1056,1055,1054,1053,1052,1051,1050,1049,1048,1047,1046,1045,1044,1043,1042,1041,1040,1039,1038,1037,1036,1035,1034,1033,1032,1031,1030,1029,1028,1027,1026,1025,1024,1023,1022,1021,1020,1019,1018,1017,1016,1015,1014,1013,1012,1011,1010,1009,1008,1007,1006,1005,1004,1003,1002,1001,1000,999,998,997,996,995,994,993,992,991,990,989,988,987,986,985,984,983,982,981,980,979,978,977,976,975,974,973,972,971,970,969,968,967,966,965,964,963,962,961,960,959,958,957,956,955,954,953,952,951,950,949,948,947,946,945,944,943,942,941,940,939,938,937,936,935,934,933,932,931,930,929,928,927,926,925,924,923,922,921,920,919,918,917,916,915,914,913,912,911,910,909,908,907,906,905,904,903,902,901,900,899,898,897,896,895,894,893,892,891,890,889,888,887,886,885,884,883,882,881,880,879,878,877,876,875,874,873,872,871,870,869,868,867,866,865,864,863,862,861,860,859,858,857,856,855,854,853,852,851,850,849,848,847,846,845,844,843,842,841,840,839,838,837,836,835,834,833,832,831,830,829,828,827,826,825,824,823,822,821,820,819,818,817,816,815,814,813,812,811,810,809,808,807,806,805,804,803,802,801,800,799,798,797,796,795,794,793,792,791,790,789,788,787,786,785,784,783,782,781,780,779,778,777,776,775,774,773,772,771,770,769,768,767,766,765,764,763,762,761,760,759,758,757,756,755,754,753,752,751,750,749,748,747,746,745,744,743,742,741,740,739,738,737,736,735,734,733,732,731,730,729,728,727,726,725,724,723,722,721,720,719,718,717,716,715,714,713,712,711,710,709,708,707,706,705,704,703,702,701,700,699,698,697,696,695,694,693,692,691,690,689,688,687,686,685,684,683,682,681,680,679,678,677,676,675,674,673,672,671,670,669,668,667,666,665,664,663,662,661,660,659,658,657,656,655,654,653,652,651,650,649,648,647,646,645,644,643,642,641,640,639,638,637,636,635,634,633,632,631,630,629,628,627,626,625,624,623,622,621,620,619,618,617,616,615,614,613,612,611,610,609,608,607,606,605,604,603,602,601,600,599,598,597,596,595,594,593,592,591,590,589,588,587,586,585,584,583,582,581,580,579,578,577,576,575,574,573,572,571,570,569,568,567,566,565,564,563,562,561,560,559,558,557,556,555,554,553,552,551,550,549,548,547,546,545,544,543,542,541,540,539,538,537,536,535,534,533,532,531,530,529,528,527,526,525,524,523,522,521,520,519,518,517,516,515,514,513,512,511,510,509,508,507,506,505,504,503,502,501,500,499,498,497,496,495,494,493,492,491,490,489,488,487,486,485,484,483,482,481,480,479,478,477,476,475,474,473,472,471,470,469,468,467,466,465,464,463,462,461,460,459,458,457,456,455,454,453,452,451,450,449,448,447,446,445,444,443,442,441,440,439,438,437,436,435,434,433,432,431,430,429,428,427,426,425,424,423,422,421,420,419,418,417,416,415,414,413,412,411,410,409,408,407,406,405,404,403,402,401,400,399,398,397,396,395,394,393,392,391,390,389,388,387,386,385,384,383,382,381,380,379,378,377,376,375,374,373,372,371,370,369,368,367,366,365,364,363,362,361,360,359,358,357,356,355,354,353,352,351,350,349,348,347,346,345,344,343,342,341,340,339,338,337,336,335,334,333,332,331,330,329,328,327,326,325,324,323,322,321,320,319,318,317,316,315,314,313,312,311,310,309,308,307,306,305,304,303,302,301,300,299,298,297,296,295,294,293,292,291,290,289,288,287,286,285,284,283,282,281,280,279,278,277,276,275,274,273,272,271,270,269,268,267,266,265,264,263,262,261,260,259,258,257,256,255,254,253,252,251,250,249,248,247,246,245,244,243,242,241,240,239,238,237,236,235,234,233,232,231,230,229,228,227,226,225,224,223,222,221,220,219,218,217,216,215,214,213,212,211,210,209,208,207,206,205,204,203,202,201,200,199,198,197,196,195,194,193,192,191,190,189,188,187,186,185,184,183,182,181,180,179,178,177,176,175,174,173,172,171,170,169,168,167,166,165,164,163,162,161,160,159,158,157,156,155,154,153,152,151,150,149,148,147,146,145,144,143,142,141,140,139,138,137,136,135,134,133,132,131,130,129,128,127,126,125,124,123,122,121,120,119,118,117,116,115,114,113,112,111,110,109,108,107,106,105,104,103,102,101,100,99,98,97,96,95,94,93,92,91,90,89,88,87,86,85,84,83,82,81,80,79,78,77,76,75,74,73,72,71,70,69,68,67,66,65,64,63,62,61,60,59,58,57,56,55,54,53,52,51,50,49,48,47,46,45,44,43,42,41,40,39,38,37,36,35,34,33,32,31,30,29,28,27,26,25,24,23,22,21,20,19,18,17,16,15,14,13,12,11,10,9,8,7,6,5,4,3,2,1,0,0},
                new int[]{ 2, 3, 1, 1, 4 },
                new int[]{ 3, 2, 1, 0, 4 }
            };

            foreach (var jumpArr in jumpArrs)
            {
                var af = new ArrayFunctions();
                Console.WriteLine(af.CanJumpGreedy(jumpArr));
            }
            return;

            int[][][] matrixes =
            {
                new int[][]
                {
                    new int[]{1,2,3},
                    new int[]{4,5,6},
                    new int[]{7,8,9},
                },
                new int[][]
                {
                    new int[]{1,2,3,4},
                    new int[]{5,6,7,8},
                    new int[]{9,10,11,12},
                },
            };

            foreach (var matrix in matrixes)
            {
                var af = new ArrayFunctions();
                var res = af.SpiralOrder(matrix);
                foreach (var item in res)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
            int[][][] images = new int[][][]
            {
                new int[][]
                {
                    new int[]{1,2,3 },
                    new int[]{4,5,6 },
                    new int[]{7,8,9 }
                }
            };

            foreach (var image in images)
            {
                var af = new ArrayFunctions();
                af.Rotate(image);
                //for (int i = 0; i < image.Length; i++)
                //{
                //    for (int j = 0; j < image.Length; j++)
                //    {
                //        Console.Write(image[i][j] + " ");
                //    }
                //    Console.WriteLine();
                //}
            }

            return;

            int[][] arrays = new int[][]
            {
                new int[]{1,2,3 },
                new int[]{0,1},
                new int[]{1},
            };

            foreach (var arr in arrays)
            {
                var af = new ArrayFunctions();
                Console.WriteLine("For array "+string.Join(" ",arr));
                var res = af.Permute(arr);
                foreach (var r in res)
                {
                    foreach (var item in r)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                }
            }

            return;

            int[][] arrs = new int[][]
            {
                new int[]{1,2,0}
            };

            foreach (var num in arrs)
            {
                var af = new ArrayFunctions();
                Console.WriteLine(af.FirstMissingPositive(num));
            }
            return;
            List<KeyValuePair<int[], int>> targets = new List<KeyValuePair<int[], int>>();
            targets.Add(new KeyValuePair<int[], int>(new int[] { 5, 7, 7, 8, 8, 10 }, 8));
            targets.Add(new KeyValuePair<int[], int>(new int[] { 5, 7, 7, 8, 8, 10 }, 6));
            //targets.Add(new KeyValuePair<int[], int>(new int[] { 4, 5, 6, 7, 8, 1, 2, 3 }, 8));


            foreach (var target in targets)
            {
                var af = new ArrayFunctions();
                var positions = af.SearchRange(target.Key, target.Value);
                Console.WriteLine(positions[0]+" "+positions[1]);
            }
            //List<KeyValuePair<int[], int>> targets = new List<KeyValuePair<int[], int>>();
            //targets.Add(new KeyValuePair<int[], int>(new int[] { 4, 5, 6, 7, 0, 1, 2 },0));
            ////targets.Add(new KeyValuePair<int[], int>(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3));
            //targets.Add(new KeyValuePair<int[], int>(new int[] {4, 5, 6, 7, 8, 1, 2, 3}, 8));


            //foreach (var target in targets)
            //{
            //    var af = new ArrayFunctions();
            //    Console.WriteLine(af.Search(target.Key, target.Value));
            //}

            return;

            int[][] numsArr =
            {
                new int[]{1,2,2 },
                new int[]{1,2,3 },
                new int[]{1,1 },
                new int[]{1 },
                new int[]{ },
                new int[]{1,1,2 },
                new int[]{0,0,1,1,1,2,2,3,3,4}
            };
            

            foreach (var nums in numsArr)
            {
                ArrayFunctions af = new ArrayFunctions();
                Console.WriteLine(af.RemoveDuplicates(nums));
                Console.WriteLine();
            }

            return;

            //int[] num1 = { 1, 3 };
            //int[] num2 = { 2 };
            //int[] num1 = { 1};
            //int[] num2 = { 1 };
            //Console.WriteLine($"Median is {af.FindMedianSortedArrays(num1,num2)}"); 
        }
    }
}

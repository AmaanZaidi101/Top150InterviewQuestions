using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLibrary
{
    public class GraphFunctions
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            if (wordList.IndexOf(endWord) < 0)
                return 0;

            //add beginword to list
            wordList = wordList.ToList();
            if(!wordList.Contains(beginWord))
                wordList.Add(beginWord);
            int len = beginWord.Length;

            //create adjacency list
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            for (int i = 0; i < wordList.Count; i++)
            {
                for (int j = 0; j < wordList[i].Length; j++)
                {
                    string pattern = wordList[i].Substring(0, len-j-1) + "*" + wordList[i].Substring(len - j);

                    if (!dictionary.ContainsKey(pattern))
                        dictionary.Add(pattern, new List<string>());
                    //add all words to the pattern
                    dictionary[pattern].Add(wordList[i]);
                }
            }

            //now lets go with BFS
            HashSet<string> seen = new HashSet<string>();
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(beginWord);
            seen.Add(beginWord);

            int res = 1;
            while(queue.Count > 0)
            {
                int c = queue.Count;
                //check all neighbours
                for (int i = 0; i < c; i++)
                {
                    string word = queue.Dequeue();

                    if (word == endWord)
                        return res;

                    //get all patterns for current word
                    for (int j = 0; j < word.Length; j++)
                    {
                        string pattern = word.Substring(0, len - j - 1) + "*" + word.Substring(len - j);
                        //get all neighbours for current pattern
                        foreach (var item in dictionary[pattern])
                        {
                            if (!seen.Contains(item))
                            {
                                seen.Add(item);
                                queue.Enqueue(item);
                            }
                        }
                    }
                }
                
                res++;
            }
            return 0;
        }

        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            int n = prerequisites.Length;
            if (n == 0)
                return true;
            List<int> indegrees = new List<int>(n);
            for (int i = 0; i < numCourses; i++)
            {
                indegrees.Add(0);
            }
            Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; i++)
            {
                int pre = prerequisites[i][1];
                int connectsTo = prerequisites[i][0];

                if (adjacencyList.ContainsKey(pre))
                    adjacencyList[pre].Add(connectsTo);
                else
                    adjacencyList.Add(pre, new List<int>() { connectsTo });
                 
                indegrees[connectsTo] += 1;
            }

            int removedNodes = 0;
            while (removedNodes != numCourses)
            {
                int index = -1;
                for (int i = 0; i < indegrees.Count; i++)
                {
                    if(indegrees[i] == 0) //check if it can be removed
                    {
                        //removed this node so indegree of other nodes becomes 1 less
                        if(adjacencyList.ContainsKey(i)) //if it has others that can be affected
                        {
                            var connectedNodes = adjacencyList[i];
                            
                            foreach (var node in connectedNodes)
                            {
                                indegrees[node] -= 1;
                            }
                        }
                        indegrees[i] = -1;
                        index = i;
                        removedNodes++;
                        break;
                    }
                }
                if (index == -1)
                    break;
            }
            return removedNodes == numCourses;
        }

        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            int n = prerequisites.Length;
            Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();
            var independentNodes = new HashSet<int>();
            int[] indegrees = new int[numCourses];
            
            for (int i = 0; i < n; i++)
            {
                int pre = prerequisites[i][1];
                int to = prerequisites[i][0];

                if (adjacencyList.ContainsKey(pre))
                    adjacencyList[pre].Add(to);
                else
                    adjacencyList.Add(pre, new List<int>() { to });

                indegrees[to]++;
            }

            List<int> traversalList = new List<int>();
            while(traversalList.Count < numCourses)
            {
                int index = -1;
                for (int i = 0; i < indegrees.Length; i++)
                {
                    if(indegrees[i] == 0)
                    {
                        if (adjacencyList.ContainsKey(i))
                        {
                            var connectedNodes = adjacencyList[i];
                            foreach (var node in connectedNodes)
                            {
                                indegrees[node] -= 1;
                            }
                        }
                        indegrees[i] = -1;
                        index = i;
                        traversalList.Add(i);
                    }
                }
                if (index == -1)
                    break;
            }

            return traversalList.Count == numCourses ? traversalList.ToArray() : new int[] { };
        }

        public string AlienOrder(string[] words)
        {
            Dictionary<char, HashSet<char>> adjList = new Dictionary<char, HashSet<char>>();
            var chars = string.Join("", words).Distinct();
            foreach (var ch in chars)
            {
                adjList.Add(ch, new HashSet<char>());
            }

            for (int i = 0; i < words.Length-1; i++)
            {
                var w1 = words[i];
                var w2 = words[i + 1];

                if (w1.Length > w2.Length && w2.IndexOf(w1) >= 0) //second word is prefix of first - this case is invalid because this is wrong ordering
                    return "";
                int minLength = Math.Min(w1.Length, w2.Length);
                
                for (int j = 0; j < minLength; j++)
                {
                    if (w1[j] != w2[j])
                    {
                        adjList[w1[j]].Add(w2[j]);
                        break;
                    }
                }
            }

            Dictionary<char, bool> visited = new Dictionary<char, bool>(); //add when visited, make true if its in path
            List<char> res = new List<char>();
            foreach (char ch in adjList.Keys)
            {
                if (DFSAlien(ch, visited, adjList, res))
                    return "";
            }
            res.Reverse(); //we did post order so we have to reverse
            
            return new string(res.ToArray());
        }

        //POST ORDER TRAVERSAL
        private bool DFSAlien(char ch, Dictionary<char, bool> visited, Dictionary<char,HashSet<char>> adjList, List<char> res)
        {
            if (visited.ContainsKey(ch))
                return visited[ch]; //false means we have visited so don't add, true means we visited in this very iteration so its a cycle

            visited.Add(ch, true); //mark it visited and in path

            foreach (var adjacentCharacter in adjList[ch])
            {
                if (DFSAlien(adjacentCharacter, visited, adjList, res)) //if cycle
                    return true;
            }

            visited[ch] = false; //its been visited but it is not in the current path anymore
            //only add when we are done visiting all children - post order
            res.Add(ch);
            return false;
        }
    }
}

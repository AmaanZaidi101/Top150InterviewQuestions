using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLibrary
{
    public static class StatClass
    {
        public static void fun()
        {
            Console.WriteLine(this+"works");
        }
    }
    public class OtherFunctions
    {
        public bool IsValidSudoku(char[][] board)
        {
            return FillSudoku(board);
        }

        public int[] solution(int[] balances, string[] requests)
        {
            for(int i=0; i < requests.Length; i++)
            {
                var req = requests[i];
                var arr = req.Split(" ");
                int acc = int.Parse(arr[1]);
                int amt = int.Parse(arr[2]);
                if (acc < 1 || acc > balances.Length)
                    return new int[] { -(i+1) };
                switch (arr[0])
                {
                    case "withdraw":
                        if (balances[acc - 1] - amt < 0)
                            return new int[] { -(i+1) };
                        else
                            balances[acc - 1] -= amt;
                        break;
                    case "deposit":
                        balances[acc - 1] += amt;
                        break;
                    case "transfer":
                        int acc2 = amt;
                        amt = int.Parse(arr[3]);
                        if (acc2 < 1 || acc2 > balances.Length)
                            return new int[] { -(i+1) };
                        if (balances[acc - 1] - amt < 0)
                            return new int[] { -(i + 1) };
                        else
                        {
                            balances[acc - 1] -= amt;
                            balances[acc2 - 1] += amt;
                        }
                        break;
                    default:
                        break;
                }
            }
            return balances;

        }

        private bool FillSudoku(char[][] board, int row=0, int col=0)
        {
            if (row >= 9 || col >= 9)
                return true;

            if (board[row][col] == '.')
            {
                for (char c = '1'; c <= '9'; c++)
                {
                    if (IsValid(board, row, col, c))
                    {
                        board[row][col] = c;
                        if (col == 8)
                        {
                            if (FillSudoku(board, row + 1, 0))
                                return true;
                        }
                        else
                        {
                            if (FillSudoku(board, row, col + 1))
                                return true;
                        }
                        board[row][col] = '.';
                    }
                }
            }
            else
            {
                if (col == 8)
                {
                    if (FillSudoku(board, row + 1, 0))
                        return true;
                }
                else
                {
                    if (FillSudoku(board, row, col + 1))
                        return true;
                }
            }
            return false;
        }

        private bool IsValid(char[][] board, int row, int col, char ch)
        {
            //check all rows of column
            for (int i = 0; i < 9; i++)
            {
                if (board[i][col] == ch)
                    return false;
            }
            //check all columns of row
            for (int i = 0; i < 9; i++)
            {
                if (board[row][i] == ch)
                    return false;
            }

            int startRow;
            int endRow;
            if (row < 3)
            {
                startRow = 0;
                endRow = 3;
            }
            else if (row < 6)
            {
                startRow = 3;
                endRow = 6;
            }
            else
            {
                startRow = 6;
                endRow = 9;
            }

            int startCol;
            int endCol;
            if (col < 3)
            {
                startCol = 0;
                endCol = 3;
            }
            else if (col < 6)
            {
                startCol = 3;
                endCol = 6;
            }
            else
            {
                startCol = 6;
                endCol = 9;
            }
            for (int i = startRow; i < endRow; i++)
            {
                for (int j = startCol; j < endCol; j++)
                {
                    if (board[i][j] == ch)
                        return false;
                }
            }
            return true;
        }

        public bool JustValidateSudoku(char[][] board)
        {
            var colMap = new HashSet<char>[9];
            var rowMap = new HashSet<char>();
            var gridMap = new HashSet<char>[9];

            for (int i = 0; i < 9; i++)
            {
                rowMap.Clear();
                for (int j = 0; j < 9; j++)
                {
                    if (colMap[j] == null)
                        colMap[j] = new HashSet<char>();

                    if (!Validate(rowMap, board[i][j]))
                        return false;
                    if (!Validate(colMap[j], board[i][j]))
                        return false;

                    var grid = GetGrid(i, j);

                    if (gridMap[grid] == null)
                        gridMap[grid] = new HashSet<char>();

                    if (!Validate(gridMap[grid], board[i][j]))
                        return false;
                }
            }
            return true;
        }

        private bool Validate(HashSet<char> hashSet, char c)
        {
            if (c == '.')
                return true;
            if (hashSet.Contains(c))
                return false;
            else
                hashSet.Add(c);
            return true;
        }

        private int GetGrid(int i, int j)
        {
            return 3 * (i / 3) + j / 3;
        }

        
    }

    public class LRUCache
    {
        internal class CacheNode
        {
            internal int key;
            internal int val;
            internal CacheNode prev;
            internal CacheNode next;

            public CacheNode(int k, int v)
            {
                key = k;
                val = v;
            }
        }

        CacheNode left, right;
        Dictionary<int, CacheNode> dictionary;

        int c;
        int rank = int.MaxValue;
        public LRUCache(int capacity)
        {
            c = capacity;
            dictionary = new Dictionary<int, CacheNode>();
            left = new CacheNode(-1, -1);
            right = new CacheNode(-1, -1);
            left.next = right;
            right.prev = left;
        }

        public int Get(int key)
        {
            if (dictionary.ContainsKey(key))
            {
                //remove our node from the linked list and add it on the Most recently used side
                Remove(dictionary[key]);
                Add(dictionary[key]);
                var val = dictionary[key].val;
                return val;
            }
            return -1;
        }

        private void Add(CacheNode cacheNode)
        {
            var p = right.prev;
            p.next = cacheNode;
            right.prev = cacheNode;
            cacheNode.prev = p;
            cacheNode.next = right;
        }

        private void Remove(CacheNode cacheNode)
        {
            var p = cacheNode.prev;
            var n = cacheNode.next;

            p.next = n;
            n.prev = p;
        }

        public void Put(int key, int value)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key].val = value;
                Remove(dictionary[key]);
                Add(dictionary[key]);
            }
            else
            {
                CacheNode node = new CacheNode(key, value);

                if (dictionary.Count < c)
                    dictionary.Add(key, node);
                else
                {
                    var leastUsed = left.next;
                    var k = leastUsed.key;
                    Remove(leastUsed);
                    dictionary.Remove(k);
                    dictionary.Add(key, node);
                }
                Add(node);
            }
            

        }
    }

    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */

    //public class MinStack
    //{
    //    Stack<int> stack;
    //    Stack<int> minStack;
    //    public MinStack()
    //    {
    //        stack = new Stack<int>();
    //        minStack = new Stack<int>();
    //    }

    //    public void Push(int val)
    //    {
    //        stack.Push(val);
    //        if(minStack.Count > 0)
    //        {
    //            int min = minStack.Peek();
    //            if (val < min)
    //                minStack.Push(val);
    //            else
    //                minStack.Push(min);
    //        }
    //        else
    //            minStack.Push(val);
    //    }

    //    public void Pop()
    //    {
    //        stack.Pop();
    //        minStack.Pop();
    //    }

    //    public int Top()
    //    {
    //        return stack.Peek();
    //    }

    //    public int GetMin()
    //    {
    //        return minStack.Peek();
    //    }
    //}
    
    //Basically keep a track of min at every step so after every pop you know the min
    public class MinStack
    {
        internal class StackNode
        {
            internal int val;
            internal int min;
            public StackNode(int _val, int _min)
            {
                val = _val;
                min = _min;
            }
        }
        Stack<StackNode> stack;
        public MinStack()
        {
            stack = new Stack<StackNode>();
        }

        public void Push(int val)
        {
            int min = val;
            if (stack.Count > 0)
                min = Math.Min(val, stack.Peek().min);
            stack.Push(new StackNode(val, min));
        }

        public void Pop()
        {
            stack.Pop();
        }

        public int Top()
        {
            return stack.Peek().val;
        }

        public int GetMin()
        {
            return stack.Peek().min;
        }
    }

    /**
     * Your MinStack object will be instantiated and called as such:
     * MinStack obj = new MinStack();
     * obj.Push(val);
     * obj.Pop();
     * int param_3 = obj.Top();
     * int param_4 = obj.GetMin();
     */

    public class Trie
    {
        internal class TrieNode
        {
            internal Dictionary<char, TrieNode> characters;
            internal bool IsEnd = false;
            public TrieNode()
            {
                characters = new Dictionary<char, TrieNode>();
            }
        }

        Dictionary<char, TrieNode> trie;
        public Trie()
        {
            trie = new Dictionary<char, TrieNode>();
        }

        public void Insert(string word)
        {
            InsertCharacter(trie, word,0);
        }

        private void InsertCharacter(Dictionary<char, TrieNode> t, string word, int index)
        {
            if (index == word.Length)
                return;
            
            char ch = word[index];

            if(t.ContainsKey(ch))
            {
                var chars = t[ch].characters;
                if (index + 1 == word.Length)
                {
                    t[ch].IsEnd = true;
                    return;
                }
                InsertCharacter(chars, word, index + 1);
            }
            else
            {
                t.Add(ch, new TrieNode());
                if (index + 1 == word.Length)
                {
                    t[ch].IsEnd = true;
                    return;
                }
                InsertCharacter(t[ch].characters, word, index + 1);
            }
        }

        public bool Search(string word)
        {
            return SearchWord(trie, word, 0);
        }

        private bool SearchWord(Dictionary<char, TrieNode> t, string word, int index, bool isPrefix=false)
        {
            char ch = word[index];
            if (t.ContainsKey(ch))
            {
                if (index == word.Length - 1)
                    return isPrefix ? true : t[ch].IsEnd;
                return SearchWord(t[ch].characters, word, index + 1, isPrefix);
            }
                
            return false;
        }

        public bool StartsWith(string prefix)
        {
            return SearchWord(trie, prefix, 0, true);
        }
    }

    public class TrieNode2
    {
        public Dictionary<char, TrieNode2> children;
        public bool isEnd;
        public TrieNode2()
        {
            children = new Dictionary<char, TrieNode2>();
        }
    }
    public class Trie2
    {
        public TrieNode2 root;
        public Trie2()
        {
            root = new TrieNode2();
        }

        public void AddWord(string word)
        {
            var current = root;
            foreach (char ch in word)
            {
                if (!current.children.ContainsKey(ch))
                    current.children.Add(ch, new TrieNode2());
                current = current.children[ch];
            }
            current.isEnd = true;
        }
    }

    /**
     * Your Trie object will be instantiated and called as such:
     * Trie obj = new Trie();
     * obj.Insert(word);
     * bool param_2 = obj.Search(word);
     * bool param_3 = obj.StartsWith(prefix);
     */

    
  // This is the interface that allows for creating nested lists.
  // You should not implement it, or speculate about its implementation
 public interface NestedInteger {
 
      // @return true if this NestedInteger holds a single integer, rather than a nested list.
      bool IsInteger();
 
      // @return the single integer that this NestedInteger holds, if it holds a single integer
      // Return null if this NestedInteger holds a nested list
      int GetInteger();
 
      // @return the nested list that this NestedInteger holds, if it holds a nested list
      // Return null if this NestedInteger holds a single integer
      IList<NestedInteger> GetList();
  }
 
    public class NestedIterator
    {
        List<int> resultList;
        public NestedIterator(IList<NestedInteger> nestedList)
        {
            resultList = new List<int>();
            Flatten(nestedList, resultList);
        }

        private void Flatten(IList<NestedInteger> nestedList, List<int> resultList)
        {
            for (int i = 0; i < nestedList.Count; i++)
            {
                var item = nestedList[i];
                if (item.IsInteger())
                    resultList.Add(item.GetInteger());
                else
                    Flatten(item.GetList(), resultList);
            }
        }

        public bool HasNext()
        {
            return resultList.Count > 0;
        }

        public int Next()
        {
            var res = resultList[0];
            resultList.RemoveAt(0);
            return res;
        }
    }

    /**
     * Your NestedIterator will be called like this:
     * NestedIterator i = new NestedIterator(nestedList);
     * while (i.HasNext()) v[f()] = i.Next();
     */

    public class RandomizedSet
    {
        Random r;
        HashSet<int> set;
        public RandomizedSet()
        {
            r = new Random();
            set = new HashSet<int>();
        }

        public bool Insert(int val)
        {
            if (set.Contains(val))
                return false;
            set.Add(val);
            return true;
        }

        public bool Remove(int val)
        {
            if (!set.Contains(val))
                return false;
            set.Remove(val);
            return true;
        }

        public int GetRandom()
        {
            int index = r.Next(0, set.Count);
            return set.ElementAt(index);
        }
    }

    /**
     * Your RandomizedSet object will be instantiated and called as such:
     * RandomizedSet obj = new RandomizedSet();
     * bool param_1 = obj.Insert(val);
     * bool param_2 = obj.Remove(val);
     * int param_3 = obj.GetRandom();
     */

    public class Solution
    {
        int[] original;
        Random r;
        public Solution(int[] nums)
        {
            r = new Random();
            original = nums;

        }

        public int[] Reset()
        {
            return original;
        }

        public int[] Shuffle()
        {
            List<int> ans = new List<int>();
            var hashMap = new HashSet<int>();
            while (ans.Count < original.Length)
            {
                int index = r.Next(0, original.Length);
                if (hashMap.Contains(index))
                    continue;
                ans.Add(original[index]);
                hashMap.Add(index);
            }
            return ans.ToArray();
        }
    }

    /**
     * Your Solution object will be instantiated and called as such:
     * Solution obj = new Solution(nums);
     * int[] param_1 = obj.Reset();
     * int[] param_2 = obj.Shuffle();
     */

    public class Vector2D
    {
        
        Queue<int> queue;
        public Vector2D(int[][] v)
        {
            List<int> list = new List<int>();
            foreach (var arr in v)
            {
                list.AddRange(arr);
            }
            queue = new Queue<int>(list);
        }

        public int Next()
        {
            int val = queue.Dequeue();
            return val; 
        }

        public bool HasNext()
        {
            return queue.Count > 0;
        }
    }

    public interface Knows
    {
        bool Knows(int a, int b);
    }

    public class Relation
    {
        Knows k;
        public Relation(Knows _k)
        {
            k = _k;
        }
        public int FindCelebrity(int n)
        {
            //assume 0 is celeb
            int candidate = 0;
            for (int i = 1; i < n; i++)
            {
                if (k.Knows(candidate, i)) // if candidate knows i then it cannot be celeb but i can be
                    candidate = i;
            }
            //we will have one final candidate to compare against
            for (int i = 0; i < n; i++)
            {
                if (i != candidate && (k.Knows(candidate, i) || !k.Knows(i, candidate))) //if celeb knows i or i doesnt know celeb then its not a celeb
                    return -1;
            }

            return candidate;
        }
        //public int FindCelebrity(int n)
        //{
        //    HashSet<int> people;
        //    int[] knownCount = new int[n];
            
        //    people = new HashSet<int>();
        //    var possibleCelebrity = new HashSet<int>();
        //    for (int i = 0; i < n; i++)
        //    {
        //        people.Add(i);
        //        possibleCelebrity.Add(i);
        //    }

        //    for (int i = 0; i < possibleCelebrity.Count; i++)
        //    {
        //        int b = possibleCelebrity.ElementAt(i);
        //        bool isCeleb = true;
        //        for (int j = 0; j < people.Count; j++)
        //        {
        //            int a = people.ElementAt(j);
        //            if (a == b)
        //                continue;
        //            if(k.Knows(a,b))
        //            {
        //                possibleCelebrity.Remove(a);
        //            }
        //            else
        //            {
        //                possibleCelebrity.Remove(b);
        //                isCeleb = false;
        //                break;
        //            }
        //        }
        //        if (isCeleb)
        //            return b;
        //    }
        //    return -1;
        //}
    }

    public class TicTacToe
    {
        int[] rows;
        int[] cols;
        int diagonal, antiDiagonal;
        int N;
        public TicTacToe(int n)
        {
            N = n;
            rows = new int[n];
            cols = new int[n];
        }

        public int Move(int row, int col, int player)
        {
            int val = player == 1 ? 1 : -1;
            rows[row] += val;
            cols[col] += val;
            if (row == col)
                diagonal += val;
            if (row == N - col - 1)
                antiDiagonal += val;

            if (Math.Abs(rows[row]) == N || Math.Abs(cols[col]) == N || Math.Abs(diagonal) == N || Math.Abs(antiDiagonal) == N)
                return player;
            return 0;
        }
    }

    abstract public class Course
    {
        // TODO: implement
        public virtual int cost { get; }
    }

    public class ProgrammingCourse : Course
    {
        // TODO: implement
        public override int cost { get { return 30; } }
    }

    public class MathematicsCourse : Course
    {
        // TODO: implement
        public override int cost { get { return 20; } }
    }

    public class EconomicsCourse : Course
    {
        // TODO: implement
        public override int cost { get { return 10; } }
    }

    public class User
    {
        static int count=0;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private int money;

        public User(string fname, string lname, int mon=30)
        {
            Id = count++; 
            FirstName = fname;
            LastName = lname;
            money = mon;
        }
        public bool order(List<Course> courses)
        {
            // TODO: implement
            int tmp = money;
            foreach (var course in courses)
            {
                if (money - course.cost < 0)
                {
                    money = tmp;
                    return false;
                }
                else
                    money -= course.cost;
            }
            return true;
        }
    }

    public class solve
    {
        public bool[] solution(string[][] userInformation, string[][] orders)
        {
            User[] users = new User[userInformation.Length];
            bool[] result = new bool[orders.Length];
            for (int i = 0; i < userInformation.Length; ++i)
            {
                if (userInformation[i].Length == 3)
                    users[i] = new User(userInformation[i][0], userInformation[i][1], int.Parse(userInformation[i][2]));
                else
                    users[i] = new User(userInformation[i][0], userInformation[i][1]);
            }
            for (int i = 0; i < orders.Length; ++i)
            {
                List<Course> courses = new List<Course>();
                for (int j = 1; j < orders[i].Length; ++j)
                {
                    if (orders[i][j] == "Programming")
                        courses.Add(new ProgrammingCourse());
                    if (orders[i][j] == "Mathematics")
                        courses.Add(new MathematicsCourse());
                    if (orders[i][j] == "Economics")
                        courses.Add(new EconomicsCourse());
                }
                result[i] = users[int.Parse(orders[i][0])].order(courses);
            }
            return result;
        }

    }

   
}



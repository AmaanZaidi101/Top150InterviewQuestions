using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLibrary
{
    public class ArrayFunctions
    {
        public double FindMedianSortedArrays(int[] num1, int[] num2)
        {
            int totalLength = num1.Length + num2.Length;

            int firstMedian = (totalLength) / 2 - 1;
            int secondMedian = (totalLength) / 2;

            bool even = false;

            if (totalLength % 2 == 0)
                even = true;

            if (num1.Length > 0 && num2.Length > 0)
            {

                int[] num3 = new int[totalLength];
                int count1 = 0, count2 = 0, count3 = 0;

                while (count1 < num1.Length && count2 < num2.Length)
                {
                    if (num1[count1] < num2[count2])
                    {
                        num3[count3] = num1[count1];
                        count1++;
                    }
                    else
                    {
                        num3[count3] = num2[count2];
                        count2++;
                    }
                    count3++;
                    if (even)
                    {
                        if (count3 > firstMedian && count3 > secondMedian)
                            return (num3[firstMedian] + num3[secondMedian]) / 2.0;
                    }
                    else
                    {
                        if (count3 > secondMedian)
                            return (double)(num3[secondMedian]);
                    }
                }
                while (count1 < num1.Length)
                {
                    num3[count3] = num1[count1];
                    count1++;
                    count3++;
                    if (even)
                    {
                        if (count3 > firstMedian && count3 > secondMedian)
                            return (num3[firstMedian] + num3[secondMedian]) / 2.0;
                    }
                    else
                    {
                        if (count3 > secondMedian)
                            return (double)(num3[secondMedian]);
                    }
                }
                while (count2 < num2.Length)
                {
                    num3[count3] = num2[count2];
                    count2++;
                    count3++;
                    if (even)
                    {
                        if (count3 > firstMedian && count3 > secondMedian)
                            return (num3[firstMedian] + num3[secondMedian]) / 2.0;
                    }
                    else
                    {
                        if (count3 > secondMedian)
                            return (double)(num3[secondMedian]);
                    }
                }
            }
            else if (num1.Length > 0)
            {
                if (even)
                {
                    return (num1[firstMedian] + num1[secondMedian]) / 2.0;
                }
                else
                {
                    return (double)(num1[secondMedian]);
                }
            }
            else if (num2.Length > 0)
            {
                if (even)
                {
                    return (num2[firstMedian] + num2[secondMedian]) / 2.0;
                }
                else
                {
                    return (double)(num2[secondMedian]);
                }
            }
            else
                return 0.00;
            return 0.00;
        }

        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            bool flag = false;
            
            int nextPos = 1;
            int i=0;
            int j=0;
            while (i<nums.Length)
            {
                j = i + 1;
                while (j < nums.Length && nums[i] == nums[j])
                {
                    j++;
                    flag = true;
                }
                if (j < nums.Length && nextPos < nums.Length)
                {
                    nums[nextPos++] = nums[j];
                    i = j;
                }
                else
                {
                    i++;
                }
            }
            //for (i = 0; i < nums.Length; i++)
            //{
            //    j = i + 1;
            //    while (j < nums.Length && nums[i] == nums[j])
            //    {
            //        j++;
            //        flag = true;
            //    }
            //    if (j < nums.Length && nextPos < nums.Length)
            //    {
            //        nums[nextPos++] = nums[j];
            //        i = j;
            //    }
            //}
            return flag ? nextPos : nums.Length;
            
        }

        private void PrintArray(int[] nums)
        {
            foreach (var num in nums)
            {
                Console.Write(num+" ");
            }
        }

        public int Search(int[] nums, int target)
        {
            int index = FindZeroIndex(nums,target,0,nums.Length-1);
            return index;
        }

        private int FindZeroIndex(int[] nums, int target, int first, int last)
        {
            if (first == last && nums[first] != target)
                return -1;
            if (nums[first] == target)
                return first;
            if (nums[last] == target)
                return last;
            int mid = (first + last) / 2;
            if (nums[mid] == target)
                return mid;

            
                if(nums[mid] < nums[last] && nums[mid] > nums[first])
                {
                    if (target > nums[mid])
                        return FindZeroIndex(nums, target, mid + 1, last);
                    else
                        return FindZeroIndex(nums, target, first, mid - 1);
                }
                if (nums[mid] > nums[last] && nums[mid] > nums[first])
                {
                    if (target > nums[mid])
                        return FindZeroIndex(nums, target, mid+1, last);
                    else if (target < nums[mid] && target > nums[last])
                        return FindZeroIndex(nums, target, first, mid - 1);
                    else
                        return FindZeroIndex(nums, target, mid+1, last);
            }
                if (nums[mid] < nums[last] && nums[mid] < nums[first])
                {
                    if (target < nums[mid])
                        return FindZeroIndex (nums, target, first, mid-1);
                    else if(target > nums[mid] && target > nums[last])
                        return FindZeroIndex (nums, target, first, mid - 1);
                    else
                        return FindZeroIndex(nums, target, mid+1, last);
            }
            return -1;
        }
        public int[] SearchRange(int[] nums, int target)
        {
            return new int[] { FindLeftSide(nums, target), FindRightSide(nums, target) };
        }

       
        private int FindLeftSide(int[] nums, int target)
        {
            int index = -1;
            int first = 0;
            int last = nums.Length - 1;

            while(first <= last)
            {
                int mid = first + (last-first) / 2;
                if (nums[mid] >= target)
                    last = mid - 1;
                else
                    first = mid + 1;
                if (nums[mid] == target)
                    index = mid;
            }
            return index;
        }

        private int FindRightSide(int[] nums, int target)
        {
            int index = -1;
            int first = 0;
            int last = nums.Length - 1;

            while(first <= last)
            {
                int mid = first + (last-first) / 2;
                if (nums[mid] <= target)
                    first = mid + 1;
                else
                    last = mid - 1;
                if (nums[mid] == target)
                    index = mid;
            }
            return index;
        }

        public int FirstMissingPositive(int[] nums)
        {
            /*Array.Sort(nums);
            int smallest = nums[0];
            int index = 0;
            while(index < nums.Length && nums[index] <= 0)
            {
                index++;
            }
            int posInt=1;

            while(index < nums.Length && posInt == nums[index])
            {
                index++;
                while(index < nums.Length && nums[index] == posInt)
                    index++;
                posInt++;
            }

            return posInt;
            */
            //without sorting
            bool isOnePresent = false;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    isOnePresent = true;
                    break;
                }
            }
            if (!isOnePresent)
                return 1;

            int n = nums.Length;

            //invalidate all negatives, zeros and values greater than length of array

            for (int i = 0; i < n; i++)
            {
                if (nums[i] <= 0 || nums[i] > n)
                    nums[i] = 1;
            }

            for (int i = 0; i < n; i++)
            {
                int index = Math.Abs(nums[i]);

                if (index < n) //invalidate the box index of which is nums[index]
                    nums[index] = -Math.Abs(nums[index]);
                else //put in 0 because zeroes are already gone
                    nums[0] = -Math.Abs(nums[0]);
            }

            for (int i = 1; i < n; i++)
            {
                if (nums[i] > 0)
                    return i;
            }

            if (nums[0] > 0) //this mean n is missing
                return n;
            return n + 1;
        }

        public IList<IList<int>> Permute(int[] nums)
        {
            return GetPermutations(nums.ToList()).ToArray();
        }

        private List<List<int>> GetPermutations(List<int> nums)
        {
            List<List<int>> list = new List<List<int>>();
            if (nums.Count == 1)
            {
                list.Add(new List<int>(){ nums[0]});
                return list;
            }

            for (int i = 0; i < nums.Count; i++)
            {
                int fix =  nums[i];
                nums.Remove(fix);
                var perms = GetPermutations(nums);
                for (int j = 0; j < perms.Count; j++)
                {
                    perms[j].Add(fix);
                }
                list.AddRange(perms);
                nums.Insert(i,fix);
            }

            return list;

        }

        public void Rotate(int[][] matrix)
        {
            Console.WriteLine("Before");
            PrintMatrix(matrix);
            ConvertRowsToColumns(matrix);
            Console.WriteLine("After row to column");
            SwapColumns(matrix);
            PrintMatrix(matrix);
            Console.WriteLine("After swap");
            PrintMatrix(matrix);
        }

        private void SwapColumns(int[][] matrix)
        {
            int first = 0;
            int n = matrix.Length;
            int last = n - 1;
            while(first < last)
            {
                for (int row = 0; row < n; row++)
                {
                    int tmp = matrix[row][first];
                    matrix[row][first] = matrix[row][last];
                    matrix[row][last] = tmp;
                }
                first++;
                last--;
            }
        }

        private void ConvertRowsToColumns(int[][] matrix)
        {
            int n = matrix.Length;
            for (int row = 0; row < n; row++)
            {
                for (int col = row; col < n; col++) //increase column along with row otherwise we'll undo our previous replace
                {
                    int tmp = matrix[row][col];
                    matrix[row][col] = matrix[col][row];
                    matrix[col][row] = tmp;
                }
            }
        }

        private void PrintMatrix(int[][] image)
        {
            int m = image.Length;
            for (int i = 0; i < m; i++)
            {
                int n = image[i].Length;
                for (int j = 0; j < n; j++)
                {
                    Console.Write(image[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        private void PrintCharMatrix(char[][] image)
        {
            int m = image.Length;
            for (int i = 0; i < m; i++)
            {
                int n = image[i].Length;
                for (int j = 0; j < n; j++)
                {
                    Console.Write(image[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        public int MaxSubArray(int[] nums)
        {
            int maxSum = nums[0];
            int sum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (sum < 0)
                    sum = 0;
                sum += nums[i];
                maxSum = Math.Max(sum, maxSum);
            }

            return maxSum;
        }

        private int MaxSubArraydeAndConquer(int[] nums, int first, int last)
        {
            int mid = (first + last)/ 2;
            int lss = MaxSubArraydeAndConquer(nums, first, mid);
            int rss = MaxSubArraydeAndConquer(nums, mid, last);

            int css = middle(nums, first, mid, last);

            return Math.Max(Math.Max(lss, rss), css);
        }

        private int middle(int[] nums, int first, int mid, int last)
        {
            int lsum = int.MinValue;
            int rsum = int.MinValue;
            int sum = 0;
            int pointer = mid;
            while(pointer >=0)
            {
                sum += nums[pointer];
                if (sum > lsum)
                    lsum = sum;
                pointer--;
            }
            pointer = mid;
            sum = 0;
            while (pointer <= last)
            {
                sum += nums[pointer];
                if (sum > rsum)
                    rsum = sum;
                pointer++;
            }
            return Math.Max(rsum, lsum);
        }
        public IList<int> SpiralOrder(int[][] matrix)
        {
            List<int> list = new List<int>();
            int m = matrix.Length;
            int n = matrix[0].Length;

            bool[,] map = new bool[m, n];

            int total = m * n;
            list.Add(matrix[0][0]);
            map[0, 0] = true;
            int row = 0;
            int col = 0;
            int direction = 0;
            while (list.Count < total)
            {
                if (direction == 0)//right
                {
                    if (col + 1 < n && !map[row, col + 1])
                    {
                        list.Add(matrix[row][col + 1]);
                        map[row, col + 1] = true;
                        col++;
                    }
                    else
                        direction++;
                }
                else if (direction == 1)//down
                {
                    if (row + 1 < m && !map[row + 1, col])
                    {
                        list.Add(matrix[row + 1][col]);
                        map[row + 1, col] = true;
                        row++;
                    }
                    else
                        direction++;
                }
                else if (direction == 2)//left
                {
                    if (col - 1 >= 0 && !map[row, col - 1])
                    {
                        list.Add(matrix[row][col - 1]);
                        map[row, col - 1] = true;
                        col--;
                    }
                    else
                        direction++;
                }
                else //up
                {
                    if (row - 1 >= 0 && !map[row - 1, col])
                    {
                        list.Add(matrix[row - 1][col]);
                        map[row - 1, col] = true;
                        row--;
                    }
                    else
                        direction = 0;
                }
            }

            return list;
        }

        public bool CanJump(int[] nums)
        {
            bool?[] cache = new bool?[nums.Length];
            return CanIJump(nums, 0, cache);
        }

        private bool CanIJump(int[] nums, int currentPos, bool?[] cache)
        {
            if (currentPos >= nums.Length - 1)
            {
                return true;
            }

            if (cache[currentPos].HasValue)
                return cache[currentPos].GetValueOrDefault();


            if (nums[currentPos] == 0)
            {
                cache[currentPos] = false;
                return false;
            }

            int maxJump = nums[currentPos];

            while (maxJump > 0)
            {
                int nextPos = currentPos + maxJump;
                if (CanIJump(nums, nextPos, cache))
                {
                    cache[currentPos] = true;
                    return true;
                }
                maxJump--;
            }

            cache[currentPos] = false;
            return false;
        }

        public bool CanJumpGreedy(int[] nums)
        {
            int goalIndex = nums.Length - 1;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                if (nums[i] + i >= goalIndex)
                    goalIndex = i;
            }
            return goalIndex == 0;
        }

        public bool CanJumpSlidingWindow(int[] nums)
        {
            int left = 0; //used to iterate over all indexes
            int right = 0;

            while(right < nums.Length && left <= right)
            {
                right = Math.Max(left + nums[left], right);
                left++;
            }
            if(right < nums.Length-1)
                return false;
            return true;
        }

        public int[][] Merge(int[][] intervals)
        {

            if (intervals.Length == 1)
                return intervals;

            List<int[]> original = new List<int[]>();
            original.AddRange(intervals);

            for (int i = 0; i < original.Count; i++)
            {
                int start = original[i][0];
                int end = original[i][1];
                int[] outer = original[i];
                for (int j = 0; j < original.Count; j++)
                {
                    int[] inner = original[j];
                    int currStart = original[j][0];
                    int currEnd = original[j][1];

                    if (currStart == start && currEnd == end && i==j)
                        continue;
                    
                    if(currEnd == end || currStart == start || (currStart <= end && currEnd > start) || (start <= currEnd && end > currStart))
                    {
                        int s = Math.Min(start, currStart);
                        int e = Math.Max(end, currEnd);
                        Console.WriteLine($"Merging [{start},{end}] and [{currStart},{currEnd}] into [{s},{e}]");
                        original.Remove(inner);
                        original.Remove(outer);
                        original.Add(new int[] { s, e });
                        i = 0;
                    }
                }
            }

            return original.ToArray();

        }

        public int[][] MergeAfterSort(int[][] intervals)
        {

            if (intervals.Length == 1)
                return intervals;

            List<int[]> list = intervals.ToList();
            list.Sort((a, b) => { return a[0] - b[0]; });

            for (int i = 0; i < list.Count-1; i++)
            {
                if(list[i][1] >= list[i+1][0]) //if current end greater equal to next start
                {
                    list[i][1] = Math.Max(list[i][1], list[i + 1][1]); // greater end time, start time already sorted
                    list.RemoveAt(i + 1);
                    i--;
                }
            }

            return list.ToArray();
        }

        public int UniquePaths(int m, int n)
        {
            int?[,] cache = new int?[m, n];
            return WaysToReach(m - 1, n - 1, cache);
        }

        private int WaysToReach(int m, int n, int?[,] cache)
        {
            if (m == 0 || n == 0)
                return 1;

            if (cache[m, n].HasValue)
                return cache[m, n].GetValueOrDefault();
            
            int topCell = 0;
            if (m - 1 >= 0)
                topCell = WaysToReach(m - 1, n, cache);
            int leftCell = 0;

            if (n - 1 >= 0)
                leftCell = WaysToReach(m, n - 1, cache);

            cache[m, n] = topCell + leftCell;

            return topCell + leftCell;
        }

        public int[] PlusOne(int[] digits)
        {
            int carry = 1;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                int sum = digits[i] + carry;
                carry = sum / 10;

                if (carry == 0)
                {
                    digits[i] = sum;
                    break;
                }
                else
                {
                    digits[i] = sum - 10;
                }
            }
            if (carry > 0)
            {
                int[] arr = new int[digits.Length + 1];
                digits.CopyTo(arr, 1);
                arr[0] = carry; 
                return arr;
            }
            return digits;
        }
        public void SetZeroes(int[][] matrix)
        {
            Console.WriteLine("Before");
            PrintMatrix(matrix);

            int m = matrix.Length;
            List<int> rows = new List<int>();
            List<int> cols = new List<int>();

            for (int i = 0; i < m; i++)
            {
                int n = matrix[i].Length;
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        rows.Add(i);
                        cols.Add(j);
                    }
                }
            }

            for (int i = 0; i < rows.Count; i++)
            {
                int n = matrix[rows[i]].Length;
                for (int j = 0; j < n; j++)
                {
                    matrix[rows[i]][j] = 0;
                }
            }
            for (int i = 0; i < cols.Count; i++)
            {
                int n = matrix.Length;
                for (int j = 0; j < n; j++)
                {
                    matrix[j][cols[i]] = 0;
                }
            }
            Console.WriteLine("After");
            PrintMatrix(matrix);

        }

        private void SetZeroesConstantSpace(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;

            //we'll use first row as ar colList
            //first col as our row list
            //plus on extra indicator for first row

            bool isFirstRowZero = false;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(matrix[i][j] == 0)
                    {
                        matrix[0][j] = 0;
                        if (j != 0)
                            matrix[i][0] = 0;
                        else
                            isFirstRowZero = true;
                    }
                }
            }
            //skip first row and column
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (matrix[0][j] == 0 || matrix[0][j] == 0)
                        matrix[i][j] = 0;
                }
            }

            //if first 0,0 is zero then zero out all rows of first column
            if(matrix[0][0] == 0)
            {
                for (int i = 0; i < m; i++)
                {
                    matrix[i][0] = 0;
                }
            }

            //zero out first row
            if(isFirstRowZero)
            {
                for (int i = 0; i < n; i++)
                {
                    matrix[0][i] = 0;
                }
            }

        }
        public IList<IList<int>> Subsets(int[] nums)
        {
            var result = new List<List<int>>();
            FindCombination(nums, 0, new List<int>(), result);
            return result.ToArray();
        }

        private void FindCombination(int[] nums, int index, List<int> list, List<List<int>> result)
        {
            if (index == nums.Length)
            {
                result.Add(new List<int>(list));
                return;
            }

            //include this index in existing list
            list.Add(nums[index]);
            FindCombination(nums, index + 1, list, result);

            //dont include the index
            list.Remove(nums[index]);
            FindCombination(nums, index + 1, list, result);
        }

        public bool Exist(char[][] board, string word)
        {
            int m = board.Length;
            int n = board[0].Length;
            if (word.Length > m * n)
                return false;
            bool[,] map = new bool[m, n];
            //return CheckIfExists(board, word,map,m,n);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (CheckIfExistsSimpler(board, word,map, m, n, i,j))
                        return true;
                }
            }
            return false;
        }

        enum Direction
        {
            right,
            down,
            left,
            up
        }
        private bool CheckIfExists(char[][] board, string word, bool[,] map, int m, int n, int row=0, int col=0, int index=0, string newword="")
        {
            //Console.WriteLine("Looking for "+word[index]);
            if (index == word.Length-1 && board[row][col] == word[index])
                return true;

            Direction direction = Direction.right;
            
            while(row >=0 && col >=0 && row < m && col < n)
            {
                if (board[row][col] == word[index] && ((int)direction) < 4 && word.Length >1)
                {
                    //move to next character
                    switch (direction)
                    {
                        case Direction.right:
                            if (col + 1 < n && !map[row, col + 1])
                            {
                                map[row, col + 1] = true;
                                var res = CheckIfExists(board, word, map, m, n, row, col + 1, index + 1);
                                if (!res)
                                {
                                    direction++;
                                    map[row, col + 1] = false;
                                }
                                else
                                    return true;
                            }
                            else
                                direction++;
                            break;
                        case Direction.down:
                            if (row + 1 < m && !map[row + 1, col])
                            {
                                map[row + 1, col] = true;
                                var res = CheckIfExists(board, word, map, m, n, row + 1, col, index + 1);
                                if (!res)
                                {
                                    direction++;
                                    map[row + 1, col] = false;
                                }
                                else
                                    return true;
                            }
                            else
                                direction++;
                            break;
                        case Direction.left:
                            if (col - 1 >= 0 && !map[row, col - 1])
                            {
                                map[row, col - 1] = true;
                                var res = CheckIfExists(board, word, map, m, n, row, col - 1, index + 1);
                                if (!res)
                                {
                                    direction++;
                                    map[row, col - 1] = false;
                                }
                                else
                                    return true;
                            }
                            else
                                direction++;
                            break;
                        case Direction.up:
                            if (row - 1 >= 0 && !map[row - 1, col])
                            {
                                map[row - 1, col] = true;
                                var res = CheckIfExists(board, word, map, m, n, row - 1, col, index + 1);
                                if (!res)
                                {
                                    direction++;
                                    map[row - 1, col] = false;
                                }
                                else
                                    return true;
                            }
                            else
                                direction++;
                            break;
                        default:
                                return false;
                            break;
                    }
                }
                else if (board[row][col] == word[index] && word.Length == 1)
                {
                    return true;
                }
                else if (index == 0)
                {
                    direction = 0;
                    col++;
                    if (col == n)
                    {
                        col = 0;
                        row++;
                    }
                }
                else
                    return false;
            }

            return false;
        }
        private bool CheckIfExistsSimpler(char[][] board, string word, bool[,] map, int m, int n, int row = 0, int col = 0, int index = 0)
        {
            if (index == word.Length)
                return true;

            if (row < 0 || col < 0 || row >= m || col >= n || board[row][col] != word[index] || map[row,col])
                return false;

            map[row, col] = true;
            var res = CheckIfExistsSimpler(board, word, map, m, n, row, col + 1, index + 1) ||
                CheckIfExistsSimpler(board, word, map, m, n, row + 1, col, index + 1) ||
                CheckIfExistsSimpler(board, word, map, m, n, row, col - 1, index + 1) ||
                CheckIfExistsSimpler(board, word, map, m, n, row - 1, col, index + 1);
            map[row, col] = false;
            return res;
        }

        public int LargestRectangleArea(int[] heights)
        {
            int maxaArea = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                int height = heights[i];
                for (int j = i; j < heights.Length; j++)
                {
                    int width = j - i + 1;
                    height = Math.Min(height,heights[j]);
                    //for (int k = i; k <= j; k++)
                    //{
                    //    height = Math.Min(height, heights[k]);
                    //}
                    int area = height * width;
                    maxaArea = Math.Max(area, maxaArea);
                }
            }
            return maxaArea;
        }
        public int LargestRectangleAreaByStack(int[] heights)
        {
            int maxArea = 0;
            Stack<KeyValuePair<int, int>> indexHeight = new Stack<KeyValuePair<int, int>>(); //stack stores index - height pairs

            for (int i = 0; i < heights.Length; i++)
            {
                int start = i;
                while(indexHeight.Count > 0 && indexHeight.Peek().Value > heights[i])
                {
                    var ih = indexHeight.Pop();
                    int poppedIndex = ih.Key;
                    int poppedHeight = ih.Value;
                    start = poppedIndex; //extend current height's starting point backwards because current height is smaller and can extend back
                    int width = (i - poppedIndex);
                    int area = poppedHeight * width;
                    maxArea = Math.Max(area, maxArea);
                }
                indexHeight.Push(new KeyValuePair<int, int>(start, heights[i]));
            }

            //check area for heights that extend upto the end of histogram
            foreach (var item in indexHeight)
            {
                int height = item.Value;
                int width = heights.Length - item.Key;
                int area = height * width;
                maxArea = Math.Max(area, maxArea);
            }

            return maxArea;
        }
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (n == 0)
                return;
            if (m == 0)
            {
                nums2.CopyTo(nums1, 0);
                return;
            }
            int[] nums3 = new int[m + n];
            int i = 0;
            int j = 0;
            int k = 0;
            while (i < m && j < n)
            {
                if (nums1[i] <= nums2[j])
                {
                    nums3[k] = nums1[i];
                    i++;
                }
                else
                {
                    nums3[k] = nums2[j];
                    j++;
                }
                k++;
            }
            while (i < m)
            {
                nums3[k] = nums1[i];
                k++;
                i++;
            }
            while (j < n)
            {
                nums3[k] = nums2[j];
                k++;
                j++;
            }

            nums3.CopyTo(nums1, 0);
        }

        public int LongestConsecutive(int[] nums)
        {

            if (nums.Length == 0)
                return 0;
            Array.Sort(nums);

            int maxCount = 1;
            int count = 1;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i + 1] - nums[i] == 1)
                    count++;
                else if (nums[i + 1] - nums[i] == 0)
                    continue;
                else
                {
                    maxCount = Math.Max(maxCount, count);
                    count = 1;
                }

            }
            return Math.Max(maxCount, count);
        }

        public int LongestConsecutiveUsingSet(int[] nums)
        {
            int maxCount = 0;
            var set = new HashSet<int>(nums);
            foreach (var num in nums)
            {
                if(!set.Contains(num-1))
                {
                    int count = 0;
                    while(set.Contains(num+count))
                    {
                        count++;
                    }
                    maxCount = Math.Max(count, maxCount);
                }
            }
            return maxCount;
        }

        public void Solve(char[][] board)
        {
            int m = board.Length;
            int n = board[0].Length;
            Console.WriteLine("Before");
            PrintCharMatrix(board);
            var map = FindAllConnectedOs(board, m, n);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(board[i][j] == 'O' && !map[i,j])
                    {
                            board[i][j] = 'X';
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("After");
            Console.WriteLine();
            PrintCharMatrix(board);
        }

        private bool[,] FindAllConnectedOs(char[][] board, int m, int n)
        {
            bool[,] map = new bool[m, n];
            
            for (int row = 0; row < m; row++)
            {
                if (board[row][0] == 'O') //left most column
                    FillMap(board, map, row, 0, m, n);

                if (board[row][n - 1] == 'O')//right most column
                    FillMap(board, map, row, n - 1, m, n);
            }

            for (int col = 0; col < n; col++)
            {
                if (board[0][col] == 'O') //upper most row
                    FillMap(board, map, 0, col, m, n);

                if (board[m - 1][col] == 'O') //lowest row
                    FillMap(board, map, m - 1, col, m, n);
            }
            return map;
        }

        private void FillMap(char[][] board, bool[,] map, int row, int col, int m, int n)
        {
            if (!map[row, col])
            {
                map[row, col] = true;

                Queue<KeyValuePair<int, int>> queue = new Queue<KeyValuePair<int, int>>();
                queue.Enqueue(new KeyValuePair<int, int>(row, col));

                while (queue.Count > 0)
                {

                    var rowcol = queue.Dequeue();
                    int r = rowcol.Key;
                    int c = rowcol.Value;

                    if (c + 1 < n && !map[r, c + 1] && board[r][c + 1] == 'O') //look right
                    {
                        queue.Enqueue(new KeyValuePair<int, int>(r, c + 1));
                        map[r, c + 1] = true;
                    }
                    if (c - 1 >= 0 && !map[r, c - 1] && board[r][c - 1] == 'O')//look left
                    {
                        queue.Enqueue(new KeyValuePair<int, int>(r, c - 1));
                        map[r, c - 1] = true;
                    }
                    if (r - 1 >= 0 && !map[r - 1, c] && board[r - 1][c] == 'O') //look up
                    {
                        queue.Enqueue(new KeyValuePair<int, int>(r - 1, c));
                        map[r - 1, c] = true;
                    }
                    if (r + 1 < m && !map[r + 1, c] && board[r + 1][c] == 'O') //look down
                    {
                        queue.Enqueue(new KeyValuePair<int, int>(r + 1, c));
                        map[r + 1, c] = true;
                    }
                }
            }
        }
        private bool CanWeFlip(char[][] board, int i, int j, int m, int n)
        {
            if (i == m - 1 || j == n - 1 || m == 0 || n == 0)
                return false;
            bool up=false, down=false, left=false, right=false;
            //look up
            for (int row = i-1; row >= 0; row--)
            {
                if (board[row][j] == 'X')
                {
                    up = true;
                    break;
                }
            }
            //look down
            for (int row = i; row < m; row++)
            {
                if (board[row][j] == 'X')
                {
                    down = true;
                    break;
                }
            }
            //look right
            for (int col = j; col < n; col++)
            {
                if(board[i][col] == 'X')
                {
                    right = true;
                    break;
                }
            }
            //look left
            for (int col = j-1; col >= 0; col--)
            {
                if (board[i][col] == 'X')
                {
                    left = true;
                    break;
                }
            }

            return up && down && left && right;
        }

        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            if (gas.Length == 1)
                return gas[0] >= cost[0] ? 0 : -1;
            //for (int i = 0; i < gas.Length; i++)
            //{
            //    if (gas[i] > cost[i])
            //    {
            //        if (CanComplete(gas, cost, i, i, i + 1))
            //            return i;
            //    }
            //}
            //for (int i = 0; i < gas.Length; i++)
            //{

            //    if(gas[i] >= cost[i])
            //    {
            //        int extraGas = 0;
            //        int index = i;
            //        while (gas[index] + extraGas >= cost[index])
            //        {
            //            extraGas = gas[index] + extraGas - cost[index];
            //            index++;

            //            if (index == gas.Length)
            //                index = 0;

            //            if (index == i)
            //                return i;
            //            if (extraGas < 0)
            //                break;

            //        }
            //        i = index > i? index : i;
            //    }

            //}
            //for revolution the sum of gas should be greater tha or equal to sum of cost

            int totalSum = 0;
            int ans = 0;
            int rangeSum = 0;
            for (int i = 0; i < gas.Length; i++)
            {
                int gasRemaining = gas[i] - cost[i];
                rangeSum += gasRemaining;
                totalSum += gasRemaining;
                //for any given i if range fails then it is not the answer so we increment it
                if (rangeSum < 0)
                {
                    rangeSum = 0;
                    ans = i + 1;
                }
            }


            return totalSum < 0 ? -1 : ans;
        }

        private bool CanComplete(int[] gas, int[] cost, int originalIndex, int startIndex, int nextIndex, int extraGas=0)
        {
            if (nextIndex == gas.Length)
                nextIndex = 0;

            int gasRemaining = gas[startIndex] - cost[startIndex] + extraGas;

            if(gasRemaining >= 0) //we can move to the next station
            {
                if (nextIndex == originalIndex)
                    return true;
                startIndex = nextIndex;
                nextIndex++;
                return CanComplete(gas, cost, originalIndex, startIndex, nextIndex, gasRemaining);
            }
            return false;

        }

        public int SingleNumber(int[] nums)
        {
            int ans = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                ans = ans ^ nums[i]; //XOR of a number with itself is zero. XOR of zero with any number is the number itself so we'll be left with the single non recurring number
            }
            return ans;
        }

        public int MaxProduct(int[] nums)
        {
            int n = nums.Length;
            //we keep track of both min and max because of negatives and positives magnitues
            int currMin = 1, currMax = 1;
            int max=int.MinValue;
            bool hasZero = false;

            for (int i = 0; i < n; i++)
            {
                //zero breaks our chain so reset our max and min pointers
                if (nums[i] == 0)
                {
                    hasZero = true;
                    currMax = 1;
                    currMin = 1;
                    continue;
                }
                int tmp = currMin;
                currMin = Math.Min(Math.Min(nums[i], nums[i] * currMin), nums[i] * currMax);
                currMax = Math.Max(Math.Max(nums[i], nums[i] * tmp), nums[i] * currMax);
                max = Math.Max(currMax, max);
            }
            if (hasZero)
                return Math.Max(max, 0);
            return max;
            //int maxProduct = int.MinValue;
            //for (int i = 0; i < n; i++)
            //{
            //    int product = nums[i];
            //    maxProduct = Math.Max(product, maxProduct);

            //    for (int j = i+1; j < n; j++)
            //    {
            //        product *= nums[j];
            //        maxProduct = Math.Max(product, maxProduct);
            //    }
            //}
            //return maxProduct;
        }

        public int FindPeakElement(int[] nums)
        {
            if (nums.Length == 0)
                return -1;

            if (nums.Length == 1)
                return 0;

            if (nums[0] > int.MinValue && nums[0] > nums[1])
                return 0;

            int n = nums.Length;

            for (int i = 1; i < n-1; i++)
            {
                if (nums[i] > nums[i - 1] && nums[i] > nums[i + 1])
                    return i;
            }

            if (nums[n - 1] > nums[n - 2] && nums[n - 1] > int.MinValue)
                return n - 1;

            return -1;
        }

        public int FindPeakElementLogN(int[] nums)
        {
            int low = 0;
            int high = nums.Length-1;

            while(low < high)
            {
                int mid = low + (high - low) / 2;

                if (nums[mid] < nums[mid + 1])
                    low = mid + 1;
                else
                    high = mid;
            }
            return low;
        }
        public string LargestNumber(int[] nums)
        {
            var strArr = Array.ConvertAll<int,string>(nums, x=> x.ToString());
            Array.Sort(strArr, (x, y) =>
             {
                //which one is lexicographically better i.e. greater
                string firstCombination = x + y;
                 string secondCombination = y + x;
                 return secondCombination.CompareTo(firstCombination);
             });

            if (strArr[0] == "0") //dont want to append more than one zeroes
                return "0";

            return string.Join("", strArr);
        }
        public void Rotate(int[] nums, int k)
        {
            //in place
            int n = nums.Length;
            k = k % n; //for case when k > n
            Array.Reverse(nums);
            Array.Reverse(nums, 0, k);
            Array.Reverse(nums, k + 1, n - k -1);
            PrintArray(nums);
        }

        private void Swap(int[] nums, int i, int pos)
        {
            int tmp = nums[i];
            nums[i] = nums[pos];
            nums[pos] = tmp;
        }

        public int NumIslands(char[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            bool[,] seen = new bool[m, n];
            int count = 0;
            List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>();
            
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == '1')
                        list.Add(new KeyValuePair<int, int>(i, j));
                }
            }

            foreach (var rowcol in list)
            {
                int row = rowcol.Key;
                int col = rowcol.Value;

                if (seen[row, col])
                    continue;

                Queue<KeyValuePair<int, int>> queue = new Queue<KeyValuePair<int, int>>();
                queue.Enqueue(rowcol);
                while(queue.Count > 0)
                {
                    var rc = queue.Dequeue();
                    int r = rc.Key;
                    int c = rc.Value;

                    seen[r, c] = true;

                    //find all connected 1s aka land
                    if (r - 1 >= 0 && grid[r - 1][c] == '1' && !seen[r - 1, c])
                        queue.Enqueue(new KeyValuePair<int, int>(r - 1, c));
                    if (r + 1 < m && grid[r + 1][c] == '1' && !seen[r + 1, c])
                        queue.Enqueue(new KeyValuePair<int, int>(r + 1, c));
                    if (c - 1 >= 0 && grid[r][c - 1] == '1' && !seen[r, c - 1])
                        queue.Enqueue(new KeyValuePair<int, int>(r, c - 1));
                    if (c + 1 < n && grid[r][c + 1] == '1' && !seen[r, c + 1])
                        queue.Enqueue(new KeyValuePair<int, int>(r, c + 1));
                }
                //when all connected 1s have been exhausted then increase count
                count++;
            }
            return count;
        }

        public int NumIslandsLessMemory(char[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int count = 0;
            
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        count++; //increment because we are going to alter all the other connected 1s anyway
                        Queue<int[]> queue = new Queue<int[]>();
                        queue.Enqueue(new int[] { i, j });
                        while (queue.Count > 0)
                        {
                            var rc = queue.Dequeue();
                            int r = rc[0];
                            int c = rc[1];

                            grid[r][c] = 'N';

                            //find all connected 1s aka land
                            if (r - 1 >= 0 && grid[r - 1][c] == '1')
                                queue.Enqueue(new int[] { r - 1, c });
                            if (r + 1 < m && grid[r + 1][c] == '1')
                                queue.Enqueue(new int[] { r + 1, c });
                            if (c - 1 >= 0 && grid[r][c - 1] == '1')
                                queue.Enqueue(new int[] { r, c - 1 });
                            if (c + 1 < n && grid[r][c + 1] == '1')
                                queue.Enqueue(new int[] { r, c + 1 });
                        }
                    }
                }
            }

            return count;
        }

        public int NumIslandsLESSSMEMORY(char[][] grid)
        {

            if (grid == null || grid.Length == 0)
            {
                return 0;
            }

            int numberOfIslands = 0;

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    char v = grid[i][j];
                    if (v == '1')
                    {
                        numberOfIslands += sink(grid, i, j);
                    }
                }
            }

            return numberOfIslands;
        }

        public int sink(char[][] grid, int i, int j)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == '0')
            {
                return 0;
            }

            grid[i][j] = '0';
            sink(grid, i, j + 1);
            sink(grid, i, j - 1);
            sink(grid, i + 1, j);
            sink(grid, i - 1, j);
            return 1;
        }

        public IList<string> FindWords(char[][] board, string[] words)
        {
            int m = board.Length;
            int n = board[0].Length;
            
            List<string> list = new List<string>();
            foreach (var word in words)
            {
                var res = false;
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (word[0] == board[i][j])
                        {
                            bool[,] seen = new bool[m, n];
                            var r = FindWordInBoard1(board, word, i, j, m, n, seen);
                            if(r)
                            {
                                res = true;
                                goto outer;
                            }
                        }
                    }
                }
                outer:
                if (res)
                    list.Add(word);
            }

            return list.ToArray();
        }

        //private bool FindWordInBoard(char[][] board, string word, int row, int col, int m, int n, bool[,] seen, int index=0)
        //{
        //    if (index == word.Length)
        //        return true;

        //    if (col < 0 || col >= n || row < 0 || row >= m || seen[row,col])
        //        return false;

        //    if (board[row][col] != word[index])
        //        return false;

        //    seen[row, col] = true;

        //    int[] dx = { -1, 1, 0, 0 };
        //    int[] dy = { 0, 0, -1, 1 };

        //    for (int i = 0; i < dx.Length; i++)
        //    {
        //        if (FindWordInBoard(board, word, row + dx[i], col + dy[i], m, n, seen, index + 1))
        //            return true;
        //    }
        //    seen[row, col] = false;
        //    return false;
        //}

        private bool FindWordInBoard1(char[][] board, string word, int row, int col, int m, int n, bool[,] seen, int index = 0)
        {
            if (board[row][col] != word[index])
                return false;
            seen[row, col] = true;
            var res = index+1 == word.Length ||
                (row + 1 < m && !seen[row + 1, col] && FindWordInBoard1(board, word, row + 1, col, m, n, seen, index + 1)) ||
                (row - 1 >= 0 && !seen[row - 1, col] && FindWordInBoard1(board, word, row - 1, col, m, n, seen, index + 1)) ||
                (col + 1 < n && !seen[row, col + 1] && FindWordInBoard1(board, word, row, col + 1, m, n, seen, index + 1)) ||
                (col - 1 >= 0 && !seen[row, col - 1] && FindWordInBoard1(board, word, row, col - 1, m, n, seen, index + 1));
            seen[row, col] = false;
            return res;
        }

        public IList<string> FindWordsWithTrie(char[][] board, string[] words)
        {
            int m = board.Length;
            int n = board[0].Length;

            var set = new HashSet<string>();
            Trie2 trie = new Trie2();
            foreach (var word in words)
            {
                trie.AddWord(word);
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    bool[,] seen = new bool[m, n];
                    AddFoundWordsFromPos(trie.root, board, i, j, m ,n, "", seen, set);
                }
            }
            return set.ToArray();
        }

        private void AddFoundWordsFromPos(TrieNode2 node, char[][] board, int row, int col, int m, int n, string word, bool[,] seen, HashSet<string> set)
        {
            if (row < 0 || row >= m || col < 0 || col >= n || seen[row, col] || !node.children.ContainsKey(board[row][col]))
                return;
            seen[row, col] = true;
            node = node.children[board[row][col]];
            word += board[row][col];
            if (node.isEnd)
                set.Add(word);

            AddFoundWordsFromPos(node, board, row+1, col, m, n, word, seen, set);
            AddFoundWordsFromPos(node, board, row-1, col, m, n, word, seen, set);
            AddFoundWordsFromPos(node, board, row, col+1, m, n, word, seen, set);
            AddFoundWordsFromPos(node, board, row, col-1, m, n, word, seen, set);
            seen[row, col] = false;
        }

        public int FindKthLargest(int[] nums, int k)
        {
            int n = nums.Length;
            //kth largest is n-kth smallest
            int index = QuickSelect(nums, 0, n - 1, n-k);
            return nums[index];
        }

        private int QuickSelect(int[] nums, int low, int high, int k)
        {
            if (low >= high)
                return low;
            int i = low;
            int j = high;
            int pivot = high;
            while(i<j)
            {
                while (i <= high && nums[i] < nums[pivot])
                    i++;
                while (j >= low && nums[j] >= nums[pivot])
                    j--;
                if (i < j)
                    Swap(nums, i, j);
            }
            Swap(nums, i, pivot);
            if (i == k)
                return i;
            if (i > k)
                return QuickSelect(nums, low, i - 1, k);
            else
                return QuickSelect(nums, i + 1, high, k);
        }

        private void QuickSort(int[] nums, int low, int high)
        {
            if (low >= high)
                return;

            int pivot = high;
            int i = low;
            int j = high;
            while(i < j)
            {
                while (i <= high && nums[i] < nums[pivot])
                    i++;
                while(j >= low && nums[j] >= nums[pivot])
                    j--;
                if(i < j)
                    Swap(nums, i, j);
            }
            Swap(nums, i, pivot);
            QuickSort(nums, low, i-1);
            QuickSort(nums, i + 1, high);
        }

        public bool ContainsDuplicate(int[] nums)
        {
            var hashMap = new HashSet<int>(nums);
            foreach (var num in nums)
            {
                if (hashMap.Contains(num))
                    return true;
                hashMap.Add(num);
            }
            return false;
        }

        internal class BuildingPoint
        {
            internal int x;
            internal bool isStart;
            internal int height;
        }
        public IList<IList<int>> GetSkyline(int[][] buildings)
        {
            List<BuildingPoint> buildingPoints = new List<BuildingPoint>();

            int index = 0;
            
            for (int i = 0; i < buildings.Length; i++)
            {
                buildingPoints.Add(new BuildingPoint()
                {
                    x = buildings[i][0],
                    height = buildings[i][2],
                    isStart = true
                });

                buildingPoints.Add(new BuildingPoint()
                {
                    x = buildings[i][1],
                    height = buildings[i][2],
                    isStart = false
                });
            }

            
            buildingPoints.Sort((a, b) =>
            {
                if (a.x == b.x) //if both x coordinates are tied
                {
                    if (a.isStart && !b.isStart) // return the start one
                        return -1;
                    else if (a.isStart && b.isStart) //if both are start take max height
                        return b.height - a.height;
                    else if (!a.isStart && !b.isStart) //if both end then take min height
                        return a.height - b.height;
                }
                return a.x - b.x;
            });

            var res = new List<List<int>>();

            var pq = new SortedDictionary<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a))); //max sorted dictionary/queue - handling duplicates by increasing count MAX HEIGHT
            pq.Add(0, 1);

            int prevMax = 0;
            foreach (var bp in buildingPoints)
            {
                if (bp.isStart)
                {
                    if (pq.ContainsKey(bp.height))
                        pq[bp.height]++;
                    else
                        pq.Add(bp.height, 1);
                }
                else
                {
                    if (pq[bp.height] == 1)
                        pq.Remove(bp.height);
                    else
                        pq[bp.height]--;
                }
                int currMax = pq.First().Key;
                if(currMax != prevMax)
                {
                    res.Add(new List<int>() { bp.x, currMax });
                    prevMax = currMax;
                }
            }

            return res.ToArray();

        }
        public int[] ProductExceptSelf(int[] nums)
        {
            long product = 1;
            int countZero = 0;
            int indexZero = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    countZero++;
                    if (countZero > 1)
                        break;

                    indexZero = i;
                }
                else
                    product = product * nums[i];
            }
            if (countZero > 0)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    nums[i] = 0;
                }
                if (countZero == 1)
                    nums[indexZero] = (int)product;
            }
            else
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    nums[i] = (int)(product / nums[i]);
                }
            }


            return nums;
        }

        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            //using First.Value is faster than First()
            //monotonically decreasing queue
            LinkedList<int> deQueue = new LinkedList<int>(); // queue will store indices
            int left=0,right= 0;
            List<int> answer = new List<int>();
            while(right < nums.Length)
            {
                //pop smaller values from queue so left ost of queue contains maximum
                while (deQueue.Count > 0 && nums[deQueue.Last.Value] <= nums[right])
                    deQueue.RemoveLast();
                //add new value index in its correct positions
                deQueue.AddLast(right);

                
                //when we have sliding window length then add result
                if (right + 1 >= k)
                {
                    answer.Add( nums[deQueue.First.Value]);
                    //update sliding window start
                    left += 1;
                }
                //update queue to match sliding window
                if (left > deQueue.First.Value)
                    deQueue.RemoveFirst();

                //right will always update
                right += 1;
            }
            return answer.ToArray();
        }

        public bool SearchMatrix(int[][] matrix, int target)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            int row = 0, col = n-1;
            while(row < m && col >= 0)
            {
                if (matrix[row][col] < target)
                    row++;
                else if (matrix[row][col] > target)
                    col--;
                else
                    return true;
            }
            return false;
        }

        public int MissingNumber(int[] nums)
        {
            int n = nums.Length;
            int sum = nums.Sum();
            int allSum = n * (n + 1) / 2;
            return allSum - sum;

            int xorResult = 0;
            
            //xor of number with itself is zero, xor of zero with  number is number
            for (int i = 0; i <= n; i++)
            {
                xorResult = xorResult ^ nums[i];
            }
            for (int i = 0; i < n; i++)
            {
                xorResult = xorResult ^ nums[i];
            }
            return xorResult;
        }
        public void MoveZeroes(int[] nums)
        {
            int n = nums.Length;
            int left = 0, right = 0;
            
            while(left < n && right < n)
            {
                while (left < n && nums[left] != 0)
                    left++;
                right = left + 1;
                while (right < n && nums[right] == 0)
                    right++;
                if(left < n && right < n)
                    Swap(nums, left, right);
            }

            //other solution\
            //fill every position with non zero first
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] != 0)
                    nums[index++] = nums[i];
            }
            //fill remaining with zeroes
            for (int i = index; i < n; i++)
            {
                nums[i] = 0;
            }
        }
        public int FindDuplicate(int[] nums)
        {
            //floyd's totoise and hare
            int slow = 0, fast = 0;
            do
            {
                slow = nums[slow];
                fast = nums[fast];
                fast = nums[fast];
            } while (slow != fast);

            int secondSlow = 0;
            while(slow != secondSlow)
            {
                slow = nums[slow];
                secondSlow = nums[secondSlow];
            }
            return slow;
        }

        public void GameOfLife(int[][] board)
        {
            PrintMatrix(board);
            Console.WriteLine();
            int m = board.Length;
            int n = board[0].Length;

            int[][] next = new int[m][];
            
            for (int i = 0; i < m; i++)
            {
                next[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    int neighbours = CountNeighbours(board, i, j, m, n);
                    if(board[i][j] ==1)
                    {
                        if (neighbours < 2 || neighbours > 3)
                            next[i][j] = 0;
                        else
                            next[i][j] = 1;
                    }
                    else
                    {
                        if (neighbours == 3)
                            next[i][j] = 1;
                        else
                            next[i][j] = 0;
                    }
                }
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    board[i][j] = next[i][j];
                }
            }
            PrintMatrix(board);

        }

        private int CountNeighbours(int[][] board, int i, int j, int m, int n)
        {
            int count = 0;
            if(i-1 >=0 )
            {
                if (j - 1 >= 0 && board[i - 1][j - 1] == 1)
                    count++;
                if (board[i - 1][j] == 1)
                    count++;
                if (j + 1 < n && board[i - 1][j + 1] == 1)
                    count++;
            }
            if(i+1 <m)
            {
                if (j - 1 >= 0 && board[i + 1][j - 1] == 1)
                    count++;
                if (board[i + 1][j] == 1)
                    count++;
                if (j + 1 < n && board[i + 1][j + 1] == 1)
                    count++;
            }
            if (j - 1 >= 0 && board[i][j - 1] == 1)
                count ++;
            if (j + 1 < n && board[i][j + 1] == 1)
                count++;
            return count;
        }

        public int LengthOfLIS(int[] nums)
        {
            int n = nums.Length;
            if (n == 0)
                return 0;
            SortedSet<int> set = new SortedSet<int>();
            set.Add(nums[0]);
            for (int i = 1; i < n; i++)
            {
                int? ceiling = TreeSetCeiling(nums[i], set);
                if(ceiling == null)
                {
                    set.Add(nums[i]);
                }
                else
                {
                    set.Remove(ceiling.GetValueOrDefault());
                    set.Add(nums[i]);
                }
            }
            return set.Count;
            int[] LIS = new int[n];
            for (int i = 0; i < n; i++)
            {
                LIS[i] = 1;
            }

            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = i+1; j < n; j++)
                {
                    if (nums[i] < nums[j])
                        LIS[i] = Math.Max(LIS[i], 1 + LIS[j]);
                }
            }
            return LIS.Max();
        }

        private int? TreeSetCeiling(int num, SortedSet<int> set)
        {
            foreach (var n in set)
            {
                if (n >= num)
                    return n;
            }
            return null;
        }

        public IList<int> CountSmaller(int[] nums)
        {

            int n = nums.Length;
            (int, int)[] numIndices = new (int, int)[n];
            for (int i = 0; i < n; i++)
            {
                numIndices[i].Item1 = nums[i];
                numIndices[i].Item2 = i;
            }
            int[] answer = new int[n];
            int left = 0;
            int right = n-1;
            CountWithMergeSort(left, right, numIndices, answer);
            return answer;
            
            
            
            
            //List<int> sorted = new List<int>();
            //int[] answer = new int[n];
            //for (int i = n - 1; i >= 0; i--)
            //{
            //    int left = 0;
            //    int right = sorted.Count;
            //    while(left < right)
            //    {
            //        int mid = left + (right - left) / 2;
            //        if (sorted[mid] >= nums[i])
            //            right = mid;
            //        else
            //            left = mid + 1;
            //    }
            //    answer[i] = left;
            //    sorted.Insert(left,nums[i]);
            //}
            //return answer;
            
            //increment 1 every time we go to right

            //int n = nums.Length;
            //int[] answer = new int[n];
            //BSTNode root = null;
            //for (int i = n - 1; i >= 0; i--)
            //{
            //    root = InsertIntoTree(root, i, 0, answer, nums);
            //}
            //return answer;
        }

        private void CountWithMergeSort(int left,int right, (int, int)[] numIndices, int[] answer)
        {
            
            if(left < right)
            {
                int mid = left + (right - left) / 2;
                CountWithMergeSort(left, mid, numIndices, answer);
                CountWithMergeSort(mid+1, right, numIndices, answer);
                CountAndMerge(left, mid, right, numIndices, answer);
            }
        }

        private void CountAndMerge(int left, int mid, int right, (int, int)[] numIndices, int[] answer)
        {
            int i = left;
            int j = mid + 1;
            (int, int)[] temp = new (int, int)[right - left + 1];
            int k = 0;
            //DESCENDING
            while(i <= mid && j <= right)
            {
                if(numIndices[i].Item1 > numIndices[j].Item1)
                {
                    answer[numIndices[i].Item2] = right - j + 1;//since it is sorted it will be larger than all elements right of j
                    temp[k++] = numIndices[i++];
                }
                else
                {
                    temp[k++] = numIndices[j++];
                }
            }
            while(i<=mid)
            {
                temp[k++] = numIndices[i++];
            }
            while (j<=right)
            {
                temp[k++] = numIndices[j++];
            }
            for (int x = left; x <= right; x++)
            {
                numIndices[x] = temp[x - left];
            }
        }

        private BSTNode InsertIntoTree(BSTNode root, int index, int leftCountSoFar, int[] answer, int[] nums)
        {
            if(root == null)
            {
                root = new BSTNode(nums[index]);
                answer[index] = leftCountSoFar;
            }
            else if(root.val >= nums[index])//go left - no increment
            {
                root.leftCount++;
                root.left = InsertIntoTree(root.left, index, leftCountSoFar, answer, nums);
            }
            else // go right - increment count since we are going right
            {
                root.right = InsertIntoTree(root.right, index, root.leftCount + leftCountSoFar + 1, answer, nums);
            }
            return root;
        }

        internal class BSTNode
        {
            internal int val;
            internal int leftCount;
            internal BSTNode left;
            internal BSTNode right;
            public BSTNode(int v)
            {
                val = v;
            }
        }

        public int CoinChange(int[] coins, int amount)
        {
            int[] dp = new int[amount+1];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = amount+1; //amound+1 will never be answer so it is like infinity
            }
            dp[0] = 0;
            for (int a = 1; a <= amount; a++)
            {
                foreach (var coin in coins)
                {
                    if (a - coin >= 0)
                        dp[a] = Math.Min(dp[a], 1 + dp[a - coin]);
                }
            }
            return dp[amount] != amount+1 ? dp[amount] : -1;
        }
        public void WiggleSort2(int[] nums)
        {
            //https://www.youtube.com/watch?v=mwsjU6CHOb4
            int n = nums.Length;
            Array.Sort(nums);
            int[] answer = new int[n];
            int i = 1;
            int j = n - 1;
            while(i < n)
            {
                answer[i] = nums[j];
                i += 2;
                j--;
            }
            i = 0;
            while(i<n)
            {
                answer[i] = nums[j];
                i += 2;
                j--;
            }
            Array.Copy(answer, nums, n);
        }
        public void WiggleSort1(int[] nums)
        {//includes equal to
            int n = nums.Length;
            int m = n - n / 2;
            Array.Sort(nums);
            var left = new ArraySegment<int>(nums, 0, m).ToArray();
            var right = new ArraySegment<int>(nums, m, n / 2).ToArray();
            int i = 0;
            int j = 0;
            int k = 0;


            while(i < left.Length && j < right.Length && k < n)
            {
                nums[k++] = left[i++];
                nums[k++] = right[j++];
            }
            while(i < left.Length && k < n)
            {
                nums[k++] = left[i++];
            }
            while(j < right.Length && k < n)
            {
                nums[k++] = right[j++];
            }
        }

        public int LongestIncreasingPath(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            int[,] dp = new int[m, n];
            List<int> ans = new List<int>();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int a = MaxIncPath(i, j, m, n, matrix, dp);
                    ans.Add(a);
                }
            }
            return ans.Max();
        }

        private int MaxIncPath(int row,int col,int m, int n, int[][] matrix, int[,] dp)
        {
            int up=0, down=0, left=0, right=0;
            
            if (dp[row, col] != 0)
                return dp[row, col];
            
            if (row + 1 < m && matrix[row + 1][col] > matrix[row][col])
                down = MaxIncPath(row + 1, col, m, n, matrix, dp);
            if (row - 1 >= 0 && matrix[row - 1][col] > matrix[row][col])
                up = MaxIncPath(row - 1, col, m, n, matrix, dp);
            if (col + 1 < n && matrix[row][col + 1] > matrix[row][col])
                right = MaxIncPath(row, col + 1, m, n, matrix, dp);
            if (col - 1 >= 0 && matrix[row][col - 1] > matrix[row][col])
                left = MaxIncPath(row, col - 1, m, n, matrix, dp);

            dp[row, col] = 1 + Math.Max(Math.Max(left, Math.Max(up, down)), right);
            return dp[row, col];
        }

        public bool IncreasingTriplet(int[] nums)
        {
            int i = int.MaxValue;
            int j = int.MaxValue;
            int n = nums.Length;
            //can be done by LengthOfLIS
            for (int index = 0; index < n; index++)
            {
                if (nums[index] <= i)
                    i = nums[index];
                else if (nums[index] <= j)
                    j = nums[index];
                else //if it is greater than both then it satisfies the sequence
                    return true;
            }
            return false;
        }

        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (dictionary.ContainsKey(num))
                    dictionary[num]++;
                else
                    dictionary.Add(num, 1);
            }
            dictionary = dictionary.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
           
            return dictionary.Keys.Take(k).ToArray();
        }

        public int[] Intersect(int[] nums1, int[] nums2)
        {
            int m = nums1.Length;
            int n = nums2.Length;
            List<int> ans = new List<int>();
            Dictionary<int, int> d1 = new Dictionary<int, int>();
            Dictionary<int, int> d2 = new Dictionary<int, int>();
            if(m < n)
            {
                foreach (var num in nums1)
                {
                    if (d1.ContainsKey(num))
                        d1[num]++;
                    else
                        d1.Add(num, 1);
                }
                int index = 0;
                while(d1.Count > 0 && index < n)
                {
                    int num = nums2[index];
                    if (d1.ContainsKey(num))
                    {
                        ans.Add(num);
                        d1[num]--;
                        if (d1[num] == 0)
                            d1.Remove(num);
                    }
                    
                    index++;
                }
            }
            else
            {
                foreach (var num in nums2)
                {
                    if (d1.ContainsKey(num))
                        d1[num]++;
                    else
                        d1.Add(num, 1);
                }
                int index = 0;
                while (d1.Count > 0 && index < m)
                {
                    int num = nums1[index];
                    if (d1.ContainsKey(num))
                    {
                        ans.Add(num);
                        d1[num]--;
                        if (d1[num] == 0)
                            d1.Remove(num);
                    }

                    index++;
                }
            }
            return ans.ToArray();
        }

        public int KthSmallest(int[][] matrix, int k)
        {
        //https://www.youtube.com/watch?v=F22d27HJsxg
            int low = matrix[0][0];
            int n = matrix.Length;
            int high = matrix[n-1][n-1];
            while(low < high)
            {
                int mid = low + (high - low) / 2;
                int rank = CountRankOfCalculatedNumber(matrix,mid,n);
                if (rank < k)
                    low = mid + 1;
                else
                    high = mid;
            }
            return low;
        }

        private int CountRankOfCalculatedNumber(int[][] matrix, int num, int n)
        {
            int col = n - 1, row = 0;
            int rank = 0;
            while(col >=0 && row < n)
            {
                if (matrix[row][col] > num)
                    col--;
                else
                {
                    rank = rank + col + 1;
                    row++;
                }
            }
            return rank;
        }

        public IList<string> FizzBuzz(int n)
        {

            string[] ans = new string[n];

            for (int i = 0, fizz=0 ,buzz = 0; i < n; i++)
            {
                fizz++;
                buzz++;
                if (fizz == 3 && buzz == 5)
                {
                    ans[i] = "FizzBuzz";
                    fizz = 0;
                    buzz = 0;
                }
                else if (fizz == 3)
                {
                    fizz = 0;
                    ans[i] = "Fizz";
                }
                else if (buzz == 5)
                {
                    ans[i] = "Buzz";
                    buzz = 0;
                }
                else
                    ans[i] = (i+1).ToString();
            }

            return ans;

        }

        public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
        {
            Dictionary<int, int> sum12 = new Dictionary<int, int>();
            foreach (var n1 in nums1)
            {
                foreach (var n2 in nums2)
                {
                    if (sum12.ContainsKey(n1 + n2))
                        sum12[n1 + n2]++;
                    else
                        sum12.Add(n1 + n2, 1);
                }
            }
            int count = 0;
            foreach (var n3 in nums3)
            {
                foreach (var n4 in nums4)
                {
                    if (sum12.ContainsKey(-(n3 + n4)))
                        count += sum12[-(n3 + n4)];
                }
            }
            return count;
        }

        public IList<string> FindMissingRanges(int[] nums, int lower, int upper)
        {
            //another approach - substract a[i+1] - a[i]
            List<string> ans = new List<string>();

            int index = 0;
            int i = lower;
            int start;
            int end;
            while(index < nums.Length && i <= upper)
            {
                
                if(nums[index] == i)
                {
                    index++;
                    i++;
                }
                else if(nums[index] < i)
                {
                    continue;
                }
                else
                {
                    int count = 0;
                    start = i;
                    while (i < nums[index] && i < upper)
                    {
                        i++;
                        count++;
                    }
                    if (i == nums[index])
                        i--;
                    end = i;
                    if (count > 1)
                        ans.Add(start + "->" + end);
                    else
                        ans.Add(start.ToString());
                    i++;
                }
            }
            if (i < upper && upper != i)
                ans.Add(i + "->" + upper);
            else
                ans.Add(upper.ToString());
            return ans;
            
        }

        public int MinMeetingRooms(int[][] interval)
        {
            //basically return max number of simultaneous meetings
            int n = interval.Length;
            List<int> startTimes = new List<int>();
            List<int> endTimes = new List<int>();
            
            foreach (var meeting in interval)
            {
                startTimes.Add(meeting[0]);
                endTimes.Add(meeting[1]);
            }
            startTimes.Sort();
            endTimes.Sort();
            //iterate through starts and end times
            int start = 0;
            int end = 0;
            int count = 0;
            int maxCount = 0;
            while(start < n)
            {
                if (startTimes[start] < endTimes[end])
                {
                    count++;
                    start++;
                }
                else if (startTimes[start] > endTimes[end])
                {
                    count--;
                    end++;
                }
                else //if start and end collide then one meeting is ending before next is starting
                {
                    count--;
                    end++;
                }
                maxCount = Math.Max(count, maxCount);
            }
            return maxCount;
        }

    }

    public class NumMatrix
    {
        int[][] matrix;
        int[,] dp;
        public NumMatrix(int[][] mat)
        {
            matrix = mat;
            int m = matrix.Length;
            int n = matrix[0].Length;
            dp = new int[m, n];
            //calculate sum till current col for all rows
            for (int i = 0; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i, j] += matrix[i][j - 1];
                }
            }
            //calculate sum till current row for all cols
            for (int i = 1; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dp[i, j] += matrix[i - 1][j];
                }
            }

        }

        public int SumRegion(int row1,int col1,int row2, int col2)
        {
            int total = dp[row2, col2];
            int extra = row1 > 0 ? dp[row1 - 1, col2] : 0 + col1 > 0 ? dp[row2, col1 - 1] : 0 - ((row1 > 0 && col1 > 0) ? dp[row1 - 1, col1 - 1] : 0);
            return total - extra;
        }
    }

    


}

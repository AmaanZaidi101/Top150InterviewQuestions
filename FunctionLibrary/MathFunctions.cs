using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionLibrary
{
    public class MathFunctions
    {
        public string IntToRoman(int num)
        {
            string roman = "";
            int quotient;
            int remainder;
            if(num >= 1000)
            {
                quotient = num / 1000; ;
                remainder = num % 1000;
                while (quotient > 0)
                {
                    roman = roman + "M";
                    quotient--;
                }
                return roman + IntToRoman(remainder);
            }
            else if (num >= 900)
            {
                roman = roman + "CM";
                remainder = num - 900;
                return roman + IntToRoman(remainder);
            }
            else if(num >= 500)
            {
                roman = roman + "D";
                remainder = num - 500;
                return roman + IntToRoman(remainder);
            }
            else if(num >= 400)
            {
                roman = roman + "CD";
                remainder = num - 400;
                return roman + IntToRoman(remainder);
            }
            else if(num >=100)
            {
                quotient = num / 100;
                remainder = num % 100;
                while(quotient > 0)
                {
                    roman = roman + "C";
                    quotient--;
                }
                return roman + IntToRoman(remainder);
            }
            else if(num >= 90)
            {
                roman = roman + "XC";
                remainder = num - 90;
                return roman + IntToRoman(remainder);
            }
            else if(num >= 50)
            {
                roman = roman + "L";
                remainder = num - 50;
                return roman + IntToRoman(remainder);
            }
            else if(num >= 40)
            {
                roman = roman + "XL";
                remainder = num - 40;
                return roman + IntToRoman(remainder);
            }
            else if(num >= 10)
            {
                quotient = num / 10;
                remainder = num % 10;
                while(quotient > 0)
                {
                    roman = roman + "X";
                    quotient--;
                }
                return roman + IntToRoman(remainder);
            }
            else if(num >= 9)
            {
                roman = roman + "IX";
                remainder = num - 9;
                return roman + IntToRoman(remainder);
            }
            else if(num >= 5)
            {
                roman = roman + "V";
                remainder = num - 5;
                return roman + IntToRoman(remainder);
            }
            else if(num == 4)
            {
                roman = roman + "IV";
                return roman;
            }
            else
            {
                while(num > 0)
                {
                    roman = roman + "I";
                    num--;
                }
            }
            return roman;
        }
        public int RomanToInt(string s)
        {
            int prev=0;
            int current;
            int sum = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                current = GetInt(s[i]);
                if (prev == 0)
                    sum += current;
                else
                {
                    if (prev > current)
                        sum = sum - current;
                    else
                        sum = sum + current;
                }
                prev = current;
            }
            return sum;
        }

        private int GetInt(char v)
        {
            switch (v)
            {
                case 'M':
                    return 1000;
                case 'D':
                    return 500;
                case 'C':
                    return 100;
                case 'L':
                    return 50;
                case 'X':
                    return 10;
                case 'V':
                    return 5;
                case 'I':
                    return 1;
                default:
                    break;
            }
            return 0;
        }
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> outerList = new List<IList<int>>();
            
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i-1])
                    continue;

                int leftPointer = i + 1;
                int rightPointer = nums.Length - 1;
                
                while (leftPointer < rightPointer)
                {
                    if (nums[i] + nums[leftPointer] + nums[rightPointer] == 0)
                    {
                        outerList.Add(new List<int>() { nums[i], nums[leftPointer], nums[rightPointer] });
                        leftPointer++;
                        while(leftPointer < rightPointer && nums[leftPointer] == nums[leftPointer-1]) //only increase one pointer the loop will handle the other pointer
                            leftPointer++;
                    }
                    else if (nums[i] + nums[leftPointer] + nums[rightPointer] > 0)
                        rightPointer--;
                    else 
                        leftPointer++;
                }
            }
            return outerList;
        }

        public IList<IList<int>> ThreeSuum(int[] nums)
        {
            Dictionary<string, bool> d = new Dictionary<string, bool>();
            IList<IList<int>> outerList = new List<IList<int>>();
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                List<int> list = new List<int>();
                for (int j = i + 1; j < nums.Length; j++)
                {

                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        if (CheckCondition(nums[i], nums[j], nums[k]))
                        {
                            list.Add(nums[i]);
                            list.Add(nums[j]);
                            list.Add(nums[k]);
                            //list.Sort();
                            string key = list[0].ToString() + list[1].ToString() + list[2].ToString();
                            if (!d.ContainsKey(key))
                            {
                                outerList.Add(list);
                                d.Add(key, true);
                            }
                            list = new List<int>();
                        }
                    }
                }
            }
            return outerList;
        }

        private bool CheckCondition(int x, int y, int z)
        {
            return  (x + y + z == 0);
        }

        public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            int sum = int.MaxValue;
            int diff = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                int fix = nums[i];
                int leftPointer = i + 1;
                int rightPointer = nums.Length - 1;

                while (leftPointer < rightPointer)
                {
                    int currsum = nums[leftPointer] + nums[rightPointer] + fix;
                    int currdiff = target - currsum;

                    if(target < currsum)
                    {
                        rightPointer--;
                    }
                    else if(target > currsum)
                    {
                        leftPointer++;
                        while (leftPointer < rightPointer && nums[leftPointer] == nums[leftPointer - 1])
                            leftPointer++;
                    }
                    else
                    {
                        return currsum;
                    }

                    if (Math.Abs(currdiff) < diff)
                    { 
                        diff = Math.Abs(currdiff);
                        sum = currsum;
                    }
                }
            }
            return sum;
        }
        public int Divide1(int dividend, int divisor)
        {
            if (dividend == divisor)
                return 1;
            if (dividend == 0)
                return 0;
            if (divisor == 1)
            {
                if (dividend > int.MaxValue)
                    return int.MaxValue;
                return dividend; 
            }
            if(divisor == -1)
            {
                if (dividend > int.MaxValue || dividend < int.MinValue)
                    return int.MaxValue;
                int q = dividend - dividend - dividend;
                if (q > int.MaxValue || q <= int.MinValue)
                    return int.MaxValue;
            }
            bool negativeFlag = false;
            int resultant = 0;
            int quotient = 0;


            if (dividend < 0 && divisor > 0)
            {
                while(resultant > dividend)
                {
                    quotient++;
                    resultant = resultant - divisor;
                }
                if (resultant < dividend)
                    quotient--;
                negativeFlag = true;
            }
            else if(dividend > 0 && divisor < 0)
            {
                while(resultant < dividend)
                {
                    quotient++;
                    resultant = resultant - divisor;
                }
                if (resultant > dividend)
                    quotient--;
                negativeFlag = true;
            }
            else if(dividend <0 && divisor < 0)
            {
                while(resultant > dividend)
                {
                    quotient++;
                    resultant = resultant + divisor;
                }
                if (resultant < dividend)
                    quotient--;
            }
            else
            {
                while (resultant < dividend)
                {
                    quotient++;
                    resultant = resultant + divisor;
                }
                if (resultant > dividend)
                    quotient--;
            }

            if(quotient > int.MaxValue)
                return int.MaxValue;

            if (negativeFlag)
                quotient = quotient - quotient - quotient;
            if (quotient > int.MaxValue || (negativeFlag && quotient <= int.MinValue))
                return int.MaxValue;
            return quotient;
        }

        public int Divide(int dividend, int divisor)
        {
            if (dividend == divisor)
                return 1;
            if (divisor == 1)
                return dividend;
            if (dividend == int.MinValue && divisor == -1)
                return int.MaxValue;
            if (divisor == -1)
                return -dividend;
            if (divisor == int.MinValue) // will always overflow
                return 0;
            bool isNegative = (divisor > 0 && dividend < 0) || (dividend > 0 && divisor < 0);

            divisor = Math.Abs(divisor);
            int quotient = 0;
            //we cant take abs if dividend is int.MinValue so let's do one step manually
            if(dividend == int.MinValue)
            {
                quotient++;
                dividend = dividend + divisor;
            }
            dividend = Math.Abs(dividend);

            while(dividend - divisor >= 0)
            {
                int count = 0;
                while(dividend - (divisor << 1 << count) >=0)
                {
                    count++;
                }
                quotient += 1 << count; //(1<<count gives us how many times we were able to shift)
                dividend -= divisor << count;
            }
            return isNegative? -quotient: quotient;
        }
        public int Divideee(int dividend, int divisor)
        {
            return DivideAnotherMethod(dividend, divisor);
            //if (dividend == divisor)
            //    return 1;
            //if (dividend == 0)
            //    return 0;
            //if (divisor == 1)
            //{
            //    if (dividend > int.MaxValue)
            //        return int.MaxValue;
            //    return dividend;
            //}
            //if (divisor == -1)
            //{
            //    if (dividend > int.MaxValue || dividend < int.MinValue)
            //        return int.MaxValue;
            //    int q = dividend - dividend - dividend;
            //    if (q > int.MaxValue || q <= int.MinValue)
            //        return int.MaxValue;
            //}
            //if (divisor == int.MinValue)
            //{
            //    return 0;
            //}
            //if (divisor < 0 && dividend <0 && divisor < dividend)
            //{
            //    return 0;
            //}
            //if (divisor > 0 && dividend > 0 && divisor > dividend)
            //{
            //    return 0;
            //}
            
            //string dividendString = dividend.ToString();
            //string divisorString = divisor.ToString();
            //string dividendSign = "+";
            //string divisorSign = "+";
            
            //if(dividendString[0] == '-')
            //{
            //    dividendSign = "-";
            //    dividendString = dividendString.Substring(1);
            //}
            //if (divisorString[0] == '-')
            //{
            //    divisorSign = "-";
            //    divisorString = divisorString.Substring(1);
            //}
            //int answer = Convert.ToInt32(DivisionWithString(dividendString, divisorString));
            //if (dividendSign == divisorSign)
            //    return answer;
            //return answer-answer-answer;
        }

        private int DivideAnotherMethod(int dividend, int divisor)
        {
            int newDividend = dividend;
            int newDivisor = divisor;
            int prevDivisor = divisor;
            int steps = 0;

            while(newDividend - newDivisor >=0)
            {
                if(newDividend - newDivisor >=0)
                {
                    steps++;
                    prevDivisor = newDivisor;
                    newDivisor = newDivisor + newDivisor;
                }
                else
                {
                    newDivisor -= prevDivisor;
                    newDividend = dividend - prevDivisor;
                }
            }
            return steps;
        }

        public string DivisionWithString(string dividend, string divisor, int index=0)
        {
            string toDivide = "";
            string quotient = "";
            for (int i = 0; i < dividend.Length; i++)
            {
                toDivide += dividend[i];
                if (toDivide.Length < divisor.Length)
                {
                    quotient += "0";
                    continue;
                }
                else if (Convert.ToInt32(toDivide) < Convert.ToInt32(divisor))
                {
                    quotient += "0";
                    continue; 
                }
                else
                {
                    int num = Convert.ToInt32(toDivide);
                    int div = Convert.ToInt32(divisor);
                    int q = 0;
                    int res = 0;
                    while (res < num)
                    {
                        res += div;
                        if (res < 0)
                        {
                            res = num;
                            break;
                        }
                        q++;
                    }
                    if (res > num)
                    {
                        res -= div;
                        q--;
                    }
                    quotient += q.ToString();
                    toDivide = (num - res).ToString();
                }
            }
            return quotient;
        }

        public double MyPow(double x, int n)
        {
            if (n == 0)
                return 1;
            if (n == 1)
                return x;
            if (n == int.MinValue)
                return 1.0D/( x * MyPow(x, Math.Abs(n + 1)));

            int pow = Math.Abs(n);
            Dictionary<int, double> cache = new Dictionary<int, double>();
            int firsthalf = pow / 2;
            int secondHalf = pow - firsthalf;
            var a = CalculatePow(x, firsthalf, cache);
            var b = CalculatePow(x, secondHalf, cache);
            return n > 0 ? CalculatePow(x, firsthalf, cache)* CalculatePow(x, secondHalf, cache) : 1.0D / (CalculatePow(x, firsthalf, cache) * CalculatePow(x, secondHalf, cache));
        }

        private double CalculatePow(double x, int n, Dictionary<int,double> cache)
        {
            if (n == 0)
                return 1;
            if (n == 1)
                return x;
            if (cache.ContainsKey(n))
                return cache[n];
            int firsthalf = n / 2;
            int secondHalf = n - firsthalf;
            var res = CalculatePow(x, firsthalf,cache) * CalculatePow(x, secondHalf,cache);
            cache.Add(n, res);
            return cache[n];
        }
        //only for int and int
        public double PowerBitWise(int x, int n)
        {
            if (n == 0)
                return 1;
            if (n == 1)
                return x;
            int ans = 1;
            
            if(n > 0)
            {
                while(n > 0)
                {
                    int lastBit = (x & 1);

                    //check if lsb is set
                    if(lastBit == 1)
                    {
                        ans = ans * x;
                    }
                    x = x * x;

                    //right shift
                    n = n >> 1;
                }
                return ans;
            }
            else
            {
                while (n < 0)
                {
                    int lastBit = (x & 1);

                    //check if lsb is set
                    if (lastBit == 1)
                    {
                        ans = ans * x;
                    }
                    x = x * x;

                    //right shift
                    n = n << 1;
                }
                return ans;
            }

            
        }
        public int MySqrt(int x)
        {
            if (x == 1 || x == 2)
                return 1;
            var a = (int)Math.Sqrt(x);
            var b = FindSqrt(x, 1, x);
            return b;
        }

        private int FindSqrt(int x, int low, int high)
        {
            int mid = (low + high) / 2;
            
            if (mid == low || mid == high)
                return mid;
            if (mid > x / mid) //mid * mid > x
                return FindSqrt(x, low, mid);
            else if (mid < x / mid)//mid * mid < x
                return FindSqrt(x, mid, high);
            else
                return mid;

        }

        public int ClimbStairs(int n)
        {
            int?[] cache = new int?[n+1];
            return StepsToReach(n, cache);
        }

        private int StepsToReach(int n, int?[] cache)
        {
            Console.WriteLine("Steps: "+n);
            if (n == 0 || n == 1)
                return 1;
            if (n < 0)
                return 0;
            if (cache[n].HasValue)
                return cache[n].GetValueOrDefault();
            
            int downOne = StepsToReach(n - 1,cache);
            int downTwo = StepsToReach(n - 2,cache);

            cache[n] = downOne + downTwo;
            return cache[n].GetValueOrDefault();
        }

        //Pascal's Triangle
        public IList<IList<int>> Generate(int numRows)
        {
            int[][] arr = new int[numRows][];

            for (int i = 0; i < numRows; i++)
            {
                arr[i] = new int[i + 1];
                arr[i][0] = 1;
                arr[i][i] = 1;

                for (int j = 1; j < i; j++)
                {
                    arr[i][j] = arr[i - 1][j - 1] + arr[i - 1][j];
                }
            }

            PrintMatrix(arr);
            return null;
        }

        private void PrintMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j]);
                }
                Console.WriteLine();
            }
        }
        //sliding window    
        public int MaxProfit(int[] prices)
        {

            int maxProfit = 0;

            int left = 0;
            int right = 1;

            while(left < prices.Length && right < prices.Length)
            {
                int profit = prices[right] - prices[left];

                maxProfit = Math.Max(profit, maxProfit);

                if (prices[right] < prices[left])
                    left = right;
                right++;
            }

            return maxProfit;
        }

        public int MaxPointsFaster(int[][] points)
        {
            int n = points.Length;
            if (n == 1)
                return 1;
            int maxCount = 0;
            for (int i = 0; i < n-1; i++)
            {
                int x1 = points[i][0];
                int y1 = points[i][1];
                for (int j = i+1; j < n; j++)
                {
                    int count = 2;
                    int x2 = points[j][0];
                    int y2 = points[j][1];
                    //slope = (y2-y1)/(x2-x1)
                    //if we get slope with points p1 and p2 and again slope with points p3 and p3, keeping point p2 common
                    //then if the slope is same we know that p3 lies on the same line as p1 and p2 because of p2 being common
                    for (int k = 0; k < n; k++)
                    {
                        if (k == i || k == j) //don't count points already being used to make the slope
                            continue;

                        int x3 = points[k][0];
                        int y3 = points[k][1];
                        /*
                         * y2-y1    y3-y2
                         * ------ = ------ can be written as (y2-y1)(x3-x2) = (y3-y2)(x2-x1) so we can eliminate decimals and not deal with divide by zero 
                         * x2-x1    x3-x2
                         */
                        if ((y2 - y1) * (x3 - x2) == (y3 - y2) * (x2 - x1))
                            count++;
                    }
                    if (count > maxCount)
                        maxCount = count;
                }
            }
            return maxCount;
        }
        public int MaxPoints(int[][] points)
        {
            int n = points.Length;
            if (n <= 1)
                return n;
            Dictionary<string, int> mc = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                int x2 = points[i][0];
                int y2 = points[i][1];

                for (int k = i+1; k < n; k++)
                {
                    if (i == k)
                        continue;

                    int x1 = points[k][0];
                    int y1 = points[k][1];
                    double m = (double)(y2 - y1) / (double)(x2 - x1);
                    
                    double c = y1 - m * x1;
                    string key = Math.Abs(Math.Round(m,2)).ToString() + "," + Math.Round(c,2).ToString();

                    if (double.IsInfinity(m))
                        key = "inf," + x1.ToString();

                    if (mc.ContainsKey(key))
                        continue;

                    mc.Add(key, 2);

                    for (int j = 0; j < n; j++)
                    {
                        if (j == i || j == k)
                            continue;

                        int x = points[j][0];
                        int y = points[j][1];

                        if(key.StartsWith("inf") && x == x1)
                            mc[key]++;

                        else if (Math.Abs(y - (m * x + c)) < 0.01)
                            mc[key]++;
                    }
                }

            }
            

            int maxCount = 0;
            var a= mc.Keys.OrderBy(x => x);
            foreach (var key in mc.Keys)
            {
                int count = mc[key];
                maxCount = Math.Max(maxCount, count);
            }

            return maxCount;
        }
        public int EvalRPN(string[] tokens)
        {
            if (tokens.Length == 1)
                return int.Parse(tokens[0]);

            Stack<string> stack = new Stack<string>();
            int val = int.Parse(tokens[0]);
            for (int i = 0; i < tokens.Length; i++)
            {
                if (!IsOperator(tokens[i]))
                    stack.Push(tokens[i]);
                else
                {
                    int first = int.Parse(stack.Pop());
                    int second = int.Parse(stack.Pop());
                    string operand = tokens[i];
                    val = Evaluate(second, first, operand); //switch frst and second cause LIFO
                    stack.Push(val.ToString());
                }
            }
            return val;
        }
        public int EvalRPNN(string[] tokens)
        {
            if (tokens.Length == 1)
                return int.Parse(tokens[0]);

            Stack<string> stack = new Stack<string>();
            int val = int.MinValue;
            bool takefirstsecond = true;
            for (int i = tokens.Length - 1; i >= 1; i--)
            {
                if (IsOperator(tokens[i]) || IsOperator(tokens[i-1]))
                    stack.Push(tokens[i]);
                else
                {
                    int first = int.Parse(tokens[i - 1]);
                    int second = int.Parse(tokens[i]);
                    string operand = stack.Pop();
                    val = Evaluate(first, second, operand);
                    while(stack.Count > 0 && !IsOperator(stack.Peek()))
                    {
                        first = val;
                        second = int.Parse(stack.Pop());
                        operand = stack.Pop();
                        val = Evaluate(first, second, operand);
                    }
                    stack.Push(val.ToString());
                    i--;
                }
            }
            while (stack.Count > 1)
            {
                int first = int.Parse(tokens[0]);
                int second = int.Parse(stack.Pop());
                string operand = stack.Pop();
                val = Evaluate(first, second, operand);
            }
            return val;
        }

        private int Evaluate(int first, int second, string operand)
        {
            switch (operand)
            {
                case "+":
                    return first + second;
                case "-":
                    return first - second;
                case "*":
                    return first * second;
                case "/":
                    return first / second;
                default:
                    break;
            }
            return 1;
        }

        private bool IsOperator(string s)
        {
            return s == "+" || s == "-" || s == "*" || s == "/";
        }

        public string FractionToDecimal(int numerator, int denominator)
        {
            long num = (long)numerator;
            long den = (long)denominator;
            string ans = "";

            bool negative = false;

            if (num * den < 0)
                negative = true;

            num = Math.Abs(num);
            den = Math.Abs(den);

            long quotient = num / den;
            ans += quotient.ToString();
            
            long remainder = num % den;

            if (remainder == 0)
                return negative ? "-" + ans : ans;
            ans += ".";

            Dictionary<long, int> remainderHashPos = new Dictionary<long, int>();
            
            while(remainder !=0)
            {
                if (!remainderHashPos.ContainsKey(remainder))
                    remainderHashPos.Add(remainder, ans.Length);
                else
                {
                    ans = ans.Insert(remainderHashPos[remainder], "(");
                    ans += ")";
                    break;
                }
                remainder = remainder * 10;

                quotient = remainder / den;
                remainder = remainder % den;

                ans += quotient.ToString();
                
            }

            return negative ? "-" + ans : ans;
        }

        public int MajorityElement(int[] nums)
        {
            //Dictionary<int, int> counts = new Dictionary<int, int>();
            //int maxCount = 0;
            //int maxElement = 0;

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if (!counts.ContainsKey(nums[i]))
            //        counts.Add(nums[i], 1);
            //    else
            //        counts[nums[i]]++;
            //}
            //foreach (var key in counts.Keys)
            //{
            //    if(counts[key] > maxCount)
            //    {
            //        maxCount = counts[key];
            //        maxElement = key;
            //    }
            //}

            //return maxElement;

            // Moore's voting algorithm
            //since majority element apears more than n/2 times so even if we substract count for all the time it doesnt appear, it'll still have more count than others
            int maxElement = nums[0];
            int maxCount = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != maxElement)
                    maxCount--;
                else
                    maxCount++;

                if(maxCount == 0)
                {
                    maxCount = 1;
                    maxElement = nums[i];
                }
            }

            return maxElement;

        }

        public int TrailingZeroes(int n)
        {
            //even long will overflow
            //do it like PnC
            //count how many 5s and 2s we have to make 10 aka trailining zero, we will always have enough 2s for 5s so just count 5s
            //divide by 5 to find out how many, if answer is greater than 0 keep doing it since there will be more 5s
            int count = 0;
            while(n > 0)
            {
                count += n / 5;
                n = n / 5;
            }
            return count;
        }

        public uint reverseBits(uint n)
        {
            //string str = Convert.ToString(n, 2);

            //while (str.Length < 32)
            //{
            //    str = "0" + str;
            //}
            //Console.WriteLine(str);
            //var charArr = str.ToCharArray();
            //Array.Reverse(charArr);
            //str = new string(charArr);
            //Console.WriteLine(str);

            //return Convert.ToUInt32(str,2);

            //bit manipulation

            uint reverse = 0;
            for (int i = 0; i < 32; i++)
            {
                uint bit = (n >> i) & 1;  // it'll tell us what the lsb is then the one before and similarly all the bits
                reverse = reverse | (bit << (31 - i)); //ORing will put ones in left places as need
            }
            return reverse;
        }
        //Find number of 1 bits
        public int HammingWeight(uint n)
        {
            int count = 0;
            for (int i = 0; i < 32; i++)
            {
                if (((n >> i) & 1) == 1)
                    count++;
            }
            return count;
        }
        public int Rob(int[] nums)
        {
            int n = nums.Length;
            if (n == 1)
                return nums[0];
            //max sum at any house will be money at that house + money collected if next house was skipped vs max money at the next house
            int[] dp = new int[n];

            dp[n - 1] = nums[n - 1];
            dp[n - 2] = Math.Max(nums[n - 2],nums[n-1]);

            for (int i = n - 3; i >= 0; i--)
            {
                dp[i] = Math.Max(dp[i + 1], nums[i] + dp[i + 2]);
            }
            return dp.Max();
        }

        public bool IsHappy(int n)
        {
            if (n == 1)
                return true;
            int tmp = n;
            var hashMap = new HashSet<int>();
            

            do
            {
                hashMap.Add(tmp);
                int sum = 0;
                while (tmp > 0)
                {
                    int digit = tmp % 10;
                    sum += (digit * digit);
                    tmp = tmp / 10;
                }
                tmp = sum;
            } while (!hashMap.Contains(tmp) && tmp != 1);

            return tmp == 1;
        }
        //Sieve of Erastothenes
        /*
         * why we used square
         * Suppose xy=N=N−−√N−−√. If x≥N−−√, then y≤N−−√ and vice-versa. Thus, if xy=N, then one of x or y must be less than or equal to N−−√. 
         * This means that if N can be factored, one of the factors must be less than or equal to N−−√.
        This is the contrapositive of what Gadi A said, but sometimes, if a statement doesn't make sense to you, its contrapositive might.
        To answer the question asked: if you've crossed out the multiples of all the numbers less than or equal to N−−√, 
        all multiples of numbers greater than N−−√ will already be crossed out. 
        This is because any number which is less than or equal to N and is a multiple of a number greater than N−−√, will have a factor that is less than or equal to N−−√ 
        and therefore will already be crossed out. (Of course, when we are speaking of multiples here we mean multiples of 2× or more, as in the Sieve.)
         */
        public int CountPrimesFaster(int n)
        {
            int count = 0;
            bool[] isPrime = Enumerable.Repeat(true, n + 1).ToArray();

            for (int i = 2; i*i <= n; i++) // we go on till square of our number is less than or equal to n
            {
                if (isPrime[i])
                {
                    for (int j = i*i; j <= n; j=j+i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            for (int i = 2; i < n; i++) //but we only want to count numbers less than n
            {
                if (isPrime[i])
                    count++;
            }

            return count;
        }
        public int CountPrimes(int n)
        {
            int count = 0;
            for (int i = n - 1; i >= 2; i--)
            {
                if (i == 2 || (i % 2 == 1 && IsPrime(i)))
                    count++;
            }
            return count;
        }

        private bool IsPrime(int i)
        {
            int c = 0;
            for (int j = 2; j < i/2; j++)
            {
                if (i % j == 0)
                    return false;
            }
            return true;
        }

        public int Calculate(string s)
        {
            int result = 0;
            s = s.Replace(" ", "");
            Stack<int> stack = new Stack<int>();
            int n = s.Length;

            bool isNegative = false;
            for (int i = 0; i < n; i++)
            {
                char ch = s[i];
                if (ch == '-')
                    isNegative = true;
                else if (ch == '+')
                    isNegative = false;
                else if (ch == '*' || ch == '/')
                {
                    int num1 = stack.Pop();
                    string str = "";
                    while (i + 1 < n && char.IsDigit(s[i + 1]))
                    {
                        str += s[i + 1];
                        i++;
                    }
                    int num2 = int.Parse(str);
                    int val = Evaluate(num1, num2, ch.ToString());
                    stack.Push(val);
                }
                else
                {
                    string str = ch.ToString();
                    while(i+1 < n && char.IsDigit(s[i+1]))
                    {
                        str += s[i + 1];
                        i++;
                    }
                    int num = int.Parse(str);
                    num = isNegative ? -num : num;
                    stack.Push(num);
                }
            }
            while(stack.Count > 0)
            {
                result += stack.Pop();
            }
            
            return result;
        }
        public int NumSquares(int n)
        {
            //calculate answer for smaller values eg- n=12, calculate for n=1,n=2,n=3 etc so go bottom up
            int[] dp = new int[n + 1];
            dp[0] = 0;
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = i;
            }
            for (int target = 1; target <= n; target++)
            {
                //for every smaller n
                for (int num = 1; num <= target; num++)
                {
                    int square = num * num;
                    if (target - square < 0)
                        break;
                    if (1 + dp[target - square] < dp[target])
                        dp[target] = 1 + dp[target - square];
                }
            }
            return dp[n];
        }


        public bool IsPowerOfThree(int n)
        {
            if (n < 1)
                return false;
            while(n > 1)
            {
                if (n % 3 != 0)
                    return false;
                n = n / 3; ;
            }
            return true;
        }

        public int GetSum(int a, int b)
        {
            //full adder - carry is a&b sum is a XOR b, continue till carry is zero
            while(b != 0)
            {
                int carry = a & b;
                a = a ^ b;
                b = carry << 1;
            }
            return a;
        }

    }
    public class MedianFinder
    {
        List<int> list;
        public MedianFinder()
        {
            list = new List<int>();
        }

        public void AddNum(int num)
        {
            //find position to insert the number
            int position = list.BinarySearch(num);

            if(position < 0)
            {
                position = 0;
            }

            list.Insert(position, num);
        }

        public double FindMedian()
        {
            int count = list.Count;
            if(count % 2 == 0)
            {
                double median = (double)(list[count / 2] + list[count / 2 - 1]) * 0.5D;
                return median;
            }

            return (double)list[count / 2];
        }
    }

}

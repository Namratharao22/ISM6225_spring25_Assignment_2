using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // Write your code here
                for (int i = 0; i < nums.Length; i++)
                {
                    int index = Math.Abs(nums[i]) - 1;
                    if (nums[index] > 0) nums[index] = -nums[index];
                }

                List<int> missing = new List<int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] > 0) missing.Add(i + 1); // Edge case: Duplicates and missing numbers are handled using absolute values
                }
                return missing; 

            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                int left = 0, right = nums.Length - 1;

                while (left < right)
                {
                    if (nums[left] % 2 > nums[right] % 2)
                    {
                        int temp = nums[left];
                        nums[left] = nums[right];
                        nums[right] = temp;
                    }

                    if (nums[left] % 2 == 0) left++;  // Edge case: Handles both negative numbers and zero correctly
                    if (nums[right] % 2 == 1) right--;
                }

                return nums; // Edge case: Empty array handled naturally, also handles all odd or all even arrays
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Write your code here
                Dictionary<int, int> map = new Dictionary<int, int>();

                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i];
                    if (map.ContainsKey(complement)) return new int[] { map[complement], i }; // Edge case: Handles duplicate values correctly
                    map[nums[i]] = i;
                }

                return new int[0]; // Edge case: No pair found, returns an empty array

            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Write your code here
                if (nums.Length < 3) return 0; // Edge case: Less than 3 elements returns 0

                int max1 = int.MinValue, max2 = int.MinValue, max3 = int.MinValue;
                int min1 = int.MaxValue, min2 = int.MaxValue;

                foreach (int num in nums)
                {
                    if (num > max1) { max3 = max2; max2 = max1; max1 = num; }
                    else if (num > max2) { max3 = max2; max2 = num; }
                    else if (num > max3) max3 = num;

                    if (num < min1) { min2 = min1; min1 = num; }
                    else if (num < min2) min2 = num;
                }

                return Math.Max(max1 * max2 * max3, min1 * min2 * max1); // Edge case: Handles array with all positive or negative values
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Write your code here
                if (decimalNumber == 0) return "0"; // Edge case: Handles 0 input

                StringBuilder binary = new StringBuilder();

                while (decimalNumber > 0)
                {
                    binary.Insert(0, decimalNumber % 2); // Edge case: Works correctly for large numbers
                    decimalNumber /= 2;
                }

                return binary.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }


        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                // Write your code here
                int left = 0, right = nums.Length - 1;

                if (nums[left] <= nums[right]) return nums[left]; // Edge case: Array not rotated, returns the first element

                while (left < right)
                {
                    int mid = left + (right - left) / 2;
                    if (nums[mid] > nums[right]) left = mid + 1; // Edge case: Properly handles rotated sorted arrays
                    else right = mid;
                }

                return nums[left]; 
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Write your code here
                if (x < 0) return false; // Edge case: Negative numbers are not palindromes
                if (x == 0) return true; // Edge case: 0 is a palindrome
                int original = x, reversed = 0;

                while (x != 0)
                {
                    int digit = x % 10;
                    reversed = reversed * 10 + digit;
                    x /= 10;
                }

                return original == reversed; // Edge case: Numbers ending in 0 are not palindromes, except for 0 itself
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Write your code here
                if (n <= 1) return n; // Edge case: Returns n directly for n = 0 or n = 1

                int a = 0, b = 1;

                for (int i = 2; i <= n; i++)
                {
                    int temp = a + b;
                    a = b;
                    b = temp;
                }

                return b; // Edge case: Handles larger Fibonacci numbers correctly
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
    
    

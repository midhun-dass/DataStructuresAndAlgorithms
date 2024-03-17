using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.DynamicProgramming
{
    public class SubsetSum
    {
        static bool IsSubsetSum(int[] arr, int n, int sum) 
        {
            bool[,] dp = new bool[n + 1, sum + 1];

            // If sum is 0, then answer is true
            for (int i = 0; i <= n; i++)
                dp[i, 0] = true;

            // If sum is not 0 and set is empty,
            // then answer is false
            for (int i = 1; i <= sum; i++)
                dp[0, i] = false;

            // Fill the dp table
            for (int i = 1; i <= n; i++) {
                for (int j = 1; j <= sum; j++) {
                    if (arr[i - 1] <= j)
                        dp[i, j] = dp[i - 1, j] || dp[i - 1, j - arr[i - 1]];
                    else
                        dp[i, j] = dp[i - 1, j];
                }
            }

            return dp[n, sum];
        }

        public static void Main1(string[] args) 
        {
            int[] A = {2, 3, 5, 7, 10};
            int sum = 14;
            int n = A.Length;

            if (IsSubsetSum(A, n, sum))
                Console.WriteLine("True");
            else
                Console.WriteLine("False");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.DynamicProgramming
{
    public class CoinChange
    {
        public int CoinChange1(int[] coins, int amount)
        {
            int n = coins.Length;
            int[,] t = new int[n + 1, amount + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= amount; j++)
                {
                    if (j == 0)
                    {
                        t[i, j] = 0;
                    }
                    else
                    {
                        t[i, j] = int.MaxValue - 1;
                    }
                }
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= amount; j++)
                {
                    if (coins[i - 1] <= j)
                    {
                        t[i, j] = Math.Min(1 + t[i, j - coins[i - 1]], t[i - 1, j]);
                    }
                    else
                    {
                        t[i, j] = t[i - 1, j];
                    }
                }
            }

            return t[n, amount] == int.MaxValue - 1 ? -1 : t[n, amount];
        }

        public int CoinChange1NeetCode(int[] coins, int amount)
        {
            int[] dp = new int[amount + 1];
            Array.Fill(dp, amount + 1);
            dp[0] = 0;
            
            for (int a = 1; a <= amount; a++)
            {
                foreach (int c in coins)
                {
                    if (a - c >= 0)
                    {
                        dp[a] = Math.Min(dp[a], 1 + dp[a - c]);
                    }
                }
            }
            
            return dp[amount] != amount + 1 ? dp[amount] : -1;
        }
        
        public int CoinChange2(int amount, int[] coins)
        {
            int[,] dp = new int[coins.Length + 1, amount + 1];

            for (int i = 0; i <= coins.Length; i++)
            {
                for (int j = 0; j <= amount; j++)
                {
                    if (j == 0)
                    {
                        dp[i, j] = 1;
                    }
                    else if (i == 0)
                    {
                        dp[i, j] = 0;
                    }
                    else
                    {
                        if (j >= coins[i - 1])
                        {
                            dp[i, j] = dp[i - 1, j] + dp[i, j - coins[i - 1]];
                        }
                        else
                        {
                            dp[i, j] = dp[i - 1, j];
                        }
                    }
                }
            }

            return dp[coins.Length, amount];
        }
    }
}
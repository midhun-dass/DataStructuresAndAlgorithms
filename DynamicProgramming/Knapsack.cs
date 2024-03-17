namespace DataStructuresAndAlgorithms.DynamicProgramming
{
    public class Knapsack
    {
        // Returns the maximum value that can be put in a knapsack of capacity W
        public static int KnapSack(int W, int[] weights, int[] profits, int n)
        {
            int[,] K = new int[n + 1, W + 1];

            // Build table K[][] in bottom-up manner
            for (int i = 0; i <= n; i++)
            {
                for (int w = 0; w <= W; w++)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;
                    else if (weights[i - 1] <= w)
                        K[i, w] = Math.Max(profits[i - 1] + K[i - 1, w - weights[i - 1]], K[i - 1, w]);
                    else
                        K[i, w] = K[i - 1, w];
                }
            }
            
            return K[n, W];
        }

        // Returns the selected items that gives maximum profit and that can be put in a knapsack of capacity W
        public static int[] KnapSack1(int W, int[] wt, int[] val, int n)
        {
            int[,] K = new int[n + 1, W + 1];

            // Build table K[][] in bottom-up manner
            for (int i = 0; i <= n; i++)
            {
                for (int w = 0; w <= W; w++)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;
                    else if (wt[i - 1] <= w)
                        K[i, w] = Math.Max(val[i - 1] + K[i - 1, w - wt[i - 1]], K[i - 1, w]);
                    else
                        K[i, w] = K[i - 1, w];
                }
            }

            // Traceback to find selected items
            int[] selected = new int[n];
            int j = W;
            for (int i = n; i > 0 && j > 0; i--)
            {
                if (K[i, j] != K[i - 1, j])
                {
                    selected[i - 1] = wt[i - 1];
                    j -= wt[i - 1];
                }
            }

            return selected;
        }
    }

}
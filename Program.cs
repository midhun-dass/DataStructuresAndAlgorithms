using DataStructuresAndAlgorithms.DynamicProgramming;

public class Program
{
    public static void Main(string[] args)
    {
        int[] profits = { 2, 3, 1, 4 }; // values
        int[] weights = { 3, 4, 6, 5 }; // weights
        int W = 8; // maximum capacity
        int n = profits.Length; // number of items

        var res0 = Knapsack.KnapSack(W, weights, profits, n);    
        var res1 = Knapsack.KnapSack1(W, weights, profits, n);    
    }
}
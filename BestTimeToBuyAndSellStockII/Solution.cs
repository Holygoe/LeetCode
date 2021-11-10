namespace BestTimeToBuyAndSellStockII
{
    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            var profit = 0;
            var previous = int.MaxValue;

            for (var i = 0; i < prices.Length; i++)
            {
                if (prices[i] > previous)
                {
                    profit += prices[i] - previous;
                }
                
                previous = prices[i];
            }
            
            return profit;
        }
    }
}
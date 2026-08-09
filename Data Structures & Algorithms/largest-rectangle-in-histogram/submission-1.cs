public class Solution
{
    public int LargestRectangleArea(int[] heights)
    {
        Stack<int> stack = new();
        int largest = 0;

        for (int i = 0; i <= heights.Length; i++)
        {
            int currentHeight = i == heights.Length ? 0 : heights[i];

            while (stack.Count > 0 && currentHeight < heights[stack.Peek()])
            {
                int heightIndex = stack.Pop();
                int height = heights[heightIndex];

                int width;

                if (stack.Count == 0)
                {
                    width = i;
                }
                else
                {
                    width = i - stack.Peek() - 1;
                }

                int area = height * width;
                largest = Math.Max(largest, area);
            }

            stack.Push(i);
        }

        return largest;
    }
}
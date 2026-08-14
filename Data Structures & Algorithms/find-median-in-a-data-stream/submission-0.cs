public class MedianFinder
{
    // Smaller half — Max Heap
    private PriorityQueue<int, int> maxHeap;

    // Larger half — Min Heap
    private PriorityQueue<int, int> minHeap;

    public MedianFinder()
    {
        maxHeap = new PriorityQueue<int, int>(
            Comparer<int>.Create((a, b) => b.CompareTo(a))
        );

        minHeap = new PriorityQueue<int, int>();
    }

    public void AddNum(int num)
    {
        // Add to maxHeap if it belongs to the smaller half
        if (maxHeap.Count == 0 || num <= maxHeap.Peek())
        {
            maxHeap.Enqueue(num, num);
        }
        else
        {
            minHeap.Enqueue(num, num);
        }

        // Balance heaps
        if (maxHeap.Count > minHeap.Count + 1)
        {
            int value = maxHeap.Dequeue();
            minHeap.Enqueue(value, value);
        }
        else if (minHeap.Count > maxHeap.Count)
        {
            int value = minHeap.Dequeue();
            maxHeap.Enqueue(value, value);
        }
    }

    public double FindMedian()
    {
        if (maxHeap.Count > minHeap.Count)
        {
            return maxHeap.Peek();
        }

        return ((double)maxHeap.Peek() + minHeap.Peek()) / 2.0;
    }
}
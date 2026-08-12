public class KthLargest {
    PriorityQueue<int, int> pq;
    int size = 0;

    public KthLargest(int k, int[] nums) {
        pq = new();
        size = k;

        foreach (int num in nums)
        {
            Add(num);
        }
    }
    
    public int Add(int val) {
        if (pq.Count < size)
        {
            pq.Enqueue(val, val);
        }
        else if (val > pq.Peek())
        {
            pq.Dequeue();
            pq.Enqueue(val, val);
        }

        return pq.Peek();
    }
}

public class Solution {
    public int LastStoneWeight(int[] stones) {
        PriorityQueue<int, int> maxHeap =
            new(Comparer<int>.Create((a, b) => b.CompareTo(a)));

        foreach(int i in stones){
            maxHeap.Enqueue(i, i);
        }

        while(maxHeap.Count >= 2){
            var a = maxHeap.Dequeue();
            var b = maxHeap.Dequeue();
            if(a - b > 0) maxHeap.Enqueue(a - b, a - b);
        }

        return maxHeap.Count > 0 ? maxHeap.Peek() : 0;
    }
}

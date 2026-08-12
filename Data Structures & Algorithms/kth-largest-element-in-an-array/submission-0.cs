public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        PriorityQueue<int, int> pq = new();
        
        foreach(int num in nums){
            if(pq.Count < k){
                pq.Enqueue(num, num);
            }else{
                if(pq.Peek() < num){
                    pq.Dequeue();
                    pq.Enqueue(num, num);
                }
            }
        }

        return pq.Dequeue();
    }
}

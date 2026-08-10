/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution {
    public void ReorderList(ListNode head) {
        if(head.next == null || head.next.next == null) return;

        var tailPrev = getTailPrev(head);
        var current = head;

        while(current.next != null && !current.Equals(tailPrev)){
            var tmpNext = current.next;
            current.next = tailPrev.next;
            current.next.next = tmpNext;
            tailPrev.next = null;
            current = current.next.next;

            tailPrev = getTailPrev(current);
        }
    }

    public ListNode getTailPrev(ListNode head){
        var current = head;
        while((current?.next?.next ?? null) != null){
            current = current.next;
        }
        return current;
    }
}

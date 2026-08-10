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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {

        ListNode current = head;
        int count = 1;
        while(current != null){
            current = current.next;
            if(current != null) count++;
        }

        if(count == n) return head.next;

        int ithNode = count - n + 1;

        int c = 1;
        current = head;
        ListNode prev = null;
        while(c < ithNode ){
            prev = current;
            current = current?.next ?? null;
            c++;
        }
      
        prev.next = current?.next ?? null;

        return head;
    }
}

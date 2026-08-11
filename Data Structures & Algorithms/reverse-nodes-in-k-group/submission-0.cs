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
    public ListNode ReverseKGroup(ListNode head, int k) {
        
        int count = 1;
        var current = head;

        while(count < k && current != null){
            current = current.next;
            count++;
        }

        if(current == null) return head;

        var tmp = current?.next ?? null;
        (ListNode nextHead, ListNode tail) = ReverseList(head, k);

        if(tmp != null){
            ListNode next = ReverseKGroup(tmp, k);
            tail.next = next;
        }

        return nextHead;
    }


    (ListNode head, ListNode tail) ReverseList(ListNode head, int k){
        int count = 1;
        var current = head;
        var tail = head;
        ListNode prev = null;
        while(count < k && current.next != null){
            var tmp = current.next;
            current.next = prev;
            prev = current;
            current = tmp;
            count++;
        }
        current.next = prev;

        return (current, tail);
    }
}

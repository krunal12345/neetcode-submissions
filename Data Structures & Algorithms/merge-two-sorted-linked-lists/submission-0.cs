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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {

        ListNode head = new ListNode(-1, null);
        ListNode current = head;
        ListNode currenta = list1;
        ListNode currentb = list2;

        while(currenta != null && currentb != null){
            if(currenta.val <= currentb.val){
                current.next = currenta;
                current = currenta;
                currenta = current.next;
            }else{
                current.next = currentb;
                current = currentb;
                currentb = currentb.next;
            }
        }

        if(currenta != null) current.next = currenta;
        if(currentb != null) current.next = currentb;

        return head.next;
    }
}
public class Solution
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists.Length == 0)
            return null;

        int interval = 1;

        while (interval < lists.Length)
        {
            for (int i = 0; i + interval < lists.Length; i += interval * 2)
            {
                lists[i] = MergeTwoLists(lists[i], lists[i + interval]);
            }

            interval *= 2;
        }

        return lists[0];
    }

    private ListNode MergeTwoLists(ListNode a, ListNode b)
    {
        ListNode dummy = new ListNode();
        ListNode current = dummy;

        while (a != null && b != null)
        {
            if (a.val <= b.val)
            {
                current.next = a;
                a = a.next;
            }
            else
            {
                current.next = b;
                b = b.next;
            }

            current = current.next;
        }

        current.next = a ?? b;

        return dummy.next;
    }
}
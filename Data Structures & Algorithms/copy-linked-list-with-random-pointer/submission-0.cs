/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node copyRandomList(Node head) {
        Dictionary<Node, Node> oldNewPair = new Dictionary<Node, Node>();

        var current = head;
        Node newHead = null;
        Node newPrev = null;
        while(current != null){
            var pair = getAndAddPairIfNull(oldNewPair, current);
            if(newHead == null) newHead = pair;

            if(current.random == null){
                pair.random = null;
            }else{
                var randomPair = getAndAddPairIfNull(oldNewPair, current.random);
                pair.random = randomPair;
            }
            if(newPrev != null){
                newPrev.next = pair;
            }

            newPrev = pair;
            current = current.next;
        }

        return newHead;

        Node getAndAddPairIfNull(
            Dictionary<Node, Node> oldNewPair, 
            Node key
        ){
            var pair = oldNewPair.GetValueOrDefault(key, null);
            if(pair == null){
                pair = new Node(key.val);
                oldNewPair.Add(key, pair);
            }
            return pair;
        }
    }
}

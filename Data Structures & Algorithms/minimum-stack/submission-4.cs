public class MinStack {

    private Stack<int> _stack;
    private Stack<int> _minStack;
    private int? min = null;

    public MinStack() {
        _stack = new Stack<int>();
        _minStack =  new Stack<int>();
    }
    
    public void Push(int val) {
        _stack.Push(val);
        int? min1;
        if(min == null){
            min1 = val;
        }else{
            min1 = Math.Min(min.Value, val);
        }

        min = min1.Value;
        _minStack.Push(min1.Value);
    }
    
    public void Pop() {
        _stack.Pop();
        _minStack.Pop();
        if(_minStack.Count == 0){
            min = null;
        }else{
            min = GetMin();
        }
    }
    
    public int Top() {
       return _stack.Peek();
    }
    
    public int GetMin() {
        return _minStack.Peek();
    }
}

public class Solution {
    public int EvalRPN(string[] tokens) {
        Stack<long> stack = new Stack<long>();

        for(int i = 0; i < tokens.Length; i++){
            if(tokens[i] == "+" || tokens[i] == "-" 
            || tokens[i] == "*" || tokens[i] == "/" ){
                var b = stack.Pop();
                var a = stack.Pop();
                long result = 0;
                switch(tokens[i]){
                    case "+":
                        result = a + b;
                        break;
                    case "-":
                        result = a - b;
                        break;
                    case "*":
                        result = a * b;
                        break;
                    case "/":
                        result = b == 0 ? 0 : a / b;
                        break;
                }
                stack.Push(result);
            }else{
                stack.Push(int.Parse(tokens[i]));
            }
        }

        return (int)stack.Pop();
    }
}

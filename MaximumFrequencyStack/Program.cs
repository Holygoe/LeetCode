using MaximumFrequencyStack;

var stack = new FreqStack();
stack.Push(5);
stack.Push(7);
stack.Push(5);
stack.Push(7);
stack.Push(4);
stack.Push(5);
Console.WriteLine(stack.Pop());
Console.WriteLine(stack.Pop());
Console.WriteLine(stack.Pop());
Console.WriteLine(stack.Pop());
namespace PBuilders.Domain.BynarySearchTree.ValueObject
{
    public class Node
    {
        public Node(int value)
        {
            Value = value;
        }

        public int Value { get; private set; }
        public Node? Left { get; private set; }
        public Node? Right { get; private set; }

        public void InsertLeft(Node? left)
        {
            Left = left;
        }

        public void InsertRight(Node? right)
        {
            Right = right;
        }
    }
}
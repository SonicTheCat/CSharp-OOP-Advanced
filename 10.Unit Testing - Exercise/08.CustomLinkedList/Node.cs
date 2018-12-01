namespace CustomLinkedList
{
    public class Node<T>
    {
        public Node(T element)
        {
            this.Element = element;
            this.NextNode = null;
        }

        public Node(T element, Node<T> prevNode)
        {
            this.Element = element;
            prevNode.NextNode = this;
        }

        public T Element { get; set; }

        public Node<T> NextNode { get; set; }
    }
}
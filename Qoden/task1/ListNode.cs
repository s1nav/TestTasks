namespace task1
{
    public class ListNode<T>
    {
        private T value;
        private ListNode<T> next;


        public ListNode(T value)
        {
            this.value = value;
        }


        public void Insert(T newValue)
        {
            var node = this;

            while (node.next != null)
            {
                node = node.next;
            }

            node.next = new ListNode<T>(newValue);
        }

        public override string ToString()
        {
            var node = this;
            var result = "";

            while (node != null)
            {
                result += $"{node.value} ";
                node = node.next;
            }

            return result;
        }
    }
}

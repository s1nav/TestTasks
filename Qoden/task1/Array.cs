namespace task1
{
    public class Array<T>
    {
        public T[] Items { get; private set; }


        public Array(int length)
        {
            Items = new T[length];
        }
    }
}

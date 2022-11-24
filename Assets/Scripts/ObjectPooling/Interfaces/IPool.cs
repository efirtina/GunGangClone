public interface IPool<T>
{
    void Push(T poolObject);
    T Pull();
}

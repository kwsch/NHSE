namespace NHSE.Core
{
    public interface ICopyableItem<in T>
    {
        void CopyFrom(T item);
        int Size { get; }
    }
}

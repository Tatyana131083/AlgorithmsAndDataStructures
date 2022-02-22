
namespace AlgorithmsLib
{
    public interface ILinkedList<T>
    {
        int GetCount(); 
        void AddNode(T value);  
        void AddNodeAfter(Node<T> node, T value); 
        void RemoveNode(int index); 
        void RemoveNode(Node<T> node);
        Node<T> FindNode(T searchValue); 

    }
}

using System.Collections.Generic;

namespace LW1.MyCollection;

interface 
    IMydeque<T>
{  
    bool Remove(T item); 
    T RemoveFirst(); 
    T RemoveLast();
    void AddFirst(T item);
    void AddLast(T item);
    void Add(T item);
    void Clear();
    bool Contains(T item);
    void CopyTo(T[] array, int arrayIndex);
    IEnumerator<T> GetEnumerator();

}
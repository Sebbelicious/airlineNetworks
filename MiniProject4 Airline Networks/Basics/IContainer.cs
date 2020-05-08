using System.Collections.Generic;

namespace MiniProject4_Airline_Networks.Basics
{
    public interface IContainer<T> : IEnumerable<T>  
    {
        int GetSize();
        bool IsEmpty() { return GetSize() == 0; }
    }
}
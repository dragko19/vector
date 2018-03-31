using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Vector<T>
{
    private int _count;
    private T[] Elem;
    public Vector(int count = 0)
    {
        Elem = new T[count];
        _count = count;
    }

    ~Vector()
    {
        Elem = null;
    }

    public int Size()
    {
        return _count;
    }

    //[] operator
    public T this[int idx]
    {
        get
        {
            if (idx < Size())
                return Elem[idx];
            else
                throw new IndexOutOfRangeException("Index is out of bounds in [] get operator");
        }
        set
        {
            if (idx < Size())
                Elem[idx] = value;
            else
                throw new IndexOutOfRangeException("Index is out of bounds in [] set operator");
        }
    }
}

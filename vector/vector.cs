using System;
using System.IO;


class Vector<T>
{
    private int _count;
    private T[] Elem;
    public Vector(int count = 0)
    {
        if (count < 0)
            throw new IndexOutOfRangeException("Number of elements cannot be less than 0");

        Elem = new T[count];
        _count = count;
    }
    //copy constructor
    public Vector(ref Vector<T> arg)
    {
        _count = arg.Size();
        T[] temp = new T[_count];
        for(int i = 0; i < _count; i++)
            temp[i] = arg[i];

        Elem = temp;

        temp = null;        
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
            if (idx < Size() && Size() != 0)
                return Elem[idx];
            else
                throw new IndexOutOfRangeException("Index is out of bounds in [] get operator");
        }
        set
        {
            if (idx < Size() && Size() != 0)
                Elem[idx] = value;
            else
                throw new IndexOutOfRangeException("Index is out of bounds in [] set operator");
        }
    }

    public void Push_back(T arg)
    {
        T[] temp = new T[_count + 1];
        for (int i = 0; i < _count; i++)
            temp[i] = Elem[i];

        temp[_count] = arg;
        _count++;
        Elem = temp;
        temp = null;
    }

    public T Pop_back()
    {
        if (Size() == 0)
            throw new IndexOutOfRangeException("Vector's size is 0, you cannot delete last element");

        T res = Elem[_count - 1];
        T[] temp = new T[_count - 1];
        _count--;
        for (int i = 0; i < _count; i++)
            temp[i] = Elem[i];

        Elem = temp;
        return res;
    }

    public void MoveTo(int arg_pos, int target_pos)
    {
        if (Size() < 2)
            throw new Exception("There is not enough elements in Vector to move");
        if (arg_pos >= Size() || target_pos >= Size())
            throw new IndexOutOfRangeException("Argument's position or target position is out of range");

        T[] temp = new T[Size()];
        for (int i = target_pos; i < Size(); i++)
            temp[i] = Elem[i];
        Elem[target_pos] = Elem[arg_pos];

        for (int i = target_pos + 1; i < Size(); i++)
            Elem[i] = temp[i-1];

        temp = null;
    }

    public override string ToString()
    {
        MemoryStream MStr = new MemoryStream();
        TextWriter Wr = new StreamWriter(MStr);
        for (int i = 0; i < Size(); i++)
            Wr.WriteLine(Elem[i]);
        Wr.Flush();
        TextReader StrRd = new StreamReader(MStr);
        MStr.Seek(0, SeekOrigin.Begin);
        return StrRd.ReadToEnd();
    }
}

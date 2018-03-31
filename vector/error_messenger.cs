using System;
using System.IO;


class Error_messenger
{

    private MemoryStream _MemStr;
    private StreamWriter _StrWr;
    private uint _Errors_count = 0;

    public Error_messenger(ref MemoryStream MemStr)
    {
        _MemStr = MemStr;
        _StrWr = new StreamWriter(_MemStr);
    }

    public uint Get_error_count()
    {
        return _Errors_count;
    }

    public void Report_error(string msg)
    {
        _MemStr.Seek(0, SeekOrigin.End);
        _StrWr.WriteLine(msg);
        _StrWr.Flush();
        _Errors_count++;
    }

    public void Print_current_state()
    {
        StreamReader sr = new StreamReader(_MemStr);
        Console.WriteLine("Number of errors: {0}", _Errors_count);
        _MemStr.Seek(0, SeekOrigin.Begin);
        Console.WriteLine(sr.ReadToEnd());
    }

    public void Save_report(string path)
    {
        _StrWr.WriteLine("Total number of errors: " + Get_error_count());
        _MemStr.Seek(0, SeekOrigin.Begin);
        try
        {
            FileStream fS = new FileStream(path, FileMode.OpenOrCreate);
            _MemStr.CopyTo(fS);
            fS.Flush();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void End_of_tests()
    {
        _StrWr.WriteLine("\nEnd of tests");
        _StrWr.Flush();
        Print_current_state();
    }

}
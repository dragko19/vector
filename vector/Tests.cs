using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Tests
{
    public static void Main()
    {
        MemoryStream MemStr = new MemoryStream();
        Error_messenger err = new Error_messenger(ref MemStr);
        //tests of default constructor
        {
            Vector<string> test = new Vector<string>();
            if (test.Size() != 0)
                err.Report_error("Error of default constructor");
        }

        //test of default constructor
        {
            for (int i = 0; i < 1000; i += 4)
            {
                Vector<string> test = new Vector<string>(i);
                if (test.Size() != i)
                    err.Report_error("Error of constructor in test number: " + i);
            }
        }

        //[] operator tests
        {
            
            Vector<int> test = new Vector<int>(200);
            for (int i = 0; i < test.Size(); i++)
            {
                try
                {
                    test[i] = i;
                    if (test[i] != i)
                        err.Report_error("Error in [] operator tests");
                }
                catch (IndexOutOfRangeException Exc)
                {
                    err.Report_error("Unexpected exception in [] operator tests" + Exc);
                }
            }

            for (int i = 0; i < 200; i += 5)
            {
                Vector<int> test2 = new Vector<int>(i);
                try
                {
                    test2[i] = i;
                    err.Report_error("Missed exception in [] set operator tests");
                }
                catch(IndexOutOfRangeException)
                {
                    //we want to catch exception                    
                }
            }

            for (int i = 0; i < 200; i += 5)
            {
                Vector<int> test2 = new Vector<int>(i);
                int temp;
                try
                {
                    temp = test2[i];
                    err.Report_error("Missed exception in [] get operator tests");
                }
                catch (IndexOutOfRangeException)
                {
                    //we want to catch exception;
                }
            }
        }

        err.Print_current_state();
        Console.WriteLine("End of tests");
        Console.ReadLine();

    }

}


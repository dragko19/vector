using System;
using System.IO;



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

        //copy ctor tests
        {
            Vector<int> test = new Vector<int>(150);
            for (int i = 0; i < test.Size(); i++)
                test[i] = i;
            try
            {
                Vector<int> test2 = new Vector<int>(ref test);
                if (test2.Size() != test.Size())
                    err.Report_error("Wrong size in copied Vector");
            }
            catch (Exception ex)
            {
                err.Report_error("Unexpected exception in copy ctor tests: " + ex.Message);
            }

            try
            {
                Vector<int> test2 = new Vector<int>(ref test);
                for (int i = 0; i < test2.Size(); i++)
                {
                    if (test2[i] != test[i])
                        err.Report_error("Error in copy ctor tests");
                }
            }
            catch (Exception)
            {
                err.Report_error("Unexpected exception in copy ctor tests");
            }

        }
        //Push_back() method tests
        {
            Vector<int> test = new Vector<int>(10);
            for (int i = 0; i < test.Size(); i++)
                test[i] = i;

            for(int i = 11; i < 20; i++)
            {
                try
                {
                    test.Push_back(i);
                    if (test[i-1] != i)
                        err.Report_error("Error in Push_back() method tests");
                }
                catch(Exception ex)
                {
                    err.Report_error("Unexpected exception in Push_back() method tests: " + ex.Message);
                }
            }
        }

        err.End_of_tests();
        Console.ReadLine();

    }

}


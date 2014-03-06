using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CoreComponents.Debuging
{

    public static class DebugFile
    {

        static FileInfo myFileInfo;

        static Exception myException;

        static DebugFile()
        {

            myFileInfo = new FileInfo(Name);

        }

        public static string Name
        {

            get
            {

                return "debug.txt";

            }

        }

        public static bool Exists
        {

            get
            {

                return myFileInfo.Exists;

            }

        }

        public static void Write(string OutPut)
        {

            try
            {

                if (OutPut != null && OutPut.Length > 0)
                {

                    using (StreamWriter SR = myFileInfo.AppendText())
                    {

                        SR.WriteLine(DateTime.Now);

                        SR.WriteLine(OutPut);

                        SR.WriteLine();

                    }

                }

            }
            catch
            {

                if (CreateIfNotExists())
                {

                    Write(OutPut);

                }

            }

        }

        public static void Write(Exception OutPut)
        {

            try
            {

                using (StreamWriter SR = myFileInfo.AppendText())
                {

                    SR.WriteLine(DateTime.Now);

                    SR.WriteLine("|>|>|>|>|>|>| Exception |<|<|<|<|<|<|");

                    SR.WriteLine("Message:");

                    SR.WriteLine(OutPut.Message);

                    SR.WriteLine("StackTrace:");

                    SR.WriteLine(OutPut.StackTrace);

                    SR.WriteLine();

                }

            }
            catch
            {

                if (CreateIfNotExists())
                {

                    Write(OutPut);

                }

            }

        }

        public static void Write(ErrorEventArgs TheErrorEventArgs)
        {

            if (TheErrorEventArgs.HasException)
            {

                Write(TheErrorEventArgs.Exception);

            }
            else
            {

                Write(TheErrorEventArgs.Message);

            }

        }

        public static void CheckAndWrite(string OutPut)
        {

            if (CreateIfNotExists())
            {

                Write(OutPut);

            }

        }

        public static void CheckAndWrite(Exception OutPut)
        {

            if (CreateIfNotExists())
            {

                Write(OutPut);

            }

        }

        public static void CheckAndWrite(ErrorEventArgs OutPut)
        {

            if (CreateIfNotExists())
            {

                Write(OutPut);

            }

        }

        public static bool CreateIfNotExists()
        {

            try
            {

                if (!myFileInfo.Exists)
                {

                    myFileInfo.Create().Close();

                }

            }
            catch (Exception e)
            {

                myException = e;

                return false;

            }

            //Return true if either file exists or has been created.

            return true;

        }

        public static Exception Exception
        {

            get
            {

                return myException;

            }

        }

        public static bool CaughtException
        {

            get
            {

                return myException != null;

            }

        }

    }

}

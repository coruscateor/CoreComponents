
using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using CoreComponents.Application.Messaging;
using CoreComponents.Items;

namespace CoreComponents.FileSystem.Writing
{
	
	public class QuickFileWriter
	{
		
		public QuickFileWriter()
		{	
		}
		
		public void Write(string Path, IEnumerable<IMessageLine> Messages, bool overwrite, Action<Exception> OnWriteError)
		{
			
			try
			{
				
               	using (StreamWriter Writer = new StreamWriter(Path, overwrite))
               	{

                    StringBuilder SB = new StringBuilder();

                    foreach (IMessageLine Message in Messages)
                    {

                        SB.AppendLine(Message.ToString());

                    }

					Writer.Write(SB.ToString());

                }

            }
            catch (Exception e)
            {

                OnWriteError(e);

            }
			
		}

        public static void Write(string Path, StringBuilder SB) //, GeneralExceptionDelegate OnWriteError)
        {

            //try
            //{

            using (StreamWriter Writer = new StreamWriter(Path, true))
            {

                Writer.Write(SB.ToString());

            }


            //} catch (Exception e)
            //{

            //    OnWriteError(e);

            //}

        }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CoreComponents.Text.Documents
{

    public class SimpleFileDocument : TextDocument
    {

        protected string myPath;

        public SimpleFileDocument()
        {
        }

        public string Path
        {

            get
            {

                return myPath;

            }

        }

        public string Name
        {

            get
            {

                return System.IO.Path.GetFileName(myPath);

            }

        }

        public string Directory
        {

            get
            {

                return System.IO.Path.GetDirectoryName(myPath);

            }

        }

        public bool HasDocument
        {

            get
            {

                return myPath != null && myPath.Length > 0;

            }

        }

        public void Load(string ThePath)
        {

            using(StreamReader FS = new StreamReader(ThePath))
            {

                while(!FS.EndOfStream)
                {

                    myLines.Add(FS.ReadLine());

                }

                myPath = ThePath;

            }

        }

        public void Load(FileInfo TheFile)
        {

            Load(TheFile.FullName);

        }

        public void Save()
        {

            using(StreamWriter SW = new StreamWriter(myPath, false))
            {

                foreach(ITextDocumentLine Item in myLines)
                {

                    SW.WriteLine(Item);

                }

            }

        }

    }

}

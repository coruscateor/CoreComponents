using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CoreComponents.Items;

namespace CoreComponents.FileSystem
{
    public interface IFileSystemObject : IChild<Directory>, IHasName
    {

    	//event Gimmie<SenderEventArgs<FileSystemObject>>.GimmieSomethin NameChanged;

        //event Action<SenderEventArgs<FileSystemObject>> NameChanged;
    	
        DateTime CreationTime
        {
            get;
            set;
        }

        DateTime CreationTimeUtc
        {
            get;
            set;
        }

        bool Exists
        {
            get;
        }

        string Extension
        {
            get;
        }

        DateTime LastAccessTime
        {
            get;
            set;
        }

        DateTime LastAccessTimeUtc
        {
            get;
            set;
        }

        DateTime LastWriteTime
        {
            get;
            set;
        }


        DateTime LastWriteTimeUtc
        {
            get;
            set;
        }
		
        void Delete();

    }

}

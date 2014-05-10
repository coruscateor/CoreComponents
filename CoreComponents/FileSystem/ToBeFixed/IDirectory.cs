using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CoreComponents.Items;

namespace CoreComponents.FileSystem
{

    public interface IDirectory : IFileSystemObject //, IChild<
    {
		
		//event Gimmie<ChangeEventArgs<TParent, TParent>>.GimmieSomethin Moving;
		/*
		DirectoryList SubDirectories
        {

            get;

        }

        FileList Files
        {

            get;

        }
		*/
        //void Add(IFileSystemObject FileSystemObject);

		void Create();
		
        int Count
        {
            get;
        }
		
		DirectoryList SubDirectories
        {

            get;

        }

        FileList  Files
        {

            get;

        }
        
        bool IsRoot();
        

    }

}

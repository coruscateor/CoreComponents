using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CoreComponents.Items;

namespace CoreComponents.FileSystem
{

    public interface IDirectory : IFileSystemObject
    {
	
		DirectoryList SubDirectories
        {

            get;

        }

        FileList Files
        {

            get;

        }
		
        void Add(IFileSystemObject FileSystemObject);

		void Create();
		
		void CreateSubdirectory(string path);
		
        int Count
        {
            get;
        }

    }
	
	public class DirectoryList : ParentedList<IDirectory, IDirectory>
	{
		
		public event Gimmie<ChangeEventArgs<DirectoryList, KeyValuePair<IDirectory, Exception>>>.GimmieSomethin Error;
		
		public event Gimmie<ChangeEventArgs<DirectoryList, KeyValuePair<DirectoryInfo, Exception>>>.GimmieSomethin InfoError;
		
		public override void Add(DirectoryInfo item)
		{
			
			try {
			
				if(myOwner.FullName == item.Parent.FullName)
				{
				
					base.Add(item);
				
				} else {
			
					item.MoveTo(myOwner.FullName);
			
					base.Add(item);
				
				}
				
				} catch(Exception e)
				{
				
					OnError(item, e);
				
				}
			
		}
		
		void OnError(IDirectory Dir, Exception e)
		{
			
			if(Error != null)
				Error(new ChangeEventArgs<DirectoryList, KeyValuePair<IDirectory, Exception>>(this, new KeyValuePair<IDirectory, Exception>(Dir, e)));
				      
		}
		
		void OnInfoError(IDirectory Dir, Exception e)
		{
			
			if(InfoError != null)
				InfoError(new ChangeEventArgs<DirectoryList, KeyValuePair<IDirectory, Exception>>(this, new KeyValuePair<IDirectory, Exception>(Dir, e)));
				      
		}
		
		public void DeleteAll()
		{
			
			foreach(Directory item in myChildern)
			{
				
				item.Delete();
				
			}
			
			myChildern.Clear();
			
		}
		
		/*
		public void Add(FileInfo item)
		{
			
			Add(item);
			
		}
		*/
		
		public override void Add(IDirectory item)
		{
			
			try {
			
				base.Add(item);
				
			} catch(Exception e)
			{
				
				OnInfoError(item, e);
				
			}
			
		}

		
	}
	
	public class FileList : ParentedList<IDirectory, IFile>
	{
		
		public event Gimmie<ChangeEventArgs<DirectoryList, KeyValuePair<IFile, Exception>>>.GimmieSomethin Error;
		
		public void DeleteAll()
		{
			
			foreach(File item in myChildern)
			{
				
				item.Delete();
				
			}
			
			myChildern.Clear();
			
		}
		
	}

	/*
    public interface IDirectory<T> : IFileSystemObject<T>, IDirectory where T : IFileSystemObject
    {

        ParentedList<IDirectory<T>> SubDirectories
        {

            get;

        }

        ParentedList<IFile<T>> Files
        {

            get;

        }

    }
    */
}

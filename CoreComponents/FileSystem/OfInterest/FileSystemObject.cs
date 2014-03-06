
using System;
using System.IO;

namespace CoreComponents.FileSystem
{

	public abstract class FileSystemObject<T> : IFileSystemObject<T> where T : IFileSystemObject
	{

		protected FileSystemInfo myFSInfo;
		
		protected Directory myParent;
		
		public FileSystemObject()
		{
			
		}
		
		public FileSystemObject(FileSystemInfo FSInfo)
		{
			
			myFSInfo = FSInfo;
			
		}
		
		public FileSystemObject(FileSystemInfo FSInfo, Directory Parent)
		{
			
			myFSInfo = FSInfo;
			
			myParent = Parent;
			
		}
		
		/*
		public event Gimmie<ChangeEventArgs<FileAttributes, T>>.GimmieSomethin AttributesChanged;

        public event Gimmie<ChangeEventArgs<DateTime, T>>.GimmieSomethin CreationTimeChanged;

        public event Gimmie<ChangeEventArgs<DateTime, T>>.GimmieSomethin LastAccessTimeChanged;

        public event Gimmie<ChangeEventArgs<DateTime, T>>.GimmieSomethin LastWriteTimeChanged;

        public event Gimmie<ChangeEventArgs<string, T>>.GimmieSomethin NameChanged;

  	    //public event Gimmie<SenderEventArgs<T>>.GimmieSomethin Created;

        public event Gimmie<SenderEventArgs<T>>.GimmieSomethin Deleted;
		
		//--
		
				//public event Gimmie<ChangeEventArgs<FileAttributes, T>>.GimmieSomethin 
		
		void OnAttributesChanged()
		{
			
			if(AttributesChanged != null)
				AttributesChanged(new ChangeEventArgs<FileAttributes, T>(this, myFSInfo.Attributes));
			
		}
		
		//--
		
		void OnCreationTimeChanged()
		{
			
			if(CreationTimeChanged != null)
				CreationTimeChanged(new ChangeEventArgs<DateTime, T>(this, myFSInfo.CreationTime));
			
		}
		
		void OnLastAccessTimeChanged()
		{
			
			if(LastAccessTimeChanged != null)
				LastAccessTimeChanged(new ChangeEventArgs<DateTime, T>(this, myFSInfo.LastAccessTime));
			
		}
		
		void OnLastWriteTimeChanged()
		{
			
			if(LastWriteTimeChanged != null)
				LastWriteTimeChanged(new ChangeEventArgs<FileAttributes, T>(this, myFSInfo.LastWriteTime));
			
		}
		
		void OnAttributesChanged()
		{
			
			if(AttributesChanged != null)
				AttributesChanged(new ChangeEventArgs<FileAttributes, T>(this, myFSInfo.Attributes));
			
		}
		
				void OnAttributesChanged()
		{
			
			if(AttributesChanged != null)
				AttributesChanged(new ChangeEventArgs<FileAttributes, T>(this, myFSInfo.Attributes));
			
		}

        public event Gimmie<ChangeEventArgs<DateTime, T>>.GimmieSomethin CreationTimeChanged;

        public event Gimmie<ChangeEventArgs<DateTime, T>>.GimmieSomethin LastAccessTimeChanged;

        public event Gimmie<ChangeEventArgs<DateTime, T>>.GimmieSomethin LastWriteTimeChanged;

        public event Gimmie<ChangeEventArgs<string, T>>.GimmieSomethin NameChanged;

  	    //public event Gimmie<SenderEventArgs<T>>.GimmieSomethin Created;

        public event Gimmie<SenderEventArgs<T>>.GimmieSomethin Deleted;
		*/
		/*
		protected void TheFSInfo(FileSystemInfo FSInfo)
		{
			
			if(myFSInfo != null)
				myFSInfo = FSInfo;
			
		}
		*/
		/*
		protected void TheFSInfo(FileSystemInfo FSInfo, Directory Dir)
		{
			
			if(myFSInfo != null) {
				
				myFSInfo = FSInfo;
				
				Dir.SubDirectories.Add(Dir);
			}
		}
		*/
		
		public abstract Directory Parent
		{
			
			get;
			set;
			
		}
		
		public FileAttributes Attributes
        {
            get
			{
				
				return myFSInfo.Attributes;
				
			}
			
            set
			{
				
				myFSInfo.Attributes = value;
				
			}
        }

        public DateTime CreationTime
        {
            get
			{
				
				return myFSInfo.Attributes;
				
			}
			
            set
			{
				
				myFSInfo.Attributes = value;
				
			}
        }

        public DateTime CreationTimeUtc
        {
            get
			{
				
				return myFSInfo.Attributes;
				
			}
			
            set
			{
				
				myFSInfo.Attributes = value;
				
			}
        }

        public bool Exists
        {
            get 
			{
				return myFSInfo.Exists;
				
			}
			
        }

        public string Extension
        {
			
            get 
			{
				
				return myFSInfo.Extension;
				
			}
			
        }

        public string FullName
        {
			
            get
			{
				
				return myFSInfo.FullName;
				
			}
			
        }

        public DateTime LastAccessTime
        {
            get
			{
				
				return myFSInfo.LastAccessTime;
				
			}
			
            set
			{
				
				myFSInfo.LastAccessTime = value;
				
			}
        }

        public DateTime LastAccessTimeUtc
        {
            get
			{
				
				return myFSInfo.LastAccessTimeUtc;
				
			}
			
            set
			{
				
				myFSInfo.LastAccessTimeUtc = value;
				
			}
        }

        public DateTime LastWriteTime
        {
            get
			{
				
				return myFSInfo.LastWriteTime;
				
			}
			
            set
			{
				
				myFSInfo.LastWriteTime = value;
				
			}
        }

        public DateTime LastWriteTimeUtc
        {
            get
			{
				
				return myFSInfo.LastWriteTimeUtc;
				
			}
			
            set
			{
				
				myFSInfo.LastWriteTimeUtcs = value;
				
			}
        }

        public string Name
        {
            get
			{
				
				return myFSInfo.Name;
				
			}
			
            set
			{
				
				myFSInfo.Name = value;
				
			}
        }

        public abstract void Delete();
		
		
		
	}

}

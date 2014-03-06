
using System;
using System.IO;
using CoreComponents.Items;
using CoreComponents.Text;

namespace CoreComponents.FileSystem
{

	public abstract class FileSystemObject : IFileSystemObject
	{
		
		//public event Gimmie<SenderEventArgs<FileSystemObject>>.GimmieSomethin NameChanged;

		//public event Gimmie<SenderEventArgs<FileSystemObject>>.GimmieSomethin Created;
		
		//public event Gimmie<SenderEventArgs<FileSystemObject>>.GimmieSomethin Deleted;

        public event Action<SenderEventArgs<FileSystemObject>> NameChanged;

        public event Action<SenderEventArgs<FileSystemObject>> Created;

        public event Action<SenderEventArgs<FileSystemObject>> Deleted;

		protected string myName = "";
		
		//protected string myPath;
		
		protected string myWholePath = "";
		
		/*
		public readonly char[] IllegalCharacters; //= { '/', '\\', '*', '(', ')' };
		
		static FileSystemObject()
		{
			
			IllegalCharacters = { '/', '\\', '*', '(', ')' };
			
		}
		*/
		
		public FileSystemObject()
		{
			
		}

		protected virtual void ReBuildWholePath()
		{

            //if (myWholePath.Length > 0)
            //{

                if (!PathIsName())
                {

                    string DirName = System.IO.Path.GetDirectoryName(myWholePath);

                    if (DirName[DirName.Length - 1] == TextEntity.OSSeperator[0])
                    {

                        myWholePath = DirName + myName;

                    }
                    else
                    {

                        myWholePath = DirName + TextEntity.OSSeperator + myName;

                    }

                }

            //}
			
		}
		
		void OnNameChanged()
		{
		
			if(NameChanged != null)
				NameChanged(new SenderEventArgs<FileSystemObject>(this));
			
		}
		
		protected void OnCreated()
		{
		
			if(Created != null)
				Created(new SenderEventArgs<FileSystemObject>(this));
			
		}
		
		void OnDeleted()
		{
			
			if(Deleted != null)
			  	Deleted(new SenderEventArgs<FileSystemObject>(this));
			
		}
		
        //Reserved Windows names are:
        //CON, PRN, AUX, CLOCK$, NUL
        //COM0, COM1, COM2, COM3, COM4, COM5, COM6, COM7, COM8, COM9
        //LPT0, LPT1, LPT2, LPT3, LPT4, LPT5, LPT6, LPT7

        //From http://ionicflux.wordpress.com/2006/09/02/windows-reserved-words/

		public virtual string Name
        {
			
          get
			{
				
				return myName;
				
			}
			
          set
			{
				
				myName = value;
				
				ReBuildWholePath();
				
				OnNameChanged();
				
			}
        
        }
		
		protected virtual void GetFromFullPath(string path)
		{
			
			myWholePath = path;
			
			myName = ObtainName(path);
			
			ReBuildWholePath();
			
		}
		
		
		//Assumes path has already been determined.
		
		protected string ObtainName(string path)
		{
			
			//int PathSeparatorLoc = path.LastIndexOf(System.IO.Path.DirectorySeparatorChar);
			
			int PathSeparatorLoc = path.LastIndexOf(TextEntity.OSSeperator);
			
			return path.Remove(0, PathSeparatorLoc + 1);
			
		}
		
		public virtual string Path
        {
			
          get
			{
				
				return System.IO.Path.GetDirectoryName(myWholePath);
				
			}
			
        }
		
		public virtual string WholePath
        {
			
          get
			{
				
				return myWholePath;
				
			}
			
        }
		
		public virtual bool HasPath()
		{
			
			return System.IO.Path.GetDirectoryName(myWholePath).Length > 0;
			
		}
		
		public virtual string Extension
        {
			
          get 
			{
				
				return System.IO.Path.GetExtension(myWholePath);
				
			}
			
        }

        public virtual bool PathIsName() 
        {

            return myWholePath == myName;

        }
		
		#region IFileSystemObject implementation
		public abstract void Delete();
		
		public abstract void Create();
		
		/*
		public abstract FileAttributes Attributes {
			
			get;
			set;
			
		}
		*/
		
		public abstract DateTime CreationTime {

			get;
			set;
		}
		
		
		public abstract DateTime CreationTimeUtc {
			
			get;
			set;
			
		}
		
		
		public abstract bool Exists {
			
			get;
		}
		
		public abstract DateTime LastAccessTime {
			
			get;
			set;
		}
		
		public abstract DateTime LastAccessTimeUtc {
			
			get;
			set;
		}
		
		public abstract DateTime LastWriteTime {
			
			get;
			set;
		}
		
		public abstract DateTime LastWriteTimeUtc {
			
			get;
			set;
		}
		
		#endregion
		#region IChild<Directory> implementation
		
		public abstract bool IsOrphin();
		
		public abstract Directory Parent {
			
			get;
			set;
			
		}
		
		protected void CheckLocationAndMove(Directory Dir)
		{

            if (Return.IsNotNull(Dir))
            {

                if (System.IO.Path.GetDirectoryName(myWholePath) != Dir.WholePath)
                    System.IO.Directory.Move(myWholePath, Dir.WholePath);

            }

		}
		
		/*
		public virtual Directory Parent
		{
			
			get
			{
				
				return myAdapter.OwnersParent;
				
			}
			set
			{
				
				//If not in the same directory, move it. 
				
				if(System.IO.Path.GetDirectoryName(myWholePath) != value.Path)
					System.IO.Directory.Move(myWholePath, Parent.WholePath);
				
				myAdapter.SetParent(value);
				
				//myPath = Parent.WholePath + TextEntity.OSSeperator + Name;
				
				ReBuildWholePath();
				
			}
			
		}
		*/
		
		#endregion
		//public event Gimmie<ChangeEventArgs<TParent, TParent>>.GimmieSomethin Moving;
		
		/*
		public FileSystemObject(FileSystemInfo FSInfo)
		{
			
			myFSInfo = FSInfo;
			
		}
		 
		public FileSystemObject(FileSystemInfo FSInfo, Directory Parent)
		{
			
			myFSInfo = FSInfo;
			
			myParent = Parent;
			
		}
		*/
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
		/*
		public abstract TParent Parent
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
		*/
		
	}
	
	/*
	public abstract class FileSystemObject<TFileSystemObject, TList> : FileSystemObject where TFileSystemObject : IFileSystemObject  where TList : IParentedList<TFileSystemObject, TList> //where TList : IFSOList<TFileSystemObject, TList>
	{
		
		protected ChildToParentAdapter<Directory, TFileSystemObject, TList> myAdapter;
		
	}
	*/

}

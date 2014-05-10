using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CoreComponents.Text;
using CoreComponents.Items;

namespace CoreComponents.FileSystem
{
	
    public class Directory : FileSystemObject, IDirectory
    {
		//FileSystemObject<File, FileList>, IDirectory 
		protected DirectoryList mySubDirectories;
		
		protected FileList myFiles;
		
		protected ChildToParentAdapter<Directory, Directory, DirectoryList> myAdapter;
		
		protected FileSystemWatcher myFSW;
		
		/*
		public Directory()
		{
			
			System.IO.DriveInfo DI = new System.IO.DriveInfo("c:/");
			//DriveInfo.GetDrives();
			//DI.
			
			SetAdapter();
			
		}
		*/
		
		public Directory(string PathOrName)
		{

            if (IsNotOnlyName(PathOrName))
            {

                GetFromFullPath(PathOrName);

            }
            else 
            {

                myName = PathOrName;

                myWholePath = myName;

            }

			SetAdapter();
			
			InitialiseLists();
			
			//myFSW = new FileSystemWatcher(myWholePath);
			
			//myFSW.Path
			
		}
	
		public Directory(Directory Parent, string Name)
		{

            myName = Name;
			
			Parent.SubDirectories.Add(this);
			
			SetAdapter();
			
			InitialiseLists();
			
		}
		
		public Directory(Directory Parent, string Name, bool Create)
		{
			
			myName = Name;
			
			Parent.SubDirectories.Add(this);
			
			SetAdapter();
			
			InitialiseLists();
			
			if(Create)
				this.Create();
			
		}
		
		public Directory(Directory Parent, bool create)
		{
			
			myName = "New Directory";
			
			Parent.SubDirectories.Add(this);
			
			SetAdapter();
			
			InitialiseLists();
			
			if(create)
				this.Create();

		}
		
		public Directory(string Path, bool Create)
		{
			
			GetFromFullPath(Path);
			
			SetAdapter();
			
			InitialiseLists();
			
			if(Create)
				this.Create();
			
		}

        public static bool IsNameOnly(string PathOrName) 
        {

            return !PathOrName.Contains(System.IO.Path.DirectorySeparatorChar);

        }

        public static bool IsNotOnlyName(string PathOrName)
        {

            return PathOrName.Contains(System.IO.Path.DirectorySeparatorChar);

        }

		protected void SetAdapter()
		{
			
			myAdapter = new ChildToParentAdapter<Directory, Directory, DirectoryList>(this, "SubDirectories");
			
		}
		
		/*
		protected virtual void GetFromFullPath(string path)
		{
			
			//myPath = System.IO.Path.GetDirectoryName(path);
			
			myName = ObtainName(path);
			
			
			
			ReBuildWholePath();
			
		}
		*/
		
		/*
		//Assumes path has already been determined.
		
		string ObtainName(string path)
		{
			
			//int PathSeparatorLoc = path.LastIndexOf(System.IO.Path.DirectorySeparatorChar);
			
			int PathSeparatorLoc = myWholePath.LastIndexOf(System.IO.Path.DirectorySeparatorChar);
			
			return path.Remove(0, PathSeparatorLoc + 1);
			
		}
		*/
		
		protected void InitialiseLists()
		{
			
			mySubDirectories = new DirectoryList(this);
			
			myFiles = new FileList(this);
			
		}
		
		/*
		string ObtainPath(string path)
		{
			
			
		}
		*/
		
		public void Discover()
		{
			//Discover
			
			DiscoverDirectories();
			
			DiscoverFiles();
			
		}
		
		//public void Discover<TFSObj>
		
		public void DiscoverDirectories()
		{
			
			string[] DirectoryArray = System.IO.Directory.GetDirectories(this.myWholePath);
			
			List<string> Directories = new List<string>(DirectoryArray);
			
			foreach (Directory item in mySubDirectories)
			{
				
				foreach (string FoundDirectory in DirectoryArray)
				{
				
					if(item.Name == FoundDirectory)
					{
						
						Directories.Remove(FoundDirectory);
						
					}
					
				}
				
			}
			
			foreach (string item in Directories)
			{
				
				mySubDirectories.Add(new Directory(item));
				
			}
			
		}
		
		
		public void DiscoverFiles()
		{
			
			string[] FileArray = System.IO.Directory.GetFiles(myWholePath);
			//System.IO.Directory.GetFiles(
			List<string> FileList = new List<string>(FileArray);
			
			foreach (File item in myFiles)
			{
				
				foreach (string Foundfile in FileArray)
				{
				
					if(item.Name == Foundfile)
					{
						
						FileList.Remove(Foundfile);
						
					}
					
				}
				
			}
			
			foreach (string item in FileList)
			{
				
				myFiles.Add(new File(item));
				
			}
			
		}
		
		public bool HasAllDirectories()
		{
			
			
			return System.IO.Directory.GetDirectories(myWholePath).Length == mySubDirectories.Count;
			
			
		}
		
		public bool HasAllFiles()
		{
			
			
			return System.IO.Directory.GetFiles(myWholePath).Length == myFiles.Count;
			
			
		}
		
        public override DateTime CreationTime
        {
        	
         	get
			{
				
				return System.IO.Directory.GetCreationTime(myWholePath);
				
			}
			
          set
			{
				
				System.IO.Directory.SetCreationTime(myWholePath, value);
				
			}
          
        }

        public override DateTime CreationTimeUtc
        {
        	
          get
			{
				
				return System.IO.Directory.GetCreationTimeUtc(myWholePath);
				
			}
			
          set
			{
				
				System.IO.Directory.SetCreationTimeUtc(myWholePath, value);
				
			}
          
        }

        public override bool Exists
        {
        	
          get 
			{
				
				return System.IO.Directory.Exists(myWholePath);
				
			}
			
        }

        public override DateTime LastAccessTime
        {
          get
			{
				
				return System.IO.Directory.GetLastAccessTime(myWholePath);
				
			}
			
          set
			{
				
				System.IO.Directory.SetLastAccessTime(myWholePath, value);
				
			}
          
        }

        public override DateTime LastAccessTimeUtc
        {
          get
			{
				
				return System.IO.Directory.GetLastAccessTime(myWholePath);
				
			}
			
          set
			{
				
				System.IO.Directory.SetLastAccessTime(myWholePath, value);
				
			}
          
        }

        public override DateTime LastWriteTime
        {
          get
			{
				
				return System.IO.Directory.GetLastAccessTime(myWholePath);
				
			}
			
          set
			{
				
				System.IO.Directory.SetLastAccessTime(myWholePath, value);
				
			}
          
        }

        public override DateTime LastWriteTimeUtc
        {
          get
			{
				
				return System.IO.Directory.GetLastWriteTimeUtc(myWholePath);
				
			}
			
          set
			{
				
				System.IO.Directory.SetLastWriteTimeUtc(myWholePath, value);
				
			}
          
        }
		
		public override void Create()
		{
			
			System.IO.Directory.CreateDirectory(myWholePath);
			
			OnCreated();
			
		}
		
		public override void Delete()
		{
			
			//28062010 PCS Well just "disarm" this for now.
			
			/*
			mySubDirectories.DeleteAll();
			
			myFiles.DeleteAll();
			
			System.IO.Directory.Delete(myWholePath, true);
			
			Parent.SubDirectories.Remove(this);
			*/
		}
		
		public DirectoryList SubDirectories
        {

          get
			{
				
				return mySubDirectories;
				
			}

        }
		/*
		public void CreateSubdirectory(string name)
		{
		
			Directory NewDir = new Directory(name);
			
			mySubDirectories.Add(NewDir);
			
		}
		*/
        public FileList Files
        {

          get
			{
				
				return myFiles;
				
			}

        }
		
        public int Count
        {
        	
          get
			{
				
				return myFiles.Count + mySubDirectories.Count;
				
			}
        }
		
		public override Directory Parent
		{
			
			get
			{
				
				return myAdapter.OwnersParent;
				
			}
			set
			{
				
				//If not in the same directory, move it. 
				/*
				if(System.IO.Path.GetDirectoryName(myWholePath) != value.WholePath)
					System.IO.Directory.Move(myWholePath, value.WholePath);
				*/
				
				CheckLocationAndMove(value);
				
				myAdapter.SetParent(value);
				
				//myPath = Parent.WholePath + TextEntity.OSSeperator + Name;
				
				ReBuildWholePath();

                //Children need to be able to rebuild their paths aswell.
				
			}
			
		}
		
		public override bool IsOrphin()
		{
			
			return myAdapter.OwnerIsOrphin();
			
		}
		
		public virtual bool IsRoot()
		{	
			
			/*
			if(myName.Length > 0) {
			
				string Root = System.IO.Directory.GetDirectoryRoot(myWholePath);		
			
				return Root == myWholePath;
					
			}
			*/
			
			return false;
			
			
		}
		
    }
    
    public interface IFSOList<TParent, TChild> : IParentedList<TParent, TChild>
    {
    	
    	void DeleteAll();
    	
    }
	
	public class DirectoryList : ParentedList<Directory, Directory>, IFSOList<Directory, Directory>
	{
				
		public event Action<ChangeEventArgs<DirectoryList, KeyValuePair<Directory, Exception>>> Error;
		
		public DirectoryList(Directory Parent) : base(Parent)
		{
			
		}
		
		/*
		public void Add(FileSystemObject item)
		{
			
			try {
			
				if(myOwner.WholePath != item.Parent.WholePath)
				{
				
					//item.MoveTo(myOwner.FullName);
					
					//item.Parent = myOwner;
			
					base.Add(item);
				
				}
				
				} catch(Exception e)
				{
				
					OnError(item, e);
				
				}
			
		}
		*/
		
		void OnError(Directory item, Exception e)
		{
			
			if(Error != null)
				Error(new ChangeEventArgs<DirectoryList, KeyValuePair<Directory, Exception>>(new KeyValuePair<Directory, Exception>(item, e), this));
				      
		}
		
		public void DeleteAll()
		{

            foreach (Directory item in myChildren)
			{
				
				item.Delete();
				
			}

            myChildren.Clear();
			
		}
		
		public List<Directory> GetDirectories(string extension)
		{
			
			List<Directory> ItemList = new List<Directory>();

            foreach (Directory item in myChildren)
			{
				
				if(item.Extension == extension)
					ItemList.Add(item);
				
			}
			
			return ItemList;
			
		}		

	}
	
	public class FileList : ParentedList<Directory, File>, IFSOList<Directory, File> //where TDirectory : IDirectory where TFile : IFile
	{

        public event Action<ChangeEventArgs<DirectoryList, KeyValuePair<File, Exception>>> Error;
		
		public FileList(Directory Parent) : base(Parent)
		{
			
		}
		
		public void DeleteAll()
		{

            foreach (File item in myChildren)
			{
				
				item.Delete();
				
			}

            myChildren.Clear();
			
		}
		
		public List<File> GetFiles(string extension)
		{
			
			List<File> ItemList = new List<File>();

            foreach (File item in myChildren)
			{
				
				if(item.Extension == extension)
					ItemList.Add(item);
				
			}
			
			return ItemList;
			
		}
		
	}
	
	/*
	public delegate string[] ReturnStringArray1(string arg1);
	
	public delegate string[] ReturnStringArray2(string arg1, string arg2);
	
	public delegate string[] ReturnStringArray3(string arg1, string arg2, SearchOption arg3);
	
	public class FSORetrever<TFSO, TFSOList> : where TFSO : IFileSystemObject, where TFSOList : IParentedList
	{
		
		//public FSORetrever(
		
		
		public void Discover()
		{
			
			string[] DirectoryArray = System.IO.Directory.GetDirectories(myWholePath);
			
			List<string> Directories = new List<string>(DirectoryArray);
			
			foreach (Directory item in mySubDirectories)
			{
				
				foreach (string FoundDirectory in DirectoryArray)
				{
				
					if(item.Name == FoundDirectory)
					{
						
						Directories.Remove(FoundDirectory);
						
					}
					
				}
				
			}
			
			foreach (string item in Directories)
			{
				
				mySubDirectories.Add(new Directory(item));
				
			}
			
		}
		*/
		/*
		public void DiscoverDirectories()
		{
			
			string[] DirectoryArray = System.IO.Directory.GetDirectories(myWholePath);
			
			List<string> Directories = new List<string>(DirectoryArray);
			
			foreach (Directory item in mySubDirectories)
			{
				
				foreach (string FoundDirectory in DirectoryArray)
				{
				
					if(item.Name == FoundDirectory)
					{
						
						Directories.Remove(FoundDirectory);
						
					}
					
				}
				
			}
			
			foreach (string item in Directories)
			{
				
				mySubDirectories.Add(new Directory(item));
				
			}
			
		}
		
		
		public void DiscoverFiles()
		{
			
			string[] FileArray = System.IO.Directory.GetFiles(myWholePath);
			//System.IO.Directory.GetFiles(
			List<string> FileList = new List<string>(FileArray);
			
			foreach (File item in myFiles)
			{
				
				foreach (string Foundfile in FileArray)
				{
				
					if(item.Name == Foundfile)
					{
						
						FileList.Remove(Foundfile);
						
					}
					
				}
				
			}
			
			foreach (string item in FileList)
			{
				
				myFiles.Add(new File(item));
				
			}
			
		}
		*/
		
	//}
	
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CoreComponents.Text;
using CoreComponents.Items;

namespace CoreComponents.FileSystem
{
    public class File : FileSystemObject, IFile
    {
		//FileSystemObject<File, FileList>, IFile
		
		ChildToParentAdapter<Directory, File, FileList> myAdapter;
		
        public File()
        {
        }
		
		public File(string path)
        {
			
			GetFromFullPath(path);
			
			SetAdapter();
			
        }
		
		public File(Directory parent, string name)
		{
			
			myName = name;
			
			parent.Files.Add(this);
			
			SetAdapter();
			
			//InitialiseLists();
			
		}
		
		public File(Directory parent, string name, bool create)
		{
			
			myName = name;
			
			parent.Files.Add(this);
			
			SetAdapter();
			
			//InitialiseLists();
			
			if(create)
				this.Create();
			
		}
		
		public File(Directory parent, bool create)
		{
			
			myName = "New File";
			
			parent.Files.Add(this);
			
			SetAdapter();
			
			//InitialiseLists();
			
			if(create)
				this.Create();
			
		}
		
		public File(string path, bool create)
		{
			
			SetAdapter();
			
			//InitialiseLists();
			
			if(create)
				this.Create();
			
		}
		
		/*
		void GetFromFullPath(string path)
		{
			
			//myPath = System.IO.Path.GetDirectoryName(path);
			
			myWholePath = path;
			
			ObtainName(path);
			
			//ReBuildWholePath();
			
		}
		*.
		/*
		//Assumes path has already been determined.
		
		void ObtainName(string path)
		{
			
			//int PathSeparatorLoc = myPath.Length + 1;
			
			//myName = myWholePath.Remove(0, PathSeparatorLoc);
			
			int PathSeparatorLoc = myWholePath.LastIndexOf(System.IO.Path.DirectorySeparatorChar);
			
			myName = myWholePath.Remove(0, PathSeparatorLoc);
			
		}
		*/
		
		public void SetAdapter()
		{
			
			myAdapter = new ChildToParentAdapter<Directory, File, FileList>(this, "Files");
			
		}
		
		/*
		string ObtainPath(string path)
		{
			
			
		}
		*/
		
		public FileAttributes Attributes
        {
            get 
			{
				
				return System.IO.File.GetAttributes(myWholePath); 
				
			}
            set
			{
				
				System.IO.File.SetAttributes(myWholePath, value);
				
			}
        }

		
        public override DateTime CreationTime
        {
            get
			{
				
				return System.IO.File.GetCreationTime(myWholePath);
				
			}
			
            set
			{
				
				System.IO.File.SetCreationTime(myWholePath, value);
				
			}
        }

        public override DateTime CreationTimeUtc
        {
            get
			{
				
				return System.IO.File.GetCreationTimeUtc(myWholePath);
				
			}
			
            set
			{
				
				System.IO.File.SetCreationTimeUtc(myWholePath, value);
				
			}
        }

        public override bool Exists
        {
            get 
			{
				
				return System.IO.File.Exists(myWholePath);
				
			}
			
        }

        public override string Extension
        {
			
            get 
			{
				
				return System.IO.Path.GetExtension(myWholePath);
				
			}
			
        }
		
        public override DateTime LastAccessTime
        {
            get
			{
				
				return System.IO.File.GetLastAccessTime(myWholePath);
				
			}
			
            set
			{
				
				System.IO.File.SetLastAccessTime(myWholePath, value);
				
			}
        }

        public override DateTime LastAccessTimeUtc
        {
            get
			{
				
				return System.IO.File.GetLastAccessTime(myWholePath);
				
			}
			
            set
			{
				
				System.IO.File.SetLastAccessTime(myWholePath, value);
				
			}
        }

        public override DateTime LastWriteTime
        {
            get
			{
				
				return System.IO.File.GetLastAccessTime(myWholePath);
				
			}
			
            set
			{
				
				System.IO.File.SetLastAccessTime(myWholePath, value);
				
			}
        }

        public override DateTime LastWriteTimeUtc
        {
            get
			{
				
				return System.IO.File.GetLastWriteTimeUtc(myWholePath);
				
			}
			
            set
			{
				
				System.IO.File.SetLastWriteTimeUtc(myWholePath, value);
				
			}
        }
		
		public override void Create()
		{
			
			System.IO.File.Create(myWholePath);
			
			OnCreated();
			
		}
		
		public override void Delete()
		{
			
			//28062010 PCS Well just "disarm" this for now.
			
			/*
			System.IO.File.Delete(myWholePath);
			
			Parent.Files.Remove(this);
			*/
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
				
			}
			
		}
		
		public override bool IsOrphin()
		{
			
			return myAdapter.OwnerIsOrphin();
			
		}
		
    }
	
}

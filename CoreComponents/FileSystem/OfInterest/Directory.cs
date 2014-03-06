using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CoreComponents.Text;

namespace CoreComponents.FileSystem
{
    public class Directory : FileSystemObject<IDirectory>, IDirectory
    {
		
		//DirectoryInfo myInfo;
		
		DirectoryList mySubDirectories = new DirectoryList();
		
		FileList myFiles = new FileList();
		
		/*
		public Directory() //: base((FileSystemInfo)myInfo)
		{
				
		}
		*/
		public Directory(string path) //: base((FileSystemInfo)myInfo)
		{
			
			myFSInfo = new DirectoryInfo(path);
			
		}
		
		public Directory(Directory parent, string name)
		{
			
			myFSInfo = DirectoryInfo(parent.FullName + TextEntity.OSSeperator + name);
			
			parent.SubDirectories.Add(this);
			
			
		}
		
		public Directory(Directory parent, string name, bool create)
		{
			
			myFSInfo = DirectoryInfo(parent.FullName + TextEntity.OSSeperator + name);
			
			parent.SubDirectories.Add(this);
			
			if(create)
				this.Create();
			
		}
		
		/*
		public Directory(Directory parent, DirectoryInfo DirInfo) //: base((FileSystemInfo)DirInfo)
		{
			
			myFSInfo = (FileSystemInfo)DirInfo;
			
			parent.SubDirectories.Add(this);
			            
		}
		*/
		
		public void Create()
		{
			
			myInfo.Create();
			
		}
		
		public void Delete()
		{
			
			mySubDirectories.DeleteAll();
			
			myFiles.DeleteAll();
			
			((DirectoryInfo)myInfo).Delete(true);
			
			Parent.SubDirectories.Remove(this);
			
		}
		
		public DirectoryList SubDirectories
        {

            get
			{
				
				return mySubDirectories;
				
			}

        }
		
		public void CreateSubdirectory(string name)
		{
		
			Directory NewDir = new Directory(name);
			
			mySubDirectories.Add(NewDir);
			
		}
		
        public FileList Files
        {

            get
			{
				
				return myFiles;
				
			}

        }
		
		
		
		/*
        public void Add(IFileSystemObject FileSystemObject)
		{
				
		}
		*/
		
        public int Count
        {
            get
			{
				
				return myFiles.Count + mySubDirectories.Count;
				
			}
        }
		
		public Directory Parent
		{
			
			get
			{
				
				return myParent;
				
			}
			set
			{
				
				myParent = value;
				
			}
			
		}
		
    }
}

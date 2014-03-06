using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CoreComponents.Items;

namespace CoreComponents.FileSystem
{
    public interface IFileSystemObject //: IReadonlyParentChild<
    {

        FileAttributes Attributes
        {
            get;
            set;
        }

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

        string FullName
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

        string Name
        {
            get;
            set;
        }

        void Delete();


    }

    public interface IFileSystemObject<T> : IFileSystemObject where T : IFileSystemObject //, IChild<IDirectory>
    {
		/*
        event Gimmie<ChangeEventArgs<FileAttributes, T>>.GimmieSomethin AttributesChanged;

        event Gimmie<ChangeEventArgs<DateTime, T>>.GimmieSomethin CreationTimeChanged;

        event Gimmie<ChangeEventArgs<DateTime, T>>.GimmieSomethin LastAccessTimeChanged;

        event Gimmie<ChangeEventArgs<DateTime, T>>.GimmieSomethin LastWriteTimeChanged;

        event Gimmie<ChangeEventArgs<string, T>>.GimmieSomethin NameChanged;

        event Gimmie<SenderEventArgs<T>>.GimmieSomethin Created;

        event Gimmie<SenderEventArgs<T>>.GimmieSomethin Deleted;
		*/
        //FileAttributes Attributes
        //{
        //    get;
        //    set;
        //}

        //DateTime CreationTime
        //{
        //    get;
        //    set;
        //}

        //DateTime CreationTimeUtc
        //{
        //    get;
        //    set;
        //}

        //bool Exists
        //{
        //    get;
        //}

        //string Extension
        //{
        //    get;
        //}

        //string FullName
        //{
        //    get;
        //}

        //DateTime LastAccessTime
        //{
        //    get;
        //    set;
        //}

        //DateTime LastAccessTimeUtc
        //{
        //    get;
        //    set;
        //}

        //DateTime LastWriteTime
        //{
        //    get;
        //    set;
        //}


        //DateTime LastWriteTimeUtc
        //{
        //    get;
        //    set;
        //}

        //string Name
        //{
        //    get;
        //    set;
        //}

        //void Delete();

        //void Create();

    }
}

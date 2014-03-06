using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.FileSystem
{

    public interface IFile : IFileSystemObject
    {



    }

    public interface IFile<T> : IFileSystemObject<T>, IFile where T : IFileSystemObject
    {
    }
}

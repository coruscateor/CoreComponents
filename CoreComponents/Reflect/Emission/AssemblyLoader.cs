using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Security;

namespace CoreComponents.Reflect
{

    public class AssemblyLoader
    {

        protected Assembly myAssembly;

        protected object mySource;

        protected Type mySourceType;

        protected AssemblyLoadMethod myLoadMethod = AssemblyLoadMethod.None;

        //public event Create<SourceAndMessageEventArgs<AssemblyLoader, string>>.ADelegate LoadedFromFile;

        //public event Create<SourceAndMessageEventArgs<AssemblyLoader, string>>.ADelegate LoadedFromAssemblyString;

        //public event Create<SourceEventArgs<AssemblyLoader, string>>.ADelegate LoadedFromAssemblyString;

        public event Create<MessageEventArgs<AssemblyLoader>>.ADelegate Loaded;

        public event Create<ErrorEventArgs<AssemblyLoader>>.ADelegate LoadedException;
        
        public event Create<ItemAndMessageEventArgs<AssemblyLoader, Assembly>>.ADelegate UnLoaded;
		/*
        public event Gimmie<GotEventArgs<AssemblyLoader, Type[]>>.GimmieSomethin GotTypes;

        public event Gimmie<GotEventArgs<AssemblyLoader, Module[]>>.GimmieSomethin GotModules;

        public event Gimmie<GotEventArgs<AssemblyLoader, Module[]>>.GimmieSomethin GotAllModules;
		*/
        //public event Gimmie<GotEventArgs<AssemblyLoader, object[]>>.GimmieSomethin GotCustomAttributes;

        //public event Gimmie<GotEventArgs<AssemblyLoader, string[]>>.GimmieSomethin GotManifestResourceNames;
		/*
        public event Gimmie<ExceptionEventArgs<AssemblyLoader, ArgumentException>>.GimmieSomethin WhenArgumentException;

        public event Gimmie<ExceptionEventArgs<AssemblyLoader, ArgumentNullException>>.GimmieSomethin WhenArgumentNullException;

        public event Gimmie<ExceptionEventArgs<AssemblyLoader, FileNotFoundException>>.GimmieSomethin WhenFileNotFoundException;

        public event Gimmie<ExceptionEventArgs<AssemblyLoader, FileLoadException>>.GimmieSomethin WhenFileLoadException;

        public event Gimmie<ExceptionEventArgs<AssemblyLoader, BadImageFormatException>>.GimmieSomethin WhenBadImageFormatException;

        public event Gimmie<ExceptionEventArgs<AssemblyLoader, ArgumentOutOfRangeException>>.GimmieSomethin WhenArgumentOutOfRangeException;

        public event Gimmie<ExceptionEventArgs<AssemblyLoader, SecurityException>>.GimmieSomethin WhenSecurityException;

        public event Gimmie<ExceptionEventArgs<AssemblyLoader, PathTooLongException>>.GimmieSomethin WhenPathTooLongException;

        public event Gimmie<ExceptionEventArgs<AssemblyLoader, Exception>>.GimmieSomethin WhenException;
		*/
			
        public AssemblyLoader()
        {
        }

        protected void OnLoaded()
        {

            string LoadedMessage;

            const string LoadedWith = "Assembly loaded ";

            switch (myLoadMethod)
            {
                case AssemblyLoadMethod.AssemblyName:

                    LoadedMessage = LoadedWith + "with AssemblyName: " + ((AssemblyName)mySource).FullName;

                    break;
                case AssemblyLoadMethod.AssemblyString:

                    LoadedMessage = LoadedWith + "with AssemblySring: " + (string)mySource;

                    break;
                case AssemblyLoadMethod.ByteArray:

                    LoadedMessage = LoadedWith + "from a ByteArray";

                    break;
                case AssemblyLoadMethod.File:

                    LoadedMessage = LoadedWith + "from file: " + (string)mySource;

                    break;
                case AssemblyLoadMethod.LongFormName:

                    LoadedMessage = LoadedWith + "from LongFormName: " + (string)mySource;

                    break;
                default:

                    LoadedMessage = "OOOPS!";

                    break;
            }

            if (Loaded != null)
                Loaded(new MessageEventArgs<AssemblyLoader>(this, LoadedMessage));

        }

        protected void OnLoadedException(Exception theException)
        {

            if (LoadedException != null)
                LoadedException(new ErrorEventArgs<AssemblyLoader>(this, theException));

        }

        protected void OnUnLoaded(Assembly theAssembly)
        {

            if (UnLoaded != null)
                UnLoaded(new ItemAndMessageEventArgs<AssemblyLoader, Assembly>(this, theAssembly, "Assembly " + theAssembly.FullName + " Unloaded"));

        }

        /*
        protected void OnLoadedFromFile(string theSource)
        {

            if (LoadedFromFile != null)
                LoadedFromFile(new SourceAndMessageEventArgs<AssemblyLoader, string>(this, theSource, "Assembly loaded from location: " + theSource));

        }

        protected void OnLoadedFromAssemblyString(string theSource)
        {

            if (LoadedFromAssemblyString != null)
                LoadedFromAssemblyString(new SourceAndMessageEventArgs<AssemblyLoader, string>(this, theSource, "Assembly loaded from AssemblyString: " + theSource));

        }
        */
        
		/*
        protected void OnGotTypes()
        {

            if (GotTypes != null)
                GotTypes(new GotEventArgs<AssemblyLoader, Type[]>(this, myAssembly.GetTypes()));

        }

        protected void OnGotModules()
        {

            if (GotModules != null)
                GotModules(new GotEventArgs<AssemblyLoader, Module[]>(this, myAssembly.GetModules()));

        }
		*/
		
        //Inclueds recource modules
        /*
        protected void OnGotAllModules()
        {

            if (GotAllModules != null)
                GotAllModules(new GotEventArgs<AssemblyLoader, Module[]>(this, myAssembly.GetModules(true)));

        }

        protected void OnGotManifestResourceNames()
        {

            if (GotManifestResourceNames != null)
                GotManifestResourceNames(new GotEventArgs<AssemblyLoader, string[]>(this, myAssembly.GetManifestResourceNames()));

        }

        protected void OnWhenArgumentException(ArgumentException e)
        {

            if(WhenArgumentException != null)
                WhenArgumentException(new ExceptionEventArgs<AssemblyLoader,ArgumentException>(this, e));

        }

        protected void OnWhenArgumentNullException(ArgumentNullException e)
        {

            if (WhenArgumentNullException != null)
                WhenArgumentNullException(new ExceptionEventArgs<AssemblyLoader, ArgumentNullException>(this, e));

        }

        protected void OnWhenFileNotFoundException(FileNotFoundException e)
        {

            if (WhenFileNotFoundException != null)
                WhenFileNotFoundException(new ExceptionEventArgs<AssemblyLoader, FileNotFoundException>(this, e));

        }

        protected void OnWhenFileLoadException(FileLoadException e)
        {

            if (WhenFileLoadException != null)
                WhenFileLoadException(new ExceptionEventArgs<AssemblyLoader, FileLoadException>(this, e));

        }

        protected void OnWhenArgumentOutOfRangeException(ArgumentOutOfRangeException e)
        {

            if (WhenArgumentOutOfRangeException != null)
                WhenArgumentOutOfRangeException(new ExceptionEventArgs<AssemblyLoader, ArgumentOutOfRangeException>(this, e));

        }

        protected void OnWhenSecurityException(SecurityException e)
        {

            if (WhenSecurityException != null)
                WhenSecurityException(new ExceptionEventArgs<AssemblyLoader, SecurityException>(this, e));

        }

        protected void OnWhenPathTooLongException(PathTooLongException e)
        {

            if (WhenPathTooLongException != null)
                WhenPathTooLongException(new ExceptionEventArgs<AssemblyLoader, PathTooLongException>(this, e));

        }

        protected void OnWhenException(Exception e)
        {

            if (WhenException != null)
                WhenException(new ExceptionEventArgs<AssemblyLoader, Exception>(this, e));

        }
		*/
        /*
        protected void OnGotCustomAttributes()
        {

            if (GotCustomAttributes != null)
                GotCustomAttributes(new GotEventArgs<AssemblyLoader, string[]>(this, myAssembly.GetCustomAttributes());

        }
        */

        public void LoadFile(string path)
        {

            //try
            //{

                myAssembly = Assembly.LoadFile(path);

               
            //} catch(Exception e)
            //{
            //}

                myLoadMethod = AssemblyLoadMethod.File;

                SetSourceType(path);

                OnLoaded();

                //OnLoadedFromFile(path);

                

        }

        public void LoadAssemblyString(string assemblyString)
        {

            myAssembly = Assembly.Load(assemblyString);

            myLoadMethod = AssemblyLoadMethod.AssemblyString;

            SetSourceType(assemblyString);

            OnLoaded();

            //LoadSucceeded();

        }

        /*
        protected void LoadSucceeded()
        {

            //myAssembly.ModuleResolve += new ModuleResolveEventHandler(myAssembly_ModuleResolve);

            //OnGotTypes();

            //OnGotModules();

            //OnGotAllModules();

            //OnGotManifestResourceNames();

        }
        */

        /*
        Module myAssembly_ModuleResolve(object sender, ResolveEventArgs e)
        {

            //e.;

        }
        */

        public Assembly LoadedAssembly
        {

            get
            {

                return myAssembly;

            }

        }

        public void UnLoad()
        {

            Assembly ToBeUnloaded = myAssembly;

            myAssembly = null;

            myLoadMethod = AssemblyLoadMethod.None;

            mySourceType = typeof(object);

            OnUnLoaded(ToBeUnloaded);

        }

        public bool HasLoadedAssembly
        {

            get
            {

                return Return.IsNotNull<Assembly>(myAssembly);

            }

        }

        public AssemblyLoadMethod LoadMethod 
        {

            get 
            {

                return myLoadMethod;

            }

        }

        public object Source 
        {

            get 
            {

                return mySource;

            }
        }

        public Type SourceType
        {

            get
            {

                return mySourceType;

            }
        }

        protected void SetSourceType(object TheSource) 
        {

            mySourceType = TheSource.GetType();

        }

    }

    
    public enum AssemblyLoadMethod
    {
        None,
        File,
        ByteArray,
        AssemblyName,
        AssemblyString,
        LongFormName

    }

}

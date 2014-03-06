using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CoreComponents.Reflect
{

    public static class AssemblyVersionInfoAsText
    {

        public static string GetAll(Assembly TheCurrentlyExecutingAssembly)
        {

            StringBuilder SB = new StringBuilder();

            Append(TheCurrentlyExecutingAssembly.GetName(), SB);

            foreach (AssemblyName ReferencedAssembly in TheCurrentlyExecutingAssembly.GetReferencedAssemblies())
            {

                Append(ReferencedAssembly, SB);

            }

            return SB.ToString();

        }

        public static string GetExecuting()
        {

            return GetAll(Assembly.GetExecutingAssembly());

        }

        public static string GetEntry()
        {

            return GetAll(Assembly.GetEntryAssembly());

        }

        public static string GetCalling()
        {

            return GetAll(Assembly.GetCallingAssembly());

        }

        static void Append(AssemblyName TheAssemblyName, StringBuilder TheSB)
        {

            TheSB.Append(TheAssemblyName.Name);

            TheSB.Append(": ");

            TheSB.AppendLine(TheAssemblyName.Version.ToString());

            TheSB.AppendLine();

        }

    }

}

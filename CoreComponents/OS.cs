using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{
    
    public static class OS
    {

        public static bool CheckIsMacOSX(OperatingSystem TheOS)
        {

            return TheOS.Platform == PlatformID.MacOSX;

        }

        public static bool CheckIsUnix(OperatingSystem TheOS)
        {

            return TheOS.Platform == PlatformID.Unix;

        }

        public static bool CheckIsWin32NT(OperatingSystem TheOS)
        {

            return TheOS.Platform == PlatformID.Win32NT;

        }

        public static bool CheckIsWin32S(OperatingSystem TheOS)
        {

            return TheOS.Platform == PlatformID.Win32S;

        }

        public static bool CheckIsWin32Windows(OperatingSystem TheOS)
        {

            return TheOS.Platform == PlatformID.Win32Windows;

        }

        public static bool CheckIsWinCE(OperatingSystem TheOS)
        {

            return TheOS.Platform == PlatformID.WinCE;

        }

        public static bool CheckIsWindows(OperatingSystem TheOS)
        {

            PlatformID Platform = TheOS.Platform;

            return Platform == PlatformID.Win32NT || Platform == PlatformID.Win32S || Platform == PlatformID.Win32Windows || Platform == PlatformID.WinCE;

        }

        public static bool CheckIsXbox(OperatingSystem TheOS)
        {

            return TheOS.Platform == PlatformID.Xbox;

        }

        public static bool CheckIsWindowsOrXbox(OperatingSystem TheOS)
        {

            PlatformID Platform = TheOS.Platform;

            return Platform == PlatformID.Win32NT || Platform == PlatformID.Win32S || Platform == PlatformID.Win32Windows || Platform == PlatformID.WinCE || Platform == PlatformID.Xbox;

        }

        public static bool IsMacOSX
        {

            get
            {

                return CheckIsMacOSX(Environment.OSVersion);

            }

        }

        public static bool IsUnix
        {

            get
            {

                return CheckIsUnix(Environment.OSVersion);

            }

        }

        public static bool IsWin32NT
        {

            get
            {

                return CheckIsWin32NT(Environment.OSVersion);

            }

        }

        public static bool IsWin32S
        {

            get
            {

                return CheckIsWin32S(Environment.OSVersion);

            }

        }

        public static bool IsWin32Windows
        {

            get
            {

                return CheckIsWin32Windows(Environment.OSVersion);

            }

        }

        public static bool IsWinCE
        {

            get
            {

                return CheckIsWinCE(Environment.OSVersion);

            }

        }

        public static bool IsWindows
        {

            get
            {

                return CheckIsWindows(Environment.OSVersion);

            }

        }

        public static bool IsXbox
        {

            get
            {

                return CheckIsXbox(Environment.OSVersion);

            }

        }

        public static bool IsWindowsOrXbox
        {

            get
            {

                return CheckIsWindowsOrXbox(Environment.OSVersion);

            }

        }

    }

}

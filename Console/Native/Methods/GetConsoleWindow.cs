// Copyright © 2018 Marc King <marc@marc.software> - All Rights Reserved
//
// SPDX-License-Identifier: MIT
//
// This work is licensed under the terms of the MIT license. See <LICENSE.md> for more information.

using System;
using System.Runtime.InteropServices;

namespace LastHarbor.Console.Native
{
    /// <summary>
    /// Interop methods to access native console functions.
    /// </summary>
    internal static partial class NativeMethods
    {
        /// <summary>
        /// Retrieves the window handle used by the console associated with the calling process.
        /// </summary>
        /// <returns>
        /// The return value is a handle to the window used by the console associated with the
        /// calling process or <c>NULL</c> if there is no such associated console.
        /// </returns>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/getconsolewindow"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "GetConsoleWindow",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        internal static extern IntPtr GetConsoleWindow();
    }
}

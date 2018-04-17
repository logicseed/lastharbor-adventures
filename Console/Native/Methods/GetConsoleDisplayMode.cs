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
        /// Retrieves the display mode of the current console.
        /// </summary>
        /// <param name="lpModeFlags">
        /// The display mode of the console.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <c>TRUE</c>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <c>FALSE</c>. To get extended error
        /// information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </para>
        /// </returns>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/getconsoledisplaymode"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "GetConsoleDisplayMode",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean GetConsoleDisplayMode(
            [param: In, Out, MarshalAs(UnmanagedType.I4)]
            ref CONSOLE_DISPLAY_MODE lpModeFlags
        );
    }
}

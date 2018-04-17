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
        /// Sets extended information about the current console font.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// A handle to the console screen buffer. The handle must have the <c>GENERIC_WRITE</c>
        /// access right.
        /// </param>
        /// <param name="bMaximumWindow">
        /// If this parameter is <c>TRUE</c>, font information is set for the maximum window size. If
        /// this parameter is <c>FALSE</c>, font information is set for the current window size.
        /// </param>
        /// <param name="lpConsoleCurrentFontEx">
        /// A pointer to a <see cref="CONSOLE_FONT_INFOEX"/> structure that contains the font
        /// information.
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
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/setcurrentconsolefontex"/>
        ///
        [DllImport("kernel32.dll", 
                   EntryPoint = "SetCurrentConsoleFontEx",
                   SetLastError = true, 
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern Boolean SetCurrentConsoleFontEx(
            [param: In]
            IntPtr hConsoleOutput,

            [param: In, MarshalAs(UnmanagedType.Bool)]
            Boolean bMaximumWindow,

            [param: In]
            ref CONSOLE_FONT_INFOEX lpConsoleCurrentFontEx
        );
    }
}

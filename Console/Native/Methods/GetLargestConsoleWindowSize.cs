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
        /// Retrieves the size of the largest possible console window, based on the current font and
        /// the size of the display.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// A handle to the console screen buffer.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a <see cref="COORD"/> structure that
        /// specifies the number of character cell rows ( <c>X</c> member) and columns ( <c>Y</c>
        /// member) in the largest possible console window. Otherwise, the members of the structure
        /// are zero.
        /// </para>
        /// <para>
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The function does not take into consideration the size of the console screen buffer,
        /// which means that the window size returned may be larger than the size of the console
        /// screen buffer. The <see cref="GetConsoleScreenBufferInfo"/> function can be used to
        /// determine the maximum size of the console window, given the current screen buffer size,
        /// the current font, and the display size.
        /// </remarks>
        /// <seealso cref="https://docs.microsoft.com/en-us/windows/console/getlargestconsolewindowsize"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "GetLargestConsoleWindowSize",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        internal static extern COORD GetLargestConsoleWindowSize(
            [param: In]
            IntPtr hConsoleOutput
        );
    }
}

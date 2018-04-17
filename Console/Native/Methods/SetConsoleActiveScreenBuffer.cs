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
        /// Sets the specified screen buffer to be the currently displayed console screen buffer.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// A handle to the console screen buffer.
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
        /// <remarks>
        /// A console can have multiple screen buffers. <c>SetConsoleActiveScreenBuffer</c>
        /// determines which one is displayed. You can write to an inactive screen buffer and then
        /// use <c>SetConsoleActiveScreenBuffer</c> to display the buffer's contents.
        /// </remarks>
        /// <seealso cref="https://docs.microsoft.com/en-us/windows/console/setconsoleactivescreenbuffer"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "SetConsoleActiveScreenBuffer",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern Boolean SetConsoleActiveScreenBuffer(
            [param: In]
            IntPtr hConsoleOutput
        );
    }
}

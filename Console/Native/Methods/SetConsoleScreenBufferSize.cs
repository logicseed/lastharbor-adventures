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
        /// Changes the size of the specified console screen buffer.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// A handle to the console screen buffer. The handle must have the <c>GENERIC_READ</c>
        /// access right.
        /// </param>
        /// <param name="dwSize">
        /// A <see cref="COORD"/> structure that specifies the new size of the console screen buffer,
        /// in character rows and columns. The specified width and height cannot be less than the
        /// width and height of the console screen buffer's window. The specified dimensions also
        /// cannot be less than the minimum size allowed by the system. This minimum depends on the
        /// current font size for the console (selected by the user) and the <c>SM_CXMIN</c> and
        /// <c>SM_CYMIN</c> values returned by the <see cref="GetSystemMetrics"/> function.
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
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/setconsolescreenbuffersize"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "SetConsoleScreenBufferSize",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern Boolean SetConsoleScreenBufferSize(
            [param: In]
            IntPtr hConsoleOutput,

            [param: In]
            COORD dwSize
        );
    }
}

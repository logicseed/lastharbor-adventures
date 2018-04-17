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
        /// Retrieves extended information about the specified console screen buffer.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// A handle to the console screen buffer. The handle must have the <c>GENERIC_READ</c>
        /// access right.
        /// </param>
        /// <param name="lpConsoleScreenBufferInfoEx">
        /// A <see cref="CONSOLE_SCREEN_BUFFER_INFOEX"/> structure that receives the requested
        /// console screen buffer information.
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
        /// <para>
        /// The rectangle returned in the <c>srWindow</c> member of the
        /// <see cref="CONSOLE_SCREEN_BUFFER_INFOEX"/> structure can be modified and then passed to
        /// the <see cref="SetConsoleWindowInfo"/> function to scroll the console screen buffer in
        /// the window, to change the size of the window, or both.
        /// </para>
        /// <para>
        /// All coordinates returned in the <c>CONSOLE_SCREEN_BUFFER_INFOEX</c> structure are in
        /// character-cell coordinates, where the origin (0, 0) is at the upper-left corner of the
        /// console screen buffer.
        /// </para>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/getconsolescreenbufferinfoex"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "GetConsoleScreenBufferInfoEx",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern Boolean GetConsoleScreenBufferInfoEx(
            [param: In]
            IntPtr hConsoleOutput,

            [param: In, Out]
            ref CONSOLE_SCREEN_BUFFER_INFOEX lpConsoleScreenBufferInfoEx
        );
    }
}

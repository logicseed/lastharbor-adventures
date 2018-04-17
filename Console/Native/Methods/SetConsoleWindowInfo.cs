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
        /// Sets the current size and position of a console screen buffer's window.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// A handle to the console screen buffer. The handle must have the <c>GENERIC_READ</c>
        /// access right.
        /// </param>
        /// <param name="bAbsolute">
        /// If this parameter is <c>TRUE</c>, the coordinates specify the new upper-left and
        /// lower-right corners of the window. If it is <c>FALSE</c>, the coordinates are relative to
        /// the current window-corner coordinates.
        /// </param>
        /// <param name="lpConsoleWindow">
        /// A pointer to a <see cref="SMALL_RECT"/> structure that specifies the new upper-left and
        /// lower-right corners of the window.
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
        /// The function fails if the specified window rectangle extends beyond the boundaries of the
        /// console screen buffer. This means that the <c>Top</c> and <c>Left</c> members of the
        /// <paramref name="lpConsoleWindow"/> rectangle (or the calculated top and left coordinates,
        /// if <paramref name="bAbsolute"/> is <c>FALSE</c>) cannot be less than zero. Similarly, the
        /// <c>Bottom</c> and <c>Right</c> members (or the calculated bottom and right coordinates)
        /// cannot be greater than (screen buffer height – 1) and (screen buffer width – 1),
        /// respectively. The function also fails if the <c>Right</c> member (or calculated right
        /// coordinate) is less than or equal to the <c>Left</c> member (or calculated left
        /// coordinate) or if the <c>Bottom</c> member (or calculated bottom coordinate) is less than
        ///             or equal to the <c>Top</c> member (or calculated top coordinate).
        /// </para>
        /// <para>
        /// For consoles with more than one screen buffer, changing the window location for one
        /// screen buffer does not affect the window locations of the other screen buffers.
        /// </para>
        /// <para>
        /// To determine the current size and position of a screen buffer's window, use the
        /// <see cref="GetConsoleScreenBufferInfo"/> function. This function also returns the maximum
        /// size of the window, given the current screen buffer size, the current font size, and the
        /// screen size. The <see cref="GetLargestConsoleWindowSize"/> function returns the maximum
        /// window size given the current font and screen sizes, but it does not consider the size of
        /// the console screen buffer.
        /// </para>
        /// <para>
        /// <c>SetConsoleWindowInfo</c> can be used to scroll the contents of the console screen
        /// buffer by shifting the position of the window rectangle without changing its size.
        /// </para>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/setconsolewindowinfo"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "SetConsoleWindowInfo",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern Boolean SetConsoleWindowInfo(
            [param: In]
            IntPtr hConsoleOutput,

            [param: In, MarshalAs(UnmanagedType.Bool)]
            Boolean bAbsolute,

            [param: In]
            ref SMALL_RECT lpConsoleWindow
        );
    }
}

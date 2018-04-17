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
        /// Sets the cursor position in the specified console screen buffer.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// A handle to the console screen buffer. The handle must have the <c>GENERIC_READ</c>
        /// access right.
        /// </param>
        /// <param name="dwCursorPosition">
        /// A <see cref="COORD"/> structure that specifies the new cursor position, in characters.
        /// The coordinates are the column and row of a screen buffer character cell. The coordinates
        /// must be within the boundaries of the console screen buffer.
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
        /// The cursor position determines where characters written by the <see cref="WriteFile"/> or
        /// <see cref="WriteConsole"/> function, or echoed by the <see cref="ReadFile"/> or
        /// <see cref="ReadConsole"/> function, are displayed. To determine the current position of
        /// the cursor, use the <see cref="GetConsoleScreenBufferInfo"/> function.
        /// </para>
        /// <para>
        /// If the new cursor position is not within the boundaries of the console screen buffer's
        /// window, the window origin changes to make the cursor visible.
        /// </para>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/setconsolecursorposition"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "SetConsoleCursorPosition",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern Boolean SetConsoleCursorPosition(
            [param: In]
            IntPtr hConsoleOutput,

            [param: In]
            COORD dwCursorPosition
        );
    }
}

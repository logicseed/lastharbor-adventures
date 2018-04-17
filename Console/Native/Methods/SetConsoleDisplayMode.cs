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
        /// Sets the display mode of the specified console screen buffer.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// A handle to the console screen buffer.
        /// </param>
        /// <param name="dwFlags">
        /// The display mode of the console.
        /// </param>
        /// <param name="lpNewScreenBufferDimensions">
        /// A pointer to a <see cref="COORD"/> structure that receives the new dimensions of the
        /// screen buffer, in characters.
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
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/setconsoledisplaymode"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "SetConsoleDisplayMode",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern Boolean SetConsoleDisplayMode(
            [param: In]
            IntPtr hConsoleOutput,

            [param: In, MarshalAs(UnmanagedType.I4)]
            CONSOLE_DISPLAY_MODE dwFlags,

            [param: In, Out, Optional]
            ref COORD lpNewScreenBufferDimensions
        );
    }
}

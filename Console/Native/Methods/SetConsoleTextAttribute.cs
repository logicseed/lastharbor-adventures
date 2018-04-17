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
        /// Sets the attributes of characters written to the console screen buffer by the
        /// <see cref="WriteFile"/> or <see cref="WriteConsole"/> function, or echoed by the
        /// <see cref="ReadFile"/> or <see cref="ReadConsole"/> function. This function affects text
        /// written after the function call.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// A handle to the console screen buffer. The handle must have the <c>GENERIC_READ</c>
        /// access right.
        /// </param>
        /// <param name="wAttributes">
        /// The character attributes.
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
        /// To determine the current color attributes of a screen buffer, call the
        /// <see cref="GetConsoleScreenBufferInfo"/> function.
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/setconsoletextattribute"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "SetConsoleTextAttribute",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern Boolean SetConsoleTextAttribute(
            [param: In]
            IntPtr hConsoleOutput,

            [param: In]
            CHAR_ATTR wAttributes
        );
    }
}

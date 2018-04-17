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
        /// Retrieves the size of the font used by the specified console screen buffer.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// A handle to the console screen buffer. The handle must have the <c>GENERIC_READ</c>
        /// access right.
        /// </param>
        /// <param name="nFont">
        /// The index of the font whose size is to be retrieved. This index is obtained by calling
        /// the <see cref="GetCurrentConsoleFont"/> function.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a <see cref="COORD"/> structure that
        /// contains the width and height of each character in the font, in logical units. The
        /// <see cref="COORD.X"/> member contains the width, while the <see cref="COORD.Y"/> member
        /// contains the height.
        /// </para>
        /// <para>
        /// If the function fails, the width and the height are zero. To get extended error
        /// information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </para>
        /// </returns>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/getconsolefontsize"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "GetConsoleFontSize",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        internal static extern COORD GetConsoleFontSize(
            [param: In]
            IntPtr hConsoleOutput,

            [param: In]
            Int32 nFont
        );
    }
}

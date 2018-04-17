// Copyright © 2018 Marc King <marc@marc.software> - All Rights Reserved
//
// SPDX-License-Identifier: MIT
//
// This work is licensed under the terms of the MIT license. See <LICENSE.md> for more information.

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace LastHarbor.Console.Native
{
    /// <summary>
    /// Interop methods to access native console functions.
    /// </summary>
    internal static partial class NativeMethods
    {
        /// <summary>
        /// Retrieves the original title for the current console window.
        /// </summary>
        /// <param name="lpConsoleTitle">
        /// <para>
        /// A pointer to a buffer that receives a null-terminated string containing the original
        /// title.
        /// </para>
        /// <para>
        /// The storage for this buffer is allocated from a shared heap for the process that is 64 KB
        /// in size. The maximum size of the buffer will depend on heap usage.
        /// </para>
        /// </param>
        /// <param name="nSize">
        /// The size of the <paramref name="lpConsoleTitle"/> buffer, in characters.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the length of the string copied to the
        /// buffer, in characters.
        /// </para>
        /// <para>
        /// If the buffer is not large enough to store the title, the return value is zero and
        /// <see cref="Marshal.GetLastWin32Error"/> returns <c>ERROR_SUCCESS</c>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero and
        /// <see cref="Marshal.GetLastWin32Error"/> returns the error code.
        /// </para>
        /// </returns>
        /// <remarks>
        /// To set the title for a console window, use the <see cref="SetConsoleTitle"/> function. To
        /// retrieve the current title string, use the <see cref="GetConsoleTitle"/> function.
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/getconsoleoriginaltitle"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "GetConsoleOriginalTitleW",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.I4)]
        public static extern Int32 GetConsoleOriginalTitle(
            [param: In, Out, MarshalAs(UnmanagedType.LPWStr)]
            ref StringBuilder lpConsoleTitle,

            [param: In]
            Int32 nSize
        );
    }
}

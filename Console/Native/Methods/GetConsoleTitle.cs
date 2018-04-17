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
        /// Retrieves the title for the current console window.
        /// </summary>
        /// <param name="lpConsoleTitle">
        /// <para>
        /// A pointer to a buffer that receives a null-terminated string containing the title. If the
        /// buffer is too small to store the title, the function stores as many characters of the
        /// title as will fit in the buffer, ending with a null terminator.
        /// </para>
        /// <para>
        /// The storage for this buffer is allocated from a shared heap for the process that is 64 KB
        /// in size. The maximum size of the buffer will depend on heap usage.
        /// </para>
        /// </param>
        /// <param name="nSize">
        /// The size of the buffer pointed to by the <paramref name="lpConsoleTitle"/> parameter, in
        /// characters.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the length of the console window's title,
        /// in characters.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero and
        /// <see cref="Marshal.GetLastWin32Error"/> returns the error code.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To set the title for a console window, use the <see cref="SetConsoleTitle"/> function. To
        /// retrieve the original title string, use the <see cref="GetConsoleOriginalTitle"/>
        /// function.
        /// </para>
        /// <para>
        /// This function uses either Unicode characters or 8-bit characters from the console's
        /// current code page. The console's code page defaults initially to the system's OEM code
        /// page. To change the console's code page, use the <see cref="SetConsoleCP"/> or
        /// <see cref="SetConsoleOutputCP"/> functions.
        /// </para>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/getconsoletitle"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "GetConsoleTitleW",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.I4)]
        internal static extern Int32 GetConsoleTitle(
            [param: In, Out, MarshalAs(UnmanagedType.LPWStr)]
            ref StringBuilder lpConsoleTitle,

            [param: In]
            Int32 nSize
        );
    }
}

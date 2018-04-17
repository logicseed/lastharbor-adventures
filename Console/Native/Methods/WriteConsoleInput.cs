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
        /// Writes data directly to the console input buffer.
        /// </summary>
        /// <param name="hConsoleInput">
        /// A handle to the console input buffer. The handle must have the <c>GENERIC_WRITE</c>
        /// access right.
        /// </param>
        /// <param name="lpBuffer">
        /// <para>
        /// A pointer to an array of <see cref="INPUT_RECORD"/> structures that contain data to be
        /// written to the input buffer.
        /// </para>
        /// <para>
        /// The storage for this buffer is allocated from a shared heap for the process that is 64 KB
        /// in size. The maximum size of the buffer will depend on heap usage.
        /// </para>
        /// </param>
        /// <param name="nLength">
        /// The number of input records to be written.
        /// </param>
        /// <param name="lpNumberOfEventsWritten">
        /// A pointer to a variable that receives the number of input records actually written.
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
        /// <c>WriteConsoleInput</c> places input records into the input buffer behind any pending
        /// events in the buffer. The input buffer grows dynamically, if necessary, to hold as many
        /// events as are written.
        /// </para>
        /// <para>
        /// This function uses either Unicode characters or 8-bit characters from the console's
        /// current code page. The console's code page defaults initially to the system's OEM code
        /// page. To change the console's code page, use the <see cref="SetConsoleCP"/> or
        /// <see cref="SetConsoleOutputCP"/> functions.
        /// </para>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/writeconsoleinput"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "WriteConsoleInputW",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern Boolean WriteConsoleInput(
            [param: In]
            IntPtr hConsoleInput,

            [param: In]
            ref INPUT_RECORD[] lpBuffer,

            [param: In]
            Int32 nLength,

            [param: In, Out]
            ref Int32 lpNumberOfEventsWritten
        );
    }
}

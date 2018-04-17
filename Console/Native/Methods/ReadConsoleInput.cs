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
        /// Reads data from a console input buffer and removes it from the buffer.
        /// </summary>
        /// <param name="hConsoleInput">
        /// A handle to the console input buffer. The handle must have the <c>GENERIC_READ</c> access
        /// right.
        /// </param>
        /// <param name="lpBuffer">
        /// <para>
        /// A pointer to an array of <see cref="INPUT_RECORD"/> structures that receives the input
        /// buffer data.
        /// </para>
        /// <para>
        /// The storage for this buffer is allocated from a shared heap for the process that is 64 KB
        /// in size. The maximum size of the buffer will depend on heap usage.
        /// </para>
        /// </param>
        /// <param name="nLength">
        /// The size of the array pointed to by the <paramref name="lpBuffer"/> parameter, in array
        /// elements.
        /// </param>
        /// <param name="lpNumberOfEventsRead">
        /// A pointer to a variable that receives the number of input records read.
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
        /// If the number of records requested in the <paramref name="nLength"/> parameter exceeds
        /// the number of records available in the buffer, the number available is read. The function
        /// does not return until at least one input record has been read.
        /// </para>
        /// <para>
        /// A process can specify a console input buffer handle in one of the wait functions to
        /// determine when there is unread console input. When the input buffer is not empty, the
        /// state of a console input buffer handle is signaled.
        /// </para>
        /// <para>
        /// To determine the number of unread input records in a console's input buffer, use the
        /// <see cref="GetNumberOfConsoleInputEvents"/> function. To read input records from a
        /// console input buffer without affecting the number of unread records, use the
        /// <see cref="PeekConsoleInput"/> function. To discard all unread records in a console's
        /// input buffer, use the <see cref="FlushConsoleInputBuffer"/> function.
        /// </para>
        /// <para>
        /// This function uses either Unicode characters or 8-bit characters from the console's
        /// current code page. The console's code page defaults initially to the system's OEM code
        /// page. To change the console's code page, use the <see cref="SetConsoleCP"/> or
        /// <see cref="SetConsoleOutputCP"/> functions.
        /// </para>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/readconsoleinput"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "ReadConsoleInputW",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern Boolean ReadConsoleInput(
            [param: In]
            IntPtr hConsoleInput,

            [param: In, Out, MarshalAs(UnmanagedType.LPArray)]
            ref INPUT_RECORD[] lpBuffer,

            [param: In]
            Int32 nLength,

            [param: In, Out]
            ref Int32 lpNumberOfEventsRead
        );
    }
}

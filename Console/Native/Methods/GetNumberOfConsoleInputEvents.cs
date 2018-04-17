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
        /// Retrieves the number of unread input records in the console's input buffer.
        /// </summary>
        /// <param name="hConsoleInput">
        /// A handle to the console input buffer. The handle must have the <c>GENERIC_READ</c> access
        /// right.
        /// </param>
        /// <param name="lpcNumberOfEvents">
        /// A pointer to a variable that receives the number of unread input records in the console's
        /// input buffer.
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
        /// The <c>GetNumberOfConsoleInputEvents</c> function reports the total number of unread
        /// input records in the input buffer, including keyboard, mouse, and window-resizing input
        /// records. Processes using the <see cref="ReadFile"/> or <see cref="ReadConsole"/> function
        /// can only read keyboard input. Processes using the <see cref="ReadConsoleInput"/> function
        /// can read all types of input records.
        /// </para>
        /// <para>
        /// A process can specify a console input buffer handle in one of the wait functions to
        /// determine when there is unread console input. When the input buffer is not empty, the
        /// state of a console input buffer handle is signaled.
        /// </para>
        /// <para>
        /// To read input records from a console input buffer without affecting the number of unread
        /// records, use the <see cref="PeekConsoleInput"/> function. To discard all unread records
        /// in a console's input buffer, use the <see cref="FlushConsoleInputBuffer"/> function.
        /// </para>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/getnumberofconsoleinputevents"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "GetNumberOfConsoleInputEvents",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern Boolean GetNumberOfConsoleInputEvents(
            [param: In]
            IntPtr hConsoleInput,

            [param: In, Out]
            ref Int32 lpcNumberOfEvents
        );
    }
}

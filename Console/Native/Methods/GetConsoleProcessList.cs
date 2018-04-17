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
        /// Retrieves a list of the processes attached to the current console.
        /// </summary>
        /// <param name="lpdwProcessList">
        /// <para>
        /// A pointer to a buffer that receives an array of process identifiers upon success.
        /// </para>
        /// <para>
        /// The storage for this buffer is allocated from a shared heap for the process that is 64 KB
        /// in size. The maximum size of the buffer will depend on heap usage.
        /// </para>
        /// </param>
        /// <param name="dwProcessCount">
        /// The maximum number of process identifiers that can be stored in the
        /// <paramref name="lpdwProcessList"/> buffer.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is less than or equal to
        /// <paramref name="dwProcessCount"/> and represents the number of process identifiers stored
        /// in the <paramref name="lpdwProcessList"/> buffer.
        /// </para>
        /// <para>
        /// If the buffer is too small to hold all the valid process identifiers, the return value is
        /// the required number of array elements. The function will have stored no identifiers in
        /// the buffer. In this situation, use the return value to allocate a buffer that is large
        /// enough to store the entire list and call the function again.
        /// </para>
        /// <para>
        /// If the return value is zero, the function has failed, because every console has at least
        /// one process associated with it. To get extended error information, call
        /// <see cref="Marshal.GetLastWin32Error"/>.
        /// </para>
        /// </returns>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/getconsoleprocesslist"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "GetConsoleProcessList",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.I4)]
        public static extern Int32 GetConsoleProcessList(
            [param: In, Out, MarshalAs(UnmanagedType.LPArray)]
            ref Int32[] lpdwProcessList,

            [param: In]
            Int32 dwProcessCount
        );
    }
}

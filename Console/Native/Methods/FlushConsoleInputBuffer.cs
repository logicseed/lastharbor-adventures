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
        /// Flushes the console input buffer. All input records currently in the input buffer are
        /// discarded.
        /// </summary>
        /// <param name="hConsoleInput">
        /// A handle to the console input buffer. The handle must have the <c>GENERIC_WRITE</c>
        /// access right.
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
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/flushconsoleinputbuffer"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "FlushConsoleInputBuffer",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean FlushConsoleInputBuffer(
            [param: In]
            IntPtr hConsoleInput
        );
    }
}

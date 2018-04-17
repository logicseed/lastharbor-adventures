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
        /// Sets the handle for the specified standard device (standard input, standard output, or
        /// standard error).
        /// </summary>
        /// <param name="nStdHandle">
        /// The standard device for which the handle is to be set.
        /// </param>
        /// <param name="hHandle">
        /// The handle for the standard device.
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
        /// The standard handles of a process may have been redirected by a call to
        /// <c>SetStdHandle</c>, in which case <see cref="GetStdHandle"/> will return the redirected
        /// handle. If the standard handles have been redirected, you can specify the <c>CONIN$</c>
        /// value in a call to the <see cref="CreateFile"/> function to get a handle to a console's
        /// input buffer. Similarly, you can specify the <c>CONOUT$</c> value to get a handle to the
        /// console's active screen buffer.
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/setstdhandle"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "SetStdHandle",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern Boolean SetStdHandle(
            [param: In]
            STD_HANDLE_TYPE nStdHandle,

            [param: In]
            IntPtr hHandle
        );
    }
}

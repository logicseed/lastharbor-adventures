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
        /// Detaches the calling process from its console.
        /// </summary>
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
        /// A process can be attached to at most one console. If the calling process is not already
        /// attached to a console, the error code returned is <c>ERROR_INVALID_PARAMETER</c> (87).
        /// </para>
        /// <para>
        /// A process can use the <b>FreeConsole</b> function to detach itself from its console. If
        /// other processes share the console, the console is not destroyed, but the process that
        /// called <b>FreeConsole</b> cannot refer to it. A console is closed when the last process
        /// attached to it terminates or calls <b>FreeConsole</b>. After a process calls
        /// <b>FreeConsole</b>, it can call the <see cref="AllocConsole"/> function to create a new
        /// console or <see cref="AttachConsole"/> to attach to another console.
        /// </para>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/freeconsole"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "FreeConsole",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean FreeConsole();
    }
}

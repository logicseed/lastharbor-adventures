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
        /// Attaches the calling process to the console of the specified process.
        /// </summary>
        /// <param name="dwProcessId">
        /// The identifier of the process whose console is to be used. This parameter can be one of
        /// the following values.
        /// <list type="table">
        /// <listheader>
        /// <term>Value</term>
        /// <description>Meaning</description>
        /// </listheader>
        /// <item>
        /// <term><i>pid</i></term>
        /// <description>Use the console of the specified process.</description>
        /// </item>
        /// <item>
        /// <term><b>ATTACH_PARENT_PROCESS</b> -1</term>
        /// <description>Use the console of the parent of the current process.</description>
        /// </item>
        /// </list>
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
        /// A process can be attached to at most one console. If the calling process is already
        /// attached to a console, the error code returned is <b>ERROR_ACCESS_DENIED</b> (5). If the
        /// specified process does not have a console, the error code returned is
        /// <b>ERROR_INVALID_HANDLE</b> (6). If the specified process does not exist, the error code
        /// returned is <b>ERROR_INVALID_PARAMETER</b> (87).
        /// </para>
        /// <para>
        /// A process can use the <see cref="FreeConsole"/> function to detach itself from its
        /// console. If other processes share the console, the console is not destroyed, but the
        /// process that called <b>FreeConsole</b> cannot refer to it. A console is closed when the
        /// last process attached to it terminates or calls <b>FreeConsole</b>. After a process calls
        /// <b>FreeConsole</b>, it can call the <see cref="AllocConsole"/> function to create a new
        /// console or <b>AttachConsole</b> to attach to another console.
        /// </para>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/attachconsole"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "AttachConsole",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean AttachConsole(
            [param: In]
            Int32 dwProcessId
        );
    }
}

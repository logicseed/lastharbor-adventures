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
        /// Sends a specified signal to a console process group that shares the console associated
        /// with the calling process.
        /// </summary>
        /// <param name="dwCtrlEvent">
        /// The type of signal to be generated. This parameter can be one of the following values.
        /// <list type="table">
        /// <listheader>
        /// <term>Value</term>
        /// <description>Meaning</description>
        /// </listheader>
        /// <item>
        /// <term><see cref="CTRL_TYPE.CTRL_C_EVENT"/></term>
        /// <description>
        /// Generates a CTRL+C signal. This signal cannot be generated for process groups. If
        /// <paramref name="dwProcessGroupId"/> is nonzero, this function will succeed, but the
        /// CTRL+C signal will not be received by processes within the specified process group.
        /// </description>
        /// </item>
        /// <item>
        /// <term><see cref="CTRL_TYPE.CTRL_BREAK_EVENT"/></term>
        /// <description>Generates a CTRL+BREAK signal.</description>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="dwProcessGroupId">
        /// <para>
        /// The identifier of the process group to receive the signal. A process group is created
        /// when the <c>CREATE_NEW_PROCESS_GROUP</c> flag is specified in a call to the
        /// <see cref="CreateProcess"/> function. The process identifier of the new process is also
        /// the process group identifier of a new process group. The process group includes all
        /// processes that are descendants of the root process. Only those processes in the group
        /// that share the same console as the calling process receive the signal. In other words, if
        /// a process in the group creates a new console, that process does not receive the signal,
        /// nor do its descendants.
        /// </para>
        /// <para>
        /// If this parameter is zero, the signal is generated in all processes that share the
        /// console of the calling process.
        /// </para>
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
        /// <b>GenerateConsoleCtrlEvent</b> causes the control handler functions of processes in the
        /// target group to be called. All console processes have a default handler function that
        /// calls the <see cref="ExitProcess"/> function. A console process can use the
        /// <see cref="SetConsoleCtrlHandler"/> function to install or remove other handler
        /// functions.
        /// </para>
        /// <para>
        /// <b>SetConsoleCtrlHandler</b> can also enable an inheritable attribute that causes the
        /// calling process to ignore CTRL+C signals. If <b>GenerateConsoleCtrlEvent</b> sends a
        /// CTRL+C signal to a process for which this attribute is enabled, the handler functions for
        /// that process are not called. CTRL+BREAK signals always cause the handler functions to be
        /// called.
        /// </para>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/generateconsolectrlevent"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "GenerateConsoleCtrlEvent",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean GenerateConsoleCtrlEvent(
            [param: In, MarshalAs(UnmanagedType.I4)]
            CTRL_TYPE dwCtrlEvent,

            [param: In]
            Int32 dwProcessGroupId
        );
    }
}

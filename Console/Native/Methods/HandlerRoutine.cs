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
        /// <para>
        /// An application-defined function used with the <see cref="SetConsoleCtrlHandler"/>
        /// function.
        /// </para>
        /// <para>
        /// A console process uses this function to handle control signals received by the process.
        /// When the signal is received, the system creates a new thread in the process to execute
        /// the function.
        /// </para>
        /// <para>
        /// The <c>PHANDLER_ROUTINE</c> type defines a pointer to this callback function.
        /// <c>HandlerRoutine</c> is a placeholder for the application-defined function name.
        /// </para>
        /// </summary>
        /// <param name="dwCtrlType">
        /// The type of control signal received by the handler.
        /// </param>
        /// <returns>
        /// If the function handles the control signal, it should return <c>TRUE</c>. If it returns
        /// <c>FALSE</c>, the next handler function in the list of handlers for this process is used.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Because the system creates a new thread in the process to execute the handler function,
        /// it is possible that the handler function will be terminated by another thread in the
        /// process. Be sure to synchronize threads in the process with the thread for the handler
        /// function.
        /// </para>
        /// <para>
        /// Each console process has its own list of <c>HandlerRoutine</c> functions. Initially, this
        /// list contains only a default handler function that calls <see cref="ExitProcess"/>. A
        /// console process adds or removes additional handler functions by calling the
        /// <see cref="SetConsoleCtrlHandler"/> function, which does not affect the list of handler
        /// functions for other processes. When a console process receives any of the control
        /// signals, its handler functions are called on a last-registered, first-called basis until
        /// one of the handlers returns TRUE. If none of the handlers returns <c>TRUE</c>, the
        /// default handler is called.
        /// </para>
        /// <para>
        /// The <c>CTRL_CLOSE_EVENT</c>, <c>CTRL_LOGOFF_EVENT</c>, and <c>CTRL_SHUTDOWN_EVENT</c>
        /// signals give the process an opportunity to clean up before termination. A
        /// <c>HandlerRoutine</c> can perform any necessary cleanup, then take one of the following
        /// actions:
        /// <list type="bullet">
        /// <item>
        /// <description>Call the <c>ExitProcess</c> function to terminate the process.</description>
        /// </item>
        /// <item>
        /// <description>
        /// Return <c>FALSE</c>. If none of the registered handler functions returns <c>TRUE</c>, the
        /// default handler terminates the process.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Return <c>TRUE</c>. In this case, no other handler functions are called and the system
        /// terminates the process.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// A process can use the <see cref="SetProcessShutdownParameters"/> function to prevent the
        /// system from displaying a dialog box to the user during logoff or shutdown. In this case,
        /// the system terminates the process when <c>HandlerRoutine</c> returns <c>TRUE</c> or when
        /// the time-out period elapses.
        /// </para>
        /// <para>
        /// When a console application is run as a service, it receives a modified default console
        /// control handler. This modified handler does not call <c>ExitProcess</c> when processing
        /// the <c>CTRL_LOGOFF_EVENT</c> and <c>CTRL_SHUTDOWN_EVENT</c> signals. This allows the
        /// service to continue running after the user logs off. If the service installs its own
        /// console control handler, this handler is called before the default handler. If the
        /// installed handler calls <c>ExitProcess</c> when processing the <c>CTRL_LOGOFF_EVENT</c>
        /// signal, the service exits when the user logs off.
        /// </para>
        /// <para>
        /// Note that a third-party library or DLL can install a console control handler for your
        /// application. If it does, this handler overrides the default handler, and can cause the
        /// application to exit when the user logs off.
        /// </para>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/handlerroutine"/>
        ///
        [return: MarshalAs(UnmanagedType.Bool)]
        public delegate Boolean HandlerRoutine(
            [param: In, MarshalAs(UnmanagedType.I4)]
            CTRL_TYPE dwCtrlType
        );
    }
}

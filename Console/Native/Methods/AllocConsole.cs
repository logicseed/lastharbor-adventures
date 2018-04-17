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
        /// Allocates a new console for the calling process.
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
        /// A process can be associated with only one console, so the <c>AllocConsole</c> function
        /// fails if the calling process already has a console. A process can use the
        /// <see cref="FreeConsole"/> function to detach itself from its current console, then it can
        /// call <c>AllocConsole</c> to create a new console or <see cref="AttachConsole"/> to attach
        /// to another console.
        /// </para>
        /// <para>
        /// If the calling process creates a child process, the child inherits the new console.
        /// </para>
        /// <para>
        /// <c>AllocConsole</c> initializes standard input, standard output, and standard error
        /// handles for the new console. The standard input handle is a handle to the console's input
        /// buffer, and the standard output and standard error handles are handles to the console's
        /// screen buffer. To retrieve these handles, use the <see cref="GetStdHandle"/> function.
        /// </para>
        /// <para>
        /// This function is primarily used by graphical user interface (GUI) application to create a
        /// console window. GUI applications are initialized without a console. Console applications
        /// are initialized with a console, unless they are created as detached processes (by calling
        /// the <c>CreateProcess</c> function with the <c>DETACHED_PROCESS</c> flag).
        /// </para>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/allocconsole"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "AllocConsole",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean AllocConsole();
    }
}

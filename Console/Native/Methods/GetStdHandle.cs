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
        /// Retrieves a handle to the specified standard device (standard input, standard output, or
        /// standard error).
        /// </summary>
        /// <param name="nStdHandle">
        /// The standard device.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the specified device, or a
        /// redirected handle set by a previous call to <see cref="SetStdHandle"/>. The handle has
        /// <c>GENERIC_READ</c> and <c>GENERIC_WRITE</c> access rights, unless the application has
        /// used <c>SetStdHandle</c> to set a standard handle with lesser access.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <c>INVALID_HANDLE_VALUE</c>. To get extended
        /// error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </para>
        /// <para>
        /// If an application does not have associated standard handles, such as a service running on
        /// an interactive desktop, and has not redirected them, the return value is <c>NULL</c>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Handles returned by <c>GetStdHandle</c> can be used by applications that need to read
        /// from or write to the console. When a console is created, the standard input handle is a
        /// handle to the console's input buffer, and the standard output and standard error handles
        /// are handles of the console's active screen buffer. These handles can be used by the
        /// <see cref="ReadFile"/> and <see cref="WriteFile"/> functions, or by any of the console
        /// functions that access the console input buffer or a screen buffer (for example, the
        /// <see cref="ReadConsoleInput"/>, <see cref="WriteConsole"/>, or
        /// <see cref="GetConsoleScreenBufferInfo"/> functions).
        /// </para>
        /// <para>
        /// The standard handles of a process may be redirected by a call to
        /// <see cref="SetStdHandle"/>, in which case <c>GetStdHandle</c> returns the redirected
        /// handle. If the standard handles have been redirected, you can specify the <c>CONIN$</c>
        /// value in a call to the <see cref="CreateFile"/> function to get a handle to a console's
        /// input buffer. Similarly, you can specify the <c>CONOUT$</c> value to get a handle to a
        /// console's active screen buffer.
        /// </para>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/getstdhandle"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "GetStdHandle",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        internal static extern IntPtr GetStdHandle(
            [param: In, MarshalAs(UnmanagedType.I4)]
            STD_HANDLE_TYPE nStdHandle
        );
    }
}

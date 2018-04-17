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
        /// Creates a console screen buffer.
        /// </summary>
        /// <param name="dwDesiredAccess">
        /// The access to the console screen buffer.
        /// </param>
        /// <param name="dwShareMode">
        /// The requested sharing mode of the file or device.
        /// </param>
        /// <param name="lpSecurityAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that determines whether the
        /// returned handle can be inherited by child processes. If
        /// <paramref name="lpSecurityAttributes"/> is <c>NULL</c>, the handle cannot be inherited.
        /// The <b>lpSecurityDescriptor</b> member of the structure specifies a security descriptor
        /// for the new console screen buffer. If <paramref name="lpSecurityAttributes"/> is
        /// <c>NULL</c>, the console screen buffer gets a default security descriptor. The ACLs in
        /// the default security descriptor for a console screen buffer come from the primary or
        /// impersonation token of the creator.
        /// </param>
        /// <param name="dwFlags">
        /// The type of console screen buffer to create. The only supported screen buffer type is
        /// <b>CONSOLE_TEXTMODE_BUFFER</b>.
        /// </param>
        /// <param name="lpScreenBufferData">
        /// Reserved; should be <c>NULL</c>.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the new console screen buffer.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="INVALID_HANDLE_VALUE"/>. To get
        /// extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// A console can have multiple screen buffers but only one active screen buffer. Inactive
        /// screen buffers can be accessed for reading and writing, but only the active screen buffer
        /// is displayed. To make the new screen buffer the active screen buffer, use the
        /// <see cref="SetConsoleActiveScreenBuffer"/> function.
        /// </para>
        /// <para>
        /// The calling process can use the returned handle in any function that requires a handle to
        /// a console screen buffer, subject to the limitations of access specified by the
        /// <paramref name="dwDesiredAccess"/> parameter.
        /// </para>
        /// <para>
        /// The calling process can use the <see cref="DuplicateHandle"/> function to create a
        /// duplicate screen buffer handle that has different access or inheritability from the
        /// original handle. However, <b>DuplicateHandle</b> cannot be used to create a duplicate
        /// that is valid for a different process (except through inheritance).
        /// </para>
        /// <para>
        /// To close the console screen buffer handle, use the <see cref="CloseHandle"/> function.
        /// </para>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/createconsolescreenbuffer"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "CreateConsoleScreenBuffer",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern IntPtr CreateConsoleScreenBuffer(
            [param: In, MarshalAs(UnmanagedType.I4)]
            ACCESS_MASK dwDesiredAccess,

            [param: In, MarshalAs(UnmanagedType.I4)]
            FILE_SHARE_MODE dwShareMode,

            [param: In, Optional]
            ref SECURITY_ATTRIBUTES lpSecurityAttributes,

            [param: In, MarshalAs(UnmanagedType.I4)]
            CONSOLE_SCREEN_BUFFER_MODE dwFlags,

            [param: In]
            IntPtr lpScreenBufferData
        );
    }
}

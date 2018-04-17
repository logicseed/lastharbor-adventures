// Copyright © 2018 Marc King <marc@marc.software> - All Rights Reserved
//
// SPDX-License-Identifier: MIT
//
// This work is licensed under the terms of the MIT license. See <LICENSE.md> for more information.

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace LastHarbor.Console.Native
{
    /// <summary>
    /// Interop methods to access native console functions.
    /// </summary>
    internal static partial class NativeMethods
    {
        /// <summary>
        /// Retrieves the names of all executable files with console aliases defined.
        /// </summary>
        /// <param name="lpExeNameBuffer">
        /// A pointer to a buffer that receives the names of the executable files.
        /// </param>
        /// <param name="ExeNameBufferLength">
        /// The size of the buffer pointed to by <paramref name="lpExeNameBuffer"/>, in bytes.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero. To get extended error information, call
        /// <see cref="Marshal.GetLastWin32Error"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// To determine the required size for the <paramref name="lpExeNameBuffer"/> buffer, use the
        /// <see cref="GetConsoleAliasExesLength"/> function.
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/getconsolealiasexes"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "GetConsoleAliasExesW",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.I4)]
        public static extern Int32 GetConsoleAliasExes(
            [param: In, Out, MarshalAs(UnmanagedType.LPWStr)]
            ref StringBuilder lpExeNameBuffer,

            [param: In]
            Int32 ExeNameBufferLength
        );
    }
}

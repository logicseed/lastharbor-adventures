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
        /// Retrieves all defined console aliases for the specified executable.
        /// </summary>
        /// <param name="lpAliasBuffer">
        /// <para>
        /// A pointer to a buffer that receives the aliases.
        /// </para>
        /// <para>
        /// The format of the data is as follows: <i>Source1=Target1\0Source2=Target2\0...
        /// SourceN=TargetN\0</i>, where <i>N</i> is the number of console aliases defined.
        /// </para>
        /// </param>
        /// <param name="AliasBufferLength">
        /// The size of the buffer pointed to by <paramref name="lpAliasBuffer"/>, in bytes.
        /// </param>
        /// <param name="lpExeName">
        /// The executable file whose aliases are to be retrieved.
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
        /// To determine the required size for the <paramref name="lpExeName"/> buffer, use the
        /// <see cref="GetConsoleAliasesLength"/> function.
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/getconsolealiases"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "GetConsoleAliasesW",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.I4)]
        public static extern Int32 GetConsoleAliases(
            [param: In, Out, MarshalAs(UnmanagedType.LPWStr)]
            ref StringBuilder lpAliasBuffer,

            [param: In]
            Int32 AliasBufferLength,

            [param: In, MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder lpExeName
        );
    }
}

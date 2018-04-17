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
        /// Retrieves the text for the specified console alias and executable.
        /// </summary>
        /// <param name="lpSource">
        /// The console alias whose text is to be retrieved.
        /// </param>
        /// <param name="lpTargetBuffer">
        /// A pointer to a buffer that receives the text associated with the console alias.
        /// </param>
        /// <param name="TargetBufferLength">
        /// The size of the buffer pointed to by <paramref name="lpTargetBuffer"/>, in bytes.
        /// </param>
        /// <param name="lpExeName">
        /// The name of the executable file.
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
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/getconsolealias"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "GetConsoleAliasW",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.I4)]
        public static extern Int32 GetConsoleAlias(
            [param: In, MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder lpSource,

            [param: In, Out, MarshalAs(UnmanagedType.LPWStr)]
            ref StringBuilder lpTargetBuffer,

            [param: In]
            Int32 TargetBufferLength,

            [param: In, MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder lpExeName
        );
    }
}

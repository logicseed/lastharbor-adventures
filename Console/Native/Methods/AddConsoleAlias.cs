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
        /// Defines a console alias for the specified executable.
        /// </summary>
        /// <param name="Source">
        /// The console alias to be mapped to the text specified by <paramref name="Target"/>.
        /// </param>
        /// <param name="Target">
        /// The text to be substituted for <paramref name="Source"/>. If this parameter is
        /// <c>NULL</c>, then the console alias is removed.
        /// </param>
        /// <param name="ExeName">
        /// The name of the executable file for which the console alias is to be defined.
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
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/addconsolealias"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "AddConsoleAliasW",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean AddConsoleAlias(
            [param: In, MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Source,

            [param: In, MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Target,

            [param: In, MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder ExeName
        );
    }
}

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
        /// Retrieves the required size for the buffer used by the <see cref="GetConsoleAliasExes"/>
        /// function.
        /// </summary>
        /// <returns>
        /// The size of the buffer required to store the names of all executable files that have
        /// console aliases defined, in bytes.
        /// </returns>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/getconsolealiasexeslength"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "GetConsoleAliasExesLengthW",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.I4)]
        public static extern Int32 GetConsoleAliasExesLength();
    }
}

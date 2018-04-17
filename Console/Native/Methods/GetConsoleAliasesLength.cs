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
        /// Retrieves the required size for the buffer used by the <see cref="GetConsoleAliases"/>
        /// function.
        /// </summary>
        /// <param name="lpExeName">
        /// The name of the executable file whose console aliases are to be retrieved.
        /// </param>
        /// <returns>
        /// The size of the buffer required to store all console aliases defined for this executable
        /// file, in bytes.
        /// </returns>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/getconsolealiaseslength"/>
        ///
        [DllImport("kernel32.dll", 
                   EntryPoint = "GetConsoleAliasesLengthW", 
                   SetLastError = true, 
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.I4)]
        public static extern Int32 GetConsoleAliasesLength(
            [param: In, MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder lpExeName
        );
    }
}

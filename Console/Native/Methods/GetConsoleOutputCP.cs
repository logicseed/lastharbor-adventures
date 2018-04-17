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
        /// Retrieves the output code page used by the console associated with the calling process.
        /// </para>
        /// <para>
        /// A console uses its output code page to translate the character values written by the
        /// various output functions into the images displayed in the console window.
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value is a code that identifies the code page.
        /// </returns>
        /// <remarks>
        /// <para>
        /// A code page maps 256 character codes to individual characters. Different code pages
        /// include different special characters, typically customized for a language or a group of
        /// languages. To retrieve more information about a code page, including it's name, see the
        /// <see cref="GetCPInfoEx"/> function.
        /// </para>
        /// <para>
        /// To set a console's output code page, use the <see cref="SetConsoleOutputCP"/> function.
        /// To set and query a console's input code page, use the <see cref="SetConsoleCP"/> and
        /// <see cref="GetConsoleCP"/> functions.
        /// </para>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/getconsoleoutputcp"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "GetConsoleOutputCP",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.I4)]
        public static extern Int32 GetConsoleOutputCP();
    }
}

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
        /// Sets the input code page used by the console associated with the calling process. A
        /// console uses its input code page to translate keyboard input into the corresponding
        /// character value.
        /// </summary>
        /// <param name="wCodePageID">
        /// The identifier of the code page to be set.
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
        /// <remarks>
        /// <para>
        /// A code page maps 256 character codes to individual characters. Different code pages
        /// include different special characters, typically customized for a language or a group of
        /// languages.
        /// </para>
        /// <para>
        /// To find the code pages that are installed or supported by the operating system, use the
        /// <see cref="EnumSystemCodePages"/> function. The identifiers of the code pages available
        /// on the local computer are also stored in the registry under the following key:
        /// </para>
        /// <para>
        /// <c>HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Nls\CodePage</c>
        /// </para>
        /// <para>
        /// However, it is better to use <c>EnumSystemCodePages</c> to enumerate code pages because
        /// the registry can differ in different versions of Windows.
        /// </para>
        /// <para>
        /// To determine whether a particular code page is valid, use the
        /// <see cref="IsValidCodePage"/> function. To retrieve more information about a code page,
        /// including its name, use the <see cref="GetCPInfoEx"/> function.
        /// </para>
        /// <para>
        /// To determine a console's current input code page, use the <see cref="GetConsoleCP"/>
        /// function. To set and retrieve a console's output code page, use the
        /// <see cref="SetConsoleOutputCP"/> and <see cref="GetConsoleOutputCP"/> functions.
        /// </para>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/setconsolecp"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "SetConsoleCP",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean SetConsoleCP(
            [param: In]
            Int32 wCodePageID
        );
    }
}

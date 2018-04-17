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
        /// Sets the output code page used by the console associated with the calling process.
        /// </para>
        /// <para>
        /// A console uses its output code page to translate the character values written by the
        /// various output functions into the images displayed in the console window.
        /// </para>
        /// </summary>
        /// <param name="wCodePageID">
        /// The identifier of the code page to set.
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
        /// If the current font is a fixed-pitch Unicode font, <c>SetConsoleOutputCP</c> changes the
        /// mapping of the character values into the glyph set of the font, rather than loading a
        /// separate font each time it is called. This affects how extended characters (ASCII value
        /// greater than 127) are displayed in a console window. However, if the current font is a
        /// raster font, <c>SetConsoleOutputCP</c> does not affect how extended characters are
        /// displayed.
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
        /// the registry can differ in different versions of Windows. To determine whether a
        /// particular code page is valid, use the <see cref="IsValidCodePage"/> function. To
        /// retrieve more information about a code page, including its name, use the
        /// <see cref="GetCPInfoEx"/> function.
        /// </para>
        /// <para>
        /// To determine a console's current output code page, use the
        /// <see cref="GetConsoleOutputCP"/> function. To set and retrieve a console's input code
        /// page, use the <see cref="SetConsoleCP"/> and <see cref="GetConsoleCP"/> functions.
        /// </para>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/setconsoleoutputcp"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "SetConsoleOutputCP",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean SetConsoleOutputCP(
            [param: In]
            Int32 wCodePageID
        );
    }
}

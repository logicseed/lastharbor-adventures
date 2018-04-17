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
        /// Writes a character to the console screen buffer a specified number of times, beginning at
        /// the specified coordinates.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// A handle to the console screen buffer. The handle must have the <c>GENERIC_WRITE</c>
        /// access right.
        /// </param>
        /// <param name="cCharacter">
        /// The character to be written to the console screen buffer.
        /// </param>
        /// <param name="nLength">
        /// The number of character cells to which the character should be written.
        /// </param>
        /// <param name="dwWriteCoord">
        /// A <see cref="COORD"/> structure that specifies the character coordinates of the first
        /// cell to which the character is to be written.
        /// </param>
        /// <param name="lpNumberOfCharsWritten">
        /// A pointer to a variable that receives the number of characters actually written to the
        /// console screen buffer.
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
        /// If the number of characters to write to extends beyond the end of the specified row in
        /// the console screen buffer, characters are written to the next row. If the number of
        /// characters to write to extends beyond the end of the console screen buffer, the
        /// characters are written up to the end of the console screen buffer.
        /// </para>
        /// <para>
        /// The attribute values at the positions written are not changed.
        /// </para>
        /// <para>
        /// This function uses either Unicode characters or 8-bit characters from the console's
        /// current code page. The console's code page defaults initially to the system's OEM code
        /// page. To change the console's code page, use the <see cref="SetConsoleCP"/> or
        /// <see cref="SetConsoleOutputCP"/> functions.
        /// </para>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/fillconsoleoutputcharacter"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "FillConsoleOutputCharacterW",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean FillConsoleOutputCharacter(
            [param: In]
            IntPtr hConsoleOutput,

            [param: In]
            Char cCharacter,

            [param: In]
            Int32 nLength,

            [param: In]
            COORD dwWriteCoord,

            [param: In, Out]
            ref Int32 lpNumberOfCharsWritten
        );
    }
}

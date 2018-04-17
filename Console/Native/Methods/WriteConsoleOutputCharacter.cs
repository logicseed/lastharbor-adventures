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
        /// Copies a number of characters to consecutive cells of a console screen buffer, beginning
        /// at a specified location.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// A handle to the console screen buffer. The handle must have the <c>GENERIC_WRITE</c>
        /// access right.
        /// </param>
        /// <param name="lpCharacter">
        /// <para>
        /// The characters to be written to the console screen buffer.
        /// </para>
        /// <para>
        /// The storage for this buffer is allocated from a shared heap for the process that is 64 KB
        /// in size. The maximum size of the buffer will depend on heap usage.
        /// </para>
        /// </param>
        /// <param name="nLength">
        /// The number of characters to be written.
        /// </param>
        /// <param name="dwWriteCoord">
        /// A <see cref="COORD"/> structure that specifies the character coordinates of the first
        /// cell in the console screen buffer to which characters will be written.
        /// </param>
        /// <param name="lpNumberOfCharsWritten">
        /// A pointer to a variable that receives the number of characters actually written.
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
        /// If the number of characters to be written to extends beyond the end of the specified row
        /// in the console screen buffer, characters are written to the next row. If the number of
        /// characters to be written to extends beyond the end of the console screen buffer,
        /// characters are written up to the end of the console screen buffer.
        /// </para>
        /// <para>
        /// The attribute values at the positions written to are not changed.
        /// </para>
        /// <para>
        /// This function uses either Unicode characters or 8-bit characters from the console's
        /// current code page. The console's code page defaults initially to the system's OEM code
        /// page. To change the console's code page, use the <see cref="SetConsoleCP"/> or
        /// <see cref="SetConsoleOutputCP"/> functions.
        /// </para>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/writeconsoleoutputcharacter"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "WriteConsoleOutputCharacterW",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern Boolean WriteConsoleOutputCharacter(
            [param: In]
            IntPtr hConsoleOutput,

            [param: In, MarshalAs(UnmanagedType.LPWStr)]
            String lpCharacter,

            [param: In]
            Int32 nLength,

            [param: In]
            COORD dwWriteCoord,

            [param: In, Out]
            ref Int32 lpNumberOfCharsWritten
        );
    }
}

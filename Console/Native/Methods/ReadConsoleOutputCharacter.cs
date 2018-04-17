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
        /// Copies a number of characters from consecutive cells of a console screen buffer,
        /// beginning at a specified location.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// A handle to the console screen buffer. The handle must have the <c>GENERIC_READ</c>
        /// access right.
        /// </param>
        /// <param name="lpCharacter">
        /// <para>
        /// A pointer to a buffer that receives the characters read from the console screen buffer.
        /// </para>
        /// <para>
        /// The storage for this buffer is allocated from a shared heap for the process that is 64 KB
        /// in size. The maximum size of the buffer will depend on heap usage.
        /// </para>
        /// </param>
        /// <param name="nLength">
        /// The number of screen buffer character cells from which to read. The size of the buffer
        /// pointed to by the <paramref name="lpCharacter"/> parameter should be <c>nLength *
        /// sizeof(TCHAR)</c>.
        /// </param>
        /// <param name="dwReadCoord">
        /// The coordinates of the first cell in the console screen buffer from which to read, in
        /// characters. The <c>X</c> member of the <see cref="COORD"/> structure is the column, and
        /// the <c>Y</c> member is the row.
        /// </param>
        /// <param name="lpNumberOfCharsRead">
        /// A pointer to a variable that receives the number of characters actually read.
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
        /// If the number of characters to be read from extends beyond the end of the specified
        /// screen buffer row, characters are read from the next row. If the number of characters to
        /// be read from extends beyond the end of the console screen buffer, characters up to the
        /// end of the console screen buffer are read.
        /// </para>
        /// <para>
        /// This function uses either Unicode characters or 8-bit characters from the console's
        /// current code page. The console's code page defaults initially to the system's OEM code
        /// page. To change the console's code page, use the <see cref="SetConsoleCP"/> or
        /// <see cref="SetConsoleOutputCP"/> functions.
        /// </para>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/readconsoleoutputcharacter"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "ReadConsoleOutputCharacterW",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern Boolean ReadConsoleOutputCharacter(
            [param: In]
            IntPtr hConsoleOutput,

            [param: In, Out, MarshalAs(UnmanagedType.LPWStr)]
            ref StringBuilder lpCharacter,

            [param: In]
            Int32 nLength,

            [param: In]
            COORD dwReadCoord,

            [param: In, Out]
            ref Int32 lpNumberOfCharsRead
        );
    }
}

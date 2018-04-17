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
        /// Sets the character attributes for a specified number of character cells, beginning at the
        /// specified coordinates in a screen buffer.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// A handle to the console screen buffer. The handle must have the <c>GENERIC_WRITE</c>
        /// access right.
        /// </param>
        /// <param name="wAttribute">
        /// The attributes to use when writing to the console screen buffer.
        /// </param>
        /// <param name="nLength">
        /// The number of character cells to be set to the specified color attributes.
        /// </param>
        /// <param name="dwWriteCoord">
        /// A <see cref="COORD"/> structure that specifies the character coordinates of the first
        /// cell whose attributes are to be set.
        /// </param>
        /// <param name="lpNumberOfAttrsWritten">
        /// A pointer to a variable that receives the number of character cells whose attributes were
        /// actually set.
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
        /// If the number of character cells whose attributes are to be set extends beyond the end of
        /// the specified row in the console screen buffer, the cells of the next row are set. If the
        /// number of cells to write to extends beyond the end of the console screen buffer, the
        /// cells are written up to the end of the console screen buffer.
        /// </para>
        /// <para>
        /// The character values at the positions written to are not changed.
        /// </para>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/fillconsoleoutputattribute"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "FillConsoleOutputAttribute",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean FillConsoleOutputAttribute(
            [param: In]
            IntPtr hConsoleOutput,

            [param: In, MarshalAs(UnmanagedType.I2)]
            CHAR_ATTR wAttribute,

            [param: In]
            Int32 nLength,

            [param: In]
            COORD dwWriteCoord,

            [param: In, Out]
            ref Int32 lpNumberOfAttrsWritten
        );
    }
}

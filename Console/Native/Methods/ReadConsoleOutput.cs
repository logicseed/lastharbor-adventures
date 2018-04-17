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
        /// Reads character and color attribute data from a rectangular block of character cells in a
        /// console screen buffer, and the function writes the data to a rectangular block at a
        /// specified location in the destination buffer.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// A handle to the console screen buffer. The handle must have the <c>GENERIC_READ</c>
        /// access right.
        /// </param>
        /// <param name="lpBuffer">
        /// <para>
        /// A pointer to a destination buffer that receives the data read from the console screen
        /// buffer. This pointer is treated as the origin of a two-dimensional array of
        /// <see cref="CHAR_INFO"/> structures whose size is specified by the
        /// <paramref name="dwBufferSize"/> parameter.
        /// </para>
        /// <para>
        /// The storage for this buffer is allocated from a shared heap for the process that is 64 KB
        /// in size. The maximum size of the buffer will depend on heap usage.
        /// </para>
        /// </param>
        /// <param name="dwBufferSize">
        /// The size of the <paramref name="lpBuffer"/> parameter, in character cells. The <c>X</c>
        /// member of the <see cref="COORD"/> structure is the number of columns; the <c>Y</c> member
        /// is the number of rows.
        /// </param>
        /// <param name="dwBufferCoord">
        /// The coordinates of the upper-left cell in the <paramref name="lpBuffer"/> parameter that
        /// receives the data read from the console screen buffer. The <c>X</c> member of the
        /// <see cref="COORD"/> structure is the column, and the <c>Y</c> member is the row.
        /// </param>
        /// <param name="lpReadRegion">
        /// A pointer to a <see cref="SMALL_RECT"/> structure. On input, the structure members
        /// specify the upper-left and lower-right coordinates of the console screen buffer rectangle
        /// from which the function is to read. On output, the structure members specify the actual
        /// rectangle that was used.
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
        /// <c>ReadConsoleOutput</c> treats the console screen buffer and the destination buffer as
        /// two-dimensional arrays (columns and rows of character cells). The rectangle pointed to by
        /// the <paramref name="lpReadRegion"/> parameter specifies the size and location of the
        /// block to be read from the console screen buffer. A destination rectangle of the same size
        /// is located with its upper-left cell at the coordinates of the
        /// <paramref name="dwBufferCoord"/> parameter in the <paramref name="lpBuffer"/> array. Data
        /// read from the cells in the console screen buffer source rectangle is copied to the
        /// corresponding cells in the destination buffer. If the corresponding cell is outside the
        /// boundaries of the destination buffer rectangle (whose dimensions are specified by the
        /// <paramref name="dwBufferSize"/> parameter), the data is not copied.
        /// </para>
        /// <para>
        /// Cells in the destination buffer corresponding to coordinates that are not within the
        /// boundaries of the console screen buffer are left unchanged. In other words, these are the
        /// cells for which no screen buffer data is available to be read.
        /// </para>
        /// <para>
        /// Before <c>ReadConsoleOutput</c> returns, it sets the members of the structure pointed to
        /// by the <paramref name="lpReadRegion"/> parameter to the actual screen buffer rectangle
        /// whose cells were copied into the destination buffer. This rectangle reflects the cells in
        /// the source rectangle for which there existed a corresponding cell in the destination
        /// buffer, because <c>ReadConsoleOutput</c> clips the dimensions of the source rectangle to
        /// fit the boundaries of the console screen buffer.
        /// </para>
        /// <para>
        /// If the rectangle specified by <paramref name="lpReadRegion"/> lies completely outside the
        /// boundaries of the console screen buffer, or if the corresponding rectangle is positioned
        /// completely outside the boundaries of the destination buffer, no data is copied. In this
        /// case, the function returns with the members of the structure pointed to by the
        /// <paramref name="lpReadRegion"/> parameter set such that the <c>Right</c> member is less
        /// than the <c>Left</c>, or the <c>Bottom</c> member is less than the <c>Top</c>. To
        /// determine the size of the console screen buffer, use the
        /// <see cref="GetConsoleScreenBufferInfo"/> function.
        /// </para>
        /// <para>
        /// The <c>ReadConsoleOutput</c> function has no effect on the console screen buffer's cursor
        /// position. The contents of the console screen buffer are not changed by the function.
        /// </para>
        /// <para>
        /// This function uses either Unicode characters or 8-bit characters from the console's
        /// current code page. The console's code page defaults initially to the system's OEM code
        /// page. To change the console's code page, use the <see cref="SetConsoleCP"/> or
        /// <see cref="SetConsoleOutputCP"/> functions.
        /// </para>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/readconsoleoutput"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "ReadConsoleOutputW",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern Boolean ReadConsoleOutput(
            [param: In]
            IntPtr hConsoleOutput,

            [param: In, Out]
            ref CHAR_INFO[] lpBuffer,

            [param: In]
            COORD dwBufferSize,

            [param: In]
            COORD dwBufferCoord,

            [param: In, Out]
            ref SMALL_RECT lpReadRegion
        );
    }
}

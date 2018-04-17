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
        /// Writes character and color attribute data to a specified rectangular block of character
        /// cells in a console screen buffer. The data to be written is taken from a correspondingly
        /// sized rectangular block at a specified location in the source buffer.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// A handle to the console screen buffer. The handle must have the <c>GENERIC_WRITE</c>
        /// access right.
        /// </param>
        /// <param name="lpBuffer">
        /// <para>
        /// The data to be written to the console screen buffer. This pointer is treated as the
        /// origin of a two-dimensional array of <see cref="CHAR_INFO"/> structures whose size is
        /// specified by the <paramref name="dwBufferSize"/> parameter.
        /// </para>
        /// <para>
        /// The storage for this buffer is allocated from a shared heap for the process that is 64 KB
        /// in size. The maximum size of the buffer will depend on heap usage.
        /// </para>
        /// </param>
        /// <param name="dwBufferSize">
        /// The size of the buffer pointed to by the <paramref name="lpBuffer"/> parameter, in
        /// character cells. The <c>X</c> member of the <see cref="COORD"/> structure is the number
        /// of columns; the <c>Y</c> member is the number of rows.
        /// </param>
        /// <param name="dwBufferCoord">
        /// The coordinates of the upper-left cell in the buffer pointed to by the
        /// <paramref name="lpBuffer"/> parameter. The <c>X</c> member of the <see cref="COORD"/>
        /// structure is the column, and the <c>Y</c> member is the row.
        /// </param>
        /// <param name="lpWriteRegion">
        /// A pointer to a <see cref="SMALL_RECT"/> structure. On input, the structure members
        /// specify the upper-left and lower-right coordinates of the console screen buffer rectangle
        /// to write to. On output, the structure members specify the actual rectangle that was used.
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
        /// <c>WriteConsoleOutput</c> treats the source buffer and the destination screen buffer as
        /// two-dimensional arrays (columns and rows of character cells). The rectangle pointed to by
        /// the <paramref name="lpWriteRegion"/> parameter specifies the size and location of the
        /// block to be written to in the console screen buffer. A rectangle of the same size is
        /// located with its upper-left cell at the coordinates of the
        /// <paramref name="dwBufferCoord"/> parameter in the <paramref name="lpBuffer"/> array. Data
        /// from the cells that are in the intersection of this rectangle and the source buffer
        /// rectangle (whose dimensions are specified by the <paramref name="dwBufferSize"/>
        /// parameter) is written to the destination rectangle.
        /// </para>
        /// <para>
        /// Cells in the destination rectangle whose corresponding source location are outside the
        /// boundaries of the source buffer rectangle are left unaffected by the write operation. In
        /// other words, these are the cells for which no data is available to be written.
        /// </para>
        /// <para>
        /// Before <c>WriteConsoleOutput</c> returns, it sets the members of
        /// <paramref name="lpWriteRegion"/> to the actual screen buffer rectangle affected by the
        /// write operation. This rectangle reflects the cells in the destination rectangle for which
        /// there existed a corresponding cell in the source buffer, because
        /// <c>WriteConsoleOutput</c> clips the dimensions of the destination rectangle to the
        /// boundaries of the console screen buffer.
        /// </para>
        /// <para>
        /// If the rectangle specified by <paramref name="lpWriteRegion"/> lies completely outside
        /// the boundaries of the console screen buffer, or if the corresponding rectangle is
        /// positioned completely outside the boundaries of the source buffer, no data is written. In
        /// this case, the function returns with the members of the structure pointed to by the
        /// <paramref name="lpWriteRegion"/> parameter set such that the <c>Right</c> member is less
        /// than the <c>Left</c>, or the <c>Bottom</c> member is less than the <c>Top</c>. To
        /// determine the size of the console screen buffer, use the
        /// <see cref="GetConsoleScreenBufferInfo"/> function.
        /// </para>
        /// <para>
        /// <c>WriteConsoleOutput</c> has no effect on the cursor position.
        /// </para>
        /// <para>
        /// This function uses either Unicode characters or 8-bit characters from the console's
        /// current code page. The console's code page defaults initially to the system's OEM code
        /// page. To change the console's code page, use the <see cref="SetConsoleCP"/> or
        /// <see cref="SetConsoleOutputCP"/> functions.
        /// </para>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/writeconsoleoutput"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "WriteConsoleOutputW",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern Boolean WriteConsoleOutput(
            [param: In]
            IntPtr hConsoleOutput,

            [param: In]
            CHAR_INFO[] lpBuffer,

            [param: In]
            COORD dwBufferSize,

            [param: In]
            COORD dwBufferCoord,

            [param: In, Out]
            ref SMALL_RECT lpWriteRegion
        );
    }
}

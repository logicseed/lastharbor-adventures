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
        /// Moves a block of data in a screen buffer. The effects of the move can be limited by
        /// specifying a clipping rectangle, so the contents of the console screen buffer outside the
        /// clipping rectangle are unchanged.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// A handle to the console screen buffer. The handle must have the <c>GENERIC_READ</c>
        /// access right.
        /// </param>
        /// <param name="lpScrollRectangle">
        /// A pointer to a <see cref="SMALL_RECT"/> structure whose members specify the upper-left
        /// and lower-right coordinates of the console screen buffer rectangle to be moved.
        /// </param>
        /// <param name="lpClipRectangle">
        /// A pointer to a <see cref="SMALL_RECT"/> structure whose members specify the upper-left
        /// and lower-right coordinates of the console screen buffer rectangle that is affected by
        /// the scrolling. This pointer can be <c>NULL</c>.
        /// </param>
        /// <param name="dwDestinationOrigin">
        /// A <see cref="COORD"/> structure that specifies the upper-left corner of the new location
        /// of the <paramref name="lpScrollRectangle"/> contents, in characters.
        /// </param>
        /// <param name="lpFill">
        /// A pointer to a <see cref="CHAR_INFO"/> structure that specifies the character and color
        /// attributes to be used in filling the cells within the intersection of
        /// <paramref name="lpScrollRectangle"/> and <paramref name="lpClipRectangle"/> that were
        /// left empty as a result of the move.
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
        /// <c>ScrollConsoleScreenBuffer</c> copies the contents of a rectangular region of a screen
        /// buffer, specified by the <paramref name="lpScrollRectangle"/> parameter, to another area
        /// of the console screen buffer. The target rectangle has the same dimensions as the
        /// <paramref name="lpScrollRectangle"/> rectangle with its upper-left corner at the
        /// coordinates specified by the <paramref name="dwDestinationOrigin"/> parameter. Those
        /// parts of <paramref name="lpScrollRectangle"/> that do not overlap with the target
        /// rectangle are filled in with the character and color attributes specified by the
        /// <paramref name="lpFill"/> parameter.
        /// </para>
        /// <para>
        /// The clipping rectangle applies to changes made in both the
        /// <paramref name="lpScrollRectangle"/> rectangle and the target rectangle. For example, if
        /// the clipping rectangle does not include a region that would have been filled by the
        /// contents of <paramref name="lpFill"/>, the original contents of the region are left
        /// unchanged.
        /// </para>
        /// <para>
        /// If the scroll or target regions extend beyond the dimensions of the console screen
        /// buffer, they are clipped. For example, if <paramref name="lpScrollRectangle"/> is the
        /// region contained by (0,0) and (19,19) and <paramref name="dwDestinationOrigin"/> is
        /// (10,15), the target rectangle is the region contained by (10,15) and (29,34). However, if
        /// the console screen buffer is 50 characters wide and 30 characters high, the target
        /// rectangle is clipped to (10,15) and (29,29). Changes to the console screen buffer are
        /// also clipped according to <paramref name="lpClipRectangle"/>, if the parameter specifies
        /// a <see cref="SMALL_RECT"/> structure. If the clipping rectangle is specified as (0,0) and
        /// (49,19), only the changes that occur in that region of the console screen buffer are
        /// made.
        /// </para>
        /// <para>
        /// This function uses either Unicode characters or 8-bit characters from the console's
        /// current code page. The console's code page defaults initially to the system's OEM code
        /// page. To change the console's code page, use the <see cref="SetConsoleCP"/> or
        /// <see cref="SetConsoleOutputCP"/> functions.
        /// </para>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/scrollconsolescreenbuffer"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "ScrollConsoleScreenBufferW",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern Boolean ScrollConsoleScreenBuffer(
            [param: In]
            IntPtr hConsoleOutput,

            [param: In]
            ref SMALL_RECT lpScrollRectangle,

            [param: In, Optional]
            ref SMALL_RECT lpClipRectangle,

            [param: In]
            COORD dwDestinationOrigin,

            [param: In]
            ref CHAR_INFO lpFill
        );
    }
}

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
    /// Defines the coordinates of the upper left and lower right corners of a rectangle.
    /// </summary>
    /// <remarks>
    /// This structure is used by console functions to specify rectangular areas of console screen
    /// buffers, where the coordinates specify the rows and columns of screen-buffer character cells.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    internal struct SMALL_RECT
    {
        /// <summary>
        /// The x-coordinate of the upper left corner of the rectangle.
        /// </summary>
        public Int16 Left;

        /// <summary>
        /// The y-coordinate of the upper left corner of the rectangle.
        /// </summary>
        public Int16 Top;

        /// <summary>
        /// The x-coordinate of the lower right corner of the rectangle.
        /// </summary>
        public Int16 Right;

        /// <summary>
        /// The y-coordinate of the lower right corner of the rectangle.
        /// </summary>
        public Int16 Bottom;
    }
}

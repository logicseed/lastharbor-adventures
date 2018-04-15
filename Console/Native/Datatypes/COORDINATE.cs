// Copyright © 2018 Marc King <marc@marc.software> - All Rights Reserved
//
// SPDX-License-Identifier: MIT
//
// This work is licensed under the terms of the MIT license. See <LICENSE.md> for more information.

using System;
using System.Runtime.InteropServices;

namespace LastHarbor.Console.Native.Datatypes
{
    /// <summary>
    /// Defines the coordinates of a character cell in a console screen buffer.
    /// </summary>
    /// <remarks>
    /// The origin of the coordinate system (0,0) is at the top, left cell of the buffer.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    internal struct COORDINATE
    {
        /// <summary>
        /// The horizontal coordinate or column value. The units depend on the function call.
        /// </summary>
        public Int16 X;

        /// <summary>
        /// The vertical coordinate or row value. The units depend on the function call.
        /// </summary>
        public Int16 Y;
    }
}

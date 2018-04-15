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
    /// Contains information for a console font.
    /// </summary>
    /// <remarks>
    /// To obtain the size of the font, pass the font index to the GetConsoleFontSize function.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CONSOLE_FONT_INFO
    {
        /// <summary>
        /// The index of the font in the system's console font table.
        /// </summary>
        public Int32 Font;

        /// <summary>
        /// A <see cref="COORD"/> structure that contains the width and height of each character in
        /// the font, in logical units.
        /// </summary>
        /// <remarks>
        /// The <c>X</c> member contains the width, while the <c>Y</c> member contains the height.
        /// </remarks>
        public COORD FontSize;
    }
}

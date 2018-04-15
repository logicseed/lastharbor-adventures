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
    /// Contains information about the console cursor.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CONSOLE_CURSOR_INFO
    {
        /// <summary>
        /// The percentage of the character cell that is filled by the cursor. This value is between
        /// <c>1</c> and <c>100</c>.
        /// </summary>
        /// <remarks>
        /// The cursor appearance varies, ranging from completely filling the cell to showing up as a
        /// horizontal line at the bottom of the cell.
        /// </remarks>
        public Int32 Size;

        /// <summary>
        /// The visibility of the cursor. If the cursor is visible, this member is <c>TRUE</c>.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public Boolean Visible;
    }
}

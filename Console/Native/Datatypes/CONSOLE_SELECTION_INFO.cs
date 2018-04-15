// Copyright © 2018 Marc King <marc@marc.software> - All Rights Reserved
//
// SPDX-License-Identifier: MIT
//
// This work is licensed under the terms of the MIT license. See <LICENSE.md> for more information.

using System.Runtime.InteropServices;

namespace LastHarbor.Console.Native
{
    /// <summary>
    /// Contains information for a console selection.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CONSOLE_SELECTION_INFO
    {
        /// <summary>
        /// The selection indicator.
        /// </summary>
        [MarshalAs(UnmanagedType.I4)]
        public CONSOLE_SELECTION_FLAGS Flags;

        /// <summary>
        /// A <see cref="COORD"/> structure that specifies the selection anchor, in characters.
        /// </summary>
        public COORD SelectionAnchor;

        /// <summary>
        /// A <see cref="SMALL_RECT"/> structure that specifies the selection rectangle.
        /// </summary>
        public SMALL_RECT Selection;
    }
}

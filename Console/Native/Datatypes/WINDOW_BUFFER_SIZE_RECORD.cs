// Copyright © 2018 Marc King <marc@marc.software> - All Rights Reserved
//
// SPDX-License-Identifier: MIT
//
// This work is licensed under the terms of the MIT license. See <LICENSE.md> for more information.

using System.Runtime.InteropServices;

namespace LastHarbor.Console.Native
{
    /// <summary>
    /// Describes a change in the size of the console screen buffer.
    /// </summary>
    /// <remarks>
    /// Buffer size events are placed in the input buffer when the console is in window-aware mode
    /// (ENABLE_WINDOW_INPUT)
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    internal struct WINDOW_BUFFER_SIZE_RECORD
    {
        /// <summary>
        /// A <see cref="COORD"/> structure that contains the size of the console screen buffer, in
        /// character cell columns and rows.
        /// </summary>
        public COORD Size;
    }
}

// Copyright © 2018 Marc King <marc@marc.software> - All Rights Reserved
//
// SPDX-License-Identifier: MIT
//
// This work is licensed under the terms of the MIT license. See <LICENSE.md> for more information.

using System.Runtime.InteropServices;

namespace LastHarbor.Console.Native
{
    /// <summary>
    /// Contains information about a console screen buffer.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CONSOLE_SCREEN_BUFFER_INFO
    {
        /// <summary>
        /// A <see cref="COORD"/> structure that contains the size of the console screen buffer, in
        /// character columns and rows.
        /// </summary>
        public COORD Size;

        /// <summary>
        /// A <see cref="COORD"/> structure that contains the column and row coordinates of the
        /// cursor in the console screen buffer.
        /// </summary>
        public COORD CursorPosition;

        /// <summary>
        /// The attributes of the characters written to a screen buffer.
        /// </summary>
        [MarshalAs(UnmanagedType.I2)]
        public CHAR_ATTR Attributes;

        /// <summary>
        /// A <see cref="SMALL_RECT"/> structure that contains the console screen buffer coordinates
        /// of the upper-left and lower-right corners of the display window.
        /// </summary>
        public SMALL_RECT Window;

        /// <summary>
        /// A <see cref="COORD"/> structure that contains the maximum size of the console window, in
        /// character columns and rows, given the current screen buffer size and font and the screen
        /// size.
        /// </summary>
        public COORD MaximumWindowSize;
    }
}

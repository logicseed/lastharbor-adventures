// Copyright © 2018 Marc King <marc@marc.software> - All Rights Reserved
//
// SPDX-License-Identifier: MIT
//
// This work is licensed under the terms of the MIT license. See <LICENSE.md> for more information.

using System;

namespace LastHarbor.Console.Native.Datatypes
{
    /// <summary>
    /// The status of the mouse buttons.
    /// </summary>
    /// <remarks>
    /// The least significant bit corresponds to the leftmost mouse button. The next least
    /// significant bit corresponds to the rightmost mouse button. The next bit indicates the
    /// next-to-leftmost mouse button. The bits then correspond left to right to the mouse buttons. A
    /// bit is 1 if the button was pressed.
    /// </remarks>
    [Flags]
    internal enum MOUSE_BUTTON_STATE : Int32
    {
        /// <summary>
        /// The leftmost mouse button.
        /// </summary>
        FROM_LEFT_1ST_BUTTON_PRESSED = 0x0001,

        /// <summary>
        /// The rightmost mouse button.
        /// </summary>
        RIGHTMOST_BUTTON_PRESSED = 0x0002,

        /// <summary>
        /// The second button from the left.
        /// </summary>
        FROM_LEFT_2ND_BUTTON_PRESSED = 0x0004,

        /// <summary>
        /// The third button from the left.
        /// </summary>
        FROM_LEFT_3RD_BUTTON_PRESSED = 0x0008,

        /// <summary>
        /// The fourth button from the left.
        /// </summary>
        FROM_LEFT_4TH_BUTTON_PRESSED = 0x0010,
    }
}

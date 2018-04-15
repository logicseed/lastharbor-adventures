// Copyright © 2018 Marc King <marc@marc.software> - All Rights Reserved
//
// SPDX-License-Identifier: MIT
//
// This work is licensed under the terms of the MIT license. See <LICENSE.md> for more information.

using System;

namespace LastHarbor.Console.Native.Datatypes
{
    /// <summary>
    /// The type of mouse event.
    /// </summary>
    [Flags]
    internal enum MOUSE_EVENT_FLAGS : Int32
    {
        /// <summary>
        /// A mouse button is being pressed.
        /// </summary>
        MOUSE_PRESS = 0x0000,

        /// <summary>
        /// A mouse button is being released.
        /// </summary>
        MOUSE_RELEASE = 0x0000,

        /// <summary>
        /// A change in mouse position occurred.
        /// </summary>
        MOUSE_MOVED = 0x0001,

        /// <summary>
        /// The second click (button press) of a double-click occurred.
        /// </summary>
        /// <remarks>The first click is returned as a regular button-press event.</remarks>
        DOUBLE_CLICK = 0x0002,

        /// <summary>
        /// The vertical mouse wheel was moved.
        /// </summary>
        /// <remarks>
        /// If the high word of the dwButtonState member contains a positive value, the wheel was
        /// rotated forward, away from the user. Otherwise, the wheel was rotated backward, toward
        /// the user.
        /// </remarks>
        MOUSE_WHEELED = 0x0004,

        /// <summary>
        /// The horizontal mouse wheel was moved.
        /// </summary>
        /// <remarks>
        /// If the high word of the dwButtonState member contains a positive value, the wheel was
        /// rotated to the right. Otherwise, the wheel was rotated to the left.
        /// </remarks>
        MOUSE_HWHEELED = 0x0008,
    }
}

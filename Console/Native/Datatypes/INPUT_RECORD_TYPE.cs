// Copyright © 2018 Marc King <marc@marc.software> - All Rights Reserved
//
// SPDX-License-Identifier: MIT
//
// This work is licensed under the terms of the MIT license. See <LICENSE.md> for more information.

using System;

namespace LastHarbor.Console.Native
{
    /// <summary>
    /// The type of input event.
    /// </summary>
    internal enum INPUT_RECORD_TYPE : Int16
    {
        /// <summary>
        /// The Event member contains a <see cref="KEY_EVENT_RECORD"/> structure with information
        /// about a keyboard event.
        /// </summary>
        KEY_EVENT = 0x0001,

        /// <summary>
        /// The Event member contains a <see cref="MOUSE_EVENT_RECORD"/> structure with information
        /// about a mouse movement or button press event.
        /// </summary>
        MOUSE_EVENT = 0x0002,

        /// <summary>
        /// The Event member contains a <see cref="WINDOW_BUFFER_SIZE_RECORD"/> structure with
        /// information about the new size of the console screen buffer.
        /// </summary>
        WINDOW_BUFFER_SIZE_EVENT = 0x0004,

        /// <summary>
        /// The Event member contains a <see cref="MENU_EVENT_RECORD"/> structure. These events are
        /// used internally and should be ignored.
        /// </summary>
        MENU_EVENT = 0x0008,

        /// <summary>
        /// The Event member contains a <see cref="FOCUS_EVENT_RECORD"/> structure. These events are
        /// used internally and should be ignored.
        /// </summary>
        FOCUS_EVENT = 0x0010,
    }
}

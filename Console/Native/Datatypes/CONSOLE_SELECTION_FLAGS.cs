// Copyright © 2018 Marc King <marc@marc.software> - All Rights Reserved
//
// SPDX-License-Identifier: MIT
//
// This work is licensed under the terms of the MIT license. See <LICENSE.md> for more information.

using System;

namespace LastHarbor.Console.Native
{
    /// <summary>
    /// The selection indicator.
    /// </summary>
    [Flags]
    internal enum CONSOLE_SELECTION_FLAGS : Int32
    {
        /// <summary>
        /// No selection.
        /// </summary>
        CONSOLE_NO_SELECTION = 0x0000,

        /// <summary>
        /// Selection has begun.
        /// </summary>
        CONSOLE_SELECTION_IN_PROGRESS = 0x0001,

        /// <summary>
        /// Selection rectangle is not empty.
        /// </summary>
        CONSOLE_SELECTION_NOT_EMPTY = 0x0002,

        /// <summary>
        /// Selecting with the mouse.
        /// </summary>
        CONSOLE_MOUSE_SELECTION = 0x0004,

        /// <summary>
        /// Mouse is down.
        /// </summary>
        CONSOLE_MOUSE_DOWN = 0x0008,
    }
}

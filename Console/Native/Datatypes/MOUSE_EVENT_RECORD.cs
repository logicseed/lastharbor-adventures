// Copyright © 2018 Marc King <marc@marc.software> - All Rights Reserved
//
// SPDX-License-Identifier: MIT
//
// This work is licensed under the terms of the MIT license. See <LICENSE.md> for more information.

using System.Runtime.InteropServices;

namespace LastHarbor.Console.Native
{
    /// <summary>
    /// Describes a mouse input event in a console <see cref="INPUT_RECORD"/> structure.
    /// </summary>
    /// <remarks>
    /// Mouse events are placed in the input buffer when the console is in mouse mode
    /// (ENABLE_MOUSE_INPUT).
    ///
    /// Mouse events are generated whenever the user moves the mouse, or presses or releases one of
    /// the mouse buttons. Mouse events are placed in a console's input buffer only when the console
    /// group has the keyboard focus and the cursor is within the borders of the console's window.
    /// </remarks>
    /// <example>
    /// For an example, see Reading Input Buffer Events.
    /// https://docs.microsoft.com/en-us/windows/console/reading-input-buffer-events
    /// </example>
    [StructLayout(LayoutKind.Sequential)]
    internal struct MOUSE_EVENT_RECORD
    {
        /// <summary>
        /// A COORD structure that contains the location of the cursor, in terms of the console
        /// screen buffer's character-cell coordinates.
        /// </summary>
        public COORD MousePosition;

        /// <summary>
        /// The status of the mouse buttons.
        /// </summary>
        [MarshalAs(UnmanagedType.I4)]
        public MOUSE_BUTTON_STATE ButtonState;

        /// <summary>
        /// The state of the control keys.
        /// </summary>
        [MarshalAs(UnmanagedType.I4)]
        public CONTROL_KEY_STATE ControlKeyState;

        /// <summary>
        /// The type of mouse event.
        /// </summary>
        [MarshalAs(UnmanagedType.I4)]
        public MOUSE_EVENT_FLAGS EventFlags;
    }
}

// Copyright © 2018 Marc King <marc@marc.software> - All Rights Reserved
//
// SPDX-License-Identifier: MIT
//
// This work is licensed under the terms of the MIT license. See <LICENSE.md> for more information.

using System.Runtime.InteropServices;

namespace LastHarbor.Console.Native
{
    /// <summary>
    /// Describes an input event in the console input buffer.
    /// </summary>
    /// <remarks>
    /// These records can be read from the input buffer by using the ReadConsoleInput or
    /// PeekConsoleInput function, or written to the input buffer by using the WriteConsoleInput
    /// function.
    /// </remarks>
    /// <example>
    /// For an example, see Reading Input Buffer Events.
    /// https://docs.microsoft.com/en-us/windows/console/reading-input-buffer-events
    /// </example>
    [StructLayout(LayoutKind.Explicit)]
    internal struct INPUT_RECORD
    {
        /// <summary>
        /// A handle to the type of input event and the event record stored in the Event member.
        /// </summary>
        [FieldOffset(0), MarshalAs(UnmanagedType.I2)]
        public INPUT_RECORD_TYPE EventType;

        /// <summary>
        /// Describes a keyboard input event in a console <see cref="INPUT_RECORD"/> structure.
        /// </summary>
        [FieldOffset(2)]
        public KEY_EVENT_RECORD KeyEvent;

        /// <summary>
        /// Describes a mouse input event in a console <see cref="INPUT_RECORD"/> structure.
        /// </summary>
        [FieldOffset(2)]
        public MOUSE_EVENT_RECORD MouseEvent;

        /// <summary>
        /// Describes a window buffer size event in a console <see cref="INPUT_RECORD"/> structure.
        /// </summary>
        [FieldOffset(2)]
        public WINDOW_BUFFER_SIZE_RECORD WindowBufferSizeEvent;

        /// <summary>
        /// Describes a menu event in a console <see cref="INPUT_RECORD"/> structure.
        /// </summary>
        [FieldOffset(2)]
        public MENU_EVENT_RECORD MenuEvent;

        /// <summary>
        /// Describes a focus event in a console <see cref="INPUT_RECORD"/> structure.
        /// </summary>
        [FieldOffset(2)]
        public FOCUS_EVENT_RECORD FocusEvent;
    }
}

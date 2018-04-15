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
    /// Contains information for a console read operation.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CONSOLE_READCONSOLE_CONTROL
    {
        /// <summary>
        /// The size of the structure.
        /// </summary>
        /// <remarks>Set this member to <c>sizeof(CONSOLE_READCONSOLE_CONTROL)</c>.</remarks>
        public Int32 Length;

        /// <summary>
        /// The number of characters to skip (and thus preserve) before writing newly read input in
        /// the buffer passed to the ReadConsole function.
        /// </summary>
        /// <remarks>
        /// This value must be less than the numberOfCharsToRead parameter of the ReadConsole
        /// function.
        /// </remarks>
        public Int32 InitialChars;

        /// <summary>
        /// A user-defined control character used to signal that the read is complete.
        /// </summary>
        public Int32 CtrlWakeupMask;

        /// <summary>
        /// The state of the control keys.
        /// </summary>
        [MarshalAs(UnmanagedType.I4)]
        public CONTROL_KEY_STATE ControlKeyState;
    }
}

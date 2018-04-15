// Copyright © 2018 Marc King <marc@marc.software> - All Rights Reserved
//
// SPDX-License-Identifier: MIT
//
// This work is licensed under the terms of the MIT license. See <LICENSE.md> for more information.

using System;
using System.Runtime.InteropServices;

namespace LastHarbor.Console.Native.Datatypes
{
    /// <summary>
    /// Describes a focus event in a console <see cref="INPUT_RECORD"/> structure. These events are
    /// used internally and should be ignored.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct FOCUS_EVENT_RECORD
    {
        /// <summary>
        /// Reserved.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public Boolean SetFocus;
    }
}

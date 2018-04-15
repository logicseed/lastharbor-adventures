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
    /// A union of the Unicode or Ascii character of a screen buffer character cell.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    internal struct CHAR_UNION
    {
        /// <summary>
        /// Unicode character of a screen buffer character cell.
        /// </summary>
        [FieldOffset(0), MarshalAs(UnmanagedType.I2)]
        public Char UnicodeChar;

        /// <summary>
        /// Ascii character of a screen buffer character cell.
        /// </summary>
        [FieldOffset(0)]
        public Byte AsciiChar;
    }
}

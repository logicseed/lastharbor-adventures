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
    /// Specifies a Unicode or Ascii character and its attributes.
    /// </summary>
    /// <remarks>
    /// This structure is used by console functions to read from and write to a console screen
    /// buffer.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CHAR_INFO
    {
        /// <summary>
        /// A union of the Unicode or Ascii character of a screen buffer character cell.
        /// </summary>
        public CHAR_UNION Char;

        /// <summary>
        /// The attributes to use when writing a character to the console screen buffer.
        /// </summary>
        public Int16 Attributes;
    }
}

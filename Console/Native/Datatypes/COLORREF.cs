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
    /// This value is a 32-bit value used to specify an RGB color.
    /// </summary>
    /// <remarks>
    /// When specifying an explicit RGB color, the Color value has the following hexadecimal form.
    ///
    /// 0x00bbggrr
    ///
    /// The low-order byte contains a value for the relative intensity of red, the second byte
    /// contains a value for green, and the third byte contains a value for blue. The high-order byte
    /// must be zero. The maximum value for a single byte is 0xFF.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    internal struct COLORREF
    {
        private const Int32 RED_MASK = 0x000000FF;
        private const Int32 GREEN_MASK = 0x0000FF00;
        private const Int32 BLUE_MASK = 0x00FF0000;

        /// <summary>
        /// Raw value of the <see cref="COLORREF"/>.
        /// </summary>
        public Int32 Value;
    }
}

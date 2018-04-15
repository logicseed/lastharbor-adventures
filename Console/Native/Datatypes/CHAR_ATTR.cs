// Copyright © 2018 Marc King <marc@marc.software> - All Rights Reserved
//
// SPDX-License-Identifier: MIT
//
// This work is licensed under the terms of the MIT license. See <LICENSE.md> for more information.

using System;

namespace LastHarbor.Console.Native
{
    /// <summary>
    /// The attributes to use when writing to the console screen buffer.
    /// </summary>
    [Flags]
    internal enum CHAR_ATTR : Int16
    {
        /// <summary>
        /// No character attributes.
        /// </summary>
        NONE = 0x0000,

        /// <summary>
        /// Text color contains blue.
        /// </summary>
        FOREGROUND_BLUE = 0x0001,

        /// <summary>
        /// Text color contains green.
        /// </summary>
        FOREGROUND_GREEN = 0x0002,

        /// <summary>
        /// Text color contains red.
        /// </summary>
        FOREGROUND_RED = 0x0004,

        /// <summary>
        /// Text color is intensified.
        /// </summary>
        FOREGROUND_INTENSITY = 0x0008,

        /// <summary>
        /// Background color contains blue.
        /// </summary>
        BACKGROUND_BLUE = 0x0010,

        /// <summary>
        /// Background color contains green.
        /// </summary>
        BACKGROUND_GREEN = 0x0020,

        /// <summary>
        /// Background color contains red.
        /// </summary>
        BACKGROUND_RED = 0x0040,

        /// <summary>
        /// Background color is intensified.
        /// </summary>
        BACKGROUND_INTENSITY = 0x0080
    }
}

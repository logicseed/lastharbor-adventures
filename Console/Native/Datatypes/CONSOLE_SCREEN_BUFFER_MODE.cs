// Copyright © 2018 Marc King <marc@marc.software> - All Rights Reserved
//
// SPDX-License-Identifier: MIT
//
// This work is licensed under the terms of the MIT license. See <LICENSE.md> for more information.

using System;

namespace LastHarbor.Console.Native
{
    /// <summary>
    /// The type of console screen buffer.
    /// </summary>
    [Flags]
    internal enum CONSOLE_SCREEN_BUFFER_MODE : Int32
    {
        CONSOLE_TEXTMODE_BUFFER = 0x00000001
    }
}

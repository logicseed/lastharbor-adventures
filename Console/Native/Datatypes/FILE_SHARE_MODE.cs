// Copyright © 2018 Marc King <marc@marc.software> - All Rights Reserved
//
// SPDX-License-Identifier: MIT
//
// This work is licensed under the terms of the MIT license. See <LICENSE.md> for more information.

using System;

namespace LastHarbor.Console.Native
{
    /// <summary>
    /// The requested sharing mode of the file or device.
    /// </summary>
    [Flags]
    internal enum FILE_SHARE_MODE : Int32
    {
        /// <summary>
        /// Other open operations cannot be performed on the console screen buffer.
        /// </summary>
        NONE = 0x00000000,

        /// <summary>
        /// Other open operations can be performed on the console screen buffer for read access.
        /// </summary>
        FILE_SHARE_READ = 0x00000001,

        /// <summary>
        /// Other open operations can be performed on the console screen buffer for write access.
        /// </summary>
        FILE_SHARE_WRITE = 0x00000002,

        /// <summary>
        /// Other open operations can be performed on the console screen buffer for delete access.
        /// </summary>
        FILE_SHARE_DELETE = 0x00000004,

        /// <summary>
        /// Other open operations can be performed on the console screen buffer for read and write
        /// access.
        /// </summary>
        FILE_SHARE_READWRITE = FILE_SHARE_READ | FILE_SHARE_WRITE,
    }
}

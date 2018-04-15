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
    /// Contains information about the console history.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CONSOLE_HISTORY_INFO
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// </summary>
        /// <remarks>Set this member to <c>sizeof(CONSOLE_HISTORY_INFO)</c>.</remarks>
        public Int32 Size;

        /// <summary>
        /// The number of commands kept in each history buffer.
        /// </summary>
        public Int32 HistoryBufferSize;

        /// <summary>
        /// The number of history buffers kept for this console process.
        /// </summary>
        public Int32 NumberOfHistoryBuffers;

        /// <summary>
        /// This parameter can be zero or the following value.
        /// </summary>
        /// <remarks>
        /// HISTORY_NO_DUP_FLAG 0x1 Duplicate entries will not be stored in the history buffer.
        /// </remarks>
        public Int32 Flags;
    }
}

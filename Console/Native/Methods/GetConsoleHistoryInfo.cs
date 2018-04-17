﻿// Copyright © 2018 Marc King <marc@marc.software> - All Rights Reserved
//
// SPDX-License-Identifier: MIT
//
// This work is licensed under the terms of the MIT license. See <LICENSE.md> for more information.

using System;
using System.Runtime.InteropServices;

namespace LastHarbor.Console.Native
{
    /// <summary>
    /// Interop methods to access native console functions.
    /// </summary>
    internal static partial class NativeMethods
    {
        /// <summary>
        /// Retrieves the history settings for the calling process's console.
        /// </summary>
        /// <param name="lpConsoleHistoryInfo">
        /// A pointer to a <see cref="CONSOLE_HISTORY_INFO"/> structure that receives the history
        /// settings for the calling process's console.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is <c>TRUE</c>.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <c>FALSE</c>. To get extended error
        /// information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// If the calling process is not a console process, the function fails and sets the last
        /// error to <c>ERROR_ACCESS_DENIED</c>.
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/getconsolehistoryinfo"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "GetConsoleHistoryInfo",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean GetConsoleHistoryInfo(
            [param: In, Out]
            ref CONSOLE_HISTORY_INFO lpConsoleHistoryInfo
        );
    }
}

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
    /// Interop methods to access native console functions.
    /// </summary>
    internal static partial class NativeMethods
    {
        /// <summary>
        /// Retrieves the current input mode of a console's input buffer or the current output mode
        /// of a console screen buffer.
        /// </summary>
        /// <param name="hConsoleHandle">
        /// A handle to the console input buffer or the console screen buffer. The handle must have
        /// the <c>GENERIC_READ</c> access right.
        /// </param>
        /// <param name="lpMode">
        /// <para>
        /// A pointer to a variable that receives the current mode of the specified buffer.
        /// </para>
        /// <para>
        /// If the <paramref name="hConsoleHandle"/> parameter is an input handle, the mode can be
        /// one or more of the following values. When a console is created, all input modes except
        /// <c>ENABLE_WINDOW_INPUT</c> are enabled by default.
        /// </para>
        /// <para>
        /// If the <paramref name="hConsoleHandle"/> parameter is a screen buffer handle, the mode
        /// can be one or more of the following values. When a screen buffer is created, both output
        /// modes are enabled by default.
        /// </para>
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
        /// <para>
        /// A console consists of an input buffer and one or more screen buffers. The mode of a
        /// console buffer determines how the console behaves during input or output (I/O)
        /// operations. One set of flag constants is used with input handles, and another set is used
        /// with screen buffer (output) handles. Setting the output modes of one screen buffer does
        /// not affect the output modes of other screen buffers.
        /// </para>
        /// <para>
        /// The <c>ENABLE_LINE_INPUT</c> and <c>ENABLE_ECHO_INPUT</c> modes only affect processes
        /// that use <see cref="ReadFile"/> or <see cref="ReadConsole"/> to read from the console's
        /// input buffer. Similarly, the <c>ENABLE_PROCESSED_INPUT</c> mode primarily affects
        /// <c>ReadFile</c> and <c>ReadConsole</c> users, except that it also determines whether
        /// CTRL+C input is reported in the input buffer (to be read by the
        /// <see cref="ReadConsoleInput"/> function) or is passed to a function defined by the
        /// application.
        /// </para>
        /// <para>
        /// The <c>ENABLE_WINDOW_INPUT</c> and <c>ENABLE_MOUSE_INPUT</c> modes determine whether user
        /// interactions involving window resizing and mouse actions are reported in the input buffer
        /// or discarded. These events can be read by <c>ReadConsoleInput</c>, but they are always
        /// filtered by <c>ReadFile</c> and <c>ReadConsole</c>.
        /// </para>
        /// <para>
        /// The <c>ENABLE_PROCESSED_OUTPUT</c> and <c>ENABLE_WRAP_AT_EOL_OUTPUT</c> modes only affect
        /// processes using <c>ReadFile</c> or <c>ReadConsole</c> and <see cref="WriteFile"/> or
        /// <see cref="WriteConsole"/>.
        /// </para>
        /// <para>
        /// To change a console's I/O modes, call <see cref="SetConsoleMode"/> function.
        /// </para>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/getconsolemode"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "GetConsoleMode",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean GetConsoleMode(
            [param: In]
            IntPtr hConsoleHandle,

            [param: In, Out, MarshalAs(UnmanagedType.I4)]
            ref CONSOLE_MODE lpMode
        );
    }
}

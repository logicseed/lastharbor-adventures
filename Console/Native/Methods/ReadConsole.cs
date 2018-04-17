// Copyright © 2018 Marc King <marc@marc.software> - All Rights Reserved
//
// SPDX-License-Identifier: MIT
//
// This work is licensed under the terms of the MIT license. See <LICENSE.md> for more information.

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace LastHarbor.Console.Native
{
    /// <summary>
    /// Interop methods to access native console functions.
    /// </summary>
    internal static partial class NativeMethods
    {
        /// <summary>
        /// Reads character input from the console input buffer and removes it from the buffer.
        /// </summary>
        /// <param name="hConsoleInput">
        /// A handle to the console input buffer. The handle must have the <c>GENERIC_READ</c> access
        /// right.
        /// </param>
        /// <param name="lpBuffer">
        /// <para>
        /// A pointer to a buffer that receives the data read from the console input buffer.
        /// </para>
        /// <para>
        /// The storage for this buffer is allocated from a shared heap for the process that is 64 KB
        /// in size. The maximum size of the buffer will depend on heap usage.
        /// </para>
        /// </param>
        /// <param name="nNumberOfCharsToRead">
        /// The number of characters to be read. The size of the buffer pointed to by the
        /// <paramref name="lpBuffer"/> parameter should be at least <c>nNumberOfCharsToRead *
        /// sizeof(TCHAR)</c> bytes.
        /// </param>
        /// <param name="lpNumberOfCharsRead">
        /// A pointer to a variable that receives the number of characters actually read.
        /// </param>
        /// <param name="pInputControl">
        /// <para>
        /// A pointer to a <see cref="CONSOLE_READCONSOLE_CONTROL"/> structure that specifies a
        /// control character to signal the end of the read operation. This parameter can be
        /// <c>NULL</c>.
        /// </para>
        /// <para>
        /// This parameter requires Unicode input by default. For ANSI mode, set this parameter to
        /// <c>NULL</c>.
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
        /// <c>ReadConsole</c> reads keyboard input from a console's input buffer. It behaves like
        /// the <see cref="ReadFile"/> function, except that it can read in either Unicode
        /// (wide-character) or ANSI mode. To have applications that maintain a single set of sources
        /// compatible with both modes, use <c>ReadConsole</c> rather than <c>ReadFile</c>. Although
        /// <c>ReadConsole</c> can only be used with a console input buffer handle, <c>ReadFile</c>
        /// can be used with other handles (such as files or pipes). <c>ReadConsole</c> fails if used
        /// with a standard handle that has been redirected to be something other than a console
        /// handle.
        /// </para>
        /// <para>
        /// All of the input modes that affect the behavior of <c>ReadFile</c> have the same effect
        /// on <c>ReadConsole</c>. To retrieve and set the input modes of a console input buffer, use
        /// the <see cref="GetConsoleMode"/> and <see cref="SetConsoleMode"/> functions.
        /// </para>
        /// <para>
        /// If the input buffer contains input events other than keyboard events (such as mouse
        /// events or window-resizing events), they are discarded. Those events can only be read by
        /// using the <see cref="ReadConsoleInput"/> function.
        /// </para>
        /// <para>
        /// This function uses either Unicode characters or 8-bit characters from the console's
        /// current code page. The console's code page defaults initially to the system's OEM code
        /// page. To change the console's code page, use the <see cref="SetConsoleCP"/> or
        /// <see cref="SetConsoleOutputCP"/> functions.
        /// </para>
        /// <para>
        /// The <paramref name="pInputControl"/> parameter can be used to enable intermediate wakeups
        /// from the read in response to a file-completion control character specified in a
        /// <see cref="CONSOLE_READCONSOLE_CONTROL"/> structure. This feature requires command
        /// extensions to be enabled, the standard output handle to be a console output handle, and
        /// input to be Unicode.
        /// </para>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/readconsole"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "ReadConsoleW",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern Boolean ReadConsole(
            [param: In]
            IntPtr hConsoleInput,

            [param: In, Out, MarshalAs(UnmanagedType.LPWStr)]
            ref StringBuilder lpBuffer,

            [param: In]
            Int32 nNumberOfCharsToRead,

            [param: In, Out]
            ref Int32 lpNumberOfCharsRead,

            [param: In, Optional]
            CONSOLE_READCONSOLE_CONTROL pInputControl
        );
    }
}

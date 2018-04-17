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
        /// Writes a character string to a console screen buffer beginning at the current cursor
        /// location.
        /// </summary>
        /// <param name="hConsoleOutput">
        /// A handle to the console screen buffer. The handle must have the <c>GENERIC_WRITE</c>
        /// access right.
        /// </param>
        /// <param name="lpBuffer">
        /// <para>
        /// A pointer to a buffer that contains characters to be written to the console screen
        /// buffer.
        /// </para>
        /// <para>
        /// The storage for this buffer is allocated from a shared heap for the process that is 64 KB
        /// in size. The maximum size of the buffer will depend on heap usage.
        /// </para>
        /// </param>
        /// <param name="nNumberOfCharsToWrite">
        /// The number of characters to be written. If the total size of the specified number of
        /// characters exceeds the available heap, the function fails with
        /// <c>ERROR_NOT_ENOUGH_MEMORY</c>.
        /// </param>
        /// <param name="lpNumberOfCharsWritten">
        /// A pointer to a variable that receives the number of characters actually written.
        /// </param>
        /// <param name="lpReserved">
        /// Reserved; must be <c>NULL</c>.
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
        /// The <c>WriteConsole</c> function writes characters to the console screen buffer at the
        /// current cursor position. The cursor position advances as characters are written. The
        /// <see cref="SetConsoleCursorPosition"/> function sets the current cursor position.
        /// </para>
        /// <para>
        /// Characters are written using the foreground and background color attributes associated
        /// with the console screen buffer. The <see cref="SetConsoleTextAttribute"/> function
        /// changes these colors. To determine the current color attributes and the current cursor
        /// position, use <see cref="GetConsoleScreenBufferInfo"/>.
        /// </para>
        /// <para>
        /// All of the input modes that affect the behavior of the <see cref="WriteFile"/> function
        /// have the same effect on <c>WriteConsole</c>. To retrieve and set the output modes of a
        /// console screen buffer, use the <see cref="GetConsoleMode"/> and
        /// <see cref="SetConsoleMode"/> functions.
        /// </para>
        /// <para>
        /// The <c>WriteConsole</c> function uses either Unicode characters or ANSI characters from
        /// the console's current code page. The console's code page defaults initially to the
        /// system's OEM code page. To change the console's code page, use the
        /// <see cref="SetConsoleCP"/> or <see cref="SetConsoleOutputCP"/> functions.
        /// </para>
        /// <para>
        /// <c>WriteConsole</c> fails if it is used with a standard handle that is redirected to a
        /// file. If an application processes multilingual output that can be redirected, determine
        /// whether the output handle is a console handle (one method is to call the
        /// <c>GetConsoleMode</c> function and check whether it succeeds). If the handle is a console
        /// handle, call <c>WriteConsole</c>. If the handle is not a console handle, the output is
        /// redirected and you should call <c>WriteFile</c> to perform the I/O. Be sure to prefix a
        /// Unicode plain text file with a byte order mark.
        /// </para>
        /// <para>
        /// Although an application can use <c>WriteConsole</c> in ANSI mode to write ANSI
        /// characters, consoles do not support ANSI escape sequences. However, some functions
        /// provide equivalent functionality. For more information, see
        /// <see cref="SetConsoleCursorPosition"/>, <see cref="SetConsoleTextAttribute"/>, and
        /// <see cref="GetConsoleCursorInfo"/>.
        /// </para>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/writeconsole"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "WriteConsoleW",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern Boolean WriteConsole(
            [param: In]
            IntPtr hConsoleOutput,

            [param: In, MarshalAs(UnmanagedType.LPWStr)]
            String lpBuffer,

            [param: In]
            Int32 nNumberOfCharsToWrite,

            [param: In, Out]
            ref Int32 lpNumberOfCharsWritten,

            [param: In]
            IntPtr lpReserved
        );
    }
}

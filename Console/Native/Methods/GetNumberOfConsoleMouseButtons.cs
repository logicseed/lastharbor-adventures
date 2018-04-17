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
        /// Retrieves the number of buttons on the mouse used by the current console.
        /// </summary>
        /// <param name="lpNumberOfMouseButtons">
        /// A pointer to a variable that receives the number of mouse buttons.
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
        /// When a console receives mouse input, an <see cref="INPUT_RECORD"/> structure containing a
        /// <see cref="MOUSE_EVENT_RECORD"/> structure is placed in the console's input buffer. The
        /// <c>dwButtonState</c> member of <c>MOUSE_EVENT_RECORD</c> has a bit indicating the state
        /// of each mouse button. The bit is 1 if the button is down and 0 if the button is up. To
        /// determine the number of bits that are significant, use
        /// <c>GetNumberOfConsoleMouseButtons</c>.
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/windows/console/getnumberofconsolemousebuttons"/>
        ///
        [DllImport("kernel32.dll",
                   EntryPoint = "GetNumberOfConsoleMouseButtons",
                   SetLastError = true,
                   CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern Boolean GetNumberOfConsoleMouseButtons(
            [param: In, Out]
            ref Int32 lpNumberOfMouseButtons
        );
    }
}

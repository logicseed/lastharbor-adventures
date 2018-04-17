// Copyright © 2018 Marc King <marc@marc.software> - All Rights Reserved
//
// SPDX-License-Identifier: MIT
//
// This work is licensed under the terms of the MIT license. See <LICENSE.md> for more information.

using System;

namespace LastHarbor.Console.Native
{
    /// <summary>
    /// The display mode of the console.
    /// </summary>
    [Flags]
    internal enum CONSOLE_DISPLAY_MODE : Int32
    {
        /// <summary>
        /// Full-screen console. The console is in this mode as soon as the window is maximized. At
        /// this point, the transition to full-screen mode can still fail.
        /// </summary>
        CONSOLE_FULLSCREEN = 1,

        /// <summary>
        /// Full-screen console communicating directly with the video hardware. This mode is set
        /// after the console is in CONSOLE_FULLSCREEN mode to indicate that the transition to
        /// full-screen mode has completed.
        /// </summary>
        CONSOLE_FULLSCREEN_HARDWARE = 2,

        /// <summary>
        /// Text is displayed in a console window.
        /// </summary>
        CONSOLE_WINDOWED_MODE = 2,
    }
}

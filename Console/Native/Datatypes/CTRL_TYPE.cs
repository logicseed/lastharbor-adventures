﻿// Copyright © 2018 Marc King <marc@marc.software> - All Rights Reserved
//
// SPDX-License-Identifier: MIT
//
// This work is licensed under the terms of the MIT license. See <LICENSE.md> for more information.

using System;

namespace LastHarbor.Console.Native
{
    /// <summary>
    /// Represents a console control handler event.
    /// </summary>
    /// <seealso cref="https://docs.microsoft.com/en-us/windows/console/handlerroutine"/>
    internal enum CTRL_TYPE : Int32
    {
        /// <summary>
        /// A CTRL+C signal was received, either from keyboard input or from a signal generated by
        /// the GenerateConsoleCtrlEvent function.
        /// </summary>
        CTRL_C_EVENT = 0,

        /// <summary>
        /// A CTRL+BREAK signal was received, either from keyboard input or from a signal generated
        /// by GenerateConsoleCtrlEvent.
        /// </summary>
        CTRL_BREAK_EVENT = 1,

        /// <summary>
        /// A signal that the system sends to all processes attached to a console when the user
        /// closes the console (either by clicking Close on the console window's window menu, or by
        /// clicking the End Task button command from Task Manager).
        /// </summary>
        CTRL_CLOSE_EVENT = 2,

        /*
            RESERVED 3
            RESERVED 4
        */

        /// <summary>
        /// A signal that the system sends to all console processes when a user is logging off. This
        /// signal does not indicate which user is logging off, so no assumptions can be made.
        ///
        /// Note that this signal is received only by services. Interactive applications are
        /// terminated at logoff, so they are not present when the system sends this signal.
        /// </summary>
        CTRL_LOGOFF_EVENT = 5,

        /// <summary>
        /// A signal that the system sends when the system is shutting down. Interactive applications
        /// are not present by the time the system sends this signal, therefore it can be received
        /// only be services in this situation. Services also have their own notification mechanism
        /// for shutdown events. For more information, see Handler.
        ///
        /// This signal can also be generated by an application using GenerateConsoleCtrlEvent.
        /// </summary>
        CTRL_SHUTDOWN_EVENT = 6,
    }
}

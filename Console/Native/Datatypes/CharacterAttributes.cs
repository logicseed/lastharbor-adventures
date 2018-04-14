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
    /// The attributes to use when writing a character to the console screen buffer. 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CharacterAttributes
    {
        #region Private Fields

        private UInt16 _attributes;

        private const UInt16 BACKGROUND_MASK = 0x00F0;
        private const UInt16 FOREGROUND_MASK = 0x000F;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Gets or sets the background color of the character. 
        /// </summary>
        public ConsoleColor BackgroundColor
        {
            get
            {
                return (ConsoleColor)((_attributes & BACKGROUND_MASK) >> 4);
            }

            set
            {
                _attributes = (UInt16)(((UInt16)value << 4) | (_attributes & FOREGROUND_MASK));
            }
        }

        /// <summary>
        /// Gets or sets the foreground color of the character. 
        /// </summary>
        public ConsoleColor ForegroundColor
        {
            get
            {
                return (ConsoleColor)(_attributes & FOREGROUND_MASK);
            }

            set
            {
                _attributes = (UInt16)((UInt16)value | (_attributes & BACKGROUND_MASK));
            }
        }

        /// <summary>
        /// Implicit casting of a ConsoleColor to a CharacterAttributes.
        /// </summary>
        /// <param name="consoleColor">The ConsoleColor to cast to a CharacterAttributes.</param>
        /// <remarks>
        /// When implicitly casting from a ConsoleColor, the background will remain black.
        /// </remarks>
        public static implicit operator CharacterAttributes(ConsoleColor consoleColor)
        {
            return new CharacterAttributes()
            {
                ForegroundColor = consoleColor
            };
        }

        #endregion Public Properties
    }
}

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
    [StructLayout(LayoutKind.Explicit)]
    internal struct CharacterAttributes
    {
        #region Private Fields

        private const UInt16 BACKGROUND_MASK = 0x00F0;
        private const UInt16 FOREGROUND_MASK = 0x000F;

        [FieldOffset(0)]
        private UInt16 _attributes;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterAttributes"/> struct using the
        /// specified foreground color.
        /// </summary>
        /// <param name="foregroundColor">
        /// The foreground color of the <see cref="CharacterAttributes"/>.
        /// </param>
        public CharacterAttributes(ConsoleColor foregroundColor)
        {
            _attributes = (UInt16)foregroundColor;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterAttributes"/> struct using the
        /// specified foreground and background colors.
        /// </summary>
        /// <param name="foregroundColor">
        /// The foreground color of the <see cref="CharacterAttributes"/>.
        /// </param>
        /// <param name="backgroundColor">
        /// The background color of the <see cref="CharacterAttributes"/>.
        /// </param>
        public CharacterAttributes(ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            _attributes = (UInt16)((UInt16)foregroundColor | ((UInt16)backgroundColor << 4));
        }

        #endregion Public Constructors

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

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Implicit casting of a <see cref="ConsoleColor"/> to a <see cref="CharacterAttributes"/>.
        /// </summary>
        /// <param name="consoleColor">
        /// The <see cref="ConsoleColor"/> to cast to a <see cref="CharacterAttributes"/>.
        /// </param>
        /// <remarks>
        /// When implicitly casting from a <see cref="ConsoleColor"/>, the background will remain
        /// black.
        /// </remarks>
        public static implicit operator CharacterAttributes(ConsoleColor consoleColor)
        {
            return new CharacterAttributes(consoleColor);
        }

        #endregion Public Methods
    }
}

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
    /// Specifies a Unicode or Ascii character and its attributes. 
    /// </summary>
    /// <remarks>
    /// This structure is used by console functions to read from and write to a console screen
    /// buffer.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit)]
    internal struct CharacterInfo
    {
        #region Private Fields

        [FieldOffset(0)]
        private CharacterUnion _character;

        [FieldOffset(2)]
        private CharacterAttributes _attributes;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterInfo"/> struct with the specified
        /// Unicode character and foreground color.
        /// </summary>
        /// <param name="unicodeCharacter">
        /// The Unicode character of the <see cref="CharacterInfo"/>.
        /// </param>
        /// <param name="foregroundColor">
        /// The foreground color of the <see cref="CharacterInfo"/>.
        /// </param>
        public CharacterInfo(Char unicodeCharacter, ConsoleColor foregroundColor)
        {
            _character = new CharacterUnion(unicodeCharacter);
            _attributes = new CharacterAttributes(foregroundColor);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterInfo"/> struct with the specified
        /// Unicode character, foreground color, and background color.
        /// </summary>
        /// <param name="unicodeCharacter">
        /// The Unicode character of the <see cref="CharacterInfo"/>.
        /// </param>
        /// <param name="foregroundColor">
        /// The foreground color of the <see cref="CharacterInfo"/>.
        /// </param>
        /// <param name="backgroundColor">
        /// The background color of the <see cref="CharacterInfo"/>.
        /// </param>
        public CharacterInfo(Char unicodeCharacter, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            _character = new CharacterUnion(unicodeCharacter);
            _attributes = new CharacterAttributes(foregroundColor, backgroundColor);
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// The attributes to use when writing a character to the console screen buffer. 
        /// </summary>
        public CharacterAttributes Attributes
        {
            get
            {
                return _attributes;
            }

            set
            {
                _attributes = value;
            }
        }

        /// <summary>
        /// A union of the Unicode or Ascii character of a screen buffer character cell. 
        /// </summary>
        public CharacterUnion Character
        {
            get
            {
                return _character;
            }

            set
            {
                _character = value;
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Implicit casting a <see cref="Char"/> to a <see cref="CharacterInfo"/>. 
        /// </summary>
        /// <param name="unicodeCharacter">
        /// The <see cref="Char"/> to cast to a <see cref="CharacterInfo"/>.
        /// </param>
        /// <remarks>
        /// When implicitly casting from a <see cref="Char"/> the <see cref="CharacterAttributes"/>
        /// will be a white foreground on a black background.
        /// </remarks>
        public static implicit operator CharacterInfo(Char unicodeCharacter)
        {
            return new CharacterInfo(unicodeCharacter, ConsoleColor.White);
        }

        #endregion Public Methods
    }
}

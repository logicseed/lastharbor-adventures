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
    /// A union of the Unicode or Ascii character of a screen buffer character cell. 
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    internal struct CharacterUnion
    {
        #region Private Fields

        [FieldOffset(0)]
        private Byte _asciiCharacter;

        [FieldOffset(0)]
        private Char _unicodeCharacter;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterUnion"/> struct with the specified
        /// Ascii character.
        /// </summary>
        /// <param name="asciiCharacter">
        /// The Ascii character of the <see cref="CharacterUnion"/>.
        /// </param>
        public CharacterUnion(Byte asciiCharacter)
        {
            _unicodeCharacter = (Char)0x0000;
            _asciiCharacter = asciiCharacter;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterUnion"/> struct with the specified
        /// Unicode character.
        /// </summary>
        /// <param name="unicodeCharacter">
        /// The Unicode character of the <see cref="CharacterUnion"/>.
        /// </param>
        public CharacterUnion(Char unicodeCharacter)
        {
            _asciiCharacter = 0x00;
            _unicodeCharacter = unicodeCharacter;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Ascii character of a screen buffer character cell. 
        /// </summary>
        public Byte AsciiCharacter
        {
            get
            {
                return _asciiCharacter;
            }

            set
            {
                _asciiCharacter = value;
            }
        }

        /// <summary>
        /// Unicode character of a screen buffer character cell. 
        /// </summary>
        public Char UnicodeCharacter
        {
            get
            {
                return _unicodeCharacter;
            }

            set
            {
                _unicodeCharacter = value;
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Implicit casting of a <see cref="Byte"/> to a <see cref="CharacterUnion"/>. 
        /// </summary>
        /// <param name="asciiCharacter">
        /// The <see cref="Byte"/> to cast as a <see cref="CharacterUnion"/>.
        /// </param>
        public static implicit operator CharacterUnion(Byte asciiCharacter)
        {
            return new CharacterUnion(asciiCharacter);
        }

        /// <summary>
        /// Implicit casting of a <see cref="Char"/> to a <see cref="CharacterUnion"/>. 
        /// </summary>
        /// <param name="unicodeCharacter">
        /// The <see cref="Char"/> to cast as a <see cref="CharacterUnion"/>.
        /// </param>
        public static implicit operator CharacterUnion(Char unicodeCharacter)
        {
            return new CharacterUnion(unicodeCharacter);
        }

        #endregion Public Methods
    }
}

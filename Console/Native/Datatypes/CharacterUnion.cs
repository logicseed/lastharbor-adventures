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
    /// A union of the Unicode or ANSI character of a screen buffer character cell. 
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    internal struct CharacterUnion
    {
        #region Public Fields

        /// <summary>
        /// Ascii character of a screen buffer character cell. 
        /// </summary>
        [FieldOffset(0)]
        public Byte AsciiCharacter;

        /// <summary>
        /// Unicode character of a screen buffer character cell. 
        /// </summary>
        [FieldOffset(0)]
        public Char UnicodeCharacter;

        #endregion Public Fields

        #region Public Methods

        /// <summary>
        /// Implicit casting of a Byte to a CharacterUnion. 
        /// </summary>
        /// <param name="asciiCharacter"> The Byte to cast to a CharacterUnion. </param>
        public static implicit operator CharacterUnion(Byte asciiCharacter)
        {
            return new CharacterUnion()
            {
                AsciiCharacter = asciiCharacter
            };
        }

        /// <summary>
        /// Implicit casting of a Char to a CharacterUnion. 
        /// </summary>
        /// <param name="unicodeCharacter"> The Char to cast to a CharacterUnion. </param>
        public static implicit operator CharacterUnion(Char unicodeCharacter)
        {
            return new CharacterUnion()
            {
                UnicodeCharacter = unicodeCharacter
            };
        }

        #endregion Public Methods
    }
}

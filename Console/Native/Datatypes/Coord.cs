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
    /// Defines the coordinates of a character cell in a console screen buffer. 
    /// </summary>
    /// <remarks>
    /// The origin of the coordinate system (0,0) is at the top, left cell of the buffer.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit)]
    internal struct Coord
    {
        #region Private Fields

        [FieldOffset(0)]
        private Int16 _x;

        [FieldOffset(2)]
        private Int16 _y;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Coord"/> struct with the specified
        /// horizontal and vertical coordinates.
        /// </summary>
        /// <param name="x"> The horizontal coordinate of the <see cref="Coord"/>. </param>
        /// <param name="y"> The vertical coordinate of the <see cref="Coord"/>. </param>
        public Coord(Int16 x, Int16 y)
        {
            _x = x;
            _y = y;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// The horizontal coordinate or column value. The units depend on the function call. 
        /// </summary>
        public Int16 X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }
        }

        /// <summary>
        /// The vertical coordinate or row value. The units depend on the function call. 
        /// </summary>
        public Int16 Y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
            }
        }

        #endregion Public Properties
    }
}

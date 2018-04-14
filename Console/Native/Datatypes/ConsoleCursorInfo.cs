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
    /// Contains information about the console cursor. 
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    internal struct ConsoleCursorInfo
    {
        #region Private Fields

        private const UInt32 MAX_SIZE = 100;
        private const UInt32 MIN_SIZE = 1;

        [FieldOffset(0)]
        private UInt32 _size;

        [FieldOffset(4)]
        private Boolean _visible;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// The percentage of the character cell that is filled by the cursor. This value is between
        /// <c>1</c> and <c>100</c>.
        /// </summary>
        /// <remarks>
        /// The cursor appearance varies, ranging from completely filling the cell to showing up as a
        /// horizontal line at the bottom of the cell.
        /// </remarks>
        public UInt32 Size
        {
            get
            {
                return _size;
            }

            set
            {
                if (value > MAX_SIZE)
                {
                    _size = MAX_SIZE;
                }
                else if (value < MIN_SIZE)
                {
                    _size = MIN_SIZE;
                }
                else
                {
                    _size = value;
                }
            }
        }

        /// <summary>
        /// The visibility of the cursor. If the cursor is visible, this member is <c>TRUE</c>. 
        /// </summary>
        public Boolean Visible
        {
            get
            {
                return _visible;
            }

            set
            {
                _visible = value;
            }
        }

        #endregion Public Properties
    }
}

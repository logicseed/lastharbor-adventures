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
    /// Contains the security descriptor for an object and specifies whether the handle retrieved by
    /// specifying this structure is inheritable.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct SECURITY_ATTRIBUTES
    {
        /// <summary>
        /// The size, in bytes, of this structure.
        /// </summary>
        public Int32 Length;

        /// <summary>
        /// A pointer to a SECURITY_DESCRIPTOR structure that controls access to the object.
        /// </summary>
        public IntPtr SecurityDescriptor;

        /// <summary>
        /// A Boolean value that specifies whether the returned handle is inherited when a new
        /// process is created.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public Boolean InheritHandle;
    }
}

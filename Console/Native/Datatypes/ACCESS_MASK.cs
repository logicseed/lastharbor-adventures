// Copyright © 2018 Marc King <marc@marc.software> - All Rights Reserved
//
// SPDX-License-Identifier: MIT
//
// This work is licensed under the terms of the MIT license. See <LICENSE.md> for more information.

using System;

namespace LastHarbor.Console.Native
{
    /// <summary>
    /// The ACCESS_MASK data type defines standard, specific, and generic rights.
    /// </summary>
    [Flags]
    internal enum ACCESS_MASK : UInt32
    {
        // Object-Specific Access Rights

        OBJECT_SPECIFIC_00 = 0x00000001,
        OBJECT_SPECIFIC_01 = 0x00000002,
        OBJECT_SPECIFIC_02 = 0x00000004,
        OBJECT_SPECIFIC_03 = 0x00000008,
        OBJECT_SPECIFIC_04 = 0x00000010,
        OBJECT_SPECIFIC_05 = 0x00000020,
        OBJECT_SPECIFIC_06 = 0x00000040,
        OBJECT_SPECIFIC_07 = 0x00000080,
        OBJECT_SPECIFIC_08 = 0x00000100,
        OBJECT_SPECIFIC_09 = 0x00000200,
        OBJECT_SPECIFIC_10 = 0x00000400,
        OBJECT_SPECIFIC_11 = 0x00000800,
        OBJECT_SPECIFIC_12 = 0x00001000,
        OBJECT_SPECIFIC_13 = 0x00002000,
        OBJECT_SPECIFIC_14 = 0x00004000,
        OBJECT_SPECIFIC_15 = 0x00008000,

        /// <summary>
        /// All object specific rights.
        /// </summary>
        SPECIFIC_RIGHTS_ALL = 0x0000FFFF,

        // Standard Access Rights

        /// <summary>
        /// The right to delete the object.
        /// </summary>
        DELETE = 0x00010000,

        /// <summary>
        /// The right to read the information in the object's security descriptor, not including the
        /// information in the system access control list (SACL).
        /// </summary>
        READ_CONTROL = 0x00020000,

        /// <summary>
        /// The right to modify the discretionary access control list (DACL) in the object's security
        /// descriptor.
        /// </summary>
        WRITE_DAC = 0x00040000,

        /// <summary>
        /// The right to change the owner in the object's security descriptor.
        /// </summary>
        WRITE_OWNER = 0x00080000,

        /// <summary>
        /// The right to use the object for synchronization. This enables a thread to wait until the
        /// object is in the signaled state. Some object types do not support this access right.
        /// </summary>
        SYNCHRONIZE = 0x00100000,

        STANDARD_BIT_21 = 0x00200000,
        STANDARD_BIT_22 = 0x00400000,
        STANDARD_BIT_23 = 0x00800000,

        /// <summary>
        /// Combines DELETE, READ_CONTROL, WRITE_DAC, and WRITE_OWNER access.
        /// </summary>
        STANDARD_RIGHTS_REQUIRED = READ_CONTROL | WRITE_DAC | WRITE_OWNER,

        /// <summary>
        /// Currently defined to equal READ_CONTROL.
        /// </summary>
        STANDARD_RIGHTS_READ = READ_CONTROL,

        /// <summary>
        /// Currently defined to equal READ_CONTROL.
        /// </summary>
        STANDARD_RIGHTS_WRITE = READ_CONTROL,

        /// <summary>
        /// Currently defined to equal READ_CONTROL.
        /// </summary>
        STANDARD_RIGHTS_EXECUTE = READ_CONTROL,

        /// <summary>
        /// Combines DELETE, READ_CONTROL, WRITE_DAC, WRITE_OWNER, and SYNCHRONIZE access.
        /// </summary>
        STANDARD_RIGHTS_ALL = DELETE | READ_CONTROL | WRITE_DAC | WRITE_OWNER | SYNCHRONIZE,

        // System Security Access Rights

        /// <summary>
        /// Ability to get or set the SACL in an object's security descriptor.
        /// </summary>
        ACCESS_SYSTEM_SECURITY = 0x01000000,

        // Reserved Access Rights

        RESERVED_BIT_25 = 0x02000000,
        RESERVED_BIT_26 = 0x04000000,
        RESERVED_BIT_27 = 0x08000000,

        // Generic Access Rights

        /// <summary>
        /// All possible access rights.
        /// </summary>
        GENERIC_ALL = 0x10000000,

        /// <summary>
        /// Execute access.
        /// </summary>
        GENERIC_EXECUTE = 0x20000000,

        /// <summary>
        /// Requests write access to the console screen buffer, enabling the process to write data to
        /// the buffer.
        /// </summary>
        GENERIC_WRITE = 0x40000000,

        /// <summary>
        /// Requests read access to the console screen buffer, enabling the process to read data from
        /// the buffer.
        /// </summary>
        GENERIC_READ = 0x80000000,

        /// <summary>
        /// Requests read and write access to the console screen buffer, enabling the process to read
        /// and write data to the buffer.
        /// </summary>
        GENERIC_READ_WRITE = GENERIC_READ | GENERIC_WRITE,
    }
}

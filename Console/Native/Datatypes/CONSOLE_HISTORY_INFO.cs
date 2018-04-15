using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LastHarbor.Console.Native.Datatypes
{
    /// <summary>
    /// Contains information about the console history.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CONSOLE_HISTORY_INFO
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// </summary>
        /// <remarks>
        /// Set this member to <c>sizeof(CONSOLE_HISTORY_INFO)</c>.
        /// </remarks>
        public Int32 Size;

        /// <summary>
        /// The number of commands kept in each history buffer.
        /// </summary>
        public Int32 HistoryBufferSize;

        /// <summary>
        /// The number of history buffers kept for this console process.
        /// </summary>
        public Int32 NumberOfHistoryBuffers;

        /// <summary>
        /// This parameter can be zero or the following value.
        /// </summary>
        /// <remarks>
        /// HISTORY_NO_DUP_FLAG 0x1 Duplicate entries will not be stored in the history buffer.
        /// </remarks>
        public Int32 Flags;
    }
}

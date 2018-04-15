using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LastHarbor.Console.Native.Datatypes
{
    /// <summary>
    /// Contains extended information for a console font.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal struct CONSOLE_FONT_INFOEX
    {
        /// <summary>
        /// The size of this structure, in bytes.
        /// </summary>
        public Int32 Size;

        /// <summary>
        /// The index of the font in the system's console font table.
        /// </summary>
        public Int32 Font;

        /// <summary>
        /// A <see cref="COORD"/> structure that contains the width and height of each character in
        /// the font, in logical units.
        /// </summary>
        /// <remarks>
        /// The <c>X</c> member contains the width, while the <c>Y</c> member contains the height.
        /// </remarks>
        public COORD FontSize;

        /// <summary>
        /// The font pitch and family.
        /// </summary>
        public Int32 FontFamily;

        /// <summary>
        /// The font weight. The weight can range from 100 to 1000, in multiples of 100.
        /// </summary>
        /// <remarks>
        /// For example, the normal weight is 400, while 700 is bold.
        /// </remarks>
        public Int32 FontWeight;

        /// <summary>
        /// The name of the typeface (such as Courier or Arial).
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public String FaceName;
    }
}

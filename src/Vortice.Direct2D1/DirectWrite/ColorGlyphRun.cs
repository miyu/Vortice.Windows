// Copyright (c) Amer Koleci and contributors.
// Distributed under the MIT license. See the LICENSE file in the project root for more information.

using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpGen.Runtime;

namespace Vortice.DirectWrite
{
    public partial class ColorGlyphRun : IDisposable
    {
        public GlyphRunDescription? GlyphRunDescription { get; set; }

        public void Dispose()
        {
        }

        #region Marshal
        [StructLayout(LayoutKind.Sequential, Pack = 0)]
        internal partial struct __Native
        {
            public Vortice.DirectWrite.GlyphRun.__Native GlyphRun;
            public System.IntPtr GlyphRunDescriptionPointer;
            public float BaselineOriginX;
            public float BaselineOriginY;
            public Vortice.Mathematics.Color4 RunColor;
            public ushort PaletteIndex;

            internal unsafe void __MarshalFree()
            {
                GlyphRun.__MarshalFree();
                
                if (GlyphRunDescriptionPointer != IntPtr.Zero)
                    Marshal.FreeHGlobal(GlyphRunDescriptionPointer);
            }
        }

        internal unsafe void __MarshalFree(ref __Native @ref)
        {
            @ref.__MarshalFree();
        }

        internal unsafe void __MarshalFrom(ref __Native @ref)
        {
            GlyphRun = new GlyphRun();
            GlyphRun.__MarshalFrom(ref @ref.GlyphRun);

            GlyphRunDescription = (@ref.GlyphRunDescriptionPointer == IntPtr.Zero) ? null : new GlyphRunDescription();
            if (GlyphRunDescription != null)
            {
                GlyphRunDescription.__Native* glyphRunDescription_ = (GlyphRunDescription.__Native*)@ref.GlyphRunDescriptionPointer;
                GlyphRunDescription.__MarshalFrom(ref *glyphRunDescription_);
            }

            BaselineOriginX = @ref.BaselineOriginX;
            BaselineOriginY = @ref.BaselineOriginY;
            RunColor = @ref.RunColor;
            PaletteIndex = @ref.PaletteIndex;
        }

        internal unsafe void __MarshalTo(ref __Native @ref)
        {
            GlyphRun.__MarshalTo(ref @ref.GlyphRun);

            if (GlyphRunDescription != null)
            {
                @ref.GlyphRunDescriptionPointer = Marshal.AllocHGlobal(sizeof(GlyphRunDescription.__Native));
                GlyphRunDescription.__Native* glyphRunDescription_ = (GlyphRunDescription.__Native*)@ref.GlyphRunDescriptionPointer;
                GlyphRunDescription.__MarshalTo(ref *glyphRunDescription_);
            }

            @ref.BaselineOriginX = BaselineOriginX;
            @ref.BaselineOriginY = BaselineOriginY;
            @ref.RunColor = RunColor;
            @ref.PaletteIndex = PaletteIndex;
        }
        #endregion Marshal
    }
}

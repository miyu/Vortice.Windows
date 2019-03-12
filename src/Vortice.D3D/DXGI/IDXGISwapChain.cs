// Copyright (c) Amer Koleci and contributors.
// Distributed under the MIT license. See the LICENSE file in the project root for more information.

using System;
using SharpGen.Runtime;
using SharpGen.Runtime.Win32;

namespace Vortice.DXGI
{
    public partial class IDXGISwapChain
    {
        public T GetBackBuffer<T>(int index) where T : ComObject
        {
            var result = GetBuffer(index, typeof(T).GUID, out var nativePtr);
            if (result.Failure)
            {
                return default;
            }

            return FromPointer<T>(nativePtr);
        }

        public Result GetBackBuffer<T>(int index, out T surface) where T : ComObject
        {
            var result = GetBuffer(index, typeof(T).GUID, out var nativePtr);
            if (result.Failure)
            {
                surface = default;
                return result;
            }

            surface = FromPointer<T>(nativePtr);
            return result;
        }

        public void GetFullscreenState(out RawBool fullscreen)
        {
            GetFullscreenState(out fullscreen, out var target);
        }

        public Result SetFullscreenState(bool fullscreen, IDXGIOutput target = null)
        {
            return SetFullscreenState(new RawBool(fullscreen), target);
        }

        public Result ResizeTarget(ModeDescription newTargetParameters)
        {
            return ResizeTarget(ref newTargetParameters);
        }
    }
}

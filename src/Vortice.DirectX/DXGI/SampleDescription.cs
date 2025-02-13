// Copyright � Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

namespace Vortice.DXGI;

public partial struct SampleDescription
{
    /// <summary>
    /// A <see cref="SampleDescription"/> with Count=1 and Quality=0.
    /// </summary>
    public static readonly SampleDescription Default = new(1, 0);

    /// <summary>
    /// Create new instance of <see cref="SampleDescription"/> struct.
    /// </summary>
    /// <param name="count"></param>
    /// <param name="quality"></param>
    public SampleDescription(int count, int quality)
    {
        Count = count;
        Quality = quality;
    }

    public override string ToString() => $"Count: {Count}, Quality: {Quality}";
}

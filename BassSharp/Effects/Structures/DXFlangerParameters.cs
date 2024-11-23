﻿using System.Runtime.InteropServices;

namespace BassSharp.DirectX8;

/// <summary>
/// Parameters for DX8 Flanger Effect.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public class DXFlangerParameters : IEffectParameter
{
    /// <summary>
    /// Ratio of wet (processed) signal to dry (unprocessed) signal. Must be in the range from 0 (default) through 100 (all wet).
    /// </summary>
    public float fWetDryMix;

    /// <summary>
    /// Percentage by which the delay time is modulated by the low-frequency oscillator (LFO), in hundredths of a percentage point. Must be in the range from 0 through 100. The default value is 25.
    /// </summary>
    public float fDepth;

    /// <summary>
    /// Percentage of output signal to feed back into the effect's input, in the range from -99 to 99. The default value is 0.
    /// </summary>
    public float fFeedback;

    /// <summary>
    /// Frequency of the LFO, in the range from 0 to 10. The default value is 0.
    /// </summary>
    public float fFrequency;

    /// <summary>
    /// Waveform of the LFO. Default = <see cref="DXWaveform.Sine"/>.
    /// </summary>
    public DXWaveform lWaveform = DXWaveform.Sine;

    /// <summary>
    /// Number of milliseconds the input is delayed before it is played back, in the range from 0 to 4. The default value is 0 ms.
    /// </summary>
    public float fDelay;

    /// <summary>
    /// Phase differential between left and right LFOs. Default = <see cref="DXPhase.Zero"/>.
    /// </summary>
    public DXPhase lPhase;

    /// <summary>
    /// Gets the <see cref="EffectType"/>.
    /// </summary>
    public EffectType FXType => EffectType.DXFlanger;
}
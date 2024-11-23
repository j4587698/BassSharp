using System.Runtime.InteropServices;

namespace BassSharp;

public static partial class Bass
{
#if __IOS__
        const string DllName = "__Internal";
#else
    const string DllName = "bass";
#endif
    
    /// <summary>
        /// Updates the HSTREAM and HMUSIC channel playback buffers.
        /// </summary>
        /// <param name="length">The amount of data to render, in milliseconds.</param>
        /// <returns>If successful, then <see langword="true" /> is returned, else <see langword="false" /> is returned. Use <see cref="LastError" /> to get the error code.</returns>
        /// <exception cref="Errors.NotAvailable">Updating is already in progress.</exception>
        /// <remarks>
        /// When automatic updating is disabled, this function (or <see cref="ChannelUpdate" />) needs to be called to keep the playback buffers updated.
        /// The <paramref name="length"/> parameter should include some safety margin, in case the next update cycle gets delayed.
        /// For example, if calling this function every 100ms, 200 would be a reasonable <paramref name="length"/> parameter.
        /// </remarks>
        /// <seealso cref="ChannelUpdate"/>
        /// <seealso cref="PlaybackBufferLength"/>
        /// <seealso cref="UpdateThreads"/>
        [LibraryImport(DllName, EntryPoint = "BASS_Update")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool Update(int length);

        #region CPUUsage
        [LibraryImport(DllName)]
        internal static partial float BASS_GetCPU();

        /// <summary>
        /// Retrieves the current CPU usage of BASS as a percentage of total CPU time.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This function includes the time taken to render stream (HSTREAM) and MOD music (HMUSIC) channels during playback, and any DSP functions set on those channels.
        /// It slso includes any FX that are not using the "with FX flag" DX8 effect implementation.
        /// </para>
        /// <para>
        /// The rendering of some add-on stream formats may not be entirely included, if they use additional decoding threads.
        /// See the add-on documentation for details.
        /// </para>
        /// <para>
        /// This function does not strictly tell the CPU usage, but rather how timely the processing is.
        /// For example, if it takes 10ms to render 100ms of data, that would be 10%.
        /// If the reported usage gets to 100%, that means the channel data is being played faster than it can be rendered, and Buffer underruns are likely to occur.
        /// </para>
        /// <para>
        /// If automatic updating is disabled, then the value returned by this function is only updated after each call to <see cref="Update" />.
        /// <see cref="ChannelUpdate" /> usage is not included.
        /// The CPU usage of an individual channel is available via the <see cref="ChannelAttribute.CPUUsage"/> attribute.
        /// </para>
        /// <para><b>Platform-specific</b></para>
        /// <para>
        /// On Windows, the CPU usage does not include sample channels (HCHANNEL), which are mixed by the output device/drivers (hardware mixing) or Windows (software mixing).
        /// On other platforms, the CPU usage does include sample playback as well as the generation of the final output mix.
        /// </para>
        /// </remarks>
        public static double CPUUsage => BASS_GetCPU();
        #endregion

        #region Version
        [LibraryImport(DllName)]
        internal static partial int BASS_GetVersion();

        /// <summary>
        /// Retrieves the version of BASS that is loaded
        /// </summary>
        public static Version Version => Extensions.GetVersion(BASS_GetVersion());
        #endregion

        #region Error Code
        [LibraryImport(DllName)]
        internal static partial Errors BASS_ErrorGetCode();

        /// <summary>
        /// Gets the Error that occured on the Last Bass function that was called.
        /// </summary>
        public static Errors LastError => BASS_ErrorGetCode();
        #endregion
}
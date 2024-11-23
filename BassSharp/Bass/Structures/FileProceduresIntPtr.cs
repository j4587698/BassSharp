using System.Runtime.InteropServices;

namespace BassSharp;

[StructLayout(LayoutKind.Sequential)]
public struct FileProceduresIntPtr
{
    public FileProceduresIntPtr()
    {
    }

    public FileProceduresIntPtr(FileProcedures fileProcedures)
    {
        Close = Marshal.GetFunctionPointerForDelegate(fileProcedures.Close);
        Length = Marshal.GetFunctionPointerForDelegate(fileProcedures.Length);
        Read = Marshal.GetFunctionPointerForDelegate(fileProcedures.Read);
        Seek = Marshal.GetFunctionPointerForDelegate(fileProcedures.Seek);
    }

    /// <summary>
    /// Callback function to close the file.
    /// </summary>
    public IntPtr Close;

    /// <summary>
    /// Callback function to get the file Length.
    /// </summary>
    public IntPtr Length;

    /// <summary>
    /// Callback function to read from the file.
    /// </summary>
    public IntPtr Read;

    /// <summary>
    /// Callback function to seek in the file. Not used by buffered file streams.
    /// </summary>
    public IntPtr Seek;
}
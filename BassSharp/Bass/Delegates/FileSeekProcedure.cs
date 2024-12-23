﻿using System.Runtime.InteropServices;

namespace BassSharp;

/// <summary>
/// User file stream seek callback function (to be used with <see cref="FileProcedures" />).
/// </summary>
/// <param name="Offset">Position in bytes to seek to.</param>
/// <param name="User">The User instance data given when <see cref="Bass.CreateStream(StreamSystem,BassFlags,FileProcedures,IntPtr)" /> was called.</param>
/// <returns><see langword="true" /> if successful, else <see langword="false" />.</returns>
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate bool FileSeekProcedure(long offset, IntPtr user);
// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;
using BassSharp;

Console.WriteLine("Hello, World!");

Bass.Init();
var stream = File.OpenRead("F:\\test.mp3");
var porc = new FileProcedures()
{
    Close = (file) => { stream.Close(); },
    Length = (file) => stream.Length,
    Read = (buffer, length, user) =>
    {
        var bytes = new byte[length];
        var readBytes = stream.Read(bytes, 0, (int)length);
        Marshal.Copy(bytes, 0, buffer, readBytes);
        return readBytes;
    },
    Seek = (offset, mode) =>
    {
        stream.Seek(offset, SeekOrigin.Begin);
        return true;
    }
};

var chan = Bass.CreateStream(StreamSystem.Buffer, BassFlags.Default, porc);
Bass.ChannelPlay(chan);
Console.ReadKey();

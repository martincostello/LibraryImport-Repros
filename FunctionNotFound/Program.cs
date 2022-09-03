using System.Runtime.InteropServices;

var hModule = NativeMethods.LoadLibraryEx("kernel32.dll", 0, 0);

if (hModule == IntPtr.Zero)
{
    Console.WriteLine("Could not load kernel32.dll");
}
else
{
    Console.WriteLine("Loaded kernel32.dll");

    var address = NativeMethods.GetProcAddress(hModule, "FreeLibrary");

    if (address == IntPtr.Zero)
    {
        Console.WriteLine("FreeLibrary() not found");
    }
    else
    {
        Console.WriteLine("FreeLibrary() found");
    }

    NativeMethods.FreeLibrary(hModule);

    Console.WriteLine("Unloaded kernel32.dll");
}

internal static partial class NativeMethods
{
    [LibraryImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool FreeLibrary(IntPtr hModule);

    [LibraryImport("kernel32.dll")]
    internal static partial IntPtr GetProcAddress(
        IntPtr hModule,
        [MarshalAs(UnmanagedType.LPStr)] string lpProcName);

    [LibraryImport("kernel32.dll", /*EntryPoint = "LoadLibraryExA",*/ SetLastError = true, StringMarshalling = StringMarshalling.Utf8)]
    internal static partial IntPtr LoadLibraryEx(
        string lpFileName,
        IntPtr hFile,
        int dwFlags);
}

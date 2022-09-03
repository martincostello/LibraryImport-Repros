using System.Runtime.InteropServices;

internal static partial class NativeMethods
{
    [LibraryImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool FreeLibrary(IntPtr hModule);

    [LibraryImport("kernel32.dll")]
    internal static partial IntPtr GetProcAddress(
        IntPtr hModule,
        [MarshalAs(UnmanagedType.LPStr)] string lpProcName);

    [LibraryImport("kernel32.dll", SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    internal static partial IntPtr LoadLibraryExW(
        string lpFileName,
        IntPtr hFile,
        int dwFlags);
}

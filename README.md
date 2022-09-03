# [LibraryImport] Repros

Repro projects for possible issues with `[LibraryImport]` in .NET 7.

> ⚠️ These repos have only been tested on Windows 11.

## FunctionNotFound

Demonstrates an example of a function converted from `[DllImport]` to
`[LibraryImport]` as-is that throws an exception at runtime.

```sh
> dotnet run
Unhandled exception. System.EntryPointNotFoundException: Unable to find an entry point named 'LoadLibraryEx' in DLL 'kernel32.dll'.
   at NativeMethods.<LoadLibraryEx>g____PInvoke|2_0(Byte* lpFileName, IntPtr hFile, Int32 dwFlags)
   at NativeMethods.LoadLibraryEx(String lpFileName, IntPtr hFile, Int32 dwFlags) in C:\Coding\martincostello\LibraryImport-Repros\FunctionNotFound\Microsoft.Interop.LibraryImportGenerator\Microsoft.Interop.LibraryImportGenerator\LibraryImports.g.cs:line 79
   at Program.<Main>$(String[] args) in C:\Coding\martincostello\LibraryImport-Repros\FunctionNotFound\Program.cs:line 3
```

## UnintuitiveUnsafeCode

Demonstrates some C# code that does not use any `unsafe` features itself which
fails to compile due to the need to set `<AllowUnsafeBlocks>true</AllowUnsafeBlocks>`
as the generated code uses pointers and `[SkipLocalsInit]`.

```sh
❯ dotnet build
MSBuild version 17.4.0-preview-22368-02+c8492483a for .NET
  Determining projects to restore...
  All projects are up-to-date for restore.
C:\Program Files\dotnet\sdk\7.0.100-preview.7.22377.5\Sdks\Microsoft.NET.Sdk\targets\Microsoft.NET.RuntimeIdentifierInference.targets(219,5): message NETSDK1057: You are using a preview version of .NET. See: https://aka.ms/dotnet-support-policy [C:\Coding\martincostello\LibraryImport-Repros\UnintuitiveUnsafeCode\UnintuitiveUnsafeCode.csproj]
C:\Coding\martincostello\LibraryImport-Repros\UnintuitiveUnsafeCode\NativeMethods.cs(3,31): error CS0227: Unsafe code may only appear if compiling with /unsafe [C:\Coding\martincostello\LibraryImport-Repros\UnintuitiveUnsafeCode\UnintuitiveUnsafeCode.csproj]
C:\Coding\martincostello\LibraryImport-Repros\UnintuitiveUnsafeCode\Microsoft.Interop.LibraryImportGenerator\Microsoft.Interop.LibraryImportGenerator\LibraryImports.g.cs(5,6): error CS0227: Unsafe code may only appear if compiling with /unsafe [C:\Coding\martincostello\LibraryImport-Repros\UnintuitiveUnsafeCode\UnintuitiveUnsafeCode.csproj]
C:\Coding\martincostello\LibraryImport-Repros\UnintuitiveUnsafeCode\Microsoft.Interop.LibraryImportGenerator\Microsoft.Interop.LibraryImportGenerator\LibraryImports.g.cs(29,6): error CS0227: Unsafe code may only appear if compiling with /unsafe [C:\Coding\martincostello\LibraryImport-Repros\UnintuitiveUnsafeCode\UnintuitiveUnsafeCode.csproj]
C:\Coding\martincostello\LibraryImport-Repros\UnintuitiveUnsafeCode\Microsoft.Interop.LibraryImportGenerator\Microsoft.Interop.LibraryImportGenerator\LibraryImports.g.cs(62,6): error CS0227: Unsafe code may only appear if compiling with /unsafe [C:\Coding\martincostello\LibraryImport-Repros\UnintuitiveUnsafeCode\UnintuitiveUnsafeCode.csproj]

Build FAILED.
```

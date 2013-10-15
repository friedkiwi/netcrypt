# netcrypt
A proof-of-concept packer for .NET executables, designed to provide a starting point to explain the basic principles of runtime packing.

It is a full implementation of a simple .NET PE file packer, which doesn't use native code. 

It can perform the following tasks:
* pack itself
* packing files packed by itself (up to four layers of packing are tested)
* automagically resolve dependencies of the packed EXE

The following downsides/problems are known:
* output files are quite big
* there is no compression
* console applications/DLLs cannot be packed.

Download URL: https://github.com/friedkiwi/netcrypt/releases/tag/v1.0

# Implementation

The packer is implemented in a shared library called netcrypt.dll. If you reference this library you can just use the following code to pack a file:

	byte[] arrayOfUnpackedExeBytes;
	// ... perform file loading/generation logic
	byte[] packedExe = Packer.Pack(arrayOfUnpackedExeBytes);

A sample GUI has been created in the SimplePacker project to demonstrate this principle.

# Sample files

In the /sample firectory you can find two files: input.exe and output.exe. The naming should indicate which one is packed and which one is not.
	
# Warning

This is a proof-of-concept code sample; it is possible that it will not work on your set up or does not work at all on your system.
This packer is also considered to be highly insecure (as with all obfuscators/packers which provide security by obscurity), since an unpacker can be easily constructed. 

# License
Licensed under the GNU GPLv3 license.

# Contact
e-mail: netcrypt@friedkiwi.be
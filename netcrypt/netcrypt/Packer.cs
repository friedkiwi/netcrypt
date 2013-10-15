using System;
using System.Text;
using Microsoft.CSharp;
using System.IO;
using System.Security.Cryptography;
using System.CodeDom.Compiler;

namespace Netcrypt
{
    /// <summary>
    /// Provides an easy-to-use interface to a software packing algorythm for .NET executables.
    /// </summary>
    public class Packer
    {
        /// <summary>
        /// Packs the provided assembly
        /// </summary>
        /// <param name="assembly">A byte[] array containing the original assemly</param>
        /// <returns>a byte[] array containing the packed assemnly</returns>
        public static byte[] Pack(byte[] assembly)
        {
            RijndaelManaged rijndael = new RijndaelManaged();
            rijndael.KeySize = 256;
            rijndael.GenerateIV();
            rijndael.GenerateKey();

            string key = Convert.ToBase64String(rijndael.Key);
            string iv = Convert.ToBase64String(rijndael.IV);
            string app = "";

            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndael.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(assembly, 0, assembly.Length);
            cryptoStream.Flush();
            memoryStream.Seek(0, SeekOrigin.Begin);
            app = Convert.ToBase64String(memoryStream.ToArray());
            cryptoStream.Close();
            memoryStream.Close();

            string csharpcode = netcrypt.Properties.Resources.StubCode;

            csharpcode.Replace("%KEY%", key);
            csharpcode.Replace("%IV%", iv);
            csharpcode.Replace("%PROGRAM%", app);

            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            ICodeCompiler compiler = codeProvider.CreateCompiler();

            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateInMemory = true;
            parameters.GenerateExecutable = true;
            parameters.OutputAssembly = "Packed.exe";

            CompilerResults results = compiler.CompileAssemblyFromSource(parameters, csharpcode);

            try {
                FileStream fs = results.CompiledAssembly.GetFiles()[0];
                byte[] barr  = new byte[fs.Length];
                int r = fs.Read(barr, 0, barr.Length);
                if (r == barr.Length)
                {
                    return barr;
                }
                else
                {
                    return null;
                }
            } catch {
                return null;
            }

        }
    }
}

using System;
using System.Text;
using Microsoft.CSharp;
using System.IO;
using System.Security.Cryptography;
using System.Reflection;
using System.CodeDom.Compiler;
using System.Collections.Generic;

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

            rijndael.Padding = PaddingMode.ISO10126;

            CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndael.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(assembly, 0, assembly.Length);
            cryptoStream.FlushFinalBlock();
            cryptoStream.Flush();
            memoryStream.Seek(0, SeekOrigin.Begin);
            app = Convert.ToBase64String(memoryStream.ToArray());
            cryptoStream.Close();
            memoryStream.Close();

            string csharpcode = netcrypt.Properties.Resources.StubCode;

            csharpcode = csharpcode.Replace("%KEY%", key);
            csharpcode = csharpcode.Replace("%IV%", iv);
            csharpcode = csharpcode.Replace("%PROGRAM%", app);

            Assembly orig = Assembly.Load(assembly);
            



            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            
            

            CompilerParameters parameters = new CompilerParameters();

            parameters.CompilerOptions = "/target:winexe";

            AssemblyName[] names = orig.GetReferencedAssemblies();

            foreach (AssemblyName name in names)
            {
                if (name.Name.Contains("System.") ||
                    name.Name.Contains("Microsoft."))
                    parameters.ReferencedAssemblies.Add(name.Name + ".dll");
            }

            string tempFile = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".exe";
            
            parameters.GenerateExecutable = true;
            parameters.OutputAssembly = tempFile;

            CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, csharpcode);
            
            try {
                FileStream fs = results.CompiledAssembly.GetFiles()[0];
                byte[] barr  = new byte[fs.Length];
                int r = fs.Read(barr, 0, barr.Length);
                fs.Close();
                string fileName = fs.Name;
                fs.Dispose();
                
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

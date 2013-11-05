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
    /// Used to choose the .NET version used to pack the executable.
    /// </summary>
    public enum DotNetVersion
    {
        /// <summary>
        /// Use .NET 2.0 target
        /// </summary>
        v2_0,
        /// <summary>
        /// Use .NET 3.5 target
        /// </summary>
        v3_5,
        /// <summary>
        /// Use .NET 4.0 target
        /// </summary>
        v4_0
    }

    /// <summary>
    /// Provides an easy-to-use interface to a software packing algorythm for .NET executables.
    /// </summary>
    public class Packer
    {
        /// <summary>
        /// Packs the provided assembly using .NET 4.0 by default.
        /// </summary>
        /// <param name="assembly">A byte[] array containing the original assemly</param>
        /// <returns>a byte[] array containing the packed assembly</returns>
        /// 
        public static byte[] Pack(byte[] assembly)
        {
            return Pack(assembly, DotNetVersion.v4_0);
        }

        /// <summary>
        /// Packs the provided assembly using the chosen .NET framework.
        /// </summary>
        /// <param name="assembly">A byte[] array containing the original assemly</param>
        /// <param name="version">The version of the .NET framework used.</param>
        /// <returns>a byte[] array containing the packed assembly</returns>
        public static byte[] Pack(byte[] assembly, DotNetVersion version)
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

            var providerOptions = new Dictionary<string, string>();

            switch (version)
            {
                case DotNetVersion.v2_0:
                    providerOptions.Add("CompilerVersion", "v2.0");
                    break;
                case DotNetVersion.v3_5:
                    providerOptions.Add("CompilerVersion", "v3.5");
                    break;
                case DotNetVersion.v4_0:
                default:
                    providerOptions.Add("CompilerVersion", "v4.0");
                    break;
            }
           
            CSharpCodeProvider codeProvider = new CSharpCodeProvider(providerOptions);
            
            

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

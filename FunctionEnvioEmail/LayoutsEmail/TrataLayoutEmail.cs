using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FunctionEnvioEmail.LayoutsEmail
{
    public class TrataLayoutEmail : IDisposable
    {

        private string VerificaDiretorio
        {
            get
            {
         
                var rootFolder = Directory.GetCurrentDirectory();
                rootFolder = rootFolder.Substring(0,
                            rootFolder.IndexOf(@"\FunctionEnvioEmail\", StringComparison.Ordinal) + @"\FunctionEnvioEmail\".Length);
               var   PathToData = Path.GetFullPath(Path.Combine(rootFolder, "LayoutsEmail"));

                //if (!System.IO.Directory.Exists(PathToData))
                //    System.IO.Directory.CreateDirectory(PathToData);

                PathToData += "\\";
                return PathToData;
            }
        }



        public string GetHtmlLayout()
        {
            var diretorio = string.Concat(VerificaDiretorio, "layout.html");
            var strMail = string.Empty;
            using (StreamReader objReader = new StreamReader(diretorio))
            {
                // Lê todo o arquivo e o joga em uma variável
                strMail = objReader.ReadToEnd();
            }

            return strMail;
        }



        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

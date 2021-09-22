
using FunctionEnvioEmail.LayoutsEmail;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace FunctionEnvioEmail.Dominio
{
    public class LeituraFilaEmail : IDisposable
    {
       
        public void EnvioEmails()
        {
            var dadosEmail = new DadosEmail();

            try
            {
                var html = string.Empty;
                var textoAlteracao = "Meu Teste";
                html += $@"<td style=""text-align: center;"">
                                    <div style=""padding: 8px; height: 24px;display: flex;justify-content: center;align-items: center;background: #FEE77F;border: 1px solid #E9C12B;box-sizing: border-box;border-radius: 15px;
                                    font-family: sans-serif;font-style: normal;font-weight: 500;font-size: 10px;line-height: 12px;margin: auto;color: #03053D;"">
                                  {textoAlteracao} </div> 
                                </td>";

                var trata = new TrataLayoutEmail();
                var strMail = trata.GetHtmlLayout();
                strMail = strMail.Replace("#TAGS_TAGS", html);

                dadosEmail.EnviarEmail("Titulo Teste", strMail, "valdir.silva@fcamara.com.br");
            }
            catch (Exception)
            {

            }
        }


        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);


        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion


    }
}

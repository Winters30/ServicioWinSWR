using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSWR
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        /// 

        //Codicional para saber si entra por consola o como servicio, solo para pruebas de depuracion de código

        static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                ServiceSwr service1 = new ServiceSwr();
                service1.TestStartupAndStop(args);
            }
            else
            {

                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new ServiceSwr()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }

        //static void Main()
        //{
        //    ServiceBase[] ServicesToRun;
        //    ServicesToRun = new ServiceBase[]
        //    {
        //        new ServiceSwr()
        //    };
        //    ServiceBase.Run(ServicesToRun);
        //}
    }
}

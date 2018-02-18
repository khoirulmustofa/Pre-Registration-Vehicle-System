using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace EMailServices
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            // This code will be used for Release mod
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);

           //#if DEBUG
            //            //While debugging this section is used.
            //begin Debug on 30-jan 2018
           // Service1 myService = new Service1();
           // myService.onDebug();
           // System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
           // //// //End Debug on 30-jan 2018

           //////// //#else
           // //// //                    In Release this section is used. This is the "normal" way.
           // ServiceBase[] ServicesToRun;
           // ServicesToRun = new ServiceBase[]
           // {
           //                             new Service1()
           // };
           // ServiceBase.Run(ServicesToRun);
           //#endif
        }


    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using DeviceProject.Config;

namespace DeviceProject.Sincronizacao
{
    public class SanedSyncAuto
    {
        ////campo global define no sincronismo quando a thread está acionando o metodo de envio.
        //public static bool statusThread { get; set; }        

        ////web service
        //static referencia.Service1 _WebService = new referencia.Service1();

        ////estado da thread: true ativado, false desativado
        //static bool status;

        //static string autoSyncTime = "1800000";//30 minutos padrão.

        ////configura o tempo de ciclo de thread.
        //private static void configTimeSync()
        //{
        //    autoSyncTime = Sincronizar.threadTime;
        //}

        ////executa a thread
        //private static void ExecuteThreadSync()
        //{
        //    //converte a string para o tipo long
        //    int waitTime = int.Parse(autoSyncTime);

        //    //Objeto onde se encontra os métodos de sincronismo.
        //    Sincronizar sinc = new Sincronizar();

        //    //todo: implementar método que chama o metodo Enviar dados e verificar quando para tratar o recebimento
        //    Thread syncThread = new Thread(new ThreadStart(sinc.VoltaLeituraUpload));

        //    syncThread.IsBackground = true;
            
        //    while(status) 
        //    {
        //        Thread.Sleep(waitTime);

        //        statusThread = true;

        //        syncThread.Start();                
        //    }

        //    statusThread = false;
        //}

        ////continua a execução da thread
        //public static void StartThreadSync()
        //{
        //    status = true;
        //    configTimeSync();
        //    ExecuteThreadSync();
        //}
        
        ////interrompe a thread.
        //public static void StopThreadSync()
        //{
        //    status = false;
        //    statusThread = false;
        //}
    }
}

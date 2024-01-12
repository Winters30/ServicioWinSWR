using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ServiceSWR
{
    public partial class ServiceSwr : ServiceBase
    {
        private Timer myTimer;

        public ServiceSwr()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            //Timer para el control del tiempo entre llamadas.
            myTimer = new Timer
            {
                //Intervalo de tiempo entre llamadas.
                Interval = 3000
            };
            //Evento a ejecutar cuando se cumple el tiempo.
            myTimer.Elapsed += new System.Timers.ElapsedEventHandler(MyTimer_Elapsed);
            //Habilitar el Timer.
            myTimer.Enabled = true;

        }

        protected override void OnStop()
        {

            myTimer.Enabled = false;

        }

        void MainQueries()
        {

            try
            {

                using (SWREntities db = new SWREntities())
                {

                    int diasEliminacion = 0; //variable donde asignamos los dias de eliminacion dados desde la tabla CIUDADES_TIPO_RECOGIDAS
                    int diasFinalizacion = 0; //variable donde asignamos los dias de finalizacion dados desde la tabla CIUDADES_TIPO_RECOGIDAS

                    DateTime fechaOptmizacion = DateTime.Now; //Variable donde asignaremos la fechaOptimicacion dada desde la tabla RUTAS, por defecto cogemos fecha actual
                    DateTime fechaIncorporacion = DateTime.Now; //Variable donde asignaremos la fechaOptimicacion dada desde la tabla RUTAS, por defecto cogemos fecha actual
                    bool FechaOptimizacionNull = false;

                    TimeSpan difFechasFinalizadas = DateTime.Now - fechaOptmizacion; //Creamos variable de tipo TimeSpan para restar las fechas inicializada a 0
                    int diasFinalizada = 0; //Variable para saber los dias que lleva finalizada la ruta

                    TimeSpan difFechasEliminadas = DateTime.Now - fechaIncorporacion; //Creamos variable de tipo TimeSpan para restar las fechas inicializada a 0             
                    int diasEliminada = 0; //Variable para saber los dias que lleva finalizada la ruta


                    var lst = db.RUTAS;

                    foreach (var oRutas in lst)
                    {
                        Console.WriteLine(oRutas.IDESTADO);

                        if (oRutas.FECHA_OPTIMIZACIÓN == null)
                        {
                            FechaOptimizacionNull = true;
                        }

                        fechaOptmizacion = Convert.ToDateTime(oRutas.FECHA_OPTIMIZACIÓN); //Sacamos la fecha optimizacion convertida a DateTime
                        fechaIncorporacion = Convert.ToDateTime(oRutas.FECHA_INCORPORACION); //Sacamos la fecha incorporacion convertida a DateTime

                        difFechasFinalizadas = DateTime.Now - fechaOptmizacion; //Diferencia entre fecha actual y finalizada para despues comprobar
                        difFechasEliminadas = DateTime.Now - fechaIncorporacion; ////Diferencia entre fecha actual y eliminada para despues comprobar

                        diasFinalizada = difFechasFinalizadas.Days; //Pasamos a dias el tiempo que lleva desde que se optimizo la ruta hasta la fecha actual
                        diasEliminada = difFechasEliminadas.Days; //Pasamos a dias el tiempo que lleva desde que su fecha de incorporacion hasta la fecha actual

                        CIUDADES_TIPO_RECOGIDAS ctr = db.CIUDADES_TIPO_RECOGIDAS.Where(d => d.IDCIUDAD == oRutas.IDCIUDAD).First(); //Consulta para traer los dias desde la tabla CIUDADES_TIPO_RECOGIDAS con el IDCIUDAD

                        diasEliminacion = (int)ctr.DIAS_ELIMINACION;  //Asignamos los dias eliminacion
                        diasFinalizacion = (int)ctr.DIAS_FINALIZACION;  //Asignamos los dias finalizacion

                        //Comparamos los dias y hacemos update si los dias de finalicacion de la tabla es menor que diasque han pasado desde la fecha
                        //optimizacion ponemos el estado en finalizado =6

                        if (diasFinalizacion < diasFinalizada && FechaOptimizacionNull == false )
                        {
                            oRutas.IDESTADO = 6;
                            db.Entry(oRutas).State = System.Data.Entity.EntityState.Modified;

                        }

                        //Comparamos los dias y hacemos update si los dias de eliminacion de la tabla es menor que dias que han pasado desde la fecha incorporacion
                        // o esta a null la fechaoptimizacion, cambiamos estado a eliminada 7

                        else if (diasEliminacion < diasEliminada && FechaOptimizacionNull == true)
                        {
                            oRutas.IDESTADO = 7;
                            db.Entry(oRutas).State = System.Data.Entity.EntityState.Modified;

                        }

                    }

                    db.SaveChanges();

                }

            }
            catch (Exception ex)
            {
                //Atrapamos el error y lo guardamos en el archivo habilitado para ello

                string path = "@C:\\Users\\USUARIO\\Desktop\\ASP-MVC\\ServiceSWR\\LogErrors";
                Log oLog = new Log(path);
                oLog.Add("" + ex);

            }

        }

        void MyTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
            //Detiene el Timer
            myTimer.Enabled = false;
            //llama a la funcion principal
            MainQueries();
            //habilita el Timer nuevamente.
            myTimer.Enabled = true;
    }

        //Para las pruebas de depuracion, solo entra si tenemos salida modo aplicacion de consola
        internal void TestStartupAndStop(string[] args)
        {
            this.OnStart(args);
            Console.ReadLine();
            this.OnStop();
        }


        


    }
}

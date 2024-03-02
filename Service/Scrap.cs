using scrap.Connection;
using scrap.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace scrap.Service
{
    internal class Scrap
    {
        private System.Timers.Timer aTimer;
        List<string> urls = new List<string> { "ssds", "cpus", "motherboards", "gpus", "rams", "psus", "cases", "cpucoolers", "displays" };

        public Scrap()
        {
            //SetTimer();
            AddData();
        }

        private void SetTimer()
        {
            aTimer = new System.Timers.Timer(500000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            AddData();
        }
        public void AddData()
        {
            var modelDictionary = new Dictionary<string, dynamic>
            {
                { "ssds", new { Service = new ServiceScrap<ModelosSsd>("ssds"), Connection = new Conexion<ModelosSsd>() } },
                { "cpus", new { Service = new ServiceScrap<ModeloCpu>("cpus"), Connection = new Conexion<ModeloCpu>() } },
                { "gpus", new { Service = new ServiceScrap<ModeloGpu>("gpus"), Connection = new Conexion<ModeloGpu>() } },
                { "cases", new { Service = new ServiceScrap<ModeloCase>("cases"), Connection = new Conexion<ModeloCase>() } },
                { "cpucoolers", new { Service = new ServiceScrap<ModeloCooler>("cpucoolers"), Connection = new Conexion<ModeloCooler>() } },
                { "displays", new { Service = new ServiceScrap<ModeloMonitor>("displays"), Connection = new Conexion<ModeloMonitor>() } },
                { "motherboards", new { Service = new ServiceScrap<ModeloPlacas>("motherboards"), Connection = new Conexion<ModeloPlacas>() } },
                { "psus", new { Service = new ServiceScrap<ModeloPsu>("psus"), Connection = new Conexion<ModeloPsu>() } },
                { "rams", new { Service = new ServiceScrap<ModeloRam>("rams"), Connection = new Conexion<ModeloRam>() } },
            };

            foreach (var urlbase in urls)
            {
                if (modelDictionary.TryGetValue(urlbase, out var model))
                {
                    var nuevosComponentes = model.Service.Servicio();
                    AddComponentes(model.Connection, nuevosComponentes);
                }
                Console.WriteLine("Terminado: " + urlbase);
            }
        }

        private void AddComponentes<T>(Conexion<T> conexion, List<T> nuevosComponentes) where T : IModelo
        {
            foreach (var componente in nuevosComponentes)
            {
                if (componente.Precio != "")
                {
                    float? price = float.Parse(componente.Precio);

                    conexion.InsertData(componente);
                    Console.WriteLine($"{componente.Nombre}\n{price}\n{componente.Descripcion}");
                }
            }
        }
    }
}

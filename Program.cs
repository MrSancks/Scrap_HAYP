using scrap.Connection;
using scrap.Model;
using scrap.Service;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Iniciando la aplicación...");

        
        var connections = new List<dynamic>
        {
            new Conexion<ModeloCpu>(),
            new Conexion<ModelosSsd>(),
            new Conexion<ModeloGpu>(),
            new Conexion<ModeloCase>(),
            new Conexion<ModeloCooler>(),
            new Conexion<ModeloMonitor>(),
            new Conexion<ModeloPlacas>(),
            new Conexion<ModeloPsu>(),
            new Conexion<ModeloRam>(),

        };

        var scrap = new Scrap();
        
            scrap.AddData();

        Console.WriteLine("\nPresiona la tecla Enter para salir de la aplicación...\n");
        Console.ReadLine();
        Console.WriteLine("Terminando la aplicación...");
    }
}

using System;
using Prccss;
using Estado;
using Writer;
using Empldata;
using Nums;
using Out;

namespace Main
{
    class Program
    {
        static Procesos Init = new Procesos();
        static Block State = new Block();
        static Escritura Escribir = new Escritura();
        static Dataemploy Empleados = new Dataemploy();
        static Numericos Sueldos = new Numericos();
        static Output Salida = new Output();

        static void Main(string[] args)
        {
            Console.Title = "Tercer Desafio Practico";
            String[] datosadmin = Init.Inicio();
            int bloq = State.Bloqueo(datosadmin);
            datosadmin[2] = bloq.ToString();
            Escribir.Write(datosadmin, "admindata", "datadmin.dll");
            if (bloq < 1)
            {
                Console.WriteLine("Usuario bloqueado, presione cualquier tecla para salir.");
            }
            else
            {
                String[,] datosempl = Empleados.Wordemploy();
                Double[,] salarios = Sueldos.Calculos(datosempl);
                String[] mayormenor = Sueldos.Mymn300(salarios, datosempl);
                Salida.Escriturafinal(datosempl, salarios, mayormenor);
            }
            Console.WriteLine("Gracias por utilizar nuestros servicios, presione cualquier tecla para salir.");
            Console.ReadKey();
        }
    }
}
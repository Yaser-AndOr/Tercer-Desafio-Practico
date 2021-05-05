using System;
using System.IO;

namespace Prccss
{
    class Procesos
    {
        static StreamReader Leer;
        static StreamWriter Escribir;

        public String[] Inicio()
        {
            String txtcmplt = "";
            String[] wrdmn = new String[0];
            int tamaño = 0, f = 0;
            String directorio = Path.GetFullPath(@"admindata");
            String drcttxt = Path.GetFullPath(@"admindata\datadmin.dll");
            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }
            directorio = Path.GetFullPath(@"calculoEmple");
            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }
            directorio = Path.GetFullPath(@"hist");
            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }
            directorio = Path.Combine("c:");
            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }
            if (!File.Exists(drcttxt))
            {
                Escribir = new StreamWriter(drcttxt, true);
                Escribir.Write("Admin, Contra, 3");
                Escribir.Close();
            }
            Leer = new StreamReader(drcttxt, true);
            txtcmplt = Leer.ReadToEnd();
            tamaño = txtcmplt.Split(',').Length;
            if (tamaño < 3 || tamaño > 3)
            {
                File.Delete(drcttxt);
                Escribir = new StreamWriter(drcttxt, true);
                Escribir.Write("Admin, Contra, 3");
                Escribir.Close();
            }
            wrdmn = new String[tamaño];
            foreach (String cache in txtcmplt.Split(','))
            {
                wrdmn[f] = cache.Trim();
                f++;
            }
            f = 0;
            Leer.Close();
            int x = 0;
            if (!int.TryParse(wrdmn[2], out x))
            {
                Console.WriteLine("Fake");
                File.Delete(drcttxt);
                Escribir = new StreamWriter(drcttxt, true);
                Escribir.Write("Admin, Contra, 3");
                Escribir.Close();
                Leer = new StreamReader(drcttxt, true);
                txtcmplt = Leer.ReadToEnd();
                tamaño = txtcmplt.Split(',').Length;
                wrdmn = new String[tamaño];
                foreach (String cache in txtcmplt.Split(','))
                {
                    wrdmn[f] = cache.Trim();
                    f++;
                }
                Leer.Close();
            }
            return wrdmn;
        }
    }
}
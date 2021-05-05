using System;
using System.IO;

namespace Writer
{
    class Escritura
    {
        static StreamWriter Escribir;

        public void Write(String[] datos, String carpeta, String archivo)
        {
            String txtcmplt = "";
            String[] wrdmn = new String[0];
            int tamaño = 0, f = 0;
            String directorio = Path.GetFullPath(@"" + carpeta);
            String drcttxt = Path.GetFullPath($@"{carpeta}\{archivo}");
            File.Delete(drcttxt);
            Escribir = new StreamWriter(drcttxt, true);
            foreach (String cache in datos)
            {
                if (f < datos.Length - 1)
                    Escribir.Write(datos[f] + ", ");
                if (f >= datos.Length - 1)
                    Escribir.Write(datos[f]);
                f++;
            }
            tamaño = txtcmplt.Split(',').Length;
            wrdmn = new String[tamaño];
            Escribir.Close();
        }
    }
}
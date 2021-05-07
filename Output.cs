using System;
using System.IO;
using System.IO.Compression;

namespace Out
{
    class Output
    {
        static StreamWriter Escribir;
        public void Escriturafinal(String[,] datos, Double[,] salarios, String[] maymen)
        {
            String[] complementos = { "Nombre del empleado: ", "Cargo del empleado: ", "Código del empleado: ",
                "Horas trabajadas: ", "ISSS: $", "AFP: $", "RENTA: $", "Sueldo L: $", "Sueldo N: $", "Bonos: $"};
            String[,] cadenasalida = new String[3, 10];

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (y < 3)
                    {
                        cadenasalida[x, y] = datos[x, y];
                    }
                    else
                    {
                        cadenasalida[x, y] = salarios[x, y - 3].ToString();
                    }
                }
            }

            String localdate = "calculoSalario_" + DateTime.Today.Day + DateTime.Today.Month + DateTime.Today.Year + "_" + DateTime.Now.Hour + DateTime.Now.Minute;
            String drcttxt = Path.GetFullPath($@"calculoEmple\{localdate}.txt");
            String cachetxt = Path.Combine($@"c:\{localdate}\{localdate}.txt"), strache = "", outputg = "";
            Escribir = new StreamWriter(drcttxt, true);

            for (int x = 0, y = 0; x < 3; x++)
            {
                for (y = 0; y < 10; y++)
                {
                    if (y < 9)
                    {
                        outputg = complementos[y] + cadenasalida[x, y] + "\n";
                    }
                    else
                    {
                        if (salarios[x, 6] <= 0)
                        {
                            outputg = "No hay bonos.\n";
                        } else
                        {
                            outputg = complementos[y] + cadenasalida[x, y] + "\n";
                        }
                    }
                    Escribir.Write(outputg);
                    strache += outputg;
                    Console.Write(outputg);
                }
                Escribir.Write("\n");
                strache += "\n";
                Console.Write("\n");
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }
            Escribir.Write($"{maymen[0]} Gana menos\n{maymen[1]} Gana más\n{maymen[2]} Gana(n) más de $300\n");
            strache += $"{maymen[0]} Gana menos\n{maymen[1]} Gana más\n{maymen[2]} Gana(n) más de $300\n";
            Console.Write($"{maymen[0]} Gana menos\n{maymen[1]} Gana más\n{maymen[2]} Gana(n) más de $300\n)";
            Escribir.Close();

            Directory.CreateDirectory($@"c:\{localdate}");
            Escribir = new StreamWriter(cachetxt, true);
            Escribir.Write(strache);
            Escribir.Close();
            String ziptxt = Path.GetFullPath($@"hist\{localdate}.zip");
            ZipFile.CreateFromDirectory($@"c:\{localdate}", ziptxt);
            File.Delete($@"c:\{localdate}\{localdate}.txt");
            Directory.Delete($@"c:\{localdate}");
        }
    }
}
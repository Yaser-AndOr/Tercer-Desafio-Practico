using System;

namespace Empldata
{
    class Dataemploy
    {
        public String[,] Wordemploy()
        {
            String[] complementos = { "el nombre", "el cargo", "el código", "las horas trabajadas (valor numérico)" };
            String[,] empleados = new String[3, 4];
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    do
                    {
                        try
                        {
                            Console.WriteLine($"Ingrese {complementos[y]} del empleado {x + 1}");
                            empleados[x, y] = Console.ReadLine();
                            if (y == 3 && int.Parse(empleados[x, y]) < 1)
                            {
                                Console.WriteLine("Error, ingrese una cantidad válida (valor positivo)");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Error de formato, escriba un valor numérico.");
                            empleados[x, y] = 0.ToString();
                        }
                    } while (y == 3 && int.Parse(empleados[x, y]) < 1);
                }
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }
            return empleados;
        }
    }
}
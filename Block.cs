using System;
using Writer;

namespace Estado
{
    class Block
    {
        public int Bloqueo(String[] datos)
        {
            int estado = 0;
            Escritura esc = new Escritura();
            String adminame = "";
            if (int.Parse(datos[2]) > 3)
                datos[2] = "3";
            do
            {
                if (adminame != datos[0])
                    Console.WriteLine("Ingrese correctamente el nombre de usuario");
                Console.WriteLine("Ingrese el nombre de usuario");
                adminame = Console.ReadLine();
            } while (adminame != datos[0]);
            do
            {
                if (int.Parse(datos[2]) < 1)
                {
                    break;
                }
                Console.WriteLine($"Ingrese la contraseña del usuario {datos[0]}");
                adminame = Console.ReadLine();
                if (adminame != datos[1].Trim())
                {
                    datos[2] = (int.Parse(datos[2]) - 1).ToString();
                    esc.Write(datos, "admindata", "datadmin.dll");
                    Console.WriteLine($"Contraseña incorrecta; intentos restantes: {datos[2]}");
                }
                if (int.Parse(datos[2]) < 1)
                {
                    break;
                }
            } while (adminame != datos[1].Trim(' ') && int.Parse(datos[2]) >= 1);
            estado = int.Parse(datos[2]);
            Console.Clear();
            return estado;
        }
    }
}
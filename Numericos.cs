using System;

namespace Nums
{
    class Numericos
    {
        public Double[,] Calculos(String[,] horas)
        {
            Double[,] salarios = new Double[3, 7];
            Double Cache = 0;
            for (int x = 0; x < 3; x++)
            {
                salarios[x, 0] = Double.Parse(horas[x, 3]);
                if (salarios[x, 0] > 160)
                {
                    Cache = (160 * 9.75) + ((salarios[x, 0] - 160) * 11.5);
                }
                else
                {
                    Cache = salarios[x, 0] * 9.75;
                }
                salarios[x, 4] = Math.Truncate((Cache) * 100) / 100;
                salarios[x, 6] = Bonos(horas, salarios[x, 4]);
                salarios[x, 1] = Math.Truncate((salarios[x, 4] * 0.0525) * 100) / 100;
                salarios[x, 2] = Math.Truncate((salarios[x, 4] * 0.0688) * 100) / 100;
                salarios[x, 3] = Math.Truncate((salarios[x, 4] * 0.1) * 100) / 100;
                salarios[x, 5] = salarios[x, 4] - (salarios[x, 1] + salarios[x, 2] + salarios[x, 3]) + salarios[x, 6];
            }
            return salarios;
        }

        private Double Bonos(String[,] Data, Double sb)
        {
            Double bono = 0;
            if (Data[0, 1] == "Gerente" && Data[1, 1] == "Asistente" && Data[2, 1] == "Secretaria")
            {
                for (int x = 0; x < 3; x++)
                    bono = 0;
            }
            else
            {
                for (int x = 0; x < 3; x++)
                {
                    if (Data[x, 1] == "Gerente")
                    {
                        bono = sb * 0.1;
                    }
                    else if (Data[x, 1] == "Asistente")
                    {
                        bono = sb * 0.05;
                    }
                    else if (Data[x, 1] == "Asistente")
                    {
                        bono = sb * 0.03;
                    }
                    else
                    {
                        bono = sb * 0.02;
                    }
                }
            }
            return bono;
        }
    }
}
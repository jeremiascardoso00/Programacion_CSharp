using System;

namespace practica1parcial1
{
    class Program
    {
        static void Main(string[] args)
        {
            Fechas fechas = new Fechas();

            DateTime fechaCumpleaños = new DateTime(2020, 09, 09);
            Console.WriteLine($"Mi cumpleaños es el {fechaCumpleaños.ToShortDateString()}");
            Console.WriteLine($"Para mi cumpleaños faltan {fechas.obtenerDiasCalendario(DateTime.Now, fechaCumpleaños)} días");

            Console.WriteLine($"Dias laborales entre {DateTime.Now.ToShortDateString()} y {fechaCumpleaños.ToShortDateString()}: {fechas.obtenerDiasLaborales(DateTime.Now, fechaCumpleaños)}");
        }
    }

    class Fechas
    {
        // Obtiene los dias entre dos fechas
        public int obtenerDiasCalendario(DateTime dt1, DateTime dt2)
        {
            TimeSpan ts = dt2 - dt1;
            return ts.Days;
        }

        // Obtiene los días laborales entre dos fechas
        public int obtenerDiasLaborales(DateTime firstDate, DateTime lastDate, params DateTime[] holidayBank)
        {
            /* Sacamos las fechas de cada datetime pasado. */

            firstDate = firstDate.Date;
            lastDate = lastDate.Date;

            TimeSpan total = GetTimeSpanBetweenTwoDates(firstDate, lastDate);

            /* Sacamos el total de dias entre las 2 fechas y sumamos 1 para contar el dia por el cual empezamos. */

            int businessDays = total.Days + 1;

            /* Sacamos el total de semanas diviendo el total de dias por siete. (total de dias en una semana) */

            int totalWeeks = businessDays / 7;

            /* Condicional para filtrar los fin de semana del total de businessDays, que cuenta tanto dias laborales como no laborales:  */

            if (businessDays > totalWeeks * 7)
            {

                /* Sacamos el dia que es de los parametros que son pasados a la funcion, si es domingo, para contemplar la logica usada en el programa,
                 * contemplamos que domingo sea igual a 7 en vez de su valor real (DayofWeek.Sunday == 0)
                 */

                int firstDayOfWeek = GetDayOfWeek(firstDate);
                int lastDayOfWeek = GetDayOfWeek(lastDate);

                /* Determinamos si hay algun fin de semana que puede ser de 1 dia (es domingo) o 2 dias (es sabado). */

                /* firstDayOfWeek = 3 (Miercoles), lastDayOfWeek = 2 (Martes) empezamos a contar desde la proxima semana (lastDayOfWeek += 7) */

                if (lastDayOfWeek < firstDayOfWeek)
                {
                    lastDayOfWeek += 7;
                }

                if (firstDayOfWeek <= 6)
                {
                    if (lastDayOfWeek >= 7) // Sabado y domingo estan en lo que queda del intervalo.
                    {
                        businessDays -= 2;
                    }
                    else if (lastDayOfWeek >= 6) // solo sabado queda en el intervalo.
                    {
                        businessDays -= 1;
                    }
                }
                else if (firstDayOfWeek <= 7 && lastDayOfWeek >= 7) // Solo queda un domingo en el intervalo
                {
                    businessDays -= 1;
                }
            }
            businessDays -= totalWeeks + totalWeeks;

            /* Restamos todos los dias feraidos recibidos como params. asegurandonos que no restamos el mismo dia 2 veces con IsWeekendDay: */

            foreach (var holiday in holidayBank)
            {

                DateTime holidayDate = holiday.Date;
                if (firstDate <= holidayDate && holidayDate <= lastDate && !(IsWeekendDay(holidayDate)))
                {
                    --businessDays;
                }
            }

            return businessDays;
        }

        private static bool IsWeekendDay(DateTime dt)
        {
            return dt.DayOfWeek == DayOfWeek.Sunday || dt.DayOfWeek == DayOfWeek.Saturday;
        }

        private static TimeSpan GetTimeSpanBetweenTwoDates(DateTime dt1, DateTime dt2)
        {
            return dt2 - dt1;
        }

        private static int GetDayOfWeek(DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)dateTime.DayOfWeek;
        }




        // obtiene una fecha sumando una cantidad de dias a una fecha inicial
        private static DateTime sumarDiasLaborales(DateTime date, int workingDays)
        {

            while (workingDays > 0)
            {

                date = date.AddDays(1);

                if (!IsWeekendDay(date))
                {
                    workingDays -= 1;
                }
            }

            return date;
        }
    }
}

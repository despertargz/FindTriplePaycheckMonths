using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTriplePaycheckMonths
{
    class Program
    {
        static Dictionary<int, int> PaychecksPerMonth = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            Console.Write("Enter Any Paycheck Date: ");
            string payDateStr = Console.ReadLine();
            var payDate = DateTime.Parse(payDateStr);
            PaychecksPerMonth[payDate.Month] = 1;
          
            FindPaychecksPerMonth(payDate, -14);
            FindPaychecksPerMonth(payDate, 14);

            Console.WriteLine();
            foreach (var pair in PaychecksPerMonth.OrderBy(o => o.Key).Where(o => o.Value > 2))
            {
                string mon = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(pair.Key);
                Console.WriteLine(mon);
            }

            Console.WriteLine();
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        static void FindPaychecksPerMonth(DateTime startingPayDate, int dayChange, bool print = false)
        {
            DateTime payDate = startingPayDate;

            while (true)
            {
                payDate = payDate.AddDays(dayChange);

                if (payDate.Year != startingPayDate.Year)
                {
                    break;
                }

                if (!PaychecksPerMonth.ContainsKey(payDate.Month))
                {
                    PaychecksPerMonth[payDate.Month] = 0;
                }

                PaychecksPerMonth[payDate.Month]++;

                if (print)
                {
                    Console.WriteLine(payDate);
                }
            }
        }
    }
}

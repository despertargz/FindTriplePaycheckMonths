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
        static void Main(string[] args)
        {
            Console.Write("Enter Any Paycheck Date: ");
            string payDateStr = Console.ReadLine();

            var payDate = DateTime.Parse(payDateStr);
            var originalPayDate = payDate;
            int startingYear = payDate.Year;

            Dictionary<int, int> paychecksPerMonth = new Dictionary<int, int>();
            paychecksPerMonth[payDate.Month] = 1;
            
            while (true)
            {
                payDate = payDate.Subtract(TimeSpan.FromDays(14));

                if (payDate.Year != startingYear)
                {
                    break;
                }
                else
                {
                    if (!paychecksPerMonth.ContainsKey(payDate.Month))
                    {
                        paychecksPerMonth[payDate.Month] = 0;
                    }

                    paychecksPerMonth[payDate.Month]++;
                }
            }

            payDate = originalPayDate;

            while (true)
            {
                payDate = payDate.Add(TimeSpan.FromDays(14));

                if (payDate.Year != startingYear)
                {
                    break;
                }
                else
                {
                    if (!paychecksPerMonth.ContainsKey(payDate.Month))
                    {
                        paychecksPerMonth[payDate.Month] = 0;
                    }

                    paychecksPerMonth[payDate.Month]++;
                }
            }

            Console.WriteLine();
            foreach (var pair in paychecksPerMonth.OrderBy(o => o.Key).Where(o => o.Value > 2))
            {
                string mon = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(pair.Key);
                Console.WriteLine(mon);
            }

            Console.WriteLine();
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}

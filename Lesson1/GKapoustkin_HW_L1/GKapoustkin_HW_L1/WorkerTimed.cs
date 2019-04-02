using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GKapoustkin_HW_L1
{
    class WorkerTimed : Worker
    {
        double hoursalary = 300;
        public WorkerTimed(string name, double salary) : base(name) { }
        //метод возвращает расчёт зарплаты согласно трудочасам для всех рабочих на повременной оплате
        public override double SalaryCount()
        {
            Salary = 20.8 * 8 * hoursalary;
            return Salary;
        }
        public override void Summary()
        {
            Console.WriteLine("Имя работника: " + Name + ", повременная ставка " + Salary + " р.");
        }
    }
}
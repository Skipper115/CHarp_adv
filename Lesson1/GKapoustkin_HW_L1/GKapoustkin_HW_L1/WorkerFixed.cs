using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GKapoustkin_HW_L1
{
    class WorkerFixed : Worker
    {
        double fixedsalary = 35000;
        public WorkerFixed(string name, double salary) : base(name) { }
        //метод возвращает единую ставку для всех рабочих на полном рабочем дне
        public override double SalaryCount()
        {
            Salary = fixedsalary;
            return Salary;
        }

        public override void Summary()
        {
            Console.WriteLine("Имя работника: " + Name + ", постоянный оклад " + Salary + " р.");
        }
    }
}

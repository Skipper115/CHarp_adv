using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GKapoustkin_HW_L1
{
    abstract class Worker
    {

        protected string Name; //имя работника
        protected double Salary; // зарплата
        

        protected Worker(string name)
        {
            Name = name;
                   
        }

        public abstract double SalaryCount();
        public abstract void Summary();

    }   
}

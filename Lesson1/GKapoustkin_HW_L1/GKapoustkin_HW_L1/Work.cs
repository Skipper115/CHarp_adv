using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GKapoustkin_HW_L1
{
    static class Work
    {
        static Work() { }
        // здесь создаётся список рабочих:
        private static Worker[] _worker;


        public static void Load() //первичное заполнение массива фамилиями
        {
            _worker = new Worker[5];
            _worker[0] = new WorkerFixed("Иванов", 0);
            _worker[1] = new WorkerFixed("Петров", 0);
            _worker[2] = new WorkerFixed("Сидоров", 0);
            _worker[3] = new WorkerTimed("Соколов", 0);
            _worker[4] = new WorkerTimed("Огурцов", 0);
        }

        public static void ProcessWorkers()
        {
            foreach (Worker iworker in _worker)
            {
                iworker.SalaryCount();
                iworker.Summary();
                
            }
        }
    }
}

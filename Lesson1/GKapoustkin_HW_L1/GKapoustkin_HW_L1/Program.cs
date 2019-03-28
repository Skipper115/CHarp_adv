using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace GKapoustkin_HW_L1
{
    class Program
    {
        // Григорий Капусткин, C# продвинутый курс, урок 1, ДЗ.
        // Добавить свои объекты в иерархию объектов, чтобы получился красивый задний фон, похожий на полет в звездном пространстве.
        // * Заменить кружочки картинками, используя метод DrawImage. + 
        static void Main(string[] args)
        {
            Form form = new Form();
            form.Width = 800;
            form.Height = 600;
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }
}

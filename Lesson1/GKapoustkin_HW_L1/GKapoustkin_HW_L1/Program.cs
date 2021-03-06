﻿using System;
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

        // Дополнено согласно урока 2:
        // у2-1 Построить  три  класса  (базовый  и  2  потомка),  описывающих  работников  с  почасовой  оплатой  
        // (один  из  потомков)  и  фиксированной оплатой (второй потомок): (Worker + WorkerFixed, WorkerTimed) +
        // а) Описать в базовом классе абстрактный метод для расчета среднемесячной заработной платы.
        // Для «повременщиков» формула для расчета такова: «среднемесячная заработная плата = 20.8 * 8 * почасовая ставка»;
        // (добавлено поле time, отображающее количество отработанных часов, повременщики - они такие, 8 заменено на time)
        // для работников  с фиксированной  оплатой: «среднемесячная заработная плата = фиксированная месячная оплата»; +
        // б) Создать на базе абстрактного класса массив сотрудников и заполнить его;

        // у2-2 Переделать виртуальный метод Update в BaseObject в абстрактный и реализовать его в наследниках + 
        // у2-3 Сделать так, чтобы при столкновении пули с астероидом они регенерировались в разных концах экрана + 
        // у2-4 Сделать проверку на задание размера экрана в классе Game. Если высота или ширина (Width, Height) больше 1000 
        // или принимает отрицательное значение, выбросить исключение ArgumentOutOfRangeException(). +(Критерием проверки 
        // задан размер по любой из сторон меньше 100. Для удобства. Но в классе Game можно менять условия на желаемые.)
        // у2-5 Добавлен свой класс исключений SizeException. + (Проверка в Game, метод Load)


        static void Main(string[] args)
        {
            #region//второй урок, задача с зарплатами работниками двух типов
            Work.Load();
            Work.ProcessWorkers();
            Console.ReadKey();
            Console.Clear();
            #endregion

            //1+2 урок, поле астероидов
            Form form = new Form()
            {
                Width = Screen.PrimaryScreen.Bounds.Width,
                Height = Screen.PrimaryScreen.Bounds.Height
            };
            //form.Width = 800;
            //form.Height = 600;
            Game.Init(form);
            
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }
}

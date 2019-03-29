using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GKapoustkin_HW_L1
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        // свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game() { }

        // тот самый основной метод INIT
        public static void Init(Form form)
        {
            // Графичесоке устройство для вывода графики
            Graphics g;
            // по слухам, предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создание объекта (поверхности рисования), связывание его с формой
            // Запоминание размеров формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связывание буфера в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            // вызов метода Load, чтобы всё заработало:
            Load();

            //таймер 
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
           
        }


        //Дальше - методы.

        //метод - обработчик таймера
        private static void Timer_Tick(object sender, EventArgs e)
        { Draw(); Update(); }

        //метод Draw
        public static void Draw()
        {
            //,проверяем вывод графики
            //Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            //Buffer.Render();
            //вывод на экран
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
           // foreach (BaseObject obj in _streaks)
           //    obj.Draw();

            Buffer.Render();
        }
        //метод Update для изменения состояния объектов
        public static void Update()
        {
            foreach (BaseObject obj in _objs) obj.Update();
        //    foreach (BaseObject streak in _streaks) streak.Update();
        }

        // здесь создаются массивы объектов.
        public static BaseObject[] _objs;
       // public static BaseObject[] _streaks;
        // метод Load - должен инициализировать объекты
        public static void Load()
        {
            _objs = new BaseObject[50];
            for (int i = 0; i < 15; i++)
                _objs[i] = new ImageStar(new Point(600, i * 20), new Point(- i, -i), new Size(20, 20));
            for (int i =  15; i < 30; i++)
                _objs[i] = new Star(new Point(600, i * 20), new Point(-i, 0), new Size(5, 5));
            for (int i = 30; i < _objs.Length; i++)
            {
                Random random = new Random();
                int Speed = random.Next(15, 45);
                int StreakX = random.Next(0, Width);
                int StreakY = random.Next(0, Height);
                _objs[i] = new Starstreak(new Point(StreakX, StreakY), new Point(Speed, -i), new Size(Speed, Speed));
            }

          //  _streaks = new BaseObject[20];
          //  for (int i = 30; i < _streaks.Length; i++)
          //  {
          //      Random random = new Random();
          //      int Speed = random.Next(0, 45);
          //      int StreakX = random.Next(0, Width);
          //      int StreakY = random.Next(0, Height);
          //      _streaks[i] = new Starstreak(new Point(StreakX , StreakY), new Point(Speed, -i), new Size(Speed, Speed));
          //  }
        }
    }
}

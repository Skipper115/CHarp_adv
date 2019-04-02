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
        // здесь создаются массивы объектов.
        private static BaseObject[] _objs;
        private static Bullet _bullet;
        private static Asteroid[] _asteroids;
        private static BaseObject[] _streaks;

        //самый основной метод INIT
        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики
            Graphics g;
            // по слухам, предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создание объекта (поверхности рисования), связывание его с формой
            // Запоминание размеров формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            if (Width < 100) throw new ArgumentOutOfRangeException();
            if (Height < 100) throw new ArgumentOutOfRangeException();
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
            #region Проверка вывода графики из первого урока
            //,проверяем вывод графики
            //Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            //Buffer.Render();
            //вывод на экран
            #endregion

            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            foreach (Asteroid asteroid in _asteroids)
                asteroid.Draw();
            foreach (Starstreak streak in _streaks)
                streak.Draw();
            _bullet.Draw();

            Buffer.Render();
        }
        //метод Update для изменения состояния объектов
        public static void Update()
        {
            foreach (BaseObject obj in _objs) obj.Update();
            foreach (Starstreak streak in _streaks) streak.Update();
            foreach (Asteroid asteroid in _asteroids)
            {
                asteroid.Update();
                if (asteroid.Collision(_bullet))
                {
                    System.Media.SystemSounds.Hand.Play();
                    asteroid.Reborn();
                    _bullet.Reborn();
                }
            }
            _bullet.Update();
        }

        
        // метод Load - инициализация объектов
        public static void Load()
        {
            #region Load из первого урока
            //_objs = new BaseObject[50];
            //for (int i = 0; i < 15; i++)
            //    _objs[i] = new ImageStar(new Point(600, i * 20), new Point(- i, -i), new Size(20, 20));
            //for (int i =  15; i < 30; i++)
            //    _objs[i] = new Star(new Point(600, i * 20), new Point(-i, 0), new Size(5, 5));
            #endregion
            #region Обновлённый Load из второго урока
            _objs = new BaseObject[30];
            _bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));
            _asteroids = new Asteroid[10];
            _streaks = new Starstreak[25];

            Random random = new Random();

            for (int i = 0; i < _objs.Length; i++) //просто звёзды
            {
                int r = random.Next(5, 50);
                _objs[i] = new Star(new Point(1000, random.Next(0, Game.Height)), new Point(-r, r), new Size(3, 3));
            }
            for (var i = 0; i < _asteroids.Length; i++)  //астероиды
            {
                int r = random.Next(5, 50);
                //проверка работы своего класса исключений
                //if (r < 41) throw new SizeException("Неверные габариты объекта!");
                _asteroids[i] = new Asteroid (new Point(random.Next(400, Game.Width), random.Next(0, Game.Height)), new Point(-r/5, r), new Size(r, r));
                
            }

            for (int i = 0; i < _streaks.Length; i++)  //быстролетящие звёзды
            {
                int Speed = random.Next(15, 45);
                int StreakX = random.Next(0, Width);
                int StreakY = random.Next(0, Height);
                _streaks[i] = new Starstreak(new Point(StreakX, StreakY), new Point(Speed, -i), new Size(Speed, Speed));
            }
            #endregion
         
        }
    }
}

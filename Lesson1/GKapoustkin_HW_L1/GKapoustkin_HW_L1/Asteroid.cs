using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GKapoustkin_HW_L1
{
    class Asteroid : BaseObject, ICloneable
    {
        public int Power { get; set; }
        public Asteroid (Point pos, Point dir, Size size) : base(pos, dir, size)
        { Power = 1; }
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {            
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 1) Reborn();
        }

        public void Reborn()
        {
            Random random = new Random();
            Pos.X = Game.Width-5;
            Pos.Y = random.Next(5, Game.Height - 5);
            //появление в новом месте на правом краю экрана.
        }


        public object Clone() //хз пока зачем оно тут нужно
        {
            Asteroid asteroid = new Asteroid(new Point(Pos.X, Pos.Y), new Point(Dir.X, Dir.Y), new Size(Size.Width, Size.Height));
            asteroid.Power = Power;
            return asteroid;
        }
    }
}

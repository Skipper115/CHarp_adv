using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GKapoustkin_HW_L1
{
    class Bullet : BaseObject
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size) { }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X + 5;
            if (Pos.X > Game.Width)
            {
                Reborn();
            }
        }
        public void Reborn()
        { 
                Random random = new Random();
                Pos.X = 0;
                Pos.Y = random.Next(5, Game.Height - 5);
            //появление в новом месте на левом краю экрана.
        }
    }
}

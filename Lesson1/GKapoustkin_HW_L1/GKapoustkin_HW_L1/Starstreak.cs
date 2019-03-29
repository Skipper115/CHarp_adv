using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GKapoustkin_HW_L1
{
    class Starstreak : BaseObject
    {
        
        public Starstreak(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
         //   Random random = new Random();
         //   int Speed = random.Next(30, 65);
         //   int StreakX = random.Next(0, 600);
         //   int StreakY = random.Next(0, 800);
        }

        public override void Draw()
        {
            
            //Game.Buffer.Graphics.DrawLine(Pens.White, StreakX, StreakY, StreakX+Speed, StreakY);
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y);
            //Game.Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(Pos.X, Pos.Y, Pos.X + Size.Width, 3));
        }
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X*2; //направление движения .
            if (Pos.X < 0)
            {
                Random random = new Random();
                Pos.X = Game.Width + Size.Width;
                Pos.Y = random.Next(0, Game.Height); }//вылет за край экрана
        }

    }
}

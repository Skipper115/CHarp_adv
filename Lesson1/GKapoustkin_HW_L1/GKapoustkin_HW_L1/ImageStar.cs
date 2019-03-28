using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace GKapoustkin_HW_L1
{
    class ImageStar : BaseObject
    {
        public ImageStar(Point pos, Point dir, Size size) : base(pos, dir, size)
        { }

        public override void Draw()
        {
            Image newImage = Image.FromFile("star1.jpg");
            int x = Pos.X;
            int y = Pos.Y;
            int width = Size.Width;
            int height = Size.Height;
            Game.Buffer.Graphics.DrawImage(newImage, x, y, width, height);
        }
      

    // {
    //     Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
    //     Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
    // }
    public override void Update()
        {
            Pos.X = Pos.X - Dir.X; //Должна менять направление движения звёзд.
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
            else if (Pos.X > Game.Width) Pos.X = 0;
        }

    }
}

using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace M_Topic_5___Monster_Class
{
    public class Player
    {
        private Texture2D texture;
        private Rectangle rectangle;
        private Vector2 speed;

        public Player(Texture2D _texture, Rectangle _rectangle, Vector2 _speed) 
        { 
            texture = _texture;
            rectangle = _rectangle;
            speed = _speed;
        }

        public void Offset()
        {
            rectangle.X += (int)speed.X;
            rectangle.Y += (int)speed.Y;
        }
    }
}

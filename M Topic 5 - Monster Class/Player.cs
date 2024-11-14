﻿using Microsoft.Xna.Framework.Graphics;
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

        private int frame = 0;
        private List<Rectangle> sourceRects;

        public Player(Texture2D _texture, Rectangle _rectangle, Vector2 _speed) 
        { 
            texture = _texture;
            rectangle = _rectangle;
            speed = _speed;
        }

        public void Initialize()
        {
            sourceRects = new List<Rectangle>();
            for (int i = 0; i < 3; i++)
            {
                sourceRects.Add(new Rectangle((i * 768), 0, 768, 768));
            }
        }

        public void Offset()
        {
            rectangle.X += (int)speed.X;
            rectangle.Y += (int)speed.Y;
        }

        public void FrameAdvance()
        {
            frame++;
        }

        public void Draw()
        {
            
        }
    }
}

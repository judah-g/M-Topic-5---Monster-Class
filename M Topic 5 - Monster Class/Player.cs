﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_Topic_5___Monster_Class
{
    public class Player
    {
        private Texture2D texture;
        private Rectangle rectangle;
        private Vector2 speed, origin;
        private float rotation;

        private int frame = 0;
        private List<Rectangle> sourceRects;

        public Player(Texture2D _texture, Rectangle _rectangle, Vector2 _speed, int _frame, float _rotation) 
        { 
            texture = _texture;
            rectangle = _rectangle;
            speed = _speed;
            frame = _frame;
            rotation = _rotation;
        }

        public int Frame { get { return frame; } }

        public Vector2 Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public Rectangle Rectangle { get { return rectangle; } }

        public Rectangle Source { get { return sourceRects[frame]; } }

        public Texture2D Texture 
        { 
            get { return texture; } 
            set { texture = value; }
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public Vector2 Origin { get { return origin; } }

        public void Initialize()
        {
            sourceRects = new List<Rectangle>();
            for (int i = 2; i > -1; i--)
            {
                sourceRects.Add(new Rectangle((i * 768), 0, 768, 768));
            }

            origin = new Vector2(rectangle.Width / 2, rectangle.Height / 2);
        }

        public void Offset()
        {
            rectangle.X += (int)speed.X;
            rectangle.Y += (int)speed.Y;
        }

        public void FrameAdvance()
        {
            frame++;
            if (frame > 2) { frame = 0; }
        }
    }
}

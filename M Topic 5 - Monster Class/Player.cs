﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace M_Topic_5___Monster_Class
{
    public class Player
    {
        private Texture2D _texture;
        private Rectangle _rectangle;
        private Vector2 _speed, _origin;
        private float _rotation;
        private SpriteEffects _spritebatchEffect;


        private int _frame = 0;
        private List<Rectangle> _sourceRects;

        public Player(Texture2D texture, Rectangle rectangle, Vector2 speed, int frame, float rotation) 
        { 
            _texture = texture;
            _rectangle = rectangle;
            _speed = speed;
            _frame = frame;
            _rotation = rotation;
            _spritebatchEffect = SpriteEffects.None;
            Initialize();

        }

        public bool Intersects(Rectangle rect)
        {
            return _rectangle.Intersects(rect);
        }

        public Vector2 Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Texture2D Texture 
        { 
            get { return _texture; } 
            set { _texture = value; }
        }

        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        public Vector2 Origin { get { return _origin; } }

        public void Initialize()
        {
            _sourceRects = new List<Rectangle>();
            for (int i = 2; i > -1; i--)
            {
                _sourceRects.Add(new Rectangle((i * 768), 0, 768, 768));
            }
        }

        public void Offset(KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Keys.W) && keyboardState.IsKeyDown(Keys.S))
                _speed = new Vector2(_speed.X, 0);
            if (keyboardState.IsKeyDown(Keys.W))
                _speed = new Vector2(_speed.X, -2);
            else if (keyboardState.IsKeyDown(Keys.S))
                _speed = new Vector2(_speed.X, 2);
            else { _speed = new Vector2(_speed.X, 0); }

            if (keyboardState.IsKeyDown(Keys.A) && keyboardState.IsKeyDown(Keys.D))
                _speed = new Vector2(0, _speed.Y);
            else if (keyboardState.IsKeyDown(Keys.A))
                _speed = new Vector2(-2, _speed.Y);
            else if (keyboardState.IsKeyDown(Keys.D))
                _speed = new Vector2(2, _speed.Y);
            else { _speed = new Vector2(0, _speed.Y); }
            if (keyboardState.IsKeyDown(Keys.W) && keyboardState.IsKeyDown(Keys.A) ||
                keyboardState.IsKeyDown(Keys.S) && keyboardState.IsKeyDown(Keys.D))
                _rotation = 0.785398f;
            else if (keyboardState.IsKeyDown(Keys.S) && keyboardState.IsKeyDown(Keys.A) ||
                keyboardState.IsKeyDown(Keys.W) && keyboardState.IsKeyDown(Keys.D))
                _rotation = -0.785398f;
            else if (keyboardState.IsKeyDown(Keys.S))
                _rotation = 1.5708f;
            else if (keyboardState.IsKeyDown(Keys.W))
                _rotation = -1.5708f;
            else if (keyboardState.IsKeyDown(Keys.A) || (keyboardState.IsKeyDown(Keys.D)))
                _rotation = 0;


            _origin = new Vector2(_texture.Width / 2, _texture.Height / 2);      

            _rectangle.X += (int)_speed.X;
            _rectangle.Y += (int)_speed.Y;
            if (_speed.X > 0)
                _spritebatchEffect = SpriteEffects.FlipHorizontally;
           else if (_speed.X < 0)
                _spritebatchEffect= SpriteEffects.None;
        }

        public void FrameAdvance()
        {
            _frame++;
            if (_frame > 2) { _frame = 0; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _rectangle, _sourceRects[_frame], Color.White, _rotation, _origin, _spritebatchEffect, 0f);
        }
    }
}

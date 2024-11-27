using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace M_Topic_5___Monster_Class
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Player player = new Player(null, new Rectangle(0, 0, 50, 50), new Vector2(0, 0), 0, 0);

        Vector2 prevSpeed;
        KeyboardState keyboardState;

        double time;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            player.Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            player.Texture = Content.Load<Texture2D>("pacman-sheet");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            keyboardState = Keyboard.GetState();


            if (keyboardState.IsKeyDown(Keys.W) && keyboardState.IsKeyDown(Keys.S))
                player.Speed = new Vector2(player.Speed.X, 0);
            if (keyboardState.IsKeyDown(Keys.W))
                player.Speed = new Vector2(player.Speed.X, -2);
            else if (keyboardState.IsKeyDown(Keys.S))
                player.Speed = new Vector2(player.Speed.X, 2);
            else { player.Speed = new Vector2(player.Speed.X, 0); }

            if (keyboardState.IsKeyDown(Keys.A) && keyboardState.IsKeyDown(Keys.D))
                player.Speed = new Vector2(0, player.Speed.Y);
            else if (keyboardState.IsKeyDown(Keys.A))
                player.Speed = new Vector2(-2, player.Speed.Y);
            else if (keyboardState.IsKeyDown(Keys.D))
                player.Speed = new Vector2(2, player.Speed.Y);
            else { player.Speed = new Vector2(0, player.Speed.Y); }

            if (player.Speed.X != 0)
                prevSpeed = player.Speed;

            if (keyboardState.IsKeyDown(Keys.W) && keyboardState.IsKeyDown(Keys.A) ||
                keyboardState.IsKeyDown(Keys.S) && keyboardState.IsKeyDown(Keys.D))
                player.Rotation = 0.785398f;
            else if (keyboardState.IsKeyDown(Keys.S) && keyboardState.IsKeyDown(Keys.A) ||
                keyboardState.IsKeyDown(Keys.W) && keyboardState.IsKeyDown(Keys.D))
                player.Rotation = -0.785398f;
            else if (keyboardState.IsKeyDown(Keys.S))
                player.Rotation = 1.5708f;
            else if (keyboardState.IsKeyDown(Keys.W))
                player.Rotation = -1.5708f;
            else if (keyboardState.IsKeyDown(Keys.A) || (keyboardState.IsKeyDown(Keys.D)))
                player.Rotation = 0;

                player.Offset();

            time += gameTime.ElapsedGameTime.TotalSeconds;
            if (time > 0.2)
            { player.FrameAdvance(); time -= 0.2; }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            if (prevSpeed.X == -2)
                _spriteBatch.Draw(player.Texture, player.Rectangle, player.Source, Color.White, player.Rotation,
                player.Origin, SpriteEffects.FlipHorizontally, 0f);
            else
                _spriteBatch.Draw(player.Texture, player.Rectangle, player.Source, Color.White, player.Rotation,
                new Vector2(player.Rectangle.Width / 2, player.Rectangle.Height / 2), SpriteEffects.None, 0f);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

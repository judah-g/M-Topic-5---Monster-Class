using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace M_Topic_5___Monster_Class
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Player player = new Player(null, new Rectangle(0, 0, 50, 50), new Vector2(0, 0), 0);

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

            Window.Title = player.Speed.ToString();

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

            _spriteBatch.Draw(player.Texture, player.Rectangle, player.Source, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

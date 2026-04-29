using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_1._3___Animation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;

        Texture2D brown;
        Texture2D cream;
        Texture2D grey;
        Texture2D orange;

        Rectangle brownRect;
        Rectangle creamRect;
        Rectangle greyRect;
        Rectangle orangeRect;

        Vector2 brownSpeed;
        Vector2 creamSpeed;
        Vector2 greySpeed;
        Vector2 orangeSpeed;

        SoundEffect tribbleCoo;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            brownRect = new Rectangle(0, 0, 200, 170);
            creamRect = new Rectangle(300, 400, 120, 80);
            greyRect = new Rectangle(300, 10, 100, 100);
            orangeRect = new Rectangle(500, 200, 220, 220);

            brownSpeed = new Vector2(-2, 0);
            creamSpeed = new Vector2(2, -2);
            greySpeed = new Vector2(3, 4);
            orangeSpeed = new Vector2(9, -9);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            brown = Content.Load<Texture2D>("tribbleBrown");
            cream = Content.Load<Texture2D>("tribbleCream");
            grey = Content.Load<Texture2D>("tribbleGrey");
            orange = Content.Load<Texture2D>("tribbleOrange");
            tribbleCoo = Content.Load<SoundEffect>("tribble_coo");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            brownRect.X += (int)brownSpeed.X;
            brownRect.Y += (int)brownSpeed.Y;
            creamRect.X += (int)creamSpeed.X;
            creamRect.Y += (int)creamSpeed.Y;
            greyRect.X += (int)greySpeed.X;
            greyRect.Y += (int)greySpeed.Y;
            orangeRect.X += (int)orangeSpeed.X;
            orangeRect.Y += (int)orangeSpeed.Y;

            if (brownRect.Right > window.Width || brownRect.Left < 0)
            {
                brownSpeed.X *= -1;
            }
            if (brownRect.Bottom > window.Height || brownRect.Top < 0)
            {
                brownSpeed.Y *= -1;
            }

            if (creamRect.Right > window.Width || creamRect.Left < 0)
            {
                creamSpeed.X *= -1;
            }
            if (creamRect.Bottom > window.Height || creamRect.Top < 0)
            {
                creamSpeed.Y *= -1;
            }

            if (greyRect.Right > window.Width || greyRect.Left < 0)
            {
                greySpeed.X *= -1;
            }
            if (greyRect.Bottom > window.Height || greyRect.Top < 0)
            {
                greySpeed.Y *= -1;
            }

            if (orangeRect.Right > window.Width || orangeRect.Left < 0)
            {
                orangeSpeed.X *= -1;
            }
            if (orangeRect.Bottom > window.Height || orangeRect.Top < 0)
            {
                orangeSpeed.Y *= -1;
            }

            if (brownRect.Right > window.Width || brownRect.X < 0)
            {
                brownSpeed.X *= -1;
                tribbleCoo.Play();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BlanchedAlmond);

            _spriteBatch.Begin();
            _spriteBatch.Draw(brown, brownRect, Color.White);
            _spriteBatch.Draw(cream, creamRect, Color.White);
            _spriteBatch.Draw(grey, greyRect, Color.White);
            _spriteBatch.Draw(orange, orangeRect, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

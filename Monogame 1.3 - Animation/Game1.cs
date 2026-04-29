using Microsoft.Xna.Framework;
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

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            window = new Rectangle(0, 0, 800, 600);

            brownRect = new Rectangle(0, 0, 200, 170);
            creamRect = new Rectangle(300, 400, 120, 80);
            greyRect = new Rectangle(300, 10, 100, 100);
            orangeRect = new Rectangle(500, 200, 220, 220);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            brown = Content.Load<Texture2D>("tribbleBrown");
            cream = Content.Load<Texture2D>("tribbleCream");
            grey = Content.Load<Texture2D>("tribbleGrey");
            orange = Content.Load<Texture2D>("tribbleOrange");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

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

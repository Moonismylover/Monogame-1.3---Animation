using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using Microsoft.Xna.Framework.Input;
using System.Data.Common;
using System;

namespace Monogame_1._3___Animation
{
    public class Game1 : Game
    {
        enum Screen
        {
            Intro,
            TribbleYard,
            End
        }

        Screen screen;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;

        Texture2D brown;
        Texture2D cream;
        Texture2D grey;
        Texture2D orange;
        Texture2D tribbleIntro;

        Rectangle brownRect;
        Rectangle creamRect;
        Rectangle greyRect;
        Rectangle orangeRect;

        Vector2 brownSpeed;
        Vector2 creamSpeed;
        Vector2 greySpeed;
        Vector2 orangeSpeed;

        Color bgColor = Color.Black;
        Color creamColor = Color.White;
        Color greyColor = Color.White;  

        SoundEffect tribbleCoo;

        float seconds;
        Random generator = new Random();

        MouseState mouseState;

        SpriteFont Text;
        SpriteFont Text_two;
        SpriteFont Text_three;

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

            brownSpeed = new Vector2(2, 0);
            creamSpeed = new Vector2(1, 1);
            greySpeed = new Vector2(3, 4);
            orangeSpeed = new Vector2(5, -5);

            brownRect.X = generator.Next(0, window.Width - brownRect.Width);
            brownRect.Y = generator.Next(0, window.Height - brownRect.Height);
            creamRect.X = generator.Next(0, window.Width - creamRect.Width);
            creamRect.Y = generator.Next(0, window.Height - creamRect.Height);
            greyRect.X = generator.Next(0, window.Width - greyRect.Width);
            greyRect.Y = generator.Next(0, window.Height - greyRect.Height);
            orangeRect.X = generator.Next(0, window.Width - orangeRect.Width);  
            orangeRect.Y = generator.Next(0, window.Height - orangeRect.Height);

            screen = Screen.Intro;

            seconds = 0;

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
            tribbleIntro = Content.Load<Texture2D>("tribble_intro");
            Text = Content.Load<SpriteFont>("Text");
            Text_two = Content.Load<SpriteFont>("Text_two");    
            Text_three = Content.Load<SpriteFont>("Text_three");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mouseState = Mouse.GetState();

            seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.TribbleYard;
            }
            else if (screen == Screen.TribbleYard)
            {
                brownRect.X += (int)brownSpeed.X;
                brownRect.Y += (int)brownSpeed.Y;
                creamRect.X += (int)creamSpeed.X;
                creamRect.Y += (int)creamSpeed.Y;
                greyRect.X += (int)greySpeed.X;
                greyRect.Y += (int)greySpeed.Y;
                orangeRect.X += (int)orangeSpeed.X;
                orangeRect.Y += (int)orangeSpeed.Y;

                if (brownRect.Left > window.Width)
                {
                    brownRect.X = -brownRect.Width;
                }
                if (brownRect.Right < 0)
                {
                    brownRect.X = window.Width;
                }
                if (brownRect.Bottom > window.Height || brownRect.Top < 0)
                {
                    brownSpeed.Y *= -1;
                }

                if (creamRect.Right > window.Width || creamRect.Left < 0)
                {
                    creamRect.X = generator.Next(0, window.Width - creamRect.Width);
                    creamRect.Y = generator.Next(0, window.Height - creamRect.Height);
                    creamSpeed.X *= -1;
                    creamColor = Color.BlueViolet;
                }
                if (creamRect.Bottom > window.Height || creamRect.Top < 0)
                {
                    creamRect.X = generator.Next(0, window.Width - creamRect.Width);
                    creamRect.Y = generator.Next(0, window.Height - creamRect.Height);
                    creamColor = Color.CadetBlue;
                    creamSpeed.Y *= -1;
                }

                if (greyRect.Right > window.Width || greyRect.Left < 0)
                {
                    greySpeed.X *= -1;
                    tribbleCoo.Play();
                }
                if (greyRect.Bottom > window.Height || greyRect.Top < 0)
                {
                    greySpeed.Y *= -1;
                    greyColor = Color.LightPink;
                    tribbleCoo.Play();
                }

                if (orangeRect.Right > window.Width || orangeRect.Left < 0)
                {
                    orangeSpeed.X *= -1;
                    bgColor = Color.DarkBlue;
                }
                if (orangeRect.Bottom > window.Height || orangeRect.Top < 0)
                {
                    orangeSpeed.Y *= -1;
                    bgColor = Color.DarkSeaGreen;
                }

                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.End;
            }
            
            if (screen == Screen.TribbleYard && seconds >= 20)
            {
                screen = Screen.End;
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    Exit();
                }
            }

                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(bgColor);

            _spriteBatch.Begin();
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(tribbleIntro, window, Color.White);
                _spriteBatch.DrawString(Text, "Click to enter the Tribble Yard!", new Vector2(50, 250), Color.White);
            }
            else if (screen == Screen.TribbleYard)
            {
                _spriteBatch.Draw(brown, brownRect, Color.White);
                _spriteBatch.Draw(cream, creamRect, creamColor);
                _spriteBatch.Draw(grey, greyRect, greyColor);
                _spriteBatch.Draw(orange, orangeRect, Color.White);
                _spriteBatch.DrawString(Text_two, "Click to exit the Tribble Yard!", new Vector2(50, 550), Color.Red);
            }
            else if (screen == Screen.End)
            {
                _spriteBatch.DrawString(Text_three, "Thank for playing! Click to exit.", new Vector2(50, 250), Color.White);
            }
                _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

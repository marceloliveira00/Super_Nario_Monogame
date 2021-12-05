using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Super_Nario_Monogame.GameEngine;
using Super_Nario_Monogame.GameEngine.GameWindow;

namespace Super_Nario_Monogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _marioSprite;
        private Texture2D _backgroundSprite;

        // Window instance
        readonly Window window = new Window(1280, 670);

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Window properties
            _graphics.PreferredBackBufferWidth = window.WindowWidth;
            _graphics.PreferredBackBufferHeight = window.WindowHeight;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _marioSprite = Content.Load<Texture2D>("spritesheets/marioMovements");
            _backgroundSprite = Content.Load<Texture2D>("spritesheets/entireMap");
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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            window.Draw(_spriteBatch, _marioSprite, _backgroundSprite);

            base.Draw(gameTime);
        }
    }
}

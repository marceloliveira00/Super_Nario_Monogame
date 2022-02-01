﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Super_Nario_Monogame.GameEngine.GameManager;

namespace Super_Nario_Monogame
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;

        private readonly GameManager _gameManager = new GameManager();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _gameManager.Initialize(_graphics);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _gameManager.LoadContent(Content, GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _gameManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _gameManager.Draw();

            base.Draw(gameTime);
        }
    }
}

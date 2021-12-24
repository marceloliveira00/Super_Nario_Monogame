using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Super_Nario_Monogame.GameEngine.MarioPlayer;


namespace Super_Nario_Monogame.GameEngine.GameManager
{
    public class GameManager
    {
        private readonly Player _player = new Player();
        private readonly Window _window = new Window(1280, 670);

        public void Initialize(GraphicsDeviceManager graphics)
        {
            graphics.PreferredBackBufferWidth = _window.WindowWidth;
            graphics.PreferredBackBufferHeight = _window.WindowHeight;
            graphics.ApplyChanges();
        }

        public void LoadContent(ContentManager content, GraphicsDevice graphics)
        {
            _window.LoadContent(content, graphics);
            _player.LoadContent(content, graphics);
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw()
        {
            _window.Draw();
            _player.Draw();
        }
    }
}

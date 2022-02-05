using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Super_Nario_Monogame.GameEngine.MarioPlayer;


namespace Super_Nario_Monogame.GameEngine.GameManager
{
    public class GameManager
    {
        private readonly Player player = new Player();
        private readonly Window window = new Window(1280, 670);

        public void Initialize(GraphicsDeviceManager graphics)
        {
            graphics.PreferredBackBufferWidth = window.WindowWidth;
            graphics.PreferredBackBufferHeight = window.WindowHeight;
            graphics.ApplyChanges();
        }

        public void LoadContent(ContentManager content, GraphicsDevice graphics)
        {
            window.LoadContent(content, graphics);
            player.LoadContent(content, graphics);
        }

        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
        }

        public void Draw()
        {
            window.Draw();
            player.Draw();
        }
    }
}

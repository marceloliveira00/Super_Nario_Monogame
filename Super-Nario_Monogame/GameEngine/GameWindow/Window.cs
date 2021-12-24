using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Super_Nario_Monogame.GameEngine.GameWindow;

namespace Super_Nario_Monogame.GameEngine
{
    public class Window : IWindow
    {
        // Window properties
        public int WindowWidth { get; private set; }
        public int WindowHeight { get; private set; }

        // Map variables
        private readonly int _mapWidth = 3669;
        private readonly int _mapHeight = 224;
        private readonly float _mapUpscale = 3;
        private Texture2D _backgroundSprite;

        private SpriteBatch _spriteBatch;


        public Window(int windowWidth, int windowHeight)
        {
            WindowWidth = windowWidth;
            WindowHeight = windowHeight;
        }

        public void LoadContent(ContentManager content, GraphicsDevice graphics)
        {
            _spriteBatch = new SpriteBatch(graphics);
            _backgroundSprite = content.Load<Texture2D>("spritesheets/entireMap");
        }

        public void Draw()
        {
            _spriteBatch.Begin(SpriteSortMode.FrontToBack);
            // Texture2D texture,
            // Vector2 position,
            // Rectangle? sourceRectangle,
            // Color color,
            // float rotation,
            // Vector2 origin,
            // float scale,
            // SpriteEffects effects,
            // float layerDepth
            _spriteBatch.Draw(_backgroundSprite,
                new Vector2(0, WindowHeight - _mapHeight * _mapUpscale),
                new Rectangle(3, 3, _mapWidth, _mapHeight), Color.White, 0f,
                new Vector2(0, 0), _mapUpscale, SpriteEffects.None, 0f);
            _spriteBatch.End();
        }
    }
}

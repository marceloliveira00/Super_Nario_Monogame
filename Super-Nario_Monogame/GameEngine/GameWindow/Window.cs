using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Super_Nario_Monogame.GameEngine.GameWindow;

namespace Super_Nario_Monogame.GameEngine
{
    public class Window : IWindow
    {
        // Window properties
        public int WindowWidth { get; private set; }
        public int WindowHeight { get; private set; }

        // Mario variables
        private readonly float _marioUpscale = 3;

        // Map variables
        private readonly int _mapWidth = 3669;
        private readonly int _mapHeight = 224;
        private readonly float _mapUpscale = 3;

        public Window(int windowWidth, int windowHeight)
        {
            WindowWidth = windowWidth;
            WindowHeight = windowHeight;
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D marioSprite, Texture2D backgroundSprite)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack);
            // Texture2D texture,
            // Vector2 position,
            // Rectangle? sourceRectangle,
            // Color color,
            // float rotation,
            // Vector2 origin,
            // float scale,
            // SpriteEffects effects,
            // float layerDepth
            spriteBatch.Draw(marioSprite,
                new Vector2(0, 0),
                new Rectangle(206, 3, 16, 28), Color.White, 0f, new Vector2(- 90, 53 - _mapHeight), _marioUpscale, SpriteEffects.None, 0.1f);
            spriteBatch.Draw(backgroundSprite,
                new Vector2(0, WindowHeight - _mapHeight * _mapUpscale),
                new Rectangle(3, 3, _mapWidth, _mapHeight), Color.White, 0f, new Vector2(0, 0), _mapUpscale, SpriteEffects.None, 0f);
            spriteBatch.End();
        }

        public void Update(float delta)
        {
        }
    }
}

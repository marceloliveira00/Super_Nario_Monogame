using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Super_Nario_Monogame.GameEngine
{
    public class Window
    {
        // Window properties
        public int WindowWidth { get; private set; }
        public int WindowHeight { get; private set; }

        // Map variables
        readonly int mapWidth = 3669;
        readonly int mapHeight = 224;
        readonly float mapUpscale = 3;
        Texture2D backgroundSprite;

        SpriteBatch spriteBatch;


        public Window(int windowWidth, int windowHeight)
        {
            WindowWidth = windowWidth;
            WindowHeight = windowHeight;
        }

        public void LoadContent(ContentManager content, GraphicsDevice graphics)
        {
            spriteBatch = new SpriteBatch(graphics);
            backgroundSprite = content.Load<Texture2D>("spritesheets/entireMap");
        }

        public void Draw()
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack);
            spriteBatch.Draw(backgroundSprite,
                new Vector2(0, WindowHeight - mapHeight * mapUpscale),
                new Rectangle(3, 3, mapWidth, mapHeight), Color.White, 0f,
                new Vector2(0, 0), mapUpscale, SpriteEffects.None, 0f);
            spriteBatch.End();
        }
    }
}

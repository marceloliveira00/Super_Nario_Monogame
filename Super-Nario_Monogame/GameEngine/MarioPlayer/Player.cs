using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Super_Nario_Monogame.GameEngine.Entities;


namespace Super_Nario_Monogame.GameEngine.MarioPlayer
{
    public class Player : Entity
    {
        private SpriteBatch _spriteBatch;

        private Texture2D _marioSprite;
        private readonly float _marioUpscale = 3;

        // altura do chão (variável que será removida em breve)
        private readonly int _mapHeight = 224;

        public void LoadContent(ContentManager content, GraphicsDevice graphics)
        {
            _spriteBatch = new SpriteBatch(graphics);
            _marioSprite = content.Load<Texture2D>("spritesheets/marioMovements");
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
            _spriteBatch.Draw(_marioSprite,
                new Vector2(0, 0),
                new Rectangle(206, 3, 16, 28), Color.White, 0f,
                new Vector2(-90, 53 - _mapHeight), _marioUpscale, SpriteEffects.None, 0.1f);
            _spriteBatch.End();
        }
    }
}

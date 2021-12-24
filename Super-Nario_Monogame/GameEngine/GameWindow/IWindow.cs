﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Super_Nario_Monogame.GameEngine.GameWindow
{
    public interface IWindow
    {
        public void LoadContent(ContentManager content, GraphicsDevice graphics);
        void Draw();
    }
}

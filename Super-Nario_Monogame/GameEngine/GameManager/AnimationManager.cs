using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Super_Nario_Monogame.GameEngine.Animations;

namespace Super_Nario_Monogame.GameEngine.GameManager
{
    public class AnimationManager<TAnimation>
    {
        readonly MarioAnimations marioAnimations;
        public void StartAnimation(KeyboardState input, GameTime gameTime, short marioStatus)
        {
            marioAnimations.PlayAnimation(input, gameTime, marioStatus);
        }
    }
}
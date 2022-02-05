using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Super_Nario_Monogame.GameEngine.Enumerators;

namespace Super_Nario_Monogame.GameEngine.Animations
{
    public class MarioAnimations : Animation
    {
        private Rectangle[] MarioWalkingAhead { get; }
        private Rectangle[] MarioWalkingBack { get; }

        MarioAnimations()
        {
            MarioWalkingAhead = new Rectangle[]
            {
                new Rectangle(366, 3, 16, 28),
                new Rectangle(326, 2, 16, 28)
            };

            MarioWalkingBack = new Rectangle[]
            {
                new Rectangle(7, 3, 16, 28),
                new Rectangle(47, 2, 16, 28)
            };
        }

        public override void PlayAnimation(KeyboardState input, GameTime gameTime, short marioStatus)
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace Space_invaders
{
    public delegate void PassObject(object i);
    public delegate object PassObjectAndReturn(object i);
    class Global
    {
        // Delegates
        public static PassObject passProjectile, passAlienProjectile;

        // Game devices.
        public static GraphicsDevice graphicsDevice;
        public static SpriteBatch spriteBatch;
        public static ContentManager contentManager;

        public static SoundEffect soundEffect;
        public static GameTime gameTime;

        public static Random random = new Random();

        // Game info.
        public static int screenHeight, screenWidth;
        public static int level;

        public static float GetDistance(Vector2 pos, Vector2 target)
        {
            return (float)Math.Sqrt(Math.Pow(pos.X - target.X, 2) + Math.Pow(pos.Y - target.Y, 2));
        }
    }
}

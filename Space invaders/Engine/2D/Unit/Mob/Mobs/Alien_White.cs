using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Space_invaders
{
    public class Alien_White : Mob
    {
        MCTimer timer;
        public Alien_White(Vector2 pos, int rank) : base(rank) 
        {
            tag = "Alien_White";
            this.timer = new MCTimer(5000 + Global.random.Next(1000));
            myModel = Global.contentManager.Load<Texture2D>("Mobs\\Space_Invader_White");
            this.pos = pos;
            scale = 4;
            Scale();
            hitDist = 26;
        }

        public void Update()
        {
            this.timer.UpdateTimer();
            if (canFire)
            {
                if (this.timer.Test())
                {
                    Global.passAlienProjectile((Projectile)(new Alien_Bullet(new Vector2((pos.X + myModel.Width / 2) - 1, pos.Y + myModel.Height), "Bullets\\Bullet_Invader", 5)));
                    timer.SetTimer(5000 + Global.random.Next(1000));
                    this.timer.ResetToZero();
                }
            }
            base.Update();
        }
        public void Draw()
        {
            base.Draw();
        }        
    }
}

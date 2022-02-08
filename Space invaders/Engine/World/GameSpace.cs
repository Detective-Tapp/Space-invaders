using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Space_invaders
{
    public class GameSpace
    {
        List<Projectile> alienProjectiles = new List<Projectile>();
        List<Projectile> projectiles = new List<Projectile>();
        List<Mob> mobs = new List<Mob>();
        private Player _player;

        public GameSpace()
        {
            Global.passAlienProjectile = AddAlienProjectile;
            Global.passProjectile = AddProjectile;
            _player = new Player();
            InitializeMobs();
        }
        public virtual void AddProjectile(object INFO)
        {
            projectiles.Add((Projectile)INFO);
        }
        public void AddAlienProjectile(object INFO)
        {
            alienProjectiles.Add((Projectile)INFO);
        }
        public void Update()
        {
            _player.Update();
            for (int i = 0; i < mobs.Count; i++)
            {
                if (mobs[i].tag == "Alien_White")
                {
                    ((Alien_White)mobs[i]).Update();
                }
                mobs[i].Compare(mobs);
                if (mobs[i].IsDead)
                {
                    mobs.RemoveAt(i);
                    i--;
                } 
                
            }
            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Update(mobs.ToList<Unit>());

                if (projectiles[i].IsDead)
                {
                    projectiles.RemoveAt(i);
                    i--;
                }
            }
            for(int i = 0; i < alienProjectiles.Count; i++)
            {
                if (alienProjectiles[i].tag == "Alien_Bullet")
                {
                    ((Alien_Bullet)alienProjectiles[i]).Update();
                }
                if (alienProjectiles[i].HitSomething(_player))
                {
                    alienProjectiles.RemoveAt(i);
                    break;
                }
                if (alienProjectiles[i].HitSomething(_player.barrier.ToList<Unit>()))
                {
                    alienProjectiles.RemoveAt(i);
                    break;
                }
            }
        }
        public void Draw()
        {
            _player.Draw();
            for (int i = 0; i < mobs.Count; i++)
            {
                mobs[i].Draw();
            }
            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw();
            }
            foreach(Projectile p in alienProjectiles)
            {
                p.Draw();
            }
        }
        private void InitializeMobs()
        {
            int count = 0;
            for (int i = 0; i < Mob.gridY; i++)
            {
                for (int j = 0; j < Mob.gridX; j++)
                { 
                    
                    mobs.Add((Mob)new Alien_White(new Vector2((Mob.gridSpacingX* j)+Mob.gridSpacingX, (Mob.gridSpacingY * i) + Mob.gridY), count));
                    count++;
                }
            }
        }
    }
}

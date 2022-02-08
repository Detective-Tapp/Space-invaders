using System.Collections.Generic;

namespace Space_invaders
{
    enum Direction
    {
        right = 0,
        left = 1,
        down = 2
    }
    public class Mob : Unit
    {
        MCTimer timer;

        Direction direction;

        public static readonly int gridX = 7, gridY = 4;
        public static readonly int gridSpacingX = 50, gridSpacingY = 50;

        float test = 500;
        int interval = 4;
        int steps;  
        int count = 0;
        private int rank;

        protected bool canFire;

        protected Mob(int rank) { timer = new MCTimer(450); direction = new Direction(); this.rank = rank; }

        public void Update()
        {
            timer.UpdateTimer();
            if (timer.Test())
            {
                count++;
                MoveNext();
                
                // float test = (100 * MathF.Sin(count / 5600f * 2f * MathF.PI) / 2f + 0.5f) + 500 - (count * (450-175)/5600);

                timer = new MCTimer((int)test);
            }

            base.Update();
        }
        public void Compare(List<Mob> units)
        {
            for (int i = 0; i < units.Count; i++)
            {
                if (rank + 7 == units[i].rank && units[i].IsDead != true)
                {
                    canFire = false;
                    return;
                }
                else canFire = true;
            }
        }
        public void Draw()
        {
            base.Draw();
        }
        public void BulletDetect(Projectile bullet)
        {

        }

        public void MoveNext()
        {
            // If the enemy array is in screen.
            if (pos.X > 0 && pos.X < Global.screenWidth - gridSpacingX)
            {
                if (direction == Direction.right)
                {
                    pos.X += gridSpacingX / interval;
                    steps++;
                    if (steps == gridX * interval)
                    {
                        direction = Direction.down;
                    }
                }
                else if (direction == Direction.left)
                {
                    pos.X -= gridSpacingX / interval;
                    steps--;

                    if (steps == 0)
                    {
                        direction = Direction.down;
                    }
                }
                else { pos.Y += gridSpacingY; if (steps == 0) { direction = Direction.right; } else { direction = Direction.left; } }
            }
            // If they somehow escape reset them.
            else { pos.X = 0 + gridSpacingX ; }
            
        }
    }
}
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Space_invaders
{
    public class Player : Unit
    {
        Lives lives;
        public List<Barrier> barrier = new List<Barrier>();
        MCTimer timer;
        private int speed = 4;
        public Player()
        {
            lives = new Lives(3);
            tag = "Player";
            InitBarriers();
            myModel = Global.contentManager.Load<Texture2D>("Player\\Turret_White");
            pos.Y = Global.screenHeight - 60;
            pos.X = Global.screenWidth /2;
            size = new Vector2(myModel.Width, myModel.Height);
            scale = 5;
            Scale();
            timer = new MCTimer(350);
            hitDist = 30;
        }

        private void Clamp()
        {
            if (pos.X <= 0)
                pos.X = 0;
            if (pos.X >= Global.screenWidth - myModel.Width)
                pos.X = Global.screenWidth - myModel.Width;
        }
        private void Movement()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                pos.X -= speed;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                pos.X += speed;
            Clamp();
        }
        public void Update()
        {
            if (IsDead != true)
            {
                timer.UpdateTimer();
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    if (timer.Test())
                    {
                        Global.passProjectile((Projectile)(new PlayerBullet(new Vector2((pos.X + myModel.Width / 2) - 1, pos.Y), 5)));
                        Global.soundEffect.Play();
                        timer.ResetToZero();
                    }
                }

                Movement();

                if (Lives.Hp <= 0)
                    IsDead = true;
            }
            foreach (Barrier b in barrier)
            {
                b.Update();
            }
            base.Update();
        }
        public void Draw()
        {
            foreach (Barrier b in barrier)
            {
                b.Draw();
            }
            if (IsDead != true)
                base.Draw();
            lives.Draw();
        }
        private void InitBarriers()
        {
            barrier.Add(new Barrier(new Vector2(600, Global.screenHeight - (Mob.gridSpacingY * 2))));
            barrier.Add(new Barrier(new Vector2(425, Global.screenHeight - (Mob.gridSpacingY * 2))));
            barrier.Add(new Barrier(new Vector2(275, Global.screenHeight - (Mob.gridSpacingY * 2))));
            barrier.Add(new Barrier(new Vector2(100, Global.screenHeight - (Mob.gridSpacingY * 2))));
        }
    }
}

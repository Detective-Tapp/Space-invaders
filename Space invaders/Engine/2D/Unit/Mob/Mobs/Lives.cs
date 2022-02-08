using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Space_invaders
{
    public delegate void removeLife();
    public class Lives : Basic2D
    {
        private List<Icons> icons = new List<Icons>();
        public static removeLife removeLife = Remove;

        public static int Hp { get; private set; }
        public Lives(int hp) { Hp = hp; myModel = Global.contentManager.Load<Texture2D>("Mobs\\Barrier"); InitIcons(); }
        public static void Remove() { Hp--; }
        public void Reset()  { Hp = 3; }
        public void Draw()   { for(int i = 0; i < Hp; i++) { icons[i].Draw(); } }
        private void InitIcons() 
        { 
            icons.Add(new Icons(new Vector2(10,  Global.screenHeight - (myModel.Height * 2)), 2, "Player\\Turret_White"));
            icons.Add(new Icons(new Vector2(40, Global.screenHeight - (myModel.Height * 2)), 2, "Player\\Turret_White"));
            icons.Add(new Icons(new Vector2(70, Global.screenHeight - (myModel.Height * 2)), 2, "Player\\Turret_White"));
        }
    }
}

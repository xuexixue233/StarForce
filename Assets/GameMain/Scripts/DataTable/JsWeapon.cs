using System.Collections.Generic;

namespace StarForce
{
    public class JsWeapons
    {
        public List<JsWeapon> Weapons;
    }
    
    public class JsWeapon
    {
        public int Id;
        public int Attack;
        public double AttackInterval;
        public int BulletId;
        public float BulletSpeed;
        public int BulletSoundId;
    }
}
using System.Collections.Generic;

namespace StarForce
{
    public class JsAsteroids
    {
        public List<JsAsteroid> Asteroids;
    }
    
    public class JsAsteroid
    {
        public int Id;
        public int MaxHP;
        public int Attack;
        public float Speed;
        public float AngularSpeed;
        public int DeadEffectId;
        public int DeadSoundId;
    }
}
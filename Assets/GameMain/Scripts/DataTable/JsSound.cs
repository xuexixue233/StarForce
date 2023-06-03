using System.Collections.Generic;

namespace StarForce
{
    public class JsSounds
    {
        public List<JsSound> Sounds;
    }
    
    public class JsSound
    {
        public int Id;
        public string AssetName;
        public int Priority;
        public bool Loop;
        public float Volume;
        public float SpatialBlend;
        public float MaxDistance;
    }
}
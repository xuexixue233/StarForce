using System.Collections.Generic;

namespace StarForce
{
    public class JsUISounds
    {
        public List<JsUISound> UISounds;
    }
    
    public class JsUISound
    {
        public int Id;
        public string AssetName;
        public int Priority;
        public float Volume;
    }
}
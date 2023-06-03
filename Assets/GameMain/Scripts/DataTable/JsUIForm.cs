using System.Collections.Generic;

namespace StarForce
{
    public class JsUIForms
    {
        public List<JsUIForm> UIForms;
    }
    
    public class JsUIForm
    {
        public int Id;
        public string AssetName;
        public string UIGroupName;
        public bool AllowMultiInstance;
        public bool PauseCoveredUIForm;
    }
}
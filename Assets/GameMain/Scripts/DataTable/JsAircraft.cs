using System.Collections.Generic;
using GameFramework;

namespace StarForce
{
    public class JsAircrafts
    {
        public List<JsAircraft> Aircrafts;
    }
    
    public class JsAircraft
    {
        public int Id;
        public int ThrusterId;
        public int WeaponId0;
        public int WeaponId1;
        public int WeaponId2;
        public int ArmorId0;
        public int ArmorId1;
        public int ArmorId2;
        public int DeadEffectId;
        public int DeadSoundId;
        
        private KeyValuePair<int, int>[] m_WeaponId = null;
        
        public int GetWeaponIdAt(int index)
        {
            if (index < 0 || index >= m_WeaponId.Length)
            {
                throw new GameFrameworkException(Utility.Text.Format("GetWeaponIdAt with invalid index '{0}'.", index));
            }

            return m_WeaponId[index].Value;
        }
        
        private KeyValuePair<int, int>[] m_ArmorId = null;
        
        public int GetArmorIdAt(int index)
        {
            if (index < 0 || index >= m_ArmorId.Length)
            {
                throw new GameFrameworkException(Utility.Text.Format("GetArmorIdAt with invalid index '{0}'.", index));
            }

            return m_ArmorId[index].Value;
        }
        
        public void GeneratePropertyArray()
        {
            m_WeaponId = new KeyValuePair<int, int>[]
            {
                new KeyValuePair<int, int>(0, WeaponId0),
                new KeyValuePair<int, int>(1, WeaponId1),
                new KeyValuePair<int, int>(2, WeaponId2),
            };

            m_ArmorId = new KeyValuePair<int, int>[]
            {
                new KeyValuePair<int, int>(0, ArmorId0),
                new KeyValuePair<int, int>(1, ArmorId1),
                new KeyValuePair<int, int>(2, ArmorId2),
            };
        }
    }
}
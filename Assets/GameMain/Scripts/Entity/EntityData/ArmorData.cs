//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework.DataTable;
using System;
using UnityEngine;

namespace StarForce
{
    [Serializable]
    public class ArmorData : AccessoryObjectData
    {
        [SerializeField]
        private int m_MaxHP = 0;

        [SerializeField]
        private int m_Defense = 0;

        public ArmorData(int entityId, int typeId, int ownerId, CampType ownerCamp)
            : base(entityId, typeId, ownerId, ownerCamp)
        {
            var Armors = EntityExtension.jsArmors.Armors;
            int index = 0;
            for (int i = 0; i < Armors.Count; i++)
            {
                if (Armors[i].Id==TypeId)
                {
                    index = i;
                    break;
                }
            }
            JsArmor jsArmor = Armors[index];
            // IDataTable<DRArmor> dtArmor = GameEntry.DataTable.GetDataTable<DRArmor>();
            // DRArmor drArmor = dtArmor.GetDataRow(TypeId);
            // if (drArmor == null)
            // {
            //     return;
            // }

            m_MaxHP = jsArmor.MaxHP;
            m_Defense = jsArmor.Defense;
        }

        /// <summary>
        /// 最大生命。
        /// </summary>
        public int MaxHP
        {
            get
            {
                return m_MaxHP;
            }
        }

        /// <summary>
        /// 防御力。
        /// </summary>
        public int Defense
        {
            get
            {
                return m_Defense;
            }
        }
    }
}

﻿//------------------------------------------------------------
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
    public class ThrusterData : AccessoryObjectData
    {
        [SerializeField]
        private float m_Speed = 0f;

        public ThrusterData(int entityId, int typeId, int ownerId, CampType ownerCamp)
            : base(entityId, typeId, ownerId, ownerCamp)
        {
            // IDataTable<DRThruster> dtThruster = GameEntry.DataTable.GetDataTable<DRThruster>();
            // DRThruster drThruster = dtThruster.GetDataRow(TypeId);
            // if (drThruster == null)
            // {
            //     return;
            // }
            
            var Thrusters = EntityExtension.jsThrusters.Thrusters;
            int index = 0;
            for (int i = 0; i < Thrusters.Count; i++)
            {
                if (Thrusters[i].Id==TypeId)
                {
                    index = i;
                    break;
                }
            }
            JsThruster jsThruster = Thrusters[index];

            m_Speed = jsThruster.Speed;
        }

        /// <summary>
        /// 速度。
        /// </summary>
        public float Speed
        {
            get
            {
                return m_Speed;
            }
        }
    }
}

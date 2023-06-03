//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework.DataTable;
using System;
using System.IO;
using LitJson;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace StarForce
{
    public static class EntityExtension
    {
        // 关于 EntityId 的约定：
        // 0 为无效
        // 正值用于和服务器通信的实体（如玩家角色、NPC、怪等，服务器只产生正值）
        // 负值用于本地生成的临时实体（如特效、FakeObject等）
        private static int s_SerialId = 0;

        private static JsEntities jsEntities;
        public static JsAsteroids jsAsteroids;
        public static JsArmors jsArmors;
        public static JsAircrafts jsAircrafts;
        public static JsThrusters jsThrusters;
        public static JsWeapons jsWeapons;
        
        public static void ReadJson()
        {
            string Path = AssetUtility.GetJsonAsset("Entity");
            StreamReader streamReader = new StreamReader(Path);
            JsonReader js = new JsonReader(streamReader);
            jsEntities = JsonMapper.ToObject<JsEntities>(js);
            
            Path = AssetUtility.GetJsonAsset("Asteroid");
            streamReader = new StreamReader(Path);
            js = new JsonReader(streamReader);
            jsAsteroids = JsonMapper.ToObject<JsAsteroids>(js);
            
            Path = AssetUtility.GetJsonAsset("Armor");
            streamReader = new StreamReader(Path);
            js = new JsonReader(streamReader);
            jsArmors = JsonMapper.ToObject<JsArmors>(js);
            
            Path = AssetUtility.GetJsonAsset("Aircraft");
            streamReader = new StreamReader(Path);
            js = new JsonReader(streamReader);
            jsAircrafts = JsonMapper.ToObject<JsAircrafts>(js);
            
            
            Path = AssetUtility.GetJsonAsset("Thruster");
            streamReader = new StreamReader(Path);
            js = new JsonReader(streamReader);
            jsThrusters = JsonMapper.ToObject<JsThrusters>(js);
            
            Path = AssetUtility.GetJsonAsset("Weapon");
            streamReader = new StreamReader(Path);
            js = new JsonReader(streamReader);
            jsWeapons = JsonMapper.ToObject<JsWeapons>(js);
            
            js.Close();
            streamReader.Close();
        }

        public static Entity GetGameEntity(this EntityComponent entityComponent, int entityId)
        {
            UnityGameFramework.Runtime.Entity entity = entityComponent.GetEntity(entityId);
            if (entity == null)
            {
                return null;
            }

            return (Entity)entity.Logic;
        }

        public static void HideEntity(this EntityComponent entityComponent, Entity entity)
        {
            entityComponent.HideEntity(entity.Entity);
        }

        public static void AttachEntity(this EntityComponent entityComponent, Entity entity, int ownerId, string parentTransformPath = null, object userData = null)
        {
            entityComponent.AttachEntity(entity.Entity, ownerId, parentTransformPath, userData);
        }

        public static void ShowMyAircraft(this EntityComponent entityComponent, MyAircraftData data)
        {
            entityComponent.ShowEntity(typeof(MyAircraft), "Aircraft", Constant.AssetPriority.MyAircraftAsset, data);
        }

        public static void ShowAircraft(this EntityComponent entityComponent, AircraftData data)
        {
            entityComponent.ShowEntity(typeof(Aircraft), "Aircraft", Constant.AssetPriority.AircraftAsset, data);
        }

        public static void ShowThruster(this EntityComponent entityComponent, ThrusterData data)
        {
            entityComponent.ShowEntity(typeof(Thruster), "Thruster", Constant.AssetPriority.ThrusterAsset, data);
        }

        public static void ShowWeapon(this EntityComponent entityComponent, WeaponData data)
        {
            entityComponent.ShowEntity(typeof(Weapon), "Weapon", Constant.AssetPriority.WeaponAsset, data);
        }

        public static void ShowArmor(this EntityComponent entityComponent, ArmorData data)
        {
            entityComponent.ShowEntity(typeof(Armor), "Armor", Constant.AssetPriority.ArmorAsset, data);
        }

        public static void ShowBullet(this EntityComponent entityCompoennt, BulletData data)
        {
            entityCompoennt.ShowEntity(typeof(Bullet), "Bullet", Constant.AssetPriority.BulletAsset, data);
        }

        public static void ShowAsteroid(this EntityComponent entityCompoennt, AsteroidData data)
        {
            entityCompoennt.ShowEntity(typeof(Asteroid), "Asteroid", Constant.AssetPriority.AsteroiAsset, data);
        }

        public static void ShowEffect(this EntityComponent entityComponent, EffectData data)
        {
            entityComponent.ShowEntity(typeof(Effect), "Effect", Constant.AssetPriority.EffectAsset, data);
        }

        private static void ShowEntity(this EntityComponent entityComponent, Type logicType, string entityGroup, int priority, EntityData data)
        {
            if (data == null)
            {
                Log.Warning("Data is invalid.");
                return;
            }

            // IDataTable<DREntity> dtEntity = GameEntry.DataTable.GetDataTable<DREntity>();
            // DREntity drEntity = dtEntity.GetDataRow(data.TypeId);
            // if (drEntity == null)
            // {
            //     Log.Warning("Can not load entity id '{0}' from data table.", data.TypeId.ToString());
            //     return;
            // }
            
            int index=0;
            for (int i = 0; i < jsEntities.Entities.Count; i++)
            {
                if (jsEntities.Entities[i].Id==data.TypeId)
                {
                    index = i;
                    break;
                }
            }
            JsEntity jsEntitie = jsEntities.Entities[index];
            
            entityComponent.ShowEntity(data.Id, logicType, AssetUtility.GetEntityAsset(jsEntitie.AssetName), entityGroup, priority, data);
        }

        public static int GenerateSerialId(this EntityComponent entityComponent)
        {
            return --s_SerialId;
        }
    }
}

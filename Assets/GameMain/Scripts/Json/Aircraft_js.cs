using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LitJson;

public class Aircraft_js : MonoBehaviour
{
    public class JsAircraft
    {
        public int Id { get; set; }

        public int ThrusterId { get; set; }

        public int WeaponId0 { get; set; }

        public int WeaponId1 { get; set; }
        
        public int WeaponId2 { get; set; }
        
        public int ArmorId0 { get; set; }
        
        public int ArmorId1 { get; set; }
        
        public int ArmorId2 { get; set; }
        
        public int DeadEffectId { get; set; }
        
        public int DeadSoundId { get; set; }
        
    }
    public class JsAircrafts
    {
        public List<JsAircraft> Aircrafts{ get; set; }
    }
    private void Start()
    {
        LoadJson();
    }

    private void LoadJson()
    {
        string configPath = Application.streamingAssetsPath + "/Aircraft.json";
        
        if (!File.Exists(configPath))
        {
            Debug.LogError("严重错误！配置文件不存在！");
        }

        StreamReader streamReader = new StreamReader(configPath);
        JsonReader js = new JsonReader(streamReader);
        JsAircrafts jsAircrafts = JsonMapper.ToObject<JsAircrafts>(js);
        Debug.Log(jsAircrafts.Aircrafts[0].Id);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class MyClass
{
    public string name;
}

[System.Serializable]
public class PlayerInfo
{
    public string name;
    public int lives;
    public float health;

    public MyClass instance;

    public int[] array;

    public Hashtable ht;

    public static PlayerInfo CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<PlayerInfo>(jsonString);
    }

    // Given JSON input:
    // {"name":"Dr Charles","lives":3,"health":0.8}
    // this example will return a PlayerInfo object with
    // name == "Dr Charles", lives == 3, and health == 0.8f.
    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }
}



public class JsonTest1 : MonoBehaviour
{
    public PlayerInfo info;

    // Start is called before the first frame update
    void Start()
    {
        info.ht = new Hashtable();
        info.ht.Add("Key1", "Value1");

        var json = JsonConvert.SerializeObject(info, Formatting.Indented);
        Debug.Log(json);

        info.name = "!!!";

        info = JsonConvert.DeserializeObject<PlayerInfo>(json);
        Debug.Log($"{info.name}{info.lives}{info.health}");






        //var json = info.ToJson();//@"{""name"":""Dr Charles"",""lives"":3,""health"":0.8}";
        //Debug.Log(json);

        //var instance = PlayerInfo.CreateFromJSON(json);
        //Debug.Log($"{instance.name}{instance.lives}{instance.health}");

        //instance.name = "???";

        //json = instance.ToJson();
        //Debug.Log(json);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

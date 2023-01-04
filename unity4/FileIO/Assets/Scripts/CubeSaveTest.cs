using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

using SaveDataC = SaveDataV2;


public class CubeSaveData
{
    public Vector3 pos;
    public Quaternion rot;
    public Vector3 scale;
}

public class CubeSaveTest : MonoBehaviour
{
    private int fileNum;
    public GameObject prefab;

    public void SetFileNum(int num)
    {
        fileNum = num;
    }

    public void OnSave()
    {
        var saveData = new SaveDataC();
        saveData.cubeList = new List<CubeSaveData>();

        //SaveLoadSystem.SetFileName(fileNum);
        //var list = new List<CubeSaveData>();
        var finds = GameObject.FindGameObjectsWithTag("Cube");

        foreach (var cube in finds)
        {
            var d = new CubeSaveData()
            {
                pos = cube.transform.position,
                rot = cube.transform.rotation,
                scale = cube.transform.localScale
            };
            saveData.cubeList.Add(d);
        }

        SaveLoadSystem.Save(0, saveData);
        //var json = JsonConvert.SerializeObject(list, Formatting.Indented,
        //    new Vector3Converter(),
        //    new QuaternionConverter());
        //var path = Path.Combine(Application.persistentDataPath, "save.json");
        //File.WriteAllText(path, json);
    }

    public void OnLoad()
    {
        var finds = GameObject.FindGameObjectsWithTag("Cube");
        foreach (var cube in finds)
        {
            Destroy(cube);
        }
        //SaveLoadSystem.SetFileName(fileNum);
        var data = SaveLoadSystem.Load(0) as SaveDataV2;

        foreach (var d in data.cubeList)
        {
            var newGo = Instantiate(prefab, d.pos, d.rot);
            newGo.transform.localScale = d.scale;
        }

        //var path = Path.Combine(Application.persistentDataPath, "save.json");
        //var json = File.ReadAllText(path);
        //var list = JsonConvert.DeserializeObject<List<CubeSaveData>>(json,
        //    new Vector3Converter(),
        //    new QuaternionConverter());
        //foreach (var data in list)
        //{
        //    var newGo = Instantiate(prefab, data.pos, data.rot);
        //    newGo.transform.localScale = data.scale;
        //}
    }

    public void OnErase()
    {
        var saveData = new SaveDataC();
        saveData.cubeList = new List<CubeSaveData>();

        //SaveLoadSystem.SetFileName(fileNum);
        ////var list = new List<CubeSaveData>();
        //var finds = GameObject.FindGameObjectsWithTag("Cube");

        //foreach (var cube in finds)
        //{
        //    var d = new CubeSaveData()
        //    {
        //        pos = cube.transform.position,
        //        rot = cube.transform.rotation,
        //        scale = cube.transform.localScale
        //    };
        //    saveData.cubeList.Add(d);
        //}

        SaveLoadSystem.Erase();
    }
}
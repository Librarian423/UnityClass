using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class SaveData 
{
    public int Version;

    public virtual SaveData VersionUp() { return null; }

    public virtual SaveData VersionDown() { return null; }

}

public class SaveDataV1 : SaveData
{
    public SaveDataV1()
    {
        Version = 1;
    }
    //public override int Version => 1;

    public List<CubeSaveData> cubeList;// = new List<CubeSaveData>();

    public override SaveData VersionDown()
    {
        throw new System.NotImplementedException();
    }

    public override SaveData VersionUp()
    {
        var data = new SaveDataV2();
        data.cubeList = cubeList;
        return data;
    }
}

public class SaveDataV2 : SaveDataV1
{
    public SaveDataV2()
    {
        Version = 2;
    }
    //public override int Version => 2;

    public string newMember = "TEST";

    public override SaveData VersionDown()
    {
        var data = new SaveDataV1();
        data.cubeList = cubeList;
        return data;
    }

    public override SaveData VersionUp()
    {
        throw new System.NotImplementedException();
    }

   
}

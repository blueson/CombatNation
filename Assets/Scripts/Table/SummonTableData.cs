using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SummonTableData {
    public List<SummonData> data;

    public static SummonTableData CreateFromJson()
    {
        var asset = Resources.Load<TextAsset>("Table/SummonData");
        return JsonUtility.FromJson<SummonTableData>(asset.text);
    }

    public SummonData GetSummonDataById(int id)
    {
        foreach (var c in data)
        {
            if (c.id == id)
            {
                return c;
            }
        }
        return null;
    }
}

[System.Serializable]
public class SummonData
{
    public int id;
    public int[] heroList;
    public int upgrade;
    public int consume;
    public float[] probability;
}

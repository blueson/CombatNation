using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChapterTableData {

    public List<ChapterData> data;

    public static ChapterTableData CreateFromJson()
    {
        var asset = Resources.Load<TextAsset>("Table/ChapterData");
        return JsonUtility.FromJson<ChapterTableData>(asset.text);
    }

    public ChapterData GetChapterInfoById(int id)
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
public class ChapterData
{
    public int id;
    public int[] enemy;
    public int money;
}

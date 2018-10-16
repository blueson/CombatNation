using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class CharacterTableData {
    public List<CharacterData> data;

    public static CharacterTableData CreateFromJson(){
        var asset = Resources.Load<TextAsset>("Table/CharacterData");
        return JsonUtility.FromJson<CharacterTableData>(asset.text);
    }

    public CharacterData GetCharacterInfoById(int id){
        foreach(var c in data){
            if(c.id == id){
                return c;
            }
        }
        return null;
    }
}

[System.Serializable]
public class CharacterData{
    public int id;
    public string name;
    public int hp;
    public int atk;
    public float atkDis;
    public float atkSpeed;
    public float moveSpeed;
    public string heroPath;
}

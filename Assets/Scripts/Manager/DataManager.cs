using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataManager
{
    private static DataManager _instance;

    private UserInfo userInfo;
    private string savePath;

    private DataManager()
    {
        savePath = Application.persistentDataPath + "/" + "userInfoData.txt";

        Debug.Log(savePath);

        LoadUserInfo();

        if (userInfo == null)
        {
            userInfo = new UserInfo();
            SaveUserInfo();
        }
    }

    public static DataManager GetInstance()
    {
        if(_instance == null){
            _instance = new DataManager();
        }
        return _instance;
    }

    public bool SaveUserInfo(){
        var bf = new BinaryFormatter();
        FileStream fs = File.Create(savePath);
        bf.Serialize(fs, userInfo);
        fs.Close();

        if(File.Exists(savePath)){
            return true;
        }else{
            return false;
        }
    }

    public void LoadUserInfo(){
        if (File.Exists(savePath))
        {
            var bf = new BinaryFormatter();
            var fs = File.Open(savePath, FileMode.Open);
            userInfo = (UserInfo)bf.Deserialize(fs);
            fs.Close();
        }
    }

    public UserInfo GetUserInfo(){
        return userInfo;
    }
}

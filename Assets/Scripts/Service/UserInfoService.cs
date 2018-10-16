using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;

public class UserInfoService : IUserInfoService
{
    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    public void GetUserInfo(string savePath)
    {
        string userInfo = "";
        if (File.Exists(savePath))
        {
            StreamReader sr = new StreamReader(savePath, Encoding.Default);
            userInfo = sr.ReadToEnd();
        }

        // 回调command
        dispatcher.Dispatch(ServiceEvent.GetUserInfo,userInfo);
    }

    public void SaveUserInfo(string savePath,string userInfo)
    {
        FileStream fs = new FileStream(savePath, FileMode.OpenOrCreate);
        StreamWriter sw = new StreamWriter(fs);
        //开始写入
        sw.Write(userInfo);
        //清空缓冲区
        sw.Flush();
        //关闭流
        sw.Close();
        fs.Close();
    }
}

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

    string savePath = Application.persistentDataPath + "/" + "userInfoData.txt";

    public void GetUserInfo()
    {
        if (File.Exists(savePath))
        {
            var bf = new BinaryFormatter();
            var fs = File.Open(savePath, FileMode.Open);
            var userInfo = (UserInfoData)bf.Deserialize(fs);
            fs.Close();


            // 回调command
            dispatcher.Dispatch(ServiceEvent.GetUserInfo, userInfo);
        }
    }

    public void SaveUserInfo(IUserInfoModel userInfoModel)
    {
        // 保存英雄信息
        var heroInfoList = new List<HeroInfoData>();
        foreach (var model in userInfoModel.heroList)
        {
            heroInfoList.Add(new HeroInfoData
            {
                id = model.id,
                characterId = model.characterId,
                lastHp = model.lastHp,
                lv = model.lv
            });
        }

        // 保存用户信息
        var userInfoData = new UserInfoData
        {
            chapterId = userInfoModel.chapterId,
            summonLv = userInfoModel.summonLv,
            money = userInfoModel.money,
            fightChapterId = userInfoModel.fightChapterId,
            heroInfoData = heroInfoList
        };

        var bf = new BinaryFormatter();
        FileStream fs = File.Create(savePath);
        bf.Serialize(fs, userInfoData);
        fs.Close();
    }
}

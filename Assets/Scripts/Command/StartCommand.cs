using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;

public class StartCommand : EventCommand {

    [Inject]
    public IUserInfoService userInfoService { get; set; }

    [Inject]
    public IUserInfoModel userInfoModel { get; set; }

    private string savePath = Application.persistentDataPath + "/" + "userInfoData.txt";

    public override void Execute()
    {
        Retain();
        userInfoService.dispatcher.AddListener(ServiceEvent.GetUserInfo,LoadUserInfo);
        userInfoService.GetUserInfo(savePath);
        userInfoModel.money = 300;
    }

    void LoadUserInfo(IEvent evt){
        var userInfo = JsonUtility.FromJson<UserInfoModel>((string)evt.data);
        if(userInfo == null){
            var userInfoData = new UserInfoData { 
                chapterId = userInfoModel.chapterId,
                summonLv = userInfoModel.SummonLv,
                money = userInfoModel.money,
            };

            userInfoService.SaveUserInfo(savePath, JsonUtility.ToJson(new UserInfoData((UserInfoModel)userInfoModel)));
        }
        Release();
    }
}

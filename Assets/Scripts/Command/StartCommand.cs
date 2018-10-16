using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;

public class StartCommand : EventCommand {

    [Inject]
    public IUserInfoService userInfoService { get; set; }

    [Inject]
    public UserInfoModel userInfoModel { get; set; }

    private string savePath = Application.persistentDataPath + "/" + "userInfoData.txt";

    public override void Execute()
    {
        userInfoService.dispatcher.AddListener(ServiceEvent.GetUserInfo,LoadUserInfo);
        userInfoService.GetUserInfo(savePath);
    }

    void LoadUserInfo(IEvent evt){
        userInfoModel = JsonUtility.FromJson<UserInfoModel>((string)evt.data);
        if(userInfoModel == null){
            userInfoModel = new UserInfoModel();
            userInfoService.SaveUserInfo(savePath, JsonUtility.ToJson(userInfoModel));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;

public class StartCommand : EventCommand
{

    [Inject]
    public IUserInfoService userInfoService { get; set; }

    [Inject]
    public IUserInfoModel userInfoModel { get; set; }

    public override void Execute()
    {
        Retain();
        userInfoService.dispatcher.AddListener(ServiceEvent.GetUserInfo, LoadUserInfo);
        userInfoService.GetUserInfo();
    }

    void LoadUserInfo(IEvent evt)
    {
        var userInfo = (UserInfoData)evt.data;
        if (userInfo == null)
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
                heroInfoData = heroInfoList
            };

            userInfoModel.InitByUserInfoData(userInfo);
            userInfoService.SaveUserInfo(userInfoModel);
        }else{
            userInfoModel.InitByUserInfoData(userInfo);
        }
        Release();
    }
}

using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class AddMoneyCommand : EventCommand {

    [Inject]
    public IUserInfoModel userInfoModel { get; set; }

    [Inject]
    public IUserInfoService userInfoService { get; set; }

    public override void Execute()
    {
        int addMoney = (int)evt.data;
        userInfoModel.money += addMoney;
        userInfoService.SaveUserInfo(userInfoModel);
        dispatcher.Dispatch(CommandEvent.GetMoney);
    }
}

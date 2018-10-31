using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class UnlockSummonCommand : EventCommand {

    [Inject]
    public IUserInfoModel userInfoModel { get; set; }

    [Inject]
    public IUserInfoService userInfoService { get; set; }

    public override void Execute()
    {
        var summonLv = (int)evt.data;

        var summonTable = SummonTableData.CreateFromJson();
        var summonData = summonTable.GetSummonDataByLv(summonLv);

        if (userInfoModel.money >= summonData.upgrade)
        {
            userInfoModel.money -= summonData.upgrade;
            userInfoModel.summonLv += 1;
            userInfoService.SaveUserInfo(userInfoModel);

            dispatcher.Dispatch(MediatorEvent.UnlockSummonOver);
        }
        else
        {
            Debug.Log("钱不够");
        }
    }
}

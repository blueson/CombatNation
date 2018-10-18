using System;
using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class UpdateMainInfoCommand : EventCommand {

    [Inject]
    public IUserInfoModel userInfoModel { get; set; }

    public override void Execute()
    {
        //int chapterId,int money,int summonMoney,int upMoney

        var summonTableData = SummonTableData.CreateFromJson();
        var summonData = summonTableData.GetSummonDataByLv(userInfoModel.summonLv);
        dispatcher.Dispatch(MediatorEvent.UpdateMainInfo,new object[]{
            userInfoModel.chapterId,
            userInfoModel.money,
            summonData.consume,
            summonData.upgrade
        });
    }
}

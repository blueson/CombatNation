using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class GetRecruitMoneyCommand : EventCommand {

    [Inject]
    public IUserInfoModel userInfoModel { get; set; }

    public override void Execute()
    {
        var summonTable = SummonTableData.CreateFromJson();
        var summonData = summonTable.GetSummonDataByLv(userInfoModel.summonLv);

        dispatcher.Dispatch(MediatorEvent.GetRecruitMoney,summonData.consume);
    }
}

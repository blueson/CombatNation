using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class GetRecruitInfoCommand : EventCommand {

    [Inject]
    public IUserInfoModel userInfoModel { get; set; }

    public override void Execute()
    {
        var summonTable = SummonTableData.CreateFromJson();

        var summonInfoList = new List<Dictionary<string, System.Object>>();
        foreach(var summonData in summonTable.data){
            summonInfoList.Add(new Dictionary<string, object>(){
                {"consume",summonData.consume},
                {"lv",summonData.lv},
                {"id",summonData.id},
                {"probability",summonData.probability},
                {"upgrade",summonData.upgrade},
                {"heroList",summonData.heroList},
                {"open",summonData.lv <= userInfoModel.summonLv}
            });
        }

        dispatcher.Dispatch(MediatorEvent.GetRecruitInfo,summonInfoList);
    }
}

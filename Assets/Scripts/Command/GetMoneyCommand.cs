using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class GetMoneyCommand : EventCommand {

    [Inject]
    public IUserInfoModel userInfoModel { get; set; }

    public override void Execute()
    {
        dispatcher.Dispatch(MediatorEvent.GetMoney,userInfoModel.money);
    }
}

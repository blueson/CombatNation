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
        Debug.Log(userInfoModel.money);
    }
}

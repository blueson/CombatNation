using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class FightFubenCommand : EventCommand {

    [Inject]
    public IUserInfoModel userInfoModel { get; set; }

	public override void Execute()
    {
        Debug.Log("输出调涨的");
        Debug.Log(evt.data);
    }
}

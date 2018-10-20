using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class GetChapterInfoCommand : EventCommand {

    [Inject]
    public IUserInfoModel userInfoModel { get; set; }

    public override void Execute()
    {
        dispatcher.Dispatch(MainPanelMediatorEvent.GetChapterInfo,userInfoModel.chapterId);
    }
}

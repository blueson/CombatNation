using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class ChangeChapterCommmand : EventCommand {

    [Inject]
    public IUserInfoModel userInfoModel { get; set; }

    public override void Execute()
    {
        int changeNum = (int)evt.data;

        int chooseChapter = userInfoModel.chapterId;
        chooseChapter += changeNum;
        chooseChapter = Mathf.Min(chooseChapter, userInfoModel.chapterId);
        chooseChapter = Mathf.Max(chooseChapter, 1);

        dispatcher.Dispatch(MediatorEvent.UpdateChooseChapter,chooseChapter);
    }
}

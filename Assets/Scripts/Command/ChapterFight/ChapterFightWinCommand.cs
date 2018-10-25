using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class ChapterFightWinCommand : EventCommand {

    [Inject]
    public IUserInfoModel userInfoModel { get; set; }

    [Inject]
    public IUserInfoService userInfoService { get; set; }

    public override void Execute()
    {
        int chapterId = userInfoModel.fightChapterId + 1;
        userInfoModel.chapterId = chapterId;

        var chapterTable = ChapterTableData.CreateFromJson();
        var chapterData = chapterTable.GetChapterInfoById(userInfoModel.fightChapterId);
        userInfoModel.money += chapterData.money;

        dispatcher.Dispatch(MediatorEvent.ChapterFightWin);
    }
}

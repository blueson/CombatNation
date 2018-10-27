using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterFightCommand : EventCommand {

    [Inject]
    public IUserInfoModel userInfoModel { get; set; }

    [Inject]
    public IUserInfoService userInfoService { get; set; }

    public override void Execute()
    {

        if(userInfoModel.heroList == null || userInfoModel.heroList.Count <=0 ){
            Debug.Log("没有可上阵的英雄");
            return;
        }

        int chooseChapter = (int)evt.data;
        userInfoModel.fightChapterId = chooseChapter == 0 ? userInfoModel.chapterId : chooseChapter;

        userInfoService.SaveUserInfo(userInfoModel);

        SceneManager.LoadScene(1);
    }
}

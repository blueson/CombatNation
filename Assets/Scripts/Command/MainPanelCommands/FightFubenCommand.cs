using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightFubenCommand : EventCommand {

    [Inject]
    public IUserInfoModel userInfoModel { get; set; }

	public override void Execute()
    {
        int chooseChapter = (int)evt.data;
        userInfoModel.fightChapterId = chooseChapter == 0 ? userInfoModel.chapterId : chooseChapter;

        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
    }
}

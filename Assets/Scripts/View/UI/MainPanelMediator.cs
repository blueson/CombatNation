using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;

public class MainPanelMediator : EventMediator {

    [Inject]
    public MainPanel mainPanel { get; set; }

    private int chooseChapter = 0;

    public override void OnRegister()
    {
        AddViewEventListener();
        AddCommmandEventListener();

        mainPanel.Init();
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(MediatorEvent.UpdateMainInfo,UpdateMainInfo);
    }

    // 添加视图监听事件
    void AddViewEventListener()
    {
        mainPanel.dispatcher.AddListener(MainPanelEvent.LoadInfo, LoadInfo);
        mainPanel.dispatcher.AddListener(MainPanelEvent.FightClick,FightClick);
    }

    // 添加Command监听事件
    void AddCommmandEventListener()
    {
        dispatcher.AddListener(MediatorEvent.UpdateMainInfo, UpdateMainInfo);
    }

    #region Command监听事件
    void UpdateMainInfo(IEvent evt){

        var data = (System.Object[])evt.data;

        //设置关卡为通过的关卡id
        chooseChapter = (int)data[0];
        mainPanel.UpdateTextInfo((int)data[0], (int)data[1], (int)data[2], (int)data[3]);
    }
    #endregion

    #region 视图监听事件


    void LoadInfo(){
        dispatcher.Dispatch(CommandEvent.UpdateMainInfo);
    }

    void FightClick(){
        dispatcher.Dispatch(CommandEvent.FubenFight, chooseChapter);
        //var userinfo = DataManager.GetInstance().GetUserInfo();
        //userinfo.fightChapterId = chooseChapter == 0 ? userinfo.chapterId : chooseChapter;
        //SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;

public class ChapterViewMediator : EventMediator {

    [Inject]
    public ChapterView chapterView { get; set; }

    public override void OnRegister()
    {
        dispatcher.AddListener(MainPanelMediatorEvent.GetChapterInfo,GetChapterInfo);

        // 获取当前章节信息
        dispatcher.Dispatch(MainPanelCommandEvent.GetChapterInfo);
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(MainPanelMediatorEvent.GetChapterInfo, GetChapterInfo);   
    }

    void GetChapterInfo(IEvent evt){
        chapterView.UpdateChapter((int)evt.data);
    }
}

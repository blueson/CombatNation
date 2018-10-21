using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;

public class ChapterViewMediator : EventMediator {

    [Inject]
    public ChapterView chapterView { get; set; }

    private int chapterId = -1;

    public override void OnRegister()
    {
        dispatcher.AddListener(MainPanelMediatorEvent.GetChapterInfo, GetChapterInfo);



        // 获取当前章节信息
        dispatcher.Dispatch(MainPanelCommandEvent.GetChapterInfo);
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(MainPanelMediatorEvent.GetChapterInfo, GetChapterInfo);
    }

    void AddChapterViewEvent()
    {
        chapterView.dispatcher.AddListener(MainPanelMediatorEvent.ChangeChooseChapter,);
    }

    void GetChapterInfo(IEvent evt)
    {
        chapterId = (int)evt.data;
        chapterView.UpdateChapter(chapterId);
    }

    void ChangeChooseChapter(IEvent evt)
    {
        int changeChapter = (int)evt.data;

        chapterId += changeChapter;

        
    }
}

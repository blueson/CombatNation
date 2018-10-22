using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;

public class ChapterViewMediator : EventMediator {

    [Inject]
    public ChapterView chapterView { get; set; }

    int chapterId = -1;
    int chooseChapterId = -1;

    public override void OnRegister()
    {
        dispatcher.AddListener(MainPanelMediatorEvent.GetChapterInfo, GetChapterInfo);
        AddChapterViewEvent();


        // 获取当前章节信息
        dispatcher.Dispatch(MainPanelCommandEvent.GetChapterInfo);
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(MainPanelMediatorEvent.GetChapterInfo, GetChapterInfo);
    }

    void AddChapterViewEvent()
    {
        chapterView.dispacter.AddListener(MainPanelMediatorEvent.ChangeChooseChapter,ChangeChooseChapter);
        chapterView.dispacter.AddListener(MainPanelMediatorEvent.ChapterFight,ChapterFight);
    }

    void GetChapterInfo(IEvent evt)
    {
        chapterId = (int)evt.data;
        chooseChapterId = chapterId;
        chapterView.UpdateChapter(chooseChapterId);
    }

    void ChangeChooseChapter(IEvent evt)
    {
        int changeChapter = (int)evt.data;
        chooseChapterId += changeChapter;
        chooseChapterId = Mathf.Max(1, chapterId);
        chooseChapterId = Mathf.Min(chapterId, chooseChapterId);

        chapterView.UpdateChapter(chooseChapterId);
    }

    void ChapterFight(){
        dispatcher.Dispatch(MainPanelCommandEvent.ChapterFight,chooseChapterId);
    }
}

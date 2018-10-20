using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class ChapterView : View {

    [Inject]
    public IEventDispatcher dispacter { get; set; }

    public Text chapterText;

    public void UpdateChapter(int chapterId){
        chapterText.text = "第" + chapterId + "关";
    }

    // 挑战章节
    public void ChapterFight(){
        
    }
}

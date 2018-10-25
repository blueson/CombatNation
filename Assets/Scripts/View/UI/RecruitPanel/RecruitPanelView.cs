using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;

public class RecruitPanelView : View {

    [Inject]
    public IEventDispatcher dispatcher { get; set; }


    public void CloseRecruitPanel()
    {
        gameObject.SetActive(false);
    }
}

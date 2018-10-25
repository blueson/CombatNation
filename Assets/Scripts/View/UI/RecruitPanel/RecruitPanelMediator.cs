using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class RecruitPanelMediator : EventMediator {

    [Inject]
    public RecruitPanelView view { get; set; }

    public override void OnRegister()
    {
        
    }

    public override void OnRemove()
    {
        
    }
}

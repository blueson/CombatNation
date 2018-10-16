using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;

public class MainPanelMediator : EventMediator {

    [Inject]
    public MainPanel mainPanel { get; set; }

    public override void OnRegister()
    {
        mainPanel.dispatcher.AddListener(MediatorEvent.LoadInfo,LoadInfo);

        dispatcher.AddListener(MediatorEvent.UpdateMainInfo, UpdateMainInfo);
        mainPanel.Init();
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(MediatorEvent.UpdateMainInfo,UpdateMainInfo);
    }

    void UpdateMainInfo(IEvent evt){

        var data = (System.Object[])evt.data;
        mainPanel.UpdateTextInfo((int)data[0], (int)data[1], (int)data[2], (int)data[3]);
    }

    void LoadInfo(){
        dispatcher.Dispatch(CommandEvent.UpdateMainInfo);
    }
}

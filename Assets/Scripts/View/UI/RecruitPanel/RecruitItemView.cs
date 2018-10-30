using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine.UI;
using UnityEngine;

public class RecruitItemView : View {

    public Text recruitMoneyText;
    public Text recruitHitText;

    [HideInInspector]
    public Dictionary<string, System.Object> summonInfo;

    [Inject]
    public IEventDispatcher dispatcher { get; set; }


    public void SetSummInfo(Dictionary<string, System.Object> summonInfo){
        this.summonInfo = summonInfo;

        UpdateRecruitMoneyText((int)summonInfo["consume"]);
    }

    public void UpdateRecruitMoneyText(int money)
    {
        recruitMoneyText.text = money + "";
    }

    public void RecruitButtonClick()
    {
        dispatcher.Dispatch(RecruitPanelMediatorEvent.RecruitButtonClick);
    }
}

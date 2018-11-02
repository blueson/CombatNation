using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine.UI;
using UnityEngine;

public class RecruitItemView : View {

    public Text recruitMoneyText;
    public Text unlockMoneyText;
    public Button recruitButton;
    public Button unlockButton;

    [HideInInspector]
    public Dictionary<string, System.Object> summonInfo;

    [HideInInspector]
    public bool isOpen;

    [Inject]
    public IEventDispatcher dispatcher { get; set; }


    public void SetSummInfo(Dictionary<string, System.Object> summonInfo){
        this.summonInfo = summonInfo;
        isOpen = (bool)this.summonInfo["open"];
        UpdateSummonState();
    }

    void UpdateRecruitMoneyText(int money)
    {
        recruitMoneyText.text = money + "";
    }

    void UpdateUnlockMoneyText(int money){
        unlockMoneyText.text = money + "";
    }

    public void RecruitButtonClick()
    {
        dispatcher.Dispatch(RecruitPanelMediatorEvent.RecruitButtonClick);
    }

    public void UnlockButtonClick()
    {
        dispatcher.Dispatch(RecruitPanelMediatorEvent.UnlockButtonClick);
    }

    public void UpdateSummonState(){
        if(isOpen){
            recruitButton.gameObject.SetActive(true);
            unlockButton.gameObject.SetActive(false);

            UpdateRecruitMoneyText((int)summonInfo["consume"]);
        }else{
            recruitButton.gameObject.SetActive(false);
            unlockButton.gameObject.SetActive(true);

            UpdateUnlockMoneyText((int)summonInfo["upgrade"]);
        }
    }
}

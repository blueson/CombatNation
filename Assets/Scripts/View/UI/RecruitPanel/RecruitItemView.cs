using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine.UI;

public class RecruitItemView : View {
    
    public Text recruitMoneyText;

    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    public void UpdateRecruitMoneyText(int money)
    {
        recruitMoneyText.text = money + "";
    }

    public void RecruitButtonClick()
    {
        dispatcher.Dispatch(RecruitPanelMediatorEvent.RecruitButtonClick);
    }
}

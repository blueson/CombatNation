using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine.UI;

public class RecruitItemView : View {

    public int recruitCount;
    public Text recruitMoneyText;
    public Text recruitHitText;

    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    public void InitView()
    {
        recruitHitText.text = "招募" + (recruitCount == 1?"一":"十") + "次";
    }

    public void UpdateRecruitMoneyText(int money)
    {
        recruitMoneyText.text = money * recruitCount + "";
    }

    public void RecruitButtonClick()
    {
        dispatcher.Dispatch(RecruitPanelMediatorEvent.RecruitButtonClick,recruitCount);
    }
}

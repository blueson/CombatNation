using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

public class MoneyTextView : View {

    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    Text moneyText;

    public void InitView()
    {
        moneyText = GetComponent<Text>();
    }

    public void UpdateMoney(int money)
    {
        moneyText.text = money + "";
    }
}

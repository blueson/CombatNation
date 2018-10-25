using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainPanel : View {

    public GameObject recruitPanel;

    public void RecruitButtonClick()
    {
        recruitPanel.SetActive(true);
    }
}

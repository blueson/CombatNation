using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFramework : MonoBehaviour {

	// Use this for initialization
	void Start () {
        UIManager.Instance().PushPanel(UIPanelType.MainPanel);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.HeroEditor.Common.CharacterScripts;

public class RoleSortingOrderFix : MonoBehaviour {

    LayerManager layerManager;

	// Use this for initialization
	void Start () {
        layerManager = GetComponent<LayerManager>();
	}

	void Update () {
        float y = transform.position.y;

        if(y < 0){
            y = Mathf.Abs(y) + 5;
        }else{
            y = 5 - y;
        }

        layerManager.SortingOrderOffset = (int)(1000 * y);
        layerManager.ReadCurrentOrderBySortingOrder();
        layerManager.SetOrderBySortingOrder();
	}
}

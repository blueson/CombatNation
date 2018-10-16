using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutHpNum : MonoBehaviour {
    
    private Text cutHpText;
    private Vector2 moveDir;
    private float destroyTimer = 0.8f;

    void Awake(){
        cutHpText = GetComponent<Text>();

        var x = Random.Range(-5, 5);
        var y = Random.Range(1, 5);
        moveDir = new Vector2(x, y);
        moveDir.Normalize();
    }

    public void SetCutHpNum(int num){
        cutHpText.text = num + "";
    }
	
	// Update is called once per frame
	void Update () {

        transform.Translate(moveDir * Time.deltaTime);

        destroyTimer -= Time.deltaTime;
        if(destroyTimer <=0){
            Destroy(this.gameObject);
        }
	}
}

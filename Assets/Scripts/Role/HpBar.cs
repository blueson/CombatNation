using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour {

    public GameObject cutHpNum;

    private Role role;
    private Slider hpSlider;

	void Start () {
        role = transform.GetComponentInParent<Role>();
        hpSlider = GetComponentInChildren<Slider>();

        var scale = transform.localScale;
        scale.x = role.transform.localScale.x > 0 ? scale.x : scale.x * -1;
        transform.localScale = scale;

        hpSlider.maxValue = role.MaxHp;
        hpSlider.value = role.Hp;
	}

	void Update () {
        if((int)hpSlider.value <= 0){
            return;
        }
        var offsetHp = (int)hpSlider.value - role.Hp;
        if(offsetHp > 0){
            GameObject go = Instantiate(cutHpNum,transform);
            go.transform.position = transform.position;
            go.GetComponent<CutHpNum>().SetCutHpNum(offsetHp);

            hpSlider.value = role.Hp;
        }
	}
}

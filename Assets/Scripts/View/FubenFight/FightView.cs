using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;

public class FightView : View {

    public GameObject hpBar;

    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    public void AddCharacter(List<Dictionary<string, System.Object>> dataList,bool isHero){
        int y = 0;
        foreach (var data in dataList)
        {
            var heroPrefab = (GameObject)Resources.Load((string)data["heroPath"]);

            GameObject go = Instantiate(heroPrefab, new Vector3(12, y, 0), Quaternion.identity, transform);
            Role role = go.GetComponent<Role>();
            role.Atk = (int)data["atk"];
            if(isHero){
                role.HeroInfoId = (string)data["id"]; // 战斗模型跟英雄数据的关系
            }
            role.Hp = (int)data["hp"];
            role.MaxHp = (int)data["hp"];
            role.AtkDis = (float)data["atkDis"];
            role.AtkSpeed = (float)data["atkSpeed"];
            role.RoleType1 = (Role.RoleType)data["roleType1"];
            role.MoveSpeed = (float)data["moveSpeed"];

            Instantiate(hpBar, go.transform); // 创建血条

            y--;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;

public class FightView : View {

    public static int FightUpdate = 0;

    public GameObject hpBar;

    [Inject]
    public IEventDispatcher dispatcher { get; set; }

    [HideInInspector]
    public List<Role> roleList = new List<Role>();

    public void AddCharacter(List<Dictionary<string, System.Object>> dataList,bool isHero){
        float y = 1.2f;
        float x = isHero? -12 : 12;
        foreach (var data in dataList)
        {
            var heroPrefab = (GameObject)Resources.Load((string)data["heroPath"]);

            GameObject go = Instantiate(heroPrefab, new Vector3(x, y, 0), Quaternion.identity, transform);
            Role role = go.GetComponent<Role>();
            role.Atk = (int)data["atk"];
            if(isHero){
                role.HeroInfoId = (string)data["id"]; // 战斗模型跟英雄数据的关系
            }
            role.Hp = (int)data["hp"];
            role.MaxHp = (int)data["maxHp"];
            role.AtkDis = (float)data["atkDis"];
            role.AtkSpeed = (float)data["atkSpeed"];
            role.RoleType1 = (Role.RoleType)data["roleType1"];
            role.MoveSpeed = (float)data["moveSpeed"];
            roleList.Add(role);

            Instantiate(hpBar, go.transform); // 创建血条

            y -= 1.5f;
            if(y < -4.8f)
            {
                y = 1.2f;
                x = isHero ? x - 1.5f : x + 1.5f;
            }
        }
    }

    private void Update()
    {
        dispatcher.Dispatch(FightUpdate);
    }
}

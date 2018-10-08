using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.HeroEditor.Common.CharacterScripts;

public class RoleMove : MonoBehaviour
{
    private Role role;
    private Role targetRole;
    private Character character;
    private float attackTimer = 0;


    private float dieTimer = 2f; //死亡后消失的时间

    // Use this for initialization
    void Start()
    {
        role = GetComponent<Role>();
        character = GetComponent<Character>();

        if (role.RoleType1 == Role.RoleType.ENEMY)
        {
            //如果是敌人就调整方向
            //todo 根据敌人位置调整方向
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    void Update()
    {
        if(role.Hp <= 0){
            // 死亡了
            targetRole = null;
            dieTimer -= Time.deltaTime;
            if (dieTimer <= 0)
            {
                Destroy(this.gameObject);
            }
            return;
        }


        SearchTarget();
        CheckRoleState();
    }

    void CheckRoleState(){
        if(targetRole == null || targetRole.Hp <= 0){
            return;
        }
        float dis = Vector3.Distance(role.transform.position, targetRole.transform.position);

        if(dis <= role.AtkDis){
            Attack();
        }else{
            Move();
        }
    }

    void Move(){
        if (targetRole == null || targetRole.Hp <= 0)
        {
            return;
        }

        character.Animator.SetBool("Run", true);

        Vector3 offset = targetRole.transform.position - transform.position;
        offset.Normalize();
        transform.Translate(offset*Time.deltaTime*role.MoveSpeed);
    }

    void Attack(){
        if (targetRole == null || targetRole.Hp <= 0)
        {
            return;
        }

        character.Animator.SetBool("Run", false);
        attackTimer += Time.deltaTime;

        if(attackTimer >= role.AtkSpeed){
            attackTimer = 0.0f;

            character.Animator.SetTrigger(Time.frameCount % 2 == 0 ? "Slash" : "Jab");

            targetRole.GetComponent<RoleMove>().BeHit(role.Atk);
        }
    }

    public void BeHit(int hp){
        role.Hp -= hp;
        if(role.Hp <= 0){
            character.Animator.SetTrigger(Time.frameCount % 2 == 0 ? "DieBack" : "DieFront");
        }
    }

    //搜索可以攻击的目标
    void SearchTarget(){
        if (targetRole == null){
            GameObject go = GameObject.Find("Role");

            List<Role> enemyList = new List<Role>();
            Role[] allRole = go.GetComponentsInChildren<Role>();

            for (int i = 0; i < allRole.Length; i++)
            {
                if(allRole[i].RoleType1 != role.RoleType1){
                    enemyList.Add(allRole[i]);
                }
            }

            float minDis = 50f;
            foreach(Role r in enemyList){
                float offsetDis = Vector3.Distance(role.transform.position, r.transform.position);
                if(offsetDis < minDis){
                    minDis = offsetDis;
                    targetRole = r;
                }
            }
        }else{
            if(targetRole.Hp <= 0){
                targetRole = null;
            }
        }
    }
}

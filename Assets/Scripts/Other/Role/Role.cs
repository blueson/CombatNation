using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Role : MonoBehaviour {

    public enum RoleType
    {
        HERO,
        ENEMY
    }

    public enum Occupation
    {
        WARRIOR,
        ARCHER,
        MAGICIAN
    }

    private RoleType roleType;
    private Occupation occupation;

    private string heroInfoId;
    private int hp;
    private int maxHp;
    private int atk;
    private float atkDis;
    private float atkSpeed;
    private float moveSpeed;

    public RoleType RoleType1
    {
        get
        {
            return roleType;
        }

        set
        {
            roleType = value;
        }
    }

    public Occupation Occupation1
    {
        get
        {
            return occupation;
        }

        set
        {
            occupation = value;
        }
    }

    public int Hp
    {
        get
        {
            return hp;
        }

        set
        {
            hp = value;
        }
    }

    public int Atk
    {
        get
        {
            return atk;
        }

        set
        {
            atk = value;
        }
    }

    public float AtkDis
    {
        get
        {
            return atkDis;
        }

        set
        {
            atkDis = value;
        }
    }

    public float AtkSpeed
    {
        get
        {
            return atkSpeed;
        }

        set
        {
            atkSpeed = value;
        }
    }

    public float MoveSpeed
    {
        get
        {
            return moveSpeed;
        }

        set
        {
            moveSpeed = value;
        }
    }

    public string HeroInfoId
    {
        get
        {
            return heroInfoId;
        }

        set
        {
            heroInfoId = value;
        }
    }

    public int MaxHp
    {
        get
        {
            return maxHp;
        }

        set
        {
            maxHp = value;
        }
    }
}

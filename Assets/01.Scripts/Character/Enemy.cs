using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    override protected void InitGroupIype()
    {
        _groupType = Character.eGroupType.ENEMY;


    }
    private void Awake()
    {
        //_groupType = Character.eGroupType.ENEMY;
    }
    protected override void UpdateProcess()
    {
        UpdateState();
    }

    protected override void InitState()
    {
        base.InitState();

        State idleState = new EnemyIdleState();
        State attackState = new EnemyAttackState();

        idleState.Init(this);
        attackState.Init(this);

        _stateDic[eState.IDLE] = idleState;
        _stateDic[eState.ATTACK] = attackState;
    }
    override public void FindTarget()
    {
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
    }

    override protected void InitItem()
    {
        _gun = GunObject.AddComponent<SprialGunItem>();
        _gun.SetBullet(BulletPrefab);
        _gun.InitGroupType(_groupType);

    }

    override public void UpdateAI()
    {
        _currentState.ChangeState(eState.ATTACK);
    }

}

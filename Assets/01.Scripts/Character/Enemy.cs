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

}

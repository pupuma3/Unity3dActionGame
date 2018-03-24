﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : State
{

    bool _isShoot = false;
    Quaternion _characterRotation;

    public override void Start()
    {
        //
        _characterRotation = _character.CharacterModel.transform.localRotation;

        _isShoot = false;
        _shotTime = _character.GetShotSpeed();
        //_character.ChacterModel.GetComponent<Animator>().SetTrigger("attack");
        _character.GetAnimationModule().Play("attack",()=>
        {
        },()=>
        {

        }, ()=>
        {
            _isShoot = true;
            Debug.Log("_isShoot : " + _isShoot);
        });
    }
    override public void Stop()
    {
        _character.CharacterModel.transform.localRotation = _characterRotation;
    }
    public override void Update()
    {
        base.Update();
        //_character.CharacterModel.transform.position = Vector3.zero;

        _character.CharacterModel.transform.localPosition = Vector3.zero;
        UpdateShoot();
        _character.UpdateMove();

    }


    // Shoot 

    float _shotTime = 0.0f;

    void UpdateShoot()
    {
        if(false == _isShoot)
        {
            return;
        }

        if(_character.GetShotSpeed() <= _shotTime)
        {
            _shotTime = 0.0f;
            Shot();
        }
        _shotTime += Time.deltaTime;
    }

    void Shot()
    {
        Debug.Log("Shot");
        _character.Shot();
    }
}

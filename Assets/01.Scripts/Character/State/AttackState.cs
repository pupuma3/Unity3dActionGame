﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
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
<<<<<<< HEAD:Assets/01.Scripts/Character/State/AttackState.cs
        //_character.CharacterModel.transform.localPosition = Vector3.zero;
=======
        _character.CharacterModel.transform.localPosition = Vector3.zero;
>>>>>>> 600a767d58655a58d08d8d813a7a20931cc8d733:Assets/01.Scripts/State/AttackState.cs
        UpdateShoot();
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

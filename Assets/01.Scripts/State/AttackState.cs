using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{

    bool _isShoot = false;

    public override void Start()
    {
        //
        _isShoot = false;
        _shotTime = 0.0f;
        //_character.ChacterModel.GetComponent<Animator>().SetTrigger("attack");
        _character.GetAnimationModule().Play("attack",()=>
        {
            Debug.Log("Test Start");
        },()=>
        {
            Debug.Log("Middle Test");

        }, ()=>
        {
            _isShoot = true;
            Debug.Log("_isShoot : " + _isShoot);
        });
    }

    public override void Update()
    {
        base.Update();
        //_character.CharacterModel.transform.position = Vector3.zero;
        _character.CharacterModel.transform.localPosition = Vector3.zero;
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
    }
}

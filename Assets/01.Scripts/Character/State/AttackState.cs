using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    float _attackTime = 10.0f;
    float _attackDuration = 0.0f;

    bool _isShoot = false;
    Quaternion _characterRotation;

    public override void Start()
    {
        //
        _attackTime = Random.Range(18.0f, 20.0f);
        _attackDuration = 0.0f;

        // 총이나 총알을 바꾸어 준다.

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

        if(_attackTime <= _attackDuration)
        {
            _character.ChangeState(Character.eState.IDLE);
        }
        else
        {
            UpdateShoot();
            _character.UpdateMove();
        }
        _attackDuration += Time.deltaTime;

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

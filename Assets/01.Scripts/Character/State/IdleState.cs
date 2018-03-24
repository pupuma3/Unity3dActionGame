using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    float _waitTime = 1.0f;
    float _waitDuration = 0.0f;
    override public void Start()
    {
        _character.CharacterModel.GetComponent<Animator>().SetTrigger("idle");
        //_character.FindTarget();
        _waitTime = Random.Range(1.0f, 2.0f);
        _waitDuration = 0.0f;

    }
    override public void Update()
    {
        /*
        if(null != _character.GetTarget())
        {
            _character.Look(_character.GetTarget());
            

        }
        */
        if(_waitTime <= _waitDuration)
        {
            _character.ChangeState(Player.eState.FIND_TARGET);
        }
        _waitDuration += Time.deltaTime;

    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State
{

    Player.eInputDirection _prevAniDirection;

    override public void Start()
    {
        _prevAniDirection = Player.eInputDirection.NONE;

        UpdateAnimation();
    }
    override public void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            
            if (Player.eInputDirection.NONE != _character.GetInputVerticalDirection() &&
           Player.eInputDirection.NONE != _character.GetInputHorizontalDirection())
            {
                _character.ChangeState(Player.eState.MOVE);
                return;
            }
            //_character.ChangeState(Player.eState.IDLE);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {

            if (Player.eInputDirection.NONE == _character.GetInputVerticalDirection() &&
           Player.eInputDirection.NONE == _character.GetInputHorizontalDirection())
            {
                _character.ChangeState(Player.eState.IDLE);
                return;
            }
        }

        




        UpdateAnimation();
        _character.UpdateRun();

    }

    void UpdateAnimation()
    {
        if (_prevAniDirection == _character.GetAniDirection())
        {
            return;
        }

        _prevAniDirection = _character.GetAniDirection();


        switch (_character.GetAniDirection())
        {
            case Player.eInputDirection.FRONT:
                _character.CharacterModel.GetComponent<Animator>().SetTrigger("runfront");
                break;
            case Player.eInputDirection.BACK:
                _character.CharacterModel.GetComponent<Animator>().SetTrigger("runback");
                break;
            case Player.eInputDirection.RIGHT:
                _character.CharacterModel.GetComponent<Animator>().SetTrigger("runright");
                break;
            case Player.eInputDirection.LEFT:
                _character.CharacterModel.GetComponent<Animator>().SetTrigger("runleft");
                break;
        }
    }
}

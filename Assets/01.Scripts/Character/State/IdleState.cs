using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    override public void Start()
    {
        _character.CharacterModel.GetComponent<Animator>().SetTrigger("idle");
    }

    override public void Update()
    {

        Vector3 inputVertical = new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical"));
        Vector3 inputHorizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        if (0.0f != inputVertical.z || 0.0f != inputHorizontal.x)
        {
            _character.ChangeState(Player.eState.MOVE);
        }
<<<<<<< HEAD:Assets/01.Scripts/Character/State/IdleState.cs
        _character.CharacterModel.transform.localPosition = Vector3.zero;

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            _character.ChangeState(Player.eState.RUN);
        }
       

=======
        //_character.CharacterModel.transform.localPosition = Vector3.zero;
>>>>>>> 600a767d58655a58d08d8d813a7a20931cc8d733:Assets/01.Scripts/State/IdleState.cs
        /*
        if (Player.eInputDirection.NONE == _character.GetInputVerticalDirection() ||
            Player.eInputDirection.NONE == _character.GetInputHorizontalDirection())
        {
            _character.ChangeState(Player.eState.MOVE);
        }
        */

    }


}

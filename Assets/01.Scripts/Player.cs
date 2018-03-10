using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject ChacterModel;

    void Start()
    {
        InitState();
        ChangeState(eState.IDLE);
    }

    // Update is called once per frame
    void Update()
    {
        CheckMouseLock();

        UpdateRotate();
        UpdateState();
     
    }

    // State 
    public enum eState
    {
        IDLE,
        MOVE,
    }

    Dictionary<eState, State> _stateDic = new Dictionary<eState, State>();
   
    State _currentState;

    void InitState()
    {
        State idleState = new IdleState();
        State moveState = new MoveState();

        idleState.Init(this);
        moveState.Init(this);

        _stateDic.Add(eState.IDLE, idleState);
        _stateDic.Add(eState.MOVE, moveState);
    }

    void UpdateState()
    {
        _currentState.Update();
    }
    
    public void StartIdleState()
    {
        ChacterModel.GetComponent<Animator>().SetTrigger("idle");

    }
    void ChangeState(eState nextState)
    {
        _currentState =_stateDic[nextState];
        _currentState.Start();
  
    }


    public void UpdateIdleState()
    {
        Vector3 inputVertical = new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical"));
        Vector3 inputHorizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        if (0.0f != inputVertical.z || 0.0f != inputHorizontal.x)
        {
            ChangeState(eState.MOVE);
            //StartMoveState();
        }
    }
    
    public void StartMoveState()
    {
        //_state = eState.MOVE;
        Vector3 inputVertical = new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical"));
        Vector3 inputHorizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);

        if (0.0f < inputVertical.z)
        {
            ChacterModel.GetComponent<Animator>().SetTrigger("movefront");
        }
        else if (inputVertical.z < 0.0f)
        {
            ChacterModel.GetComponent<Animator>().SetTrigger("moveback");
        }

        if (0.0f < inputHorizontal.x)
        {
            ChacterModel.GetComponent<Animator>().SetTrigger("moveright");
        }
        else if (inputHorizontal.x < 0.0f)
        {
            ChacterModel.GetComponent<Animator>().SetTrigger("moveleft");
        }

    }
    
    public void UpdateMoveState()
    {
        Vector3 inputVertical = new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical"));
        Vector3 inputHorizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        if (0.0f == inputVertical.z && 0.0f == inputHorizontal.x)
        {
            ChangeState(eState.IDLE);
            return;
        }

        UpdateMove();
        
    }

  


    //Input
    bool _mouseLock = true;

    void CheckMouseLock()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _mouseLock = !_mouseLock;
        }

        if(_mouseLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // Rotate
    float _rotationY = 0.0f;
    void UpdateRotate()
    {
        if (false == _mouseLock)
        {
            return;
        }
        // 마우스를 이용해 수평 회전을 시칸다.
        float rotateSpeed = 360.0f;
        float addRotationY = Input.GetAxis("Mouse X") * rotateSpeed;
        _rotationY += (addRotationY * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0.0f, _rotationY, 0.0f);
    }
    // Move

    void UpdateMove()
    {
        Vector3 addPosition = Vector3.zero;

        Vector3 inputVertical = new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical"));
        if (0.0f < inputVertical.z)
        {
            addPosition.z = MoveOffset(5.0f);
        }
        else if (inputVertical.z < 0.0f)
        {
            addPosition.z = MoveOffset(-3.0f);

        }
        
        Vector3 inputHorizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        if (0.0f < inputHorizontal.x)
        {
            addPosition.x = MoveOffset(3.0f);

        }
        else if (inputHorizontal.x < 0.0f)
        {
            addPosition.x = MoveOffset(-3.0f);

        }
        
        transform.position += (transform.rotation *addPosition);

    }

    float MoveOffset(float moveSpeed)
    {
        return (moveSpeed * Time.deltaTime);

    }

}

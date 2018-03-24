using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject CharacterModel;

    void Start()
    {
        Init();
      
    }
    void Update()
    {
        UpdateProcess();

    }
    public void Init()
    {
        InitGroupIype();
        InitState();
        InitItem();
        ChangeState(eState.IDLE);
    }
    virtual protected void InitGroupIype()
    {

    }
    // Update

    virtual protected void UpdateProcess()
    {
        UpdateRotate();
        UpdateState();
    }
    // Rotate
    protected float _rotationY = 0.0f;
    virtual protected void UpdateRotate()
    {
        /*
        // 마우스를 이용해 수평 회전을 시칸다.
        float rotateSpeed = 360.0f;
        float addRotationY = Input.GetAxis("Mouse X") * rotateSpeed;
        _rotationY += (addRotationY * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0.0f, _rotationY, 0.0f);
        */
    }

    // State
    public enum eState
    {
        IDLE,
        MOVE,
        RUN,
        ATTACK,
        FIND_TARGET,
    }

    protected Dictionary<eState, State> _stateDic = new Dictionary<eState, State>();

    State _currentState;

    virtual protected void InitState()
    {
        State idleState = new IdleState();
        State moveState = new MoveState();
        State attackState = new AttackState();
        State runState = new RunState();
        State findTargetState = new FindTargetState();

        idleState.Init(this);
        moveState.Init(this);
        attackState.Init(this);
        runState.Init(this);
        findTargetState.Init(this);

        _stateDic.Add(eState.IDLE, idleState);
        _stateDic.Add(eState.MOVE, moveState);
        _stateDic.Add(eState.RUN, runState);
        _stateDic.Add(eState.ATTACK, attackState);
        _stateDic.Add(eState.FIND_TARGET, findTargetState);
    }

    protected void UpdateState()
    {
        _currentState.Update();
    }


    public void ChangeState(eState nextState)
    {
        if (null != _currentState)
        {
            _currentState.Stop();
        }
        _currentState = _stateDic[nextState];
        _currentState.Start();

    }

    //Input
    public enum eInputDirection
    {
        NONE,
        FRONT,
        BACK,
        LEFT,
        RIGHT,
    }
    protected eInputDirection _inputVerticalDirection = eInputDirection.NONE;
    protected eInputDirection _inputHorizontalDirection = eInputDirection.NONE;
    protected eInputDirection _inputAniDirection = eInputDirection.NONE;

    

  
    public eInputDirection GetInputVerticalDirection()
    {
        return _inputVerticalDirection;
    }

    public eInputDirection GetInputHorizontalDirection()
    {
        return _inputHorizontalDirection;
    }

    public eInputDirection GetAniDirection()
    {
        return _inputAniDirection;
    }


    public void UpdateMove()
    {
        Vector3 addPosition = Vector3.zero;


        switch (_inputVerticalDirection)
        {
            case eInputDirection.FRONT:
                addPosition.z = MoveOffset(5.0f);
                break;
            case eInputDirection.BACK:
                addPosition.z = MoveOffset(-3.0f);
                break;
        }

        switch (_inputHorizontalDirection)
        {
            case eInputDirection.RIGHT:
                addPosition.x = MoveOffset(3.0f);
                break;
            case eInputDirection.LEFT:
                addPosition.x = MoveOffset(-3.0f);
                break;
        }

        transform.position += (transform.rotation * addPosition);
    }

    // MoveOffset
    float MoveOffset(float moveSpeed)
    {
        return (moveSpeed * Time.deltaTime);
    }

    // RUN
    public void UpdateRun()
    {
        Vector3 addPosition = Vector3.zero;


        switch (_inputVerticalDirection)
        {
            case eInputDirection.FRONT:
                addPosition.z = MoveOffset(8.0f);
                break;
            case eInputDirection.BACK:
                addPosition.z = MoveOffset(-4.0f);
                break;
        }

        switch (_inputHorizontalDirection)
        {
            case eInputDirection.RIGHT:
                addPosition.x = MoveOffset(5.0f);
                break;
            case eInputDirection.LEFT:
                addPosition.x = MoveOffset(-5.0f);
                break;
        }

        transform.position += (transform.rotation * addPosition);
    }
    //Attack


    public void Shot()
    {
        Quaternion fireRotation = transform.rotation;
        _gun.Fire(fireRotation);
    }

    public float GetShotSpeed()
    {
        return _gun.GetShotSpeed();
    }
 
    // Animation
    public AnimationModule GetAnimationModule()
    {
        return CharacterModel.GetComponent<AnimationModule>();
    }


    //item
    public GameObject GunObject;
    public GameObject BulletPrefab;

    protected GunItem _gun;

    virtual protected void InitItem()
    {
        //_gun = GunObject.AddComponent<ShotgunItem>();
        //_gun.SetBullet(BulletPrefab);
    }
    //
    protected Character _target = null;

    virtual public void FindTarget()
    {
        //_target = null;
    }

    public Character GetTarget()
    {
        return _target;
    }

    public void Look(Character target)
    {
        target = _target;
        transform.LookAt(target.transform);
    }

    public enum eGroupType
    {
        PLAYER,
        ENEMY,
    }


    // GroupType
    protected eGroupType _groupType;

    public eGroupType GetGroupType()
    {
        return _groupType;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletItem : MonoBehaviour
{
    protected Character _target = null;
    protected Character.eGroupType _ownerGroupType;

    protected float _lifeTime = 20.0f;
    protected float _moveSpeed = 5.0f;
	// Use this for initialization
	void Start ()
    {
        GameObject.Destroy(gameObject, _lifeTime);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 moveOffset = _moveSpeed * Vector3.forward;
        transform.position += ((transform.rotation * moveOffset) * Time.deltaTime);
    }
 

    public void SetOwnerGroupType(Character.eGroupType ownerGroupType)
    {
        _ownerGroupType = ownerGroupType;
    }

    private void OnTriggerEnter(Collider other)
    {
        Character ColliderCharacter = other.gameObject.GetComponent<Character>();
        if(null != ColliderCharacter)
        {
            if(ColliderCharacter.GetGroupType() != _ownerGroupType)
            {
                GameObject.Destroy(gameObject);
            }
        }
    }

    public void SetTarget(Character target)
    {
        _target = target;
    }
}

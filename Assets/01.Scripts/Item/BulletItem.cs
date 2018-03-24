using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletItem : MonoBehaviour
{
    

    Character.eGroupType _ownerGroupType;


    float _lifeTime = 20.0f;
    float _moveSpeed = 1.0f;

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
}

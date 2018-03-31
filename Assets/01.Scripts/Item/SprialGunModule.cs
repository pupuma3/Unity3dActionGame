using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprialGunModule : GunModule
{
    Quaternion _shotRotation;
    bool _isFire = false;

    override public void Fire(Quaternion startRotation,Character target)
    {
        if (false == _isFire)
        {
            _shotRotation = startRotation;
        }
        else
        {
            _rotateY = Mathf.Sin(Mathf.PI * 2 * Time.deltaTime);
            _shotRotation = _shotRotation * Quaternion.Euler(0.0f, _rotateY, 0.0f);

        }
        _isFire = true;

        float yRotOffset = 360.0f / _wayCount;
        float yRot = -(_wayCount / 2) * yRotOffset;
        _isFire = true;


        for (int i = 0; i < _wayCount; i++)
        {
            Quaternion shotRotation = _shotRotation * Quaternion.Euler(0.0f, yRot + (yRotOffset * i), 0.0f);
            _parentGunItem.CreateBullet(shotRotation,target);
        }

    }

}

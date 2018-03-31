using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NWayGunModule : GunModule
{
    override public void Fire(Quaternion startRotation, Character target)
    {
        Quaternion shotRotation = startRotation;
        _wayCount = 3;
        float yRotOffset = 10.0f;

        //float yRot = -10.0f;
        float yRot = -(_wayCount / 2) * yRotOffset;


        for (int i = 0; i < _wayCount; i++)
        {
            shotRotation = startRotation * Quaternion.Euler(0.0f, yRot + (yRotOffset * i), 0.0f);
            _parentGunItem.CreateBullet(shotRotation, target);
            //GameObject bulletObject = GameObject.Instantiate(_bulletPrefab, transform.position, shotRotation);
            //bulletObject.transform.localScale = Vector3.one;

        }
    }
}

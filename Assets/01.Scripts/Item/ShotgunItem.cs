using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunItem : GunItem
{
    /*
    Quaternion _shotRotation;

    bool _isFire = false;
    
    public override void Fire(Quaternion startRotation)
    {
        if (null != _bulletPrefab)
        {
            if (false == _isFire)
            {
                _shotRotation = startRotation;
            }
            else
            {
                _shotRotation = _shotRotation * Quaternion.Euler(0.0f, _gunModule._rotateY, 0.0f);
            }

            _isFire = true;

            float yRotOffset = 360.0f / _gunModule._wayCount;
            float yRot = -(_gunModule._wayCount / 2) * yRotOffset;

            float xRotOffset = 360.0f / _gunModule._wayCount;
            float xRot = -(_gunModule._wayCount / 2) * yRotOffset;
            //_shotRotation = _shotRotation * Quaternion.Euler(0.0f, 20.0f, 0.0f);
            {
                for (int i = 0; i < _gunModule._wayCount; i++)
                {
                    Quaternion shotRotation = _shotRotation * Quaternion.Euler(0.0f, yRot + (yRotOffset * i), 0.0f);
                    
                     CreateBullet(shotRotation);

                }
            }
            {
                for (int i = 0; i < _gunModule._wayCount; i++)
                {
                    Quaternion shotRotation = _shotRotation * Quaternion.Euler(xRot + (xRotOffset * i), 0.0f, 0.0f);
                   
                    CreateBullet(shotRotation);

                }
            }

            //GameObject bulletObject = GameObject.Instantiate(_bulletPrefab, transform.position, _shotRotation);
            //bulletObject.transform.localScale = Vector3.one;


        }
    }
    */
}

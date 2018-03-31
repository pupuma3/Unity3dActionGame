﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunModule
{
    public int _wayCount = 3;
    public  float _rotateY = 6.0f;

    protected GunItem _parentGunItem;

    public void Init(GunItem gunItem)
    {
        _parentGunItem = gunItem;
    }

    virtual public void Fire(Quaternion startRotation, Character target)
    {
       _parentGunItem.CreateBullet(startRotation, target);
    }
}

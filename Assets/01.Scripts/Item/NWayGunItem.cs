﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NWayGunItem : GunItem
{
    
    override protected void CreateGunModule()
    {
        {
            GunModule gunModule = new NWayGunModule();
            gunModule.Init(this);
            _gunModuleList.Add(gunModule);
        }
        {
            GunModule gunModule = new SprialGunModule();
            gunModule._rotateY = 6.0f;

            gunModule.Init(this);
            _gunModuleList.Add(gunModule);
        }
        {
            GunModule gunModule = new SprialGunModule();
            gunModule._rotateY = -6.0f;
            gunModule.Init(this);
            _gunModuleList.Add(gunModule);
        }
        {
            GunModule gunModule = new NWayGunModule();
            gunModule.Init(this);
            _gunModuleList.Add(gunModule);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprialGunItem : GunItem
{
    override protected void CreateGunModule()
    {
        {
            GunModule gunModule = new SprialGunModule();
            gunModule._rotateY = 1.0f;
            gunModule._wayCount = 7;
            gunModule.Init(this);
            _gunModuleList.Add(gunModule);
        }
        {
            GunModule gunModule = new SprialGunModule();
            gunModule._rotateY = -16.0f;
            gunModule._wayCount = 2;
            gunModule.Init(this);
            _gunModuleList.Add(gunModule);
        }
        
    }
}


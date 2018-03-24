using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunItem : MonoBehaviour
{

    private void Awake()
    {
        //_gunModule.Init(this);
        CreateGunModule();
    }
    // Use this for initialization
    /*
    public struct GunItemAttr
    {
        float shotSpeed;
        int wayCount;
    }*/

    void Start()
    {
        
        //GunItemAttr attr =  GunManager.Instance.FindGunItemAttr();
        //_shotSpeed = attr.shotSpeed;
        //_wayCount = attr.wayCount;
    }

    // Update is called once per frame
    void Update()
    {

    }
    // script
    void ParsingAttr()
    {

    }

    // Interfaced

    protected GameObject _bulletPrefab;
    protected Character.eGroupType _ownerGroupType;
    protected string _itemID = "default_gun";
    protected float _shotSpeed = 0.1f;

    protected List<GunModule> _gunModuleList = new List<GunModule>();
    
    virtual protected void CreateGunModule()
    {
        GunModule gunModule = new GunModule();
        gunModule.Init(this);
        _gunModuleList.Add(gunModule);
        

    }
    virtual public void Fire(Quaternion startRotation)
    {

        if(null  != _bulletPrefab)
        {
            for(int i = 0; i < _gunModuleList.Count; i++)
            {
                _gunModuleList[i].Fire(startRotation);

            }
            //CreateBullet(startRotation);
        }
    }
            
    public void CreateBullet(Quaternion startRotation)
    {
        GameObject bulletObject = GameObject.Instantiate(_bulletPrefab, transform.position, startRotation);
        bulletObject.transform.localScale = Vector3.one;

        bulletObject.GetComponent<BulletItem>().SetOwnerGroupType(_ownerGroupType);
    }


    public void SetBullet(GameObject bulletPrefab)
    {
        _bulletPrefab = bulletPrefab;
    }

    public float GetShotSpeed()
    {
        return _shotSpeed;
    }

    public void InitGroupType(Character.eGroupType groupType)
    {
        _ownerGroupType = groupType;
    }
}
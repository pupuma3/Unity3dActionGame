using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunItem : MonoBehaviour
{
    // Use this for initialization
    struct GunItemAttr
    {
        float shotSpeed;
        int wayCount;
    }


    void Start()
    {
        //GunItemAttr attr =  ScriptManager.Instance.FindGunItemAttr();
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

    protected string _itemID = "default_gun";

    protected float _shotSpeed = 0.5f;
    protected int _wayCount = 3;

    virtual public void Fire(Quaternion startRotation)
    {
        if(null  != _bulletPrefab)
        {
            GameObject bulletObject = GameObject.Instantiate(_bulletPrefab, transform.position, startRotation);
            bulletObject.transform.localScale = Vector3.one;
        }
    }

    public void SetBullet(GameObject bulletPrefab)
    {
        _bulletPrefab = bulletPrefab;
    }

    public float GetShotSpeed()
    {
        return _shotSpeed;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationModule : MonoBehaviour
{
    // Animation
    System.Action _startCallback = null;
    System.Action _middleCallback = null;
    System.Action _endCallback = null;
    public void Play(string triggerName, System.Action startCallback, System.Action middleCallback,
        System.Action endCallback)
    {
        gameObject.GetComponent<Animator>().SetTrigger(triggerName);
        _startCallback = startCallback;
        _middleCallback = middleCallback;
        _endCallback = endCallback;
    }
    public void OnStartAnimation()
    {
        if (null != _startCallback)
        {
            _startCallback();
        }
    }
    public void OnMiddleAnimation()
    {
        if (null != _middleCallback)
        {
            _middleCallback();
        }
    }
    public void OnEndAnimation()
    {
        if(null !=_endCallback)
        {
            _endCallback();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseScene : InitBase
{
    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        Object obj = GameObject.FindAnyObjectByType(typeof(EventSystem));

        if (obj == null)
        {
            var go = Resources.Load<GameObject>("EventSystem");
            var eventSystem = Instantiate(go);
            eventSystem.name = "@EventSystem";
        }


        return true;
    }
}

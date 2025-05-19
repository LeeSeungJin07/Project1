using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Popup : UI_Base
{
    public Action closeCallback = null;

    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        return true;
    }

    public virtual void ClosePopupUI()
    {
        closeCallback?.Invoke();
        closeCallback = null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleScene : BaseScene
{
    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        Managers.Init();

        return true;
    }

    public void OnClick()
    {
        Managers.Scene.LoadScene("LobbyScene");
    }
}

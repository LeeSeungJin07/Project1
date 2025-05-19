using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public static readonly int GAME_SIZE_WIDTH = 1920;
    public static readonly int GAME_SIZE_HEIGHT = 1080;

    public enum UIEvent
    {
        Click,
        Preseed,
        PointerDown,
        PointerUp,
        BeginDrag,
        Drag,
        EndDrag,
    }
}

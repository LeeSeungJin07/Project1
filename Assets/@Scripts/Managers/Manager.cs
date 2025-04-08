using UnityEngine;

public class Manager : MonoBehaviour
{
    public static bool Initialized { get; set; }
    private static bool _isApplicationQuit = false; 

    public static Manager _instance = null;
    private static Manager Instance
    {
        get
        {
            Init();
            return _instance;
        }
    }

    public static void Init()
    {
        if (_isApplicationQuit == true)
            return;

        if (_instance == null && Initialized == false)
        {
            Initialized = true;
            GameObject go = GameObject.Find("@Manager");
            if (go == null)
            {
                go = new GameObject { name = "@manager" };
                go.AddComponent<Manager>();
            }

            DontDestroyOnLoad(go);
            _instance = go.GetComponent<Manager>();

        }
    }

    private void OnApplicationQuit()
    {
        _isApplicationQuit = true;

    }
}

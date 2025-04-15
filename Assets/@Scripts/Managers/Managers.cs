using UnityEngine;

public class Managers : MonoBehaviour
{
    public static bool Initialized { get; set; } = false;
    private static Managers _instance = null;
    private static Managers Instance
    {
        get
        {
            Init();
            return _instance;
        }
    }

    private ResourceManager _resource = new ResourceManager();
    private PoolManager _pool = new PoolManager();

    public static ResourceManager Resource { get { return Instance?._resource; } }
    public static PoolManager Pool { get { return Instance?._pool; } }

    private static bool _isApplicationQuit = false;

    public static void Init()
    {
        if (_isApplicationQuit)
            return;

        if (_instance == null && Initialized == false)
        {
            Initialized = true;
            GameObject go = GameObject.Find("@Managers");

            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);

            _instance = go.GetComponent<Managers>();
        }
    }

    private void OnApplicationQuit()
    {
        _isApplicationQuit = true;
    }

    public static void Clear()
    {

    }
}

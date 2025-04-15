using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Managers.Resource.LoadAllAsync<Object>("local", (key, count, totalCount) =>
        {
            Debug.Log($"{key} 로드 완료 : {count}/{totalCount}");

            if (count == totalCount)
            {
                Load();
            }
        });
    }

    private void Load()
    {
        var squre = Managers.Resource.Instantiate("Square", pooling: true);
        var circle = Managers.Resource.Instantiate("Circle");

        Managers.Resource.Destroy(squre);
        Managers.Resource.Destroy(circle);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

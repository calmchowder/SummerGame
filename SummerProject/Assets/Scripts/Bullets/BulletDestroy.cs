using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour {

    public float lifeTime = 2.0f;

    void OnEnable()
    {
        Invoke("Destroy", lifeTime);
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
    }
}

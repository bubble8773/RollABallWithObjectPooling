using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(this.gameObject, 5.0f);
        Invoke("DestroyBullet", 5.0f);
    }

    void DestroyBullet()
    {
        ObjectPooler._instance.ReturnToPool("bullets", gameObject);
    }

}

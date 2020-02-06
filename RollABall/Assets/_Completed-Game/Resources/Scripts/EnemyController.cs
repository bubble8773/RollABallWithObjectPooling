using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int health;
    public float movementSpeed = 0.0f;
    GameObject playerObj;
    // Start is called before the first frame update

    private void OnEnable()
    {
        health = 3;
    }
    void Start()
    {
       playerObj = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            health--;
            if (health == 0)
            {
                SpawnOb.instance.killCount++;
                //Destroy(this.gameObject);
                gameObject.SetActive(false);
                ObjectPooler._instance.ReturnToPool("Enemy", gameObject);

            }
        }

    }
   
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerObj.transform);
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
        
    }
}

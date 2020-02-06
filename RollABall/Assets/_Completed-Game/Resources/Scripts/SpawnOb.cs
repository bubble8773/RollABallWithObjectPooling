using UnityEngine;
using System.Collections;

public class SpawnOb : MonoBehaviour {

    //public GameObject enemy;
   // public int objNum;
    public int killCount;
    
	Vector3 spawn_pos;

    private float maxWidth, maxHeight, timer;
  
    public static SpawnOb instance;
    
    // Use this for initialization
    void Start () {

        instance = this;
		timer = 0.0f;
		//objNum = 20;
        maxWidth = Screen.width/20;
        maxHeight =  Screen.height/20;
        StartCoroutine (SimpleSpawning ());
       
    }
	
	IEnumerator  SimpleSpawning()
	{
		yield return new WaitForSeconds (2.0f);
		//for(int i = 0; i <= objNum; i++){
			while (timer >= 0) {
				yield return new WaitForSeconds (2.0f);
                spawn_pos =  new Vector3(Random.Range(-maxWidth, maxWidth), 0.0f, Random.Range(-maxHeight, maxHeight));

                GameObject enemy = ObjectPooler._instance.SpawnFromPool("Enemy", spawn_pos, Quaternion.identity);
                //Instantiate(Resources.Load("Prefabs/Enemy"), spawn_pos, Quaternion.identity) as GameObject;
                enemy.transform.SetParent(transform);
                yield return new WaitForSeconds (2.0f);
			}
			yield return new WaitForSeconds(Random.Range(2.0f, 5.0f));
          
       // }
	}
    

    void Update () {

        GameData._instance.killText.text = "Killed: " + killCount;
        timer += Time.deltaTime;
		if (timer >= 1) {
			
			timer = 0.0f;
		}
       
    }
}

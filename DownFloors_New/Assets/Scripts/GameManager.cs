using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public static float terrainSpeed;


	
	void Awake () {
        terrainSpeed = 50000f * Time.deltaTime;
	}
	
	 
    void OnTriggerEnter2D(Collider2D _Collider2D)
    {
        if (_Collider2D.CompareTag("terrain"))
        {
            float x = Random.Range(-309.3755f, 313f);
            float y = -608.2737f;
            _Collider2D.transform.localPosition = new Vector3(x, y, 0);
        }

    }
     
}

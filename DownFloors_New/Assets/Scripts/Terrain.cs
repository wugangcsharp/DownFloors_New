using UnityEngine;
using System.Collections;

public class Terrain : MonoBehaviour {
    
    Transform m_transform;
    float speed;
	// Use this for initialization
	void Start () {
        m_transform = this.transform;
        speed = GameManager.terrainSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        m_transform.Translate(Vector3.up * Time.deltaTime * speed);
         
	}

    

   
}

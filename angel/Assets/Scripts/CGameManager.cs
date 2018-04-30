using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameManager : MonoBehaviour {
    public GameObject Ground;
    public GameObject Floor;

	// Use this for initialization
	void Start () {
        float x = - 9.0f;
        float y = - 4.5f;
        for (; x < 10; x += 1.0f)
        {
            GameObject instance = Instantiate(Ground, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
            instance.transform.SetParent(GetComponent<Transform>());
        }
        for (x = 0.0f, y = -2.5f; y < 50f; y += 2.0f)
        {
            GameObject instance = Instantiate(Floor, new Vector3(Random.Range(- 9f, 9f), y, 0f), Quaternion.identity) as GameObject;
            instance.transform.SetParent(GetComponent<Transform>());
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

}

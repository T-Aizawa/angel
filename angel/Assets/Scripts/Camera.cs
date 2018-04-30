using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    private GameObject Peco;


	// Use this for initialization
	void Start () {
        Peco = GameObject.Find("Peco");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 PecoPos = Peco.transform.position;
        PecoPos.x = 0.0f;
        PecoPos.z = - 10.0f;
        GetComponent<Transform>().position = PecoPos;
		
	}
}

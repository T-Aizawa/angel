using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCamera : MonoBehaviour {
    private GameObject Peco;
    public float LimitY = 2.03f;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
        Peco = GameObject.Find("Peco");
        Vector3 PecoPos = Peco.transform.position;
        PecoPos.x = 0.0f;
        PecoPos.z = - 10.0f;

        float CamPosY = GetComponent<Transform>().position.y;
        //カメラは下には下がらない
        if (CamPosY > PecoPos.y)
        {
            PecoPos.y = CamPosY;
        }
        // カメラの底辺が地面より上のときは、Pecoに追従
        if (PecoPos.y < LimitY)
        {
            PecoPos.y = LimitY;
        }
        GetComponent<Transform>().position = PecoPos;
	}
}

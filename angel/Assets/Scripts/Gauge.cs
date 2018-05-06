using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gauge : MonoBehaviour {
    private float BarSize;
    private GameObject GaugeFront;

	// Use this for initialization
	void Start () {
        BarSize = GetComponent<Transform>().localScale.x;
        GaugeFront = GetComponent<Transform>().Find("JumpGauge_front").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void JumpBarVisualize(float rate)
    {
        GaugeFront.transform.localScale = new Vector3(rate, 1.0f, 1.0f);
        //位置を左に合わせる
        Vector3 tmpPosition = GaugeFront.transform.localPosition;
        tmpPosition.x = -1 * BarSize * (1.0f - rate);
        GaugeFront.transform.localPosition = tmpPosition;
    }
}

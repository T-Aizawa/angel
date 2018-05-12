using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameManager : MonoBehaviour {
    public GameObject Peco;
    public GameObject JumpGauge;

    public GameObject Ground;
    public GameObject Floor;

    //GameManagerから参照する用
    private GameObject refPeco;
    private GameObject refGauge;

	// Use this for initialization
	void Start () {
        CreateObject();

	}

    void CreateObject()
    {
        CreateFloors();
        CreateCharas();
    }

    void CreateFloors()
    {
        float x = -9.0f;
        float y = -4.5f;
        for (; x < 10; x += 1.0f)
        {
            GameObject instance = Instantiate(Ground, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
            instance.transform.SetParent(GetComponent<Transform>());
        }
        for (x = 0.0f, y = -2.5f; y < 50f; y += 2.0f)
        {
            GameObject instance = Instantiate(Floor, new Vector3(Random.Range(-9f, 9f), y, 0f), Quaternion.identity) as GameObject;
            instance.transform.SetParent(GetComponent<Transform>());
        }
    }

    void CreateCharas()
    {
        refPeco = Instantiate(Peco, new Vector3(0f, -3f, 0f), Quaternion.identity) as GameObject;
        refPeco.name = Peco.name;

        refGauge = Instantiate(JumpGauge, new Vector3(-8f, 6f, 15f), Quaternion.identity) as GameObject;
        refGauge.name = JumpGauge.name;
        refGauge.transform.parent = GameObject.Find("Main Camera").transform;
    }

	// Update is called once per frame
	void Update () {
        refGauge.GetComponent<Gauge>().JumpBarVisualize(refPeco.GetComponent<Peco>().GetJumpEnergyRate());
        if(Input.GetKey(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
	}

}

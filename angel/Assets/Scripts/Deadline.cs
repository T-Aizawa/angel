using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deadline : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other)
	{
		// レイヤー名の取得
		string layerName = LayerMask.LayerToName(other.gameObject.layer);

		// レイヤーが足場のとき
		if( layerName == "Foot")
        {
            // 足場の削除
			Destroy(other.gameObject);
        }

		// レイヤーがペコのとき
		if( layerName == "Peco")
        {
            // GameOverのシーンへ移行
			SceneManager.LoadScene("play");
        }
	}
}

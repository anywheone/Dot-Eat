using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountDown : MonoBehaviour {
	public float time = 60;

	void Start () {
		//初期値60を表示
		//float型からint型へCastし、String型に変換して表示
		GetComponent<Text>().text = ((int)time).ToString();
	}

	void Update (){
		//1秒に1ずつ減らしていく
		time -= Time.deltaTime;
		//マイナスは表示しない
		if (time < 0) time = 0;
		GetComponent<Text> ().text = ((int)time).ToString ();
		//制限時間内にクリアできなかった場合ゲームオーバー
		if ( time == 0 ){
			Application.LoadLevel ("Lose");
		}
	}
}
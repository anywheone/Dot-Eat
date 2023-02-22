using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public Transform PlayerPosition;//プレイヤーの位置
	static Vector3 pos;
	UnityEngine.AI.NavMeshAgent agent;
	float agentToPatroldistance;
	float agentToPlayerdistance;
	float Espeed;
	private Rigidbody Enemy;

	void Awake(){
	    agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

	void Start () {
		Enemy = this.GetComponent<Rigidbody> ();
	    //コルーチン実行(start) ←処理を実行し続ける
	}

	void FixedUpdate(){
	    //プレイヤーの位置を取得
	    PlayerPosition = GameObject.FindWithTag("Player").transform;
	}

	void Update(){
	    DoPatrol();

	    //Agentと目的地の距離 移動完了判定　or 敵の速度判定　update 
	    //agentToPatroldistance = Vector3.Distance (this.agent.transform.position, pos);
	    //Agentとプレイヤーの距離
	    //agentToPlayerdistance = Vector3.Distance(this.agent.transform.position,PlayerPosition.transform.position);


	    //プレイヤーとAgentの距離が10f以下になると追跡開始
	    if(agentToPlayerdistance <= 10f ){
	        DoTracking ();
	    //プレイヤーと目的地の距離が15f以下になると次の目的地をランダム指定
	    }else if(agentToPatroldistance < 15f){
	        DoPatrol();
	    }
	}

	    void OnTriggerEnter(Collider other) {  
	        EnemyRotation();
	    }  


	    //エージェントが向かう先をランダムに指定するメソッド
	    public void DoPatrol(){
	        var x = Random.Range(-8.0f, 8.0f);
	        var z = Random.Range(-8.0f, 8.0f);
	        pos = new Vector3 (x, 0, z);
	        bool targetpositionflug = agent.SetDestination (pos);
	    }

	    //playerを追いかけるメソッド
	        public void  DoTracking(){
	        pos = PlayerPosition.position; 
	        agent.SetDestination (pos);
	    }

	    public void EnemyRotation() {
	        transform.rotation = Quaternion.AngleAxis(30, Vector3.up);
	    }  
}
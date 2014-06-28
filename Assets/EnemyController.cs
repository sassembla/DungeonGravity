using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	public enum ENEMY_STATE {
		STATE_RUN,
		STATE_BACK
	};

	public ENEMY_STATE state;


	// Use this for initialization
	void Start () {
		state = ENEMY_STATE.STATE_RUN;
	}
	
	// Update is called once per frame
	void Update () {
		// 一番近所のhashに向けて向かう。
		// ゲームルール上、かならずマスタールートに繋がってるハズなので、stateで向かう、戻る、をさせれば良さそう。
		
	}


}

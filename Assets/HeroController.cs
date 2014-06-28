using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {

	private bool isBacking;

	public enum HERO_STATE {
		STATE_DROP,
		STATE_STOP,
		STATE_DEAD,
		STATE_GRAB
	};

	public HERO_STATE state;


	// Use this for initialization
	void Start () {
		state = HERO_STATE.STATE_DROP;
	}
	
	float before = -1;

	// Update is called once per frame
	void Update () {
		// キャラクターが壁にぶつかると、キー入力がうけつけられるようになる
		if (before == transform.position.y) {
			// false.Assert("現在の位置と過去のy位置がしばらく同じ = 着底した " + transform.position.y);
			// state = HERO_STATE.STATE_STOP;
		}

		// Debug.Log("L:velo " + rigidbody.velocity);
		before = transform.position.y;


		
		if (0 < transform.position.y) {
			
		} else {
			this.gameObject.SetActive(false);
		}
	}

	public void Back (bool situation) {
		isBacking = situation;
	}

}

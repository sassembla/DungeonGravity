using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
	public GameObject heroPrefab;
	public GameObject blockPrefab;
	public GameObject markPrefab;
	public GameObject enemyPrefab;

	private GameObject hero;
	private HeroController heroController;

	Dictionary<int, BlockController> blockMap;

	int WORLD_WIDTH = 50;
	int WORLD_HEIGHT = 40;

	void Awake () {
		var currentHero = Instantiate(heroPrefab) as GameObject;
		currentHero.transform.position = new Vector3((int)(WORLD_WIDTH/2), 46f, 0f);
		this.hero = currentHero;
		

		/*
			ブロックの判定体だけを作成する
			カメラに映ってる範囲だけnewすれば良いと思う
		*/
		blockMap = new Dictionary<int, BlockController>();

		for (int i = 0; i < WORLD_WIDTH * WORLD_HEIGHT; i++) {
			var p = new Point(i % WORLD_WIDTH, i / WORLD_WIDTH);

			var hashKey = p.ToHash();
			(!blockMap.ContainsKey(hashKey)).Assert("すでに含まれてる "+hashKey);

			blockMap[hashKey] = new BlockController(p);
		}


	}


	// Use this for initialization
	void Start () {
		var targetX = hero.transform.position.x;
		
		StartMapping((int)targetX);
	}

	/**
		特定の位置をスタートにして、道を形成する。
	*/
	private void StartMapping (int targetX) {
		// top point
		var targetPointHash = Point.GetHash(targetX, WORLD_HEIGHT-1);

		// このポイントが最初の穴になる。
		var entryPoint = blockMap[targetPointHash];
		entryPoint.Routing();

		var sideWinderDict = new Dictionary<Point, int>();

		// 次に、適当に2ポイントほど掘り進む
		for (int i = 0; i < 100; i++) {
			var nextTargetHash = Point.GetHash(entryPoint.p.x, entryPoint.p.y-i);
			if (blockMap.ContainsKey(nextTargetHash)) blockMap[nextTargetHash].Routing();

			// この間に、ランダムで横に向かうキーをonにする
			var rand = Random.Range(0, 100);
			if (10 < rand) {
				var p = new Point(entryPoint.p.x, entryPoint.p.y-i);
				
				var selection = rand;// あとで方向に使う
				sideWinderDict[p] = selection;
			}
		}

		/**
	
		 */
		foreach (var sides in sideWinderDict.Keys) {
			Debug.Log("L:sides "+sides.y);
		}

		/**
			視覚化
		*/
		foreach (var hash in blockMap.Keys) {
			var block = blockMap[hash];

			if (block.IsRouted()) {
			} else {
				if (block.HasBody()) {} else {
					var point = new Point(hash);
					var currentBlock = Instantiate(blockPrefab) as GameObject;
					currentBlock.transform.position = new Vector3(point.x, point.y, 0);
				}
			}
		}

	}

	
	// Update is called once per frame
	void Update () {
		// キー入力を受け付けて、キャラクターの軌道を弄る
		var hor = Input.GetAxisRaw("Horizontal");
		if (Input.GetKeyDown(KeyCode.Space)) {
			heroController.Back(true);
		} else if (Input.GetKeyUp(KeyCode.Space)) {
			heroController.Back(false);
		}

		else if (hor != 0) {
			// 横向きの力を加える
			false.Assert("左右キー " + hor);
		}

		// 通過したroutedなポイントに対して、Markedを付ける
		var heroPos = Point.GetHash((int)hero.transform.position.x, (int)hero.transform.position.y);
		
		if (blockMap.ContainsKey(heroPos)) {
			var currentPoint = blockMap[heroPos];
			
			if (currentPoint.IsMarked()) {
				
				if (currentPoint.IsUnderAttacked()) {
					currentPoint.SaveMark();

					false.Assert("敵が居る筈なので、帰ってもらう");
				}

			} else {
				var newMark = Instantiate(markPrefab) as GameObject;
				currentPoint.Mark(newMark);
			}
		}


		bool result = UpdateMarksThenDead();
		
		(result).Assert("ひもが切れたのでキャラクターを落とす。もう上がれない。ゲームオーバー");	
	}

	private bool UpdateMarksThenDead () {

		foreach (var blockCont in blockMap.Values) {

		}


		return true;
	}


}

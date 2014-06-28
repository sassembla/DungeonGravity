using UnityEngine;

class BlockController {
	bool isRouted;
	bool isMarked;
	bool isUnderAttacked;
	bool hasBody;
	
	int hp_full;
	int hp;

	GameObject mark;

	public Point p;

	public BlockController (Point p) {
		// ポイントをセットする
		this.p = p;

		// 基本壁
		isRouted = false;

		// まだマークされていない
		isMarked = false;

		// まだ襲われてない
		isUnderAttacked = false;
	}

	public bool IsRouted () {
		return isRouted;
	}

	public bool HasBody () {
		return hasBody;
	}

	public void Routing () {
		isRouted = true;
	}

	/**
		マークをつける。マークにはHPが付与される。
		そのまま大きさとして見える。
	*/
	public void Mark (GameObject mark) {
		isMarked = true;

		"2014/06/28 15:53:51".TimeAssert(1000, "HPをランダムにふりたいが、まあ適当に");
		hp_full = 100;
		hp = hp_full;

		// この位置にマークを出す
		this.mark = mark;
		this.mark.transform.position = new Vector3(p.x, p.y, 0);
	}


	public bool IsMarked () {
		return isMarked;
	}

	public bool IsUnderAttacked () {
		return isUnderAttacked;
	}


	public bool DamagedThenDead (int damage) {
		hp -= damage;
		if (hp < 0) {
			return true;
		}

		// マークのサイズの更新をする
		if (hp < 10) {

		}

		return false;
	}

	/**
		このマークからの敵を追い払う。
	*/
	public void SaveMark () {
		hp = hp_full;

		if (isUnderAttacked) {
			isUnderAttacked = false;
		}
	}




}
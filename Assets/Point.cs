class Point {
	public const int POINT_HASH_VALUE = 1000;
	public int x, y;

	public Point (int x, int y) {
		this.x = x;
		this.y = y;

		(this.y < POINT_HASH_VALUE).Assert("pointのyが大き過ぎてhashが崩壊する");
	}

	public Point (int hash) {
		this.x = hash/POINT_HASH_VALUE;
		this.y = hash%POINT_HASH_VALUE;
	}

	public int ToHash () {
		return this.x * POINT_HASH_VALUE + this.y;
	}

	public static int GetHash (int theX, int theY) {
		return theX * POINT_HASH_VALUE + theY;
	}

}
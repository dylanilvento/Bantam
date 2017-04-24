public static class GameStats {
	private static bool[] completeForts = new bool[4];
	private static int lastFortBeat = -1;

	public static void ConquerFort (int index) {
		completeForts[index] = true;
		lastFortBeat = index;
	}

	public static bool CheckForAllFortsBeat () {
		// bool check = false;

		foreach (bool fort in completeForts) {
			if (fort == false) {
				return false;
			}
		}

		return true;
	}

	public static bool CheckSingleFortBeat(int index) {
		return completeForts[index];
	}

	public static void StartGameOver () {
		for (int ii = 0; ii < completeForts.Length; ii++) {
			completeForts[ii] = false;
			
		}
		lastFortBeat = -1;
	}

	public static int LastFortBeat {
		get {
			return lastFortBeat;
		}

		set {
			lastFortBeat = value;
		}
	}
}
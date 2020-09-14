using UnityEngine;

namespace UnityKit {

public class ScoreStorage : MonoBehaviour {
	private const string HIGH_SCORE_PARAM = "highscore";
	private const string SCORE_PARAM = "score";
    
	[SerializeField] private int scoreLimit;

	public int getHighScore() {
		return PlayerPrefs.GetInt(HIGH_SCORE_PARAM, 0);
	}

	public void trySetHighScore(int score) {
		if (score <= getHighScore()) return;
		PlayerPrefs.SetInt(HIGH_SCORE_PARAM, score);
		PlayerPrefs.Save();
	}

	public int getScore() {
		return PlayerPrefs.GetInt(SCORE_PARAM, 0);
	}

	public void addToScore(int add) {
		PlayerPrefs.SetInt(SCORE_PARAM, Mathf.Clamp(getScore() + add, 0, scoreLimit));
		PlayerPrefs.Save();
	}

	public void resetAll() {
		PlayerPrefs.DeleteAll();
		PlayerPrefs.Save();
	}
}


}
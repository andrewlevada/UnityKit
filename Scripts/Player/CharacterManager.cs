using UnityEngine;

namespace UnityKit {

public class CharacterManager : MonoBehaviour {
	private const string CHAR_ID_PARAM = "character_id";
	private const string CHAR_UNLOCKED_PARAM = "character_unlocked_";
	
	[SerializeField] private RuntimeAnimatorController[] characters
		[SerializeField] private Animator playerAnimator;

	private void Awake() {
		PlayerPrefs.SetInt(CHAR_UNLOCKED_PARAM + 0, 1);
		PlayerPrefs.Save();
	}

	public int getCharacterId() {
		return PlayerPrefs.GetInt(CHAR_ID_PARAM, 0);
	}

	public void trySetToPlayer(int id) {
		if (id < 0 || id >= characters.Length) return;
		if (PlayerPrefs.GetInt(CHAR_UNLOCKED_PARAM + id, 0) == 0) return;
		
		PlayerPrefs.SetInt(CHAR_ID_PARAM, id);
		PlayerPrefs.Save();
		applyToPlayer();
	}

	public void unlock(int id) {
		if (id < 0 || id >= characters.Length) return;
		PlayerPrefs.SetInt(CHAR_UNLOCKED_PARAM + id, 1);
		PlayerPrefs.Save();
	}

	public bool isUnlocked(int id) {
		if (id < 0 || id >= characters.Length) return false;
		return id == 0 || PlayerPrefs.GetInt(CHAR_UNLOCKED_PARAM + id, 0) == 1;
	}

	public void applyToPlayer() {
		int id = PlayerPrefs.GetInt(CHAR_ID_PARAM, 0);
		playerAnimator.runtimeAnimatorController = characters[id];
	}
}

}
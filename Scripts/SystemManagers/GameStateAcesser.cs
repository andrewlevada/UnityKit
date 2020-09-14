namespace UnityKit {

public interface GameStateAcesser {
	GameState getCurrentGameState();
	void notifyGameEnded();
	void notifyGameStarted();
	
	enum GameState {
		InGame,
		OutGame
	}
}

}
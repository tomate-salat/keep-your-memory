using Player;

namespace Manager.ManagerStates {
    
    public class GameRunning : ManagerState {
        public override void OnEnter() {
            Listen(Data.clock.OnFullHour, OnFullHour);
            Listen(Data.playerSpawn.OnPlayerSpawned, OnPlayerSpawned);
            Listen(Data.gameUi.OnGiveUp, Next<GameOver>);
            Listen(Data.gameUi.OnPause, OnPause);
            Listen(Data.gameUi.OnContinue, OnContinue);

            Data.gameUi.gameObject.SetActive(true);
            
            Data.enemySpawner.EnemyLevel = 0;
            
            Data.soundManager.PlayGameClip();
            Data.soundManager.PlayFirstClockRoundShot();
            
            Data.gameManager.StartGame();
        }

        private void OnFullHour() {
            if (Data.gameManager.SpawnWave()) {
                Data.enemySpawner.EnemyLevel++;
            }
        }

        private void OnPause() {
            GameManager.UseDefaultCursor();

            if (Data.PlayerCharacter != null) {
                Data.PlayerCharacter.WeaponSystemActive = false;
            }
        }

        private void OnContinue() {
            Data.gameManager.UseGameCursor();

            if (Data.PlayerCharacter != null) {
                Data.PlayerCharacter.WeaponSystemActive = true;
            }
        }
        
        public override void OnExit() {
            Data.initialTab = 1;
            
            Data.gameUi.gameObject.SetActive(false);
            
            Data.cameraManager.SetFollowTarget(Data.playerSpawn.transform);
            Data.enemySpawner.CleanUp();
            Data.playerSpawn.KillPlayer();
            
            Data.gameManager.GameOver();
        }

        private void OnPlayerSpawned(PlayerCharacter playerCharacter) {
            Listen(playerCharacter.OnPlayerBlownUp, Next<GameOver>);
            
            Data.cameraManager.SetFollowTarget(playerCharacter.transform);
            
            Data.PlayerCharacter = playerCharacter;
        }

    }
    
}
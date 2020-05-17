namespace Manager.ManagerStates {
    
    public class GameOver : ManagerState {
        public override void OnEnter() {
            Listen(Data.menuManager.OnStartGame, Next<GameRunning>);
         
            Data.menuManager.Show(Data.initialTab);
            Data.soundManager.PlayMenuClip();
        }

    }
    
}
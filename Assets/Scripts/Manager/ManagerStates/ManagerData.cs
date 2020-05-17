using System;
using Enemy;
using Level;
using Player;
using Ui;
using UnityEngine;

namespace Manager.ManagerStates {
    
    [Serializable]
    public class ManagerData {
        [Header("Config")]
        public int initialTab = 0;
        
        [Header("Components")]
        public Clock clock;
        public CameraManager cameraManager;
        public GameManager gameManager;
        public MenuManager menuManager;
        public GameUi gameUi;
        public SoundManager soundManager;
        public PlayerSpawn playerSpawn;
        public EnemySpawner enemySpawner;
        
        public PlayerCharacter PlayerCharacter { get; set; }
    }
}
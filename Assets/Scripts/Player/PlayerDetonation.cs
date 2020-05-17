using Common;

namespace Player {
    public class PlayerDetonation : Detonation {
        
        protected override void ExplosionTriggered() {
            GetComponent<WeaponSystem>().enabled = false;
        }

        protected override void ExplosionDone() {
            Destroy(gameObject);
        }
    }
}
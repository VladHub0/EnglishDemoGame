using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.Interface;
using Zenject;


namespace EnglishDemoGame.Scripts.GamePlay.Enemy.Model {
    public class EnemyModel : IEnemyModel
    {
        public float Health { get; set; }
        public float MaxHealth { get; }
        public float Damage { get; set; }
        public float Speed { get; set; }
        public float AttackRange { get; }
        public float AttackCooldown { get; set; }
        public bool IsAlive { get; }


        [Inject]
        public EnemyModel(EnemySettingsSO settings)
        {
            MaxHealth = settings.maxHealth;
            Health = MaxHealth;
            Damage = settings.damage;
            Speed = settings.speed;
            AttackRange = settings.attackRange;
            AttackCooldown = settings.attackCooldown;
        }
    }
}
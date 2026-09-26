using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.Interface;
using Zenject;


namespace EnglishDemoGame.Scripts.GamePlay.Enemy.Model {
    public class EnemyAttackModel : IEnemyAttackModel
    {


        public float MaxDamage {  get; set; }

        public float BaseDamage { get; set; }

        public float AttackRange { get; set; }

        public float AttackCooldown { get; set; }
        [Inject]
        public EnemyAttackModel(EnemyAttackSettingsSO settings)
        {
            MaxDamage = settings.maxDamage;
            BaseDamage = settings.baseDamage;
            AttackRange = settings.attackRange;
            AttackCooldown = settings.attackCooldown;
        }

       
    }
}
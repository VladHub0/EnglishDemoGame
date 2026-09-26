

namespace EnglishDemoGame.Scripts.GamePlay.CommonInterface
{
    public interface IDamageable
    {
        bool IsAlive { get; }
        void ApplyDamage(float damage);
    }
}

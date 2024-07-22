namespace Assets.Resources.Scripts.Interface
{
    public interface IDamageSystem {
        void OnAttack(IDamageSystem damage);
        void OnDamage(int damage);
    }
}
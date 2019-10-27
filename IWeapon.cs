public interface IWeapon
{
    bool rangeWeapon { get; set; }

    void CheckIfRange();
    void Attack();
    int GetWeaponDamage();
    
}

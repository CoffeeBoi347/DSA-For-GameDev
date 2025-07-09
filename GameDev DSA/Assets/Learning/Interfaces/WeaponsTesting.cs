using UnityEngine;

public class WeaponsTesting : MonoBehaviour
{
    private void Start()
    {
        Sword sword = new Sword("Katana", 100);
        Sword sword2 = new Sword("Strawberry Cutter", 150);
        Sword sword3 = new Sword("Banana Cutter", 200);

        Weapon<Sword> weaponHolder = new Weapon<Sword>(sword);
        weaponHolder.Equip();
        weaponHolder.AddWeapon(sword2);
        weaponHolder.AddWeapon(sword3);

        weaponHolder.ViewAllItems();
    }
}
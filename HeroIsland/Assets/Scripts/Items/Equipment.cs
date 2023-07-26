using UnityEngine;
[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;
    public SkinnedMeshRenderer mesh;
    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
        //Equip use
        //Equip remove from the slot
    }
    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);

    }

}

public enum EquipmentSlot {Head, Chest, Legs, Weapon, Shield, Feet}
using System;

public class HealPot : Item
{

    Action<HealPot> healPotAction;

    public float healingTime = 5f;
    public float maxHealValue = 20;

    public HealPot(string name, int cost, int count, int purchaseAmount, bool isStackable, bool equipped,
         float maxHealValue, float healingTime) : base(name, cost, count, purchaseAmount, isStackable, equipped)
    {
        this.healingTime = healingTime;
        this.maxHealValue = maxHealValue;
    }

    protected HealPot(HealPot other) : base(other)
    {
        this.healPotAction = other.healPotAction;

        this.maxHealValue = other.maxHealValue;

        this.healingTime = other.healingTime;
    }

    public override Item Clone()
    {
        return new HealPot(this);
    }

    public void Use()
    {
        if (healPotAction != null)
        {
            healPotAction(this);
        }
    }

    public void RegisterHealPotAction(Action<HealPot> action)
    {
        healPotAction += action;
    }
    public void UnregisterHealPotAction(Action<HealPot> action)
    {
        healPotAction -= action;
    }



}

using System;

public class Bullet : Item
{
    Action<Bullet> cbBulletActions;

    // Damage caused by shooter.
    public float damage;

    // How fast this bullet moves
    public float speed;

    public Bullet(string name, int cost, int count, int purchaseAmount, bool isStackable, bool equipped,
        float damage, float speed) : base(name, cost, count, purchaseAmount, isStackable, equipped)
    {
        this.damage = damage;
        this.speed = speed;
    }

    protected Bullet(Bullet other) : base(other)
    {
        this.damage = other.damage;
        this.speed = other.speed;
    }

    public override Item Clone()
    {
        return new Bullet(this);
    }

    public void RegisterBulletActionsCallback(Action<Bullet> cb)
    {
        cbBulletActions += cb;
    }
}

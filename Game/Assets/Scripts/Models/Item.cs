using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
	public string name;
	public int cost;
	public int count;
	public int purchaseAmount;
	public bool isStackable;
	public bool equipped;

	public Item(string name, int cost, int count,
		int purchaseAmount, bool isStackable, bool equipped)
	{
		this.name           = name;
		this.cost           = cost;
		this.count          = count;
		this.purchaseAmount = purchaseAmount;
		this.isStackable    = isStackable;
		this.equipped       = equipped;
	}

	protected Item(Item other)
	{
		this.name           = other.name;
		this.cost           = other.cost;
		this.count          = other.count;
		this.purchaseAmount = other.purchaseAmount;
		this.isStackable    = other.isStackable;
		this.equipped       = other.equipped;
	}

	public virtual Item Clone()
	{
		return new Item(this);
	}
}

public class Item
{
	public string name;

	public int cost;

	public bool isStackable;

	public int count;

	// PurchaseAmount is 1 by default but we can change
	// when creating prototypes.
	public int purchaseAmount = 1;

	public virtual Item Clone()
	{
		return null;
	}
}

using UnityEngine;

public class ItemPickup : Interactable {

	public Item item;
	public override void Interact() {
		base.Interact();
		PickUp();
	}

	// Pick up the item
	void PickUp() {
		Debug.Log("Picking up " + item.name);
		if (Inventory.instance.Add(item)) {
			Destroy(gameObject);
		}
	}

}

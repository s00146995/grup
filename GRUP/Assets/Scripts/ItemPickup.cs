using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : RayCaster
{
    public override void ItemInteract()
    {
        base.ItemInteract();

    }

    public override void BedInteract()
    {
        base.BedInteract();
    }

    public override void PotionInteract()
    {
        base.PotionInteract();
    }
}

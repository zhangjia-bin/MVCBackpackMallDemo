using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData
{
    int id, price, max;

    public ItemData(int id, int price, int max)
    {
        this.Id = id;
        this.Price = price;
        this.Max = max;
    }

    public int Id { get => id; set => id = value; }
    public int Price { get => price; set => price = value; }
    public int Max { get => max; set => max = value; }
}

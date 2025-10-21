using static UnityEngine.Rendering.DebugUI;

public class Items
{
    public string name;
    public int price;

    public Items(string name, int price)
    {
        this.name = name;
        this.price = price;
    }

    public override string ToString()
    {
        return $"Name: {name}, Price: {price}";
    }
}


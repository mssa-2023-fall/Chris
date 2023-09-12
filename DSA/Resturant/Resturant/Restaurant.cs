using System;

public class Restaurant
{
    public string DishOptions(string protein)
    {
        string order = protein.ToLower();
        switch (order)
        {
            case "beef":
                return "hamburger";
            case "pepperoni":
                return "pizza";
            case "tofu":
                return "tofu fried rice";
            case "chicken":
                return "general tso's chicken";
            case "fish":
                return "blackened fish tacos";
            case "pork":
                return "pulled pork sliders";
            default:
                return "That protein is not available.";
        }
    }
}

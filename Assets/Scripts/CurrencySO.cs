using UnityEngine;

[CreateAssetMenu(fileName = "Currency", menuName = "ScriptableObjects/Currency")]
public class CurrencySO : ScriptableObject
{
    public int amount;
    public enum currencyType
    {
        goldenCoin,
        poopCoin,
    }
}

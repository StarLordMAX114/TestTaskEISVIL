using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private Text _coinText;
    private int _newValue;
    
    public void Display(int value)
    {
        _newValue += value;
        _coinText.text = string.Empty;
        _coinText.text = $"Coins: {_newValue}";
    }
}

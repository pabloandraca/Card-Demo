using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] Image cardImage;
    [HideInInspector] public CardData cardData;
    [HideInInspector] public int playerIndex;

    public void Initialize(CardData _data, int _playerIndex)
    {
        cardData = _data;
        playerIndex = _playerIndex;
        cardImage.sprite = cardData.sprite;
    }
}
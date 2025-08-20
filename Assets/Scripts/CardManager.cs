using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CardData
{
    public Sprite sprite;
    public int power;

    public CardData(Sprite sprite, int power)
    {
        this.sprite = sprite;
        this.power = power;
    }
}

public class CardManager : MonoBehaviour
{
    public static CardManager Instance { get; private set; }

    [SerializeField] GameObject cardPrefab;
    [SerializeField] Image discardImage;

    public Transform[] players;
    public List<CardData> cards = new();
    public Queue<CardData> deck = new();
    public Stack<CardData> discard = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        LoadCards();

        CreateDeck();

        Deal(5, 0);
        Deal(5, 1);
    }

    void LoadCards()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Cards");

        foreach (Sprite sprite in sprites)
        {
            string[] parts = sprite.name.Split('_');
            int power = int.Parse(parts[0]);

            cards.Add(new CardData(sprite, power));
        }
    }

    void CreateDeck()
    {
        List<CardData> shuffledCards = new();

        foreach (CardData card in cards)
        {
            shuffledCards.Add(card);
        }

        Utils.ShuffleList(shuffledCards);

        foreach (CardData card in shuffledCards)
        {
            deck.Enqueue(card);
        }
    }

    public void Deal(int amount, int playerIndex)
    {
        for (int i = 0; i < amount; i++)
        {
            if (deck.Count > 0)
            {
                CardData topCard = deck.Dequeue();
                Card card = Instantiate(cardPrefab, players[playerIndex]).GetComponent<Card>();
                card.Initialize(topCard, playerIndex);
            }
        }
    }

    public void Discard(CardData card)
    {
        discard.Push(card);

        discardImage.sprite = card.sprite;
    }
}
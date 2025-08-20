using UnityEngine;

public class Table : MonoBehaviour
{
    void Update()
    {
        CheckForCardsOnTable();
    }

    void CheckForCardsOnTable()
    {
        if (transform.childCount == CardManager.Instance.players.Length)
        {
            Card[] cardsOnTable = GetComponentsInChildren<Card>();

            Card winner = GetWinner(cardsOnTable);

            Debug.Log($"Winner is Player {winner.playerIndex + 1} with card power {winner.cardData.power}");

            foreach (Card card in cardsOnTable)
            {
                CardManager.Instance.Discard(card.cardData);
                Destroy(card.gameObject);
            }
        }
    }

    Card GetWinner(Card[] cards)
    {
        Card winner = null;
        int highestPower = 0;

        foreach (Card card in cards)
        {
            if (card.cardData.power > highestPower)
            {
                highestPower = card.cardData.power;
                winner = card;
            }
        }

        return winner;
    }
}
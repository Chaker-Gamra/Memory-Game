using System.Collections.Generic;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    public GameObject cardPrefab;//The card Prefab
    private List<Vector3> cardPositions = new List<Vector3>();//8 positions for our cards
    public CardBlueprint[] cards;//4 cards information(id, image)

    public static Card firstCard = null;
    public static Card secondCard = null;

    public GameObject victoryPanel;

    float timer;
    void Start()
    {
        //Calculate the 8 card positions (2 rows ,4 columns)
        for(int row = 0; row < 2; row++)
        {
            for(int col = 0; col < 4; col++)
            {
                Vector3 cardPosition = new Vector3(col, 0, row) * 2.5f + new Vector3(-4,0,-3);
                cardPositions.Add(cardPosition); 
            }
        }

        //Instanciate 8 cards in random positions
        for(int i = 0; i < 8; i++)
        {
            int randomIndex = Random.Range(0, cardPositions.Count);
            Vector3 randomPos = cardPositions[randomIndex];
            GameObject cardGO = Instantiate(cardPrefab, randomPos, Quaternion.identity);
            cardPositions.Remove(randomPos);

            cardGO.GetComponent<Card>().cardID = cards[i % 4].ID;
            cardGO.GetComponent<Card>().cardSR.sprite = cards[i % 4].sprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Check for Victory
        if (FindObjectsOfType<Card>().Length == 0)
        {
            victoryPanel.SetActive(true);
        }

        //Compare When we select two images
        if (firstCard != null && secondCard != null)
        {
            timer += Time.deltaTime;
            if (timer > 1.5f)
            {
                timer = 0;
                if (firstCard.cardID == secondCard.cardID)
                {
                    Destroy(firstCard.gameObject);
                    Destroy(secondCard.gameObject);
                }
                else
                {
                    firstCard.transform.Rotate(0, 0, 180);
                    firstCard.canRotate = true;
                    secondCard.transform.Rotate(0, 0, 180);
                    secondCard.canRotate = true;
                }
                firstCard = null;
                secondCard = null;
            }
        }
            
    }
}

using UnityEngine;

public class Card : MonoBehaviour
{
    public int cardID;
    public SpriteRenderer cardSR;
    public bool canRotate = true;

    private void OnMouseDown()
    {
        if (CardsManager.firstCard != null && CardsManager.secondCard != null)
            return;

        if (canRotate)
        {
            canRotate = false;
            transform.Rotate(0, 0, 180);
            if (CardsManager.firstCard == null)
                CardsManager.firstCard = this;
            else
                CardsManager.secondCard = this;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtons : MonoBehaviour
{
    public GameObject highScorePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAgain()
    {
        highScorePanel.SetActive(false);
        ResetScene();
    }

    public void ResetScene()
    {
        Debug.Log("Resetting Scene");
        // find all the cards and remove them
        UpdateSprite[] cards = FindObjectsOfType<UpdateSprite>();
        Debug.Log("Found " + cards.Length + " cards");
        foreach (UpdateSprite card in cards)
        {
            Destroy(card.gameObject);
        }
        Debug.Log("Destroyed all cards");
        ClearTopValues();
        Debug.Log("Cleared top values");
        // deal new cards
        FindObjectOfType<Solitaire>().PlayCards();
        Debug.Log("Dealt new cards");
    }

    void ClearTopValues()
    {
        Selectable[] selectables = FindObjectsOfType<Selectable>();
        foreach (Selectable selectable in selectables)
        {
            if (selectable.CompareTag("Top"))
            {
                selectable.suit = null;
                selectable.value = 0;
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public GameObject swipeToMove,finger;
    public TextMeshProUGUI scoreText;
    public int scoreCounter = 0;

    private void Update() 
    {
        if(Input.touchCount > 0)
        {
            swipeToMove.SetActive(false);
            finger.SetActive(false);
        }
    }

    public void ScoreIncrease()
    {
        scoreCounter ++;
        scoreText.text = scoreCounter.ToString();
    }

}

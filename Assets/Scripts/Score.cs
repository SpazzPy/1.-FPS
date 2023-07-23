using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI deadText;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        scoreText.text = "Zombies: " + count + " / 14";
    }

    private void Update()
    {
        if (count >= 14)
        {
            GetComponent<DeathHandler>().HandleDeath();
            deadText.text = "Ganaste";
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            GetComponent<DeathHandler>().HandleDeath();
            deadText.text = "Menu";
        }
    }


    public void AddOne()
    {
        count++;
        scoreText.text = "Zombies: " + count + " / 14";
    }
}

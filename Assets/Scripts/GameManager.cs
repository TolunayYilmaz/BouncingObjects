using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Targets;
    // Start is called before the first frame update
    private float spawnRate = 1f;
    public TextMeshProUGUI ScoreText;
    private int score;
    void Start()
    {
     StartCoroutine(SpawnTarget());
        score = 0;
      
 
    }


    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int randomTargetIndex = Random.Range(0, Targets.Count);
            Instantiate(Targets[randomTargetIndex]);
            Debug.Log("Çalisti");// Thanks to the while, the loop is running continuously. If it is written in the normal method, the method will fill up because it will run very fast.

        }

    }
   
    public void UpdateScore(int addedScore)
    {
        score += addedScore;
        ScoreText.text = "Score: " + score;
    }
}

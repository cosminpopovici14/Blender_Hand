using TMPro;
using UnityEngine;

public class ShowScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Score: {ScoreGenerator.totalScore}";
    }
}

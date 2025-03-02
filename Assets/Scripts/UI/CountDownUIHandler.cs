using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountDownUIHandler : MonoBehaviour
{
    public TextMeshProUGUI countDownText;
    private void Awake()
    {
        if (countDownText != null)
        {
            countDownText.text = "";
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(CountDownCO());
    }

    IEnumerator CountDownCO()
    {
        yield return new WaitForSeconds(0.3f);

        int counter = 3;

        while (true)
        {
            if (counter != 0)
            {
                countDownText.text = counter.ToString();
            }
            else
            {
                countDownText.text = "GO!";

                GameManager.instance.OnRaceStart();
                break;
            }

            counter--;
            // Delay in between each number
            yield return new WaitForSeconds(1.0f);
        }

        // Delay before "GO!" disappears 
        yield return new WaitForSeconds(0.5f);
        // Hides countdown canvas
        gameObject.SetActive(false);
    }
}

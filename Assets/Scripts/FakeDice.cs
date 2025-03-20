using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FakeDice : MonoBehaviour
{
    public Button kickButton; // Refer�ncia ao bot�o
    public TMP_Text resultText; // Refer�ncia ao texto onde o resultado ser� exibido
    public int biasedNumber = 6;  // N�mero favorecido
    public int biasChance = 33;   // Chance do n�mero favorecido sair

    void Start()
    {
        kickButton.onClick.AddListener(RollLoadedDice);
    }


    void RollLoadedDice()
    {
        Debug.Log("Jogando dado viciado...");
        int randomProbability = Random.Range(1, 101);
        int diceResult;

        if (randomProbability <= biasChance)
        {
            diceResult = biasedNumber;
        }
        else
        {
            diceResult = Random.Range(1, 7);
            if (diceResult == biasedNumber)
            {
                diceResult = Random.Range(1, 7);
            }
        }

        Debug.Log("O n�mero sorteado �: " + diceResult);
        resultText.text = "O n�mero sorteado �: " + diceResult;
    }

}

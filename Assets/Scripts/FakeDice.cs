using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FakeDice : MonoBehaviour
{
    public Button kickButton; // Referência ao botão
    public TMP_Text resultText; // Referência ao texto onde o resultado será exibido
    public int biasedNumber = 6;  // Número favorecido
    public int biasChance = 33;   // Chance do número favorecido sair

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

        Debug.Log("O número sorteado é: " + diceResult);
        resultText.text = "O número sorteado é: " + diceResult;
    }

}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FakeDice : MonoBehaviour
{
    // Refer�ncia ao bot�o na interface gr�fica
    public Button kickButton;

    // Refer�ncia ao componente de texto onde ser� exibido o resultado do dado
    public TMP_Text resultText;

    // N�mero favorecido pelo dado "viciado"
    public int biasedNumber = 6;

    // Chance percentual de o n�mero favorecido ser sorteado
    public int biasChance = 33;

    void Start()
    {
        // Adiciona um listener ao bot�o para chamar o m�todo RollLoadedDice ao ser pressionado
        kickButton.onClick.AddListener(RollLoadedDice);
    }

    // M�todo que simula o lan�amento de um dado viciado
    void RollLoadedDice()
    {
        Debug.Log("Jogando dado viciado...");

        // Gera um n�mero aleat�rio entre 1 e 100 para determinar se o dado sair� viciado
        int randomProbability = Random.Range(1, 101);
        int diceResult;

        // Se o n�mero aleat�rio estiver dentro da chance de vi�s, retorna o n�mero favorecido
        if (randomProbability <= biasChance)
        {
            diceResult = biasedNumber;
        }
        else
        {
            // Caso contr�rio, gera um n�mero aleat�rio entre 1 e 6
            diceResult = Random.Range(1, 7);

            // Se o n�mero gerado for o favorecido, gera outro n�mero aleat�rio (para evitar vi�s acidental)
            if (diceResult == biasedNumber)
            {
                diceResult = Random.Range(1, 7);
            }
        }

        // Exibe o resultado no console
        Debug.Log("O n�mero sorteado �: " + diceResult);

        // Atualiza o texto na interface gr�fica com o resultado
        resultText.text = "O n�mero sorteado �: " + diceResult;
    }
}

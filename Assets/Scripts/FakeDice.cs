using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FakeDice : MonoBehaviour
{
    // Referência ao botão na interface gráfica
    public Button kickButton;

    // Referência ao componente de texto onde será exibido o resultado do dado
    public TMP_Text resultText;

    // Número favorecido pelo dado "viciado"
    public int biasedNumber = 6;

    // Chance percentual de o número favorecido ser sorteado
    public int biasChance = 33;

    void Start()
    {
        // Adiciona um listener ao botão para chamar o método RollLoadedDice ao ser pressionado
        kickButton.onClick.AddListener(RollLoadedDice);
    }

    // Método que simula o lançamento de um dado viciado
    void RollLoadedDice()
    {
        Debug.Log("Jogando dado viciado...");

        // Gera um número aleatório entre 1 e 100 para determinar se o dado sairá viciado
        int randomProbability = Random.Range(1, 101);
        int diceResult;

        // Se o número aleatório estiver dentro da chance de viés, retorna o número favorecido
        if (randomProbability <= biasChance)
        {
            diceResult = biasedNumber;
        }
        else
        {
            // Caso contrário, gera um número aleatório entre 1 e 6
            diceResult = Random.Range(1, 7);

            // Se o número gerado for o favorecido, gera outro número aleatório (para evitar viés acidental)
            if (diceResult == biasedNumber)
            {
                diceResult = Random.Range(1, 7);
            }
        }

        // Exibe o resultado no console
        Debug.Log("O número sorteado é: " + diceResult);

        // Atualiza o texto na interface gráfica com o resultado
        resultText.text = "O número sorteado é: " + diceResult;
    }
}

using UnityEngine;
using TMPro; // Biblioteca para usar TextMeshPro

public class Dice : MonoBehaviour
{
    // Campo de entrada de texto (onde o jogador digita um número)
    private TMP_InputField entryText;

    // Exibe o número sorteado no dado
    private TextMeshProUGUI resultText;

    // Exibe o resultado (se acertou ou errou)
    private TextMeshProUGUI exitText;

    void Start()
    {
        // Inicializa os componentes de texto ao iniciar o jogo
        GetActionComponent();

        // Busca e atribui o componente de texto para exibir o número sorteado
        resultText = GameObject.Find("ResultText").GetComponent<TextMeshProUGUI>();

        // Busca e atribui o componente de texto para exibir o resultado da tentativa
        exitText = GameObject.Find("ExitText").GetComponent<TextMeshProUGUI>();
    }

    // Método para buscar e atribuir o campo de entrada de texto
    public void GetActionComponent()
    {
        entryText = GameObject.Find("EntryText").GetComponent<TMP_InputField>();
    }

    // Método chamado ao pressionar o botão "Chutar!"
    public void RollDice()
    {
        // Verifica se o campo de entrada foi encontrado corretamente
        if (entryText == null)
        {
            return; // Sai do método se entryText não estiver atribuído
        }

        // Gera um número aleatório entre 1 e 6 (simulando um dado)
        int roll = Random.Range(1, 7);

        // Exibe o número sorteado no texto de resultado
        resultText.text = $"O número correto é {roll}";

        // Remove espaços extras do input e tenta converter para número inteiro
        string entryTextTrimmed = entryText.text.Trim();

        // Verifica se o jogador digitou um número válido
        if (int.TryParse(entryTextTrimmed, out int userGuess))
        {
            // Garante que o número digitado esteja no intervalo de 1 a 6
            if (userGuess >= 1 && userGuess <= 6)
            {
                // Verifica se o número digitado é igual ao número sorteado
                if (roll == userGuess)
                {
                    exitText.text = "VOCÊ ACERTOU!!!"; // Mensagem de acerto
                }
                else
                {
                    exitText.text = "VOCÊ ERROU!!!"; // Mensagem de erro
                }
            }
            else
            {
                exitText.text = "Número inválido! Digite um número entre 1 e 6"; // Mensagem de entrada inválida
            }
        }
    }
}

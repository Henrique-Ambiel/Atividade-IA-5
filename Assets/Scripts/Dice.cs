using UnityEngine;
using TMPro; // Biblioteca para usar TextMeshPro

public class Dice : MonoBehaviour
{
    // Campo de entrada de texto (onde o jogador digita um n�mero)
    private TMP_InputField entryText;

    // Exibe o n�mero sorteado no dado
    private TextMeshProUGUI resultText;

    // Exibe o resultado (se acertou ou errou)
    private TextMeshProUGUI exitText;

    void Start()
    {
        // Inicializa os componentes de texto ao iniciar o jogo
        GetActionComponent();

        // Busca e atribui o componente de texto para exibir o n�mero sorteado
        resultText = GameObject.Find("ResultText").GetComponent<TextMeshProUGUI>();

        // Busca e atribui o componente de texto para exibir o resultado da tentativa
        exitText = GameObject.Find("ExitText").GetComponent<TextMeshProUGUI>();
    }

    // M�todo para buscar e atribuir o campo de entrada de texto
    public void GetActionComponent()
    {
        entryText = GameObject.Find("EntryText").GetComponent<TMP_InputField>();
    }

    // M�todo chamado ao pressionar o bot�o "Chutar!"
    public void RollDice()
    {
        // Verifica se o campo de entrada foi encontrado corretamente
        if (entryText == null)
        {
            return; // Sai do m�todo se entryText n�o estiver atribu�do
        }

        // Gera um n�mero aleat�rio entre 1 e 6 (simulando um dado)
        int roll = Random.Range(1, 7);

        // Exibe o n�mero sorteado no texto de resultado
        resultText.text = $"O n�mero correto � {roll}";

        // Remove espa�os extras do input e tenta converter para n�mero inteiro
        string entryTextTrimmed = entryText.text.Trim();

        // Verifica se o jogador digitou um n�mero v�lido
        if (int.TryParse(entryTextTrimmed, out int userGuess))
        {
            // Garante que o n�mero digitado esteja no intervalo de 1 a 6
            if (userGuess >= 1 && userGuess <= 6)
            {
                // Verifica se o n�mero digitado � igual ao n�mero sorteado
                if (roll == userGuess)
                {
                    exitText.text = "VOC� ACERTOU!!!"; // Mensagem de acerto
                }
                else
                {
                    exitText.text = "VOC� ERROU!!!"; // Mensagem de erro
                }
            }
            else
            {
                exitText.text = "N�mero inv�lido! Digite um n�mero entre 1 e 6"; // Mensagem de entrada inv�lida
            }
        }
    }
}

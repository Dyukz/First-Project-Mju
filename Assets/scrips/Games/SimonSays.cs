using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimonSays : MonoBehaviour
{   
    private int[] numbers = new int [5];
    private int[] inputs = {1, 0, 2, 2, 2};
    
    
    void Start()
    {
        Game();
    }
    void Update()
    {
        
    }

    void Game()
    {
        for (int round = 0; round < numbers.Length; round++)
        {
           numbers[round] = Random.Range(0, 8);
           // nummer zeigen
           // inputs sammeln
           for (int i = 0; i < round; i++)
            {
                if (!(inputs[i] == numbers[i]))
                {
                    print("FEHLER!");
                    return;
                }
            }
        }
    }
}

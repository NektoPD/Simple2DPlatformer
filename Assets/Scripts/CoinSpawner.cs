using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _template;

    private void Start()
    {
       foreach (Transform childTransform in transform)
        {
            Coin newCoin = Instantiate(_template, childTransform.position, Quaternion.identity);
        }
    }
}

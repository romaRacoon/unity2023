using UnityEngine;

public class Coin : MonoBehaviour
{
    public void Destroy()
    {
        this.gameObject.SetActive(false);
    }
}

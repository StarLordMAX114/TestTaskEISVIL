using UnityEngine;

public class Coin : MonoBehaviour
{
    private int _coinCount = 1;
    private CoinUI _coinUI;

    private int _speedRotation = 200;
    private float _heightFly = 2;
    
    private void Update()
    {
        Fly();
        Rotate();
    }
    
    private void Fly()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time * 2, _heightFly), transform.localPosition.z);

    }
    private void Rotate()
    {
        transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation),Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _coinUI = FindObjectOfType<CoinUI>();
            _coinUI.Display(_coinCount);
            
            Destroy(gameObject);
        }
    }
}

using Mono.Cecil;
using UnityEngine;

public sealed class Reference : MonoBehaviour
{
    private Rigidbody _bullet;
    private GameObject _coin;

    public Rigidbody Bullet
    {
        get
        {
            if (_bullet == null)
            {
                _bullet = Resources.Load<Rigidbody>("Bullet");
            }
            return _bullet;
        }
        set => _bullet = value;
    }

    public GameObject Coin
    {
        get
        {
            if (_coin == null)
            {
                _coin = Resources.Load<GameObject>("Coin");
            }
            return _coin;
        }
        set => _coin = value;
    }
}

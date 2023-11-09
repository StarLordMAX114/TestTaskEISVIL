using UnityEngine;

public sealed class Reference : MonoBehaviour
{
    private Rigidbody _bullet;
    private GameObject _coin;
    private GameObject _Uwin;

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
    
    public GameObject U_WIN
    {
        get
        {
            if (_Uwin == null)
            {
                _Uwin = Resources.Load<GameObject>("U_WIN");
            }
            return _Uwin;
        }
        set => _Uwin = value;
    }

}

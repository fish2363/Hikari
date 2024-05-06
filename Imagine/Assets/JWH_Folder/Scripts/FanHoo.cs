using UnityEngine;

public class FanHoo : MonoBehaviour
{
    public bool isLeft = true;
    [SerializeField] private Transform cusionTransform;
    [SerializeField] private Transform friendTransform;
    [SerializeField] private Transform playerTransform;
    private Gotobad gotobad;

    private IControllerPhysics[] _playerControllers;

    private void Awake()
    {
        _playerControllers = new IControllerPhysics[2]
        {
            GameObject.Find("Player").GetComponent<IControllerPhysics>(),
            GameObject.Find("Friend").GetComponent<IControllerPhysics>()
        };

        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        friendTransform = GameObject.Find("Friend").GetComponent<Transform>();


        if (!isLeft)
        {
            transform.Rotate(0, 180, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IControllerPhysics component;
        if (collision.transform.TryGetComponent<IControllerPhysics>(out component))
        {
            component.isCollisionStay = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("cusion"))
        {
            gotobad = collision.GetComponent<Gotobad>();
            if(gotobad.isCatch == false)
            {
                cusionTransform = collision.GetComponent<Transform>();
                if (isLeft)
                {
                    cusionTransform.position += new Vector3(-0.01f, 0, 0);
                }
                else
                {
                    cusionTransform.position += new Vector3(0.01f, 0, 0);
                }
            }
        }

        for(int i = 0; i<2; i++)
        {
            if (_playerControllers[i].isCollisionStay == false) continue;

            if ((isLeft == true && _playerControllers[i].h < 0) || (isLeft == false && _playerControllers[i].h > 0))
            {
                _playerControllers[i].moveSpeed = 5;
                print("속도증가");
            }
            if ((isLeft == true && _playerControllers[i].h > 0) || (isLeft == false && _playerControllers[i].h < 0))
            {
                print("속도감소");
                _playerControllers[i].moveSpeed = 1;
                _playerControllers[i].jump = 4;
            }
            if (_playerControllers[i].h == 0)
            {
                if (isLeft)
                {
                    _playerControllers[i].trm.position += new Vector3(-0.01f, 0, 0);
                }
                else
                {
                    _playerControllers[i].trm.position += new Vector3(0.01f, 0, 0);
                }
            }
        }
        

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IControllerPhysics component;
        if (collision.transform.TryGetComponent<IControllerPhysics>(out component))
        {
            component.isCollisionStay = false;
        }
        for (int i = 0; i<2; ++i)
        {
            _playerControllers[i].moveSpeed = 3;
            _playerControllers[i].jump = 6;
        }
    }
}

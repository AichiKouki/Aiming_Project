using UnityEngine;

public class ThirdPersonEnemyController : MonoBehaviour
{
    [SerializeField]
    private Enemy actor;

    private bool Jump { get; set; }

    public bool bCatch;

    public bool bThrown;

    [SerializeField]
    private FollowTarget mainCamera;

    [SerializeField]
    private GameObject player;

    Transform pos;

    Rigidbody rigid;

    Score score;

    //投げられた時の位置修正
    Vector3 thrownPos;

    int nCnt = 0;

    private void Start()
    {
        score = GameObject.Find("ScoreUI").GetComponent<Score>();
        rigid = GetComponent<Rigidbody>();

        if (actor == null)
            actor = GetComponent<Enemy>();
        
    }

    private void Update()
    {
        if( transform.position.x > 48.0f)
        {
            Suicide();
        }
    }

    private void FixedUpdate()
    {
        if( player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (!bCatch)
        {
            var h = -0.5f;
            var v = 0;

            var Enemymove = v * Vector3.back + h * Vector3.left;
       
            actor.Move(Enemymove, Jump);
            Jump = false;
        }
        if (bCatch && bThrown == false)
        {
            var Pos = player.transform.position;
            gameObject.transform.position = new Vector3( Pos.x - 2, Pos.y, Pos.z);
        }
        if (bCatch && bThrown)
        {
            if (mainCamera == null)
                mainCamera = Camera.main.GetComponent<FollowTarget>();

            mainCamera.Target = transform;



            //var h = 100;
            //var v = 0;

            //var Enemymove = v * Vector3.back + h * Vector3.left;

            //actor.Move(Enemymove, Jump);

            nCnt++;
            if( nCnt > 90)
            {
                Suicide();
                return;
            }


            if (Input.GetKeyDown(KeyCode.Space))
            {
                Suicide();
                return;
            }
        }

        //if (Input.GetKey(KeyCode.Return) && bCatch)
        //{
        //    Thrown();
        //}

    }

    public bool Catched()
    {
        if (bCatch == true)
        {
            return false;
        }
        bCatch = true;

        transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);

        var hoge = gameObject.GetComponent<EnemyAttacker>();
        Destroy(hoge);

        return bCatch;
    }

    public bool Thrown()
    {
        if (bThrown == true)
        {
            return false;
        }
        bThrown = true;

        //thrownPos = new Vector3(transform.position.x, 0, transform.position.z);
        //transform.position = thrownPos;
        
        rigid.AddForce(-500, 0, 0);
        rigid.useGravity = false;

        return bThrown;
    }

    public void Suicide()
    {
        var pos = player.GetComponentInChildren<Transform>();

        mainCamera.Target = pos;

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (bThrown)
            {
                score.AddScore();
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "Player")
        //{
        //    if ( !bCatch && !bThrown)
        //    {
        //        Catched();
        //    }
        //}
    }
}

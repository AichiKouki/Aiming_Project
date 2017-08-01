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
            Suicide();//正直これはいらない
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
		//掴まれていないし、投げられてなければ、自分(敵)は左に移動し続ける。
        if (bCatch && bThrown == false)
        {
            var Pos = player.transform.position;
            gameObject.transform.position = new Vector3( Pos.x - 2, Pos.y, Pos.z);
        }
		//掴まれたし、投げられたら、カメラが投げた敵を追従する。スマブラのホームランみたいな演出。
        if (bCatch && bThrown)
        {
            if (mainCamera == null)
                mainCamera = Camera.main.GetComponent<FollowTarget>();

            //mainCamera.Target = transform;//敵を投げた瞬間に、カメラがそれを追従する処理

            nCnt++;
            if( nCnt > 90)
            {
                Suicide();
                return;
            }

			//スペースキーを押したら、
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Suicide();//これを消しても何も影響がなかった。なんのための機能やねん
                return;
            }
        }

        //if (Input.GetKey(KeyCode.Return) && bCatch)
        //{
        //    Thrown();
        //}

    }

	//自分(敵)をプレイヤーが掴む処理
    public bool Catched()
    {
		//すでに掴んでいたら、処理しない
        if (bCatch == true)
        {
            return false;
        }
		//掴んだことを示すフラグ
        bCatch = true;

		transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);//プレイヤーに掴まれた瞬間に、自分(敵)のサイズを変更する

        var hoge = gameObject.GetComponent<EnemyAttacker>();//自分のEnemyAttackerスクリプトを取り出す
		Destroy(hoge);//自分(敵)のEnemuyAttakerスクリプトを削除する。

        return bCatch;//掴んだことを示すので、掴んだ処理をしてから、trueを返す
    }

	//投げられた時の処理
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

	//何のためにあるかわからん関数
    public void Suicide()
    {
        var pos = player.GetComponentInChildren<Transform>();

        mainCamera.Target = pos;

        Destroy(gameObject);
    }

	//敵が敵にぶつかったら、スコア処理して、オブジェクト削除処理。基本的には敵は一列に移動するので、プレイヤーがぶつけようとしない限りぶつかることはない。
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

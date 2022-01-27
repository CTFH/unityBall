using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hall : MonoBehaviour
{
    //どのボールを吸い寄せるかをタグで指定
    public string targetTag; //string参照型
    //targetにして後から登録できるようにしておく

    //boolean
    bool isHolding;
    
    //ボールが入っているかを返す
    public bool IsHolding()
    {
        return isHolding; //privateで就職していると外部から見えずアクセスできない
        //publicにしてゲッターセッターでアクセスできるようにしている
    }

    void OnTriggerEnter(Collider other)//接触した瞬間に（１回だけ）はしる
    {
        if(other.gameObject.tag==targetTag)
        {
            isHolding = true;
        }
    }

    void OnTriggerExit(Collider other)//出ていく瞬間に（１回だけ）はしる
    {
        if(other.gameObject.tag==targetTag)
        {
            isHolding = false;
        }
    }

    void OnTriggerStay(Collider other)//１秒間に６０回はしる
        //コライダとコライダが接触している間はしり続ける
        //センサに接触している間中Trueになるメソッド
        //HallにはisTrigerなコライダがついている
        //引数に実際にセンサに侵入してきたものが入る（other）
    {
        //コライダに触れているオブジェクトのRigidbodyコンポーネントを取得
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();
        //同じ色のボールだったら自分のほうにAddForceして
        //違ったら外側にAddForceして跳ね返す
        //otherは入ってきたもののコライダ
        //.gameObjectでBall（red）全体（親）。GetComponentで子要素にアクセス。
        //rigidbodyにアクセス
        //★★テスト出る

        //ボールがどの方向にあるかを計算
        Vector3 direction = other.gameObject.transform.position - transform.position;
        direction.Normalize();
        //transformはGEtcomponentと書かなくても
        //小文字で子要素にアクセス出来る
        //★★いきなりtransformでてきたらこのオブジェクトがアタッチされている
        //オブジェクトのtransform（Hall）
        //ベクトルの引き算
        //Normarizeは長さを１にする（生まれたベクトルの長さを1にする）方向成分はそのまま
        //ホールとボールの中点を結んだのがdirection
        //ホールの大きさによらずdirection大きさ１


        //タグに応じてボールに力を加える
        if (other.gameObject.tag == targetTag)
        //ぶつかってきた方のタグとホールに登録したタグを照合する

        {
            //中心地店でボールを止めるため速度を減速させる
            r.velocity *= 0.9f;//velocity速度
            r.AddForce(direction * -20.0f, ForceMode.Acceleration);
            //もし同じ色だったらマイナスかけて引き寄せる

        }
        else
        {
            r.AddForce(direction * 80.0f, ForceMode.Acceleration);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

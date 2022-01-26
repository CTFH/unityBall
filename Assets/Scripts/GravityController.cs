using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
    //:でimplements（実装）などを表している
{


    //重力加速度
    const float Gravity = 9.81f;
    //f忘れるとダブルに認識されてfloatに代入不可エラーになっちゃう

    //重力の適用具合
    public float gravityScale = 1.0f;
    //アクセス修飾子つけなかったらprivate。 publicにするときは明示的に記載する
    //publicで書いたのはinspectorに出力され、inspectorで調整できるようになる


    void Start()
    {
        //consoleに出力される
        //C#はメソッドの先頭1文字目大文字
        Debug.Log("OK");    
    }

    void Update()//動画を更新する
        //１秒間に約60回通る 
        //while trueと一緒
    {
        Debug.Log("in");

        //Vector3型（xyzをまとめて扱う。フィールドにx,y,z)
        Vector3 vector = new Vector3();

        //キーの入力を検知しベクトルを設定
        vector.x = Input.GetAxis("Horizontal");//unityの入力関係はinputクラスがする
        //Horizontal →にプラス、左だとマイナス　（左右キー）
        //jumpやhorizontal等を一元管理してるのは色々な端末で使えるようにするため
        vector.z = Input.GetAxis("Vertical");//（上下キー）

        //高さ方向の判定はキーのzとする
        if (Input.GetKey("z")) //zキーが押されているときにTrue
        {
            vector.y = 1.0f;
        }
        else
        {
            vector.y = -1.0f;
        }
        //シーンの重力を入力ベクトルの方向に合わせて変化させる
        Physics.gravity=Gravity* vector.normalized*gravityScale;
        //normarizedはあってもなくてもほとんど差がない　同時押ししたとき方向成分そのままで長さを１にする
        //（ルート２が１になる）
    }

   

    // Update is called once per frame


}


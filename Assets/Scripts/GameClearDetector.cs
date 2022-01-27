using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearDetector : MonoBehaviour//publicなのでInspectorに登場
{
    public GameObject holeRed;// Hall   Hall(Hale)クラスの型
    public Hall holeBlue;//同じプロジェクト内なら見つけてくれる
    public Hall holeGreen;//Null。HallScriptを持っているものを登録することによってうまる。

    void OnGUI()//１秒間に６０回
    {
        //全てのボールが入ったらラベルを表示
        //()はメソッド呼び出すとき　<>は型指定
        //holeRed.IsHolding()
        if(holeRed.GetComponent<Hall>().IsHolding() && holeBlue.IsHolding() && holeGreen.IsHolding())
        //hall(hale)クラスのインスタンスなので、いきなりisHoldingが使える
        //３つともクリアだったらGameClearを表示（1秒間に60回）
        {
            //画面の左上から50x-offset、50y-offset、そこからwith100、高さ30の長方形の入れ物
            GUI.Label(new Rect(50, 50, 100, 30), "Game Clear!");
        }
    }

}

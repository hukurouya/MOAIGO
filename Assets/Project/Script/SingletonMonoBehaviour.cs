﻿using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T> 
{
    // インスタンスの変数
    private static T instance;
    

    // プロパティ
    // * Javaなど、他言語の場合は"ゲッター(Getter)"、"セッター(Setter)"と呼ばれることが多い
    public static T Instance 
    {
        get 
        {
            if (instance == null) 
            {
                instance = (T)FindObjectOfType(typeof(T));
            }

            return instance;
        }
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    protected void Awake() 
    {
        CheckInstance();
    }

    /// <summary>
    /// 単一のインスタンスが作られているかをチェックするメソッド
    /// </summary>
    /// <returns>true = 作成済み, false = すでにあります</returns>
    protected bool CheckInstance() 
    {
        if (instance == null) 
        {
            instance = (T)this;
            return true;
        } 
        else if (Instance == this) 
        {
            return true;
        }

        Destroy(this.gameObject);
        return false;
    } 
}
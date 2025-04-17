using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

/**********************************
 * フェードアニメーション
 **********************************/
public class FadeManager : MonoBehaviour
{
    private static bool _isPlay;

    public static bool IsPlay
    {
        get { return _isPlay; }
    }

    public static void Begin(Action callback = default)
    {
        if(_isPlay) return;

        CreateCanvas();
        CreateFadeImage(Color.white);

        if(callback != null) callback();
    }

    public static async void FadeImage(Image target, float a, float t, Action callback = default)
    {
        _isPlay = true;
        
        target = _fadeImage;

        float deltaTime = 0;

        Color c = target.color;
        float alpha = c.a;

        if(a <= 0) alpha = 1;
        else alpha = 0;

        while ( deltaTime <= t || target == null )
        {
            #if UNITY_EDITOR
            if (!EditorApplication.isPlaying) return;
            #endif

            deltaTime += Time.deltaTime;

            c.a = Mathf.Lerp(alpha, a, deltaTime / t);
            
            target.color = c;

            //Debug.Log($"Fade:deltaTime = { deltaTime }, alpah = { c.a.ToString("F2") }, time = { (deltaTime / t * 100).ToString("F2") }%");

            await Task.Yield();
        }

        if(callback != null) callback();
    }

    public static void Finish()
    {
        _isPlay = false;

        Destroy(_canvasObject);
    }

    private static GameObject _canvasObject;
    private static RectTransform _canvasTransform;
    private static Canvas _canvas;
    private static CanvasScaler _scaler;
    private static GraphicRaycaster _raycaster;

    private static void CreateCanvas()
    {
        _canvasObject = new GameObject("Fade Canvas");
        _canvasObject.layer = LayerMask.NameToLayer("UI");

        _canvasTransform = _canvasObject.AddComponent<RectTransform>();

        _canvas = _canvasObject.AddComponent<Canvas>();
        _canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        _canvas.worldCamera = Camera.main;
        _canvas.planeDistance = 100f;

        _scaler = _canvasObject.AddComponent<CanvasScaler>();
        _scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        _scaler.referenceResolution = new Vector2(Screen.width, Screen.height);
        _scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
        _scaler.matchWidthOrHeight = 0.5f;

        _raycaster = _canvasObject.AddComponent<GraphicRaycaster>();       
        
        DontDestroyOnLoad(_canvasObject);
    }


    private static GameObject _fadeObject;
    private static RectTransform _imageTransform;
    private static Image _fadeImage;

    private static void CreateFadeImage(Color color)
    {
        _fadeObject = new GameObject("Fade Image");
        _fadeObject.AddComponent<CanvasRenderer>();
        
        _imageTransform = _fadeObject.AddComponent<RectTransform>();
        _imageTransform.SetParent(_canvasTransform);
        _imageTransform.localPosition = Vector3.zero;
        _imageTransform.sizeDelta = new Vector2(Screen.width, Screen.height);

        _fadeImage = _fadeObject.AddComponent<Image>();
        _fadeImage.color = color;
    }

    
}

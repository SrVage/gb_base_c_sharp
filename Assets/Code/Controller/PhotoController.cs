using System.Collections;
using System.IO;
using UnityEngine;
using UnityEditor;
using Object = UnityEngine.Object;

namespace Code.Controller
{
    public sealed class PhotoController
    {
        private bool _isProcessed;
        private readonly string _path;
        private int _layers = 5;
        private int _resolution = 5;
        private Camera _camera;
        private Transform _player;

        public PhotoController()
        {
            _path = Application.dataPath;
            _camera = GameObject.Find("ScreenshotCamera").GetComponent<Camera>();
            _player = Object.FindObjectOfType<Player>().gameObject.transform;
        }

        public void TakeMap()
        {
            if (_isProcessed) return;
           Coroutines.instance.StartCoroutine(DoTapExampleAsync());
        }
                              
        private IEnumerator DoTapExampleAsync()
        {
            Debug.Log("Start");
            _camera.gameObject.transform.position = _player.position+new Vector3(0,49.5f,0);
            var y = _player.eulerAngles.y;
            _camera.gameObject.transform.rotation = Quaternion.Euler(new Vector3(90, 0, -y));
            _isProcessed = true;
            var sw = _camera.pixelWidth;
            var sh = _camera.pixelHeight;
            yield return new WaitForEndOfFrame();
            RenderTexture rt = new RenderTexture(sw, sh, 24);
            _camera.targetTexture = rt;
            _camera.Render();
            var sc = new Texture2D(sw, sh, TextureFormat.RGB24, true);
            RenderTexture.active = rt;
            sc.ReadPixels(new Rect(0, 0, sw, sh-1), 0, 0);
            sc.Apply();
            var bytes = sc.EncodeToPNG();
            var filename = "map.png";
            File.WriteAllBytes(Path.Combine(_path, filename), bytes);
            Debug.Log("end");
            AssetDatabase.Refresh();
            _camera.targetTexture = null;
            RenderTexture.active = null;
            rt.Release();
            yield return new WaitForSeconds(1f);
            _isProcessed = false;
        }

    }
}
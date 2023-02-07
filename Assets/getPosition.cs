using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Linq;

// UnityWebRequest.Get example

// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.

public class getPosition : MonoBehaviour
{

    private float nextActionTime = 0.0f;
    public float period = 0.5f;

    void Start()
    {

    }

    void Update()
    {

        if (Time.time > nextActionTime)
        {
            nextActionTime += period;

            // A correct website page.
            StartCoroutine(GetRequest("https://63e11f4b59bb472a7431470f.mockapi.io/position"));
        }
    }


IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            // This code is very embarrassing, however its also just to play around
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    string str = webRequest.downloadHandler.text;
                    int freq = str.Count(f => (f == '{'));
                    print(freq/25 + 1);
                    gameObject.GetComponent<turn>().SetToPosition(freq/25 + 1);
                    break;
            }
        }
    }
}
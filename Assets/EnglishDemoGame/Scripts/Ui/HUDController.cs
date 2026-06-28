using TMPro;
using UnityEngine;
using Zenject;

using EnglishDemoGame.Scripts.UI.Interface;
using UnityEditor.ShaderGraph.Internal;
using Unity.Hierarchy;
using System.Collections;



namespace EnglishDemoGame.Scripts.UI
{

    public class HUDController : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI previewText;
        [SerializeField] private float displayTime = 2.0f;


        private IPreviewTextProvider _previewTextProvider;

        [Inject]
        public void Construct(IPreviewTextProvider previewTextProvider)
        {
            _previewTextProvider = previewTextProvider;

            Debug.LogWarning("IPreviewTextProvider injects dependency");
        }
        private void Start()
        {
            previewText.SetText(_previewTextProvider.GetPreviewText());
            StartCoroutine(PreviewDisplay(displayTime));
        }

        private IEnumerator PreviewDisplay(float displayTime)
        {
            yield return new WaitForSeconds(displayTime);
            previewText.SetText("");
        }
    }

   
}

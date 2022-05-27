using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MyGame.Scripts.Tools
{
    internal sealed class CustomText : MonoBehaviour
    {
        [SerializeField] private Text text;
        [SerializeField] private TextMeshProUGUI textMeshProUGUI;

        public string Text
        {
            get { return GetText(); }
            set { SetText(value); }
        }
        private void Start() => Initialize();
        private void OnValidate() => Initialize();



        private void Initialize()
        {
            bool hasAnyTextComponent = TryAttachTextComponent<Text>(ref text)
                | TryAttachTextComponent<TextMeshProUGUI>(ref textMeshProUGUI);

            if (!hasAnyTextComponent)
                throw new UnityException("Can't attach any text component!");
            
        }

        private bool TryAttachTextComponent<TComponent>(ref TComponent component) where TComponent : Component
        {
            if (component != null)
                return true;

            return TryGetComponent<TComponent>(out component);
        }

        public void SetText(string _text)
        {
            if (text != null)
                text.text = _text;
            else if (textMeshProUGUI != null)
                textMeshProUGUI.text = _text;

        }

        public string GetText()
        {
            if (text != null)
                return text.text;

            if (textMeshProUGUI != null)
                return textMeshProUGUI.text;

            return string.Empty;
        }
    }
}

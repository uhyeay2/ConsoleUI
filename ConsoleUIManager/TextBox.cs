using ConsoleUIManager.ExtensionMethods;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUIManager
{
    public class TextBox
    {
        public TextBox(int boxWidth)
        {
            BoxWidth = boxWidth;
        }

        public TextBox(IEnumerable<string> text, int boxWidth)
        {
            _text = text;
            BoxWidth = boxWidth;
        }

        public int BoxWidth { get; set; }

        public IEnumerable<string> Text => _text;

        public IEnumerable<string> TextCentered => _text.PadToCenter(MaxStringLength);

        public IEnumerable<string> TextCenteredInsideBorder => _text.PadToCenter(MaxStringLength).InsideSimpleBorder(BoxWidth);

        public IEnumerable<string> TextInsideBorder => _text.InsideSimpleBorder(BoxWidth);

        private IEnumerable<string> _text { get; set; }

        private int MaxStringLength => BoxWidth - 4;

        /// <summary>
        /// Add a single string to the end of the Text
        /// </summary>
        /// <param name="text"></param>
        public void ConcatText(string text)
        {
            _text = _text.Append(text);
        }

        /// <summary>
        /// Add a collection of strings to the end of the Text
        /// </summary>
        /// <param name="text"></param>
        public void ConcatText(IEnumerable<string>[] text)
        {
            _text = _text.ToArray().Concat(Text);
        }

        /// <summary>
        /// Change the Text to the collection of strings provided.
        /// </summary>
        /// <param name="text"></param>
        public void SetText(IEnumerable<string> text)
        {
            _text = text;
        }

        /// <summary>
        /// Change the Text to the collection(s) of strings provided.
        /// </summary>
        /// <param name="text"></param>
        public void SetText(params IEnumerable<string>[] text)
        {
            _text = text.Aggregate((a, b) => a.Concat(b));
        }
    }
}
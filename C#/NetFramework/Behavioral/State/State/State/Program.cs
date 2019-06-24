using System;

namespace State
{
    /// <summary>
    /// It lets you change the behavior of a class when the state changes.
    /// </summary>
    public class Program
    {
        static void Main()
        {
            var editor = new TextEditor();

            editor.Type("First line");

            editor.SetState(new UpperCase());

            editor.Type("Second, upper-cased line");
            editor.Type("Third, upper-cased line");

            editor.SetState(new LowerCase());

            editor.Type("Fourth, lower-cased line");
            editor.Type("Fifth, lower-cased line");
        }
    }

    /// <summary>
    /// First of all we have our state interface and some state implementations
    /// </summary>
    public interface IWritingState
    {
        void Write(string words);
    }

    public class UpperCase : IWritingState
    {
        public void Write(string words)
        {
            Console.WriteLine(words.ToUpperInvariant());
        }
    }

    public class LowerCase : IWritingState
    {
        public void Write(string words)
        {
            Console.WriteLine(words.ToLowerInvariant());
        }
    }

    public class DefaultText : IWritingState
    {
        public void Write(string words)
        {
            Console.WriteLine(words);
        }
    }

    /// <summary>
    /// Then we have our editor
    /// </summary>
    public class TextEditor
    {
        private IWritingState state;

        public TextEditor()
        {
            state = new DefaultText();
        }

        public void SetState(IWritingState writingState)
        {
            state = writingState;
        }

        public void Type(string words)
        {
            state.Write(words);
        }
    }
}
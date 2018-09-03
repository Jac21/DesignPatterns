using System;

namespace Memento
{
    /// <summary>
    /// Memento pattern is about capturing and storing the current state of an 
    /// object in a manner that it can be restored later on in a smooth manner.
    /// </summary>
    public class Program
    {
        static void Main()
        {
            var editor = new Editor();

            // type some stuff
            editor.Type("This is the first sentence.");
            editor.Type("This is the second.");

            // Save the state to restore to : This is the first sentence. This is second.
            editor.Save();

            // type some more
            editor.Type("This is the third");

            // output the content
            Console.WriteLine(editor.Content);

            // restoring to last saved state
            editor.Restore();

            Console.WriteLine(editor.Content);
        }
    }

    /// <summary>
    /// First of all we have our memento object that will be able to hold 
    /// the editor state
    /// </summary>
    public class EditorMemo
    {
        public string Content { get; }

        public EditorMemo(string content)
        {
            Content = content;
        }
    }

    /// <summary>
    /// Then we have our editor i.e. originator that is going to use memento object
    /// </summary>
    public class Editor
    {
        public string Content => content;
        private string content = string.Empty;
        private EditorMemo memento;

        public Editor()
        {
            memento = new EditorMemo(string.Empty);
        }

        public void Type(string words)
        {
            content = string.Concat(content, " ", words);
        }

        public void Save()
        {
            memento = new EditorMemo(content);
        }

        public void Restore()
        {
            content = memento.Content;
        }
    }
}
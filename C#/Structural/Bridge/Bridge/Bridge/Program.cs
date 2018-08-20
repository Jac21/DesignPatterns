using System;

namespace Bridge
{
    /// <summary>
    /// Bridge pattern is about preferring composition over inheritance. 
    /// Implementation details are pushed from a hierarchy to another object with a separate hierarchy.
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            var darkTheme = new DarkTheme();
            var lightTheme = new LightTheme();

            var about = new About(darkTheme);
            var careers = new Careers(lightTheme);

            Console.WriteLine(about.GetContent());
            Console.WriteLine(careers.GetContent());
        }
    }

    /// <summary>
    /// Here we have the WebPage hierarchy
    /// </summary>
    public interface IWebPage
    {
        string GetContent();
    }

    public class About : IWebPage
    {
        protected ITheme Theme;

        public About(ITheme theme)
        {
            Theme = theme;
        }

        public string GetContent()
        {
            return $"About page in {Theme.GetColor()}";
        }
    }

    class Careers : IWebPage
    {
        protected ITheme Theme;

        public Careers(ITheme theme)
        {
            Theme = theme;
        }

        public string GetContent()
        {
            return $"Careers page in {Theme.GetColor()}";
        }
    }

    /// <summary>
    /// And the separate theme hierarchy
    /// </summary>
    public interface ITheme
    {
        string GetColor();
    }

    class DarkTheme : ITheme
    {
        public string GetColor()
        {
            return "Dark Black";
        }
    }

    class LightTheme : ITheme
    {
        public string GetColor()
        {
            return "Off White";
        }
    }

    class AquaTheme : ITheme
    {
        public string GetColor()
        {
            return "Light blue";
        }
    }
}
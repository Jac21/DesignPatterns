namespace Singleton.Structural
{
    public class StructuralSingleton
    {
        private static StructuralSingleton _instance;

        protected StructuralSingleton()
        {
            
        }

        public static StructuralSingleton Instance()
        {
            // uses lazy instantiation, not thread safe
            if (_instance == null)
            {
                _instance = new StructuralSingleton();
            }

            return _instance;
        }
    }
}

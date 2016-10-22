namespace Examples.Singletons
{
    public class Singleton
    {
        private static object lockObject;

        private static Singleton instance;

        protected Singleton()
        {
        }

        public static Singleton Instance
        {
            get
            {
                if (Singleton.instance == null)
                {
                    lock (lockObject)
                    {
                        if (Singleton.instance == null)
                        {
                            Singleton.instance = new Singleton();
                        }
                    }
                }

                return Singleton.instance;
            }
        }

        public void DoWork()
        {
        }
    }
}

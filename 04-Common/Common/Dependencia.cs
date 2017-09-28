namespace Common
{
    //clase para usar la libreria de LightInject como depencia
    public class Dependencia
    {
        public static T GetInstance<T>()
        {
            return new LightInject.ServiceContainer()
                                  .GetInstance<T>();
        }
    }
}

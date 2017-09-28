using Common;
using System;
using System.Configuration;
using System.Linq;
using System.Reflection;


namespace PoliclinicoWeb.App_Start
{
    public class ParamaterConfig
    {
        public static void Initialize()
        {
            var properties = typeof(Parametros).GetProperties(BindingFlags.Public |
                                                          BindingFlags.Static);

            foreach (var p in properties)
            {
                var setting = ConfigurationManager.AppSettings.Get(p.Name);

                if (p.PropertyType.Name.ToLower().Equals("string"))
                {
                    p.SetValue(typeof(Parametros), setting);
                }

                if (p.PropertyType.Name.ToLower().Equals("int32"))
                {
                    p.SetValue(typeof(Parametros), Convert.ToInt32(setting));
                }

                if (p.PropertyType.Name.ToLower().Equals("decimal"))
                {
                    p.SetValue(typeof(Parametros), Convert.ToDecimal(setting));
                }

                if (p.PropertyType.Name.ToLower().Equals("double"))
                {
                    p.SetValue(typeof(Parametros), Convert.ToDouble(setting));
                }

                if (p.PropertyType.Name.ToLower().Equals("boolean"))
                {
                    p.SetValue(typeof(Parametros), (setting.ToLower() == "true"));
                }

                if (p.PropertyType.Name.ToLower().Equals("list`1"))
                {
                    p.SetValue(typeof(Parametros), setting.ToLower().Split(',').ToList());
                }
            }
        }
    }
}
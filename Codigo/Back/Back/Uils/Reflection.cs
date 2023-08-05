using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HirCasa.Back.Uils
{
    public static class Reflection
    {
        public static T CreateInstaceClass<T>(Type type, params object?[] objects)
        {

            return (T)Activator.CreateInstance(type, objects);
        }
        public static Out ChangeObject<Out, In>(In model) where Out : class where In : class
        {
            var newModel = Activator.CreateInstance<Out>();
            model.GetType().GetProperties().ToList().ForEach(f => {
                PropertyInfo propertyInfo = newModel.GetType().GetProperty(f.Name.Trim());
                if (propertyInfo != null)
                {
                    var valueProp = f.GetValue(model);
                    var t = propertyInfo.PropertyType;
                    if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                    {
                        t = Nullable.GetUnderlyingType(t);
                    }
                    propertyInfo.SetValue(newModel, (valueProp == null) ? null : Convert.ChangeType(valueProp, t, null));
                }
            });
            return newModel;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Components.DictionaryAdapter;
using System.Collections;

namespace Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, object>()
                {
                    { "UserId", 1234567 },
                    { 
                        "UserName", new Dictionary<string,object>()
                        {
                            { "UserFirstName", "Tim" },
                            { "UserLastName", "Rayburn" }
                        }
                    }
                };

            var data = new DictionaryAdapterFactory().GetAdapter<IUserData>(dict);

            Console.WriteLine(data.Name.FirstName);
            Console.ReadLine();
        }
    }

    public class NestedDictionaryGetterBehavior : Attribute, IDictionaryPropertyGetter
    {
        public object GetPropertyValue(IDictionaryAdapter dictionaryAdapter, string key, object storedValue, PropertyDescriptor property, bool ifExists)
        {
            if (property.PropertyType.IsAssignableFrom(storedValue.GetType()))
            {
                return storedValue;
            }

            if (property.PropertyType.IsInterface && IsDictionary(storedValue.GetType()))
            {
                return dictionaryAdapter.This.Factory.GetAdapter(property.PropertyType, storedValue as IDictionary);
            }

            return storedValue;
        }

        public int ExecutionOrder
        {
            get { return 0; }
        }

        private bool IsDictionary(Type type)
        {
            return typeof(IDictionary).IsAssignableFrom(type);
        }
    }
}

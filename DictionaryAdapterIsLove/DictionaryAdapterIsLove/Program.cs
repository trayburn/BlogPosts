using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Components.DictionaryAdapter;

namespace DictionaryAdapterIsLove
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, object>()
                {
                    { "UserId", 1234567 },
                    { "UserFirstName", "Tim" },
                    { "UserLastName", "Rayburn" }
                };

            IUserData data = new DictionaryAdapterFactory().GetAdapter<IUserData>(dict);

            Console.WriteLine(data.FirstName);
            Console.ReadLine();
        }

        //public static string UglyWayToGetUserFirstName(Dictionary<string, object> dict)
        //{
        //    string userFirstName = "UserFirstName";
        //    if (dict.ContainsKey(userFirstName)) return dict[userFirstName] as string;
        //    return null;
        //}

        //public static string CleanWayToGetUserFirstName(IUserData data)
        //{
        //    return data.UserFirstName;
        //}
    }

    public interface IUserData
    {
        [Key("UserId")]
        int Id { get; set; }

        [Key("UserFirstName")]
        string FirstName { get; set; }

        [Key("UserLastName")]
        string LastName { get; set; }
    }

}

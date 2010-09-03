using System;
using Castle.Components.DictionaryAdapter;
using System.Collections.Generic;
using System.Collections;

namespace Part2
{
    [NestedDictionaryGetterBehavior]
    public interface IUserData
    {
        [Key("UserId")]
        int Id { get; set; }

        [Key("UserName")]
        IUserName Name { get; set; }
    }

    public interface IUserName
    {
        [Key("UserFirstName")]
        string FirstName { get; set; }

        [Key("UserMiddleName")]
        string MiddleName { get; set; }

        [Key("UserLastName")]
        string LastName { get; set; }
    }

    public class CustomName : IUserName
    {
        private IDictionary dict;

        public CustomName(IDictionary dictionary)
        {
            this.dict = dictionary;
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}

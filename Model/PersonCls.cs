using System;

namespace Model
{
    public class PersonCls
    {
        /* 
          init keyword 
           - you can only assign the value in a constructor
           - you can't change it afterwards even 
             inside the class's methods, which is
             different from a private property
        */
        public PersonCls(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public string FirstName { get; init; }
        public string LastName { get; init; }
    }
}

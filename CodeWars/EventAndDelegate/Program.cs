using System;
using System.Collections.Generic;

public class PersonEventArgs : EventArgs
{
    public string Name { get; set; }

    public PersonEventArgs() { }

    public PersonEventArgs(string name)
    {
        Name = name;
    }
}


public class Publisher
{
    public event EventHandler<PersonEventArgs> ContactNotify;

    public void NotifyContact(string name)
    {
        ContactNotify?.Invoke(this, new PersonEventArgs(name));
    }


    public void CountMessages(List<string> peopleList)
    {
        Dictionary<string, int> personCount = new Dictionary<string, int>();
        foreach (string person in peopleList)
        {
            if(!personCount.ContainsKey(person))
            {
                personCount[person] = 0;
            }
            personCount[person]++;

            if (personCount[person] % 3 == 0)
            {
                NotifyContact(person); // Notify subscribers
            }
        }
    }
}
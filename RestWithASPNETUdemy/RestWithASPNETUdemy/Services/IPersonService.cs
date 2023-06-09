﻿using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services
{
    public interface IPersonService
    {
        List<Person> FindAll();
        Person Create(Person person);
        Person FindById(long id);
        Person Update(Person person);
        void Delete(long id);
    }
}

﻿using Core.Puertto;

namespace PuerttoAPI.Interfaces
{
    public interface IExample
    {
        Task SaveDataExample(Example example);

        Task<List<Example>> All();
    }
}
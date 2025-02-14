using System;
using UnityEngine;
using System.Collections.Generic;
namespace Customer
{
    [Serializable]
    public class CustomerData
    {
        public int id;
        public string name;
        public string nickname;
        public int age;
    }

    [Serializable]
    public class CustomerList
    {
        public List<CustomerData> customers;
    }
}
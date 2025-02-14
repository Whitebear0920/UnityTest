using UnityEngine;
using Customer;
using System.IO;
using JetBrains.Annotations;
using Mono.Cecil;
public class CustomerManager : MonoBehaviour
{
    private CustomerList customers;
    void Awake()
    {
        LoadCustomer();
        UpdateCusomerName(2,"HI");
    }
    private void LoadCustomer()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath,$"Customer.json");
        if(File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            customers = JsonUtility.FromJson<CustomerList>(json);
            Debug.Log(json);
            foreach(var customer in customers.customers)
            {
                Debug.Log($"{customer.name} {customer.nickname} {customer.age}");
            }
            Debug.Log(customers.customers);
        }
    }

    private void UpdateCusomerName(int id,string name)
    {
        CustomerData targetCustomer = customers.customers.Find(c => c.id == id);
        if(targetCustomer != null)
        {
            targetCustomer.name = name;
            string updateJson = JsonUtility.ToJson(customers,true);
            File.WriteAllText(Path.Combine(Application.streamingAssetsPath,$"Customer.json"),updateJson);
        }

    }
}
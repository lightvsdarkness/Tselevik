using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tselevik.Models;

using Firebase.Database;
using Firebase.Database.Query;
using System.Diagnostics;

namespace Tselevik.Services
{
    class FirebaseDataStore : IDataStore<Item>
    {
        List<Item> items;

        FirebaseClient _firebase = new FirebaseClient("https://apptselevik.firebaseio.com/");
        int databaseId;
        Random _random = new Random();
        public FirebaseDataStore()
        {
            items = new List<Item>();

            object databaseIdObject;
            if (App.Current.Properties.TryGetValue("databaseId", out databaseIdObject))
            {
                databaseId = (int)databaseIdObject;
                Debug.WriteLine("Found databaseId: " + databaseId);
            }
            else
            {
                databaseId = _random.Next();

                App.Current.Properties.Add("databaseId", databaseId);
                Debug.WriteLine("Not found databaseId: " + databaseId);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            //items.Add(item);
            await _firebase
              .Child("Items_" + databaseId)
              .PostAsync(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            //return await Task.FromResult(items);
            var _items = await _firebase
                .Child("Items_" + databaseId)
                .OnceAsync<Item>();
            foreach (var item in _items)             {
                Debug.WriteLine($"FKey: {item.Key}");
            }

            items = (await _firebase
              .Child("Items_" + databaseId)
              .OnceAsync<Item>()).Select(item => new Item
              {
                  Id = item.Object.Id,
                  Text = item.Object.Text,
                  Description = item.Object.Description,
                  Date = item.Object.Date,
                  Importance = item.Object.Importance,
                  Category = item.Object.Category
              }).ToList();
            return items;
        }
    }
}

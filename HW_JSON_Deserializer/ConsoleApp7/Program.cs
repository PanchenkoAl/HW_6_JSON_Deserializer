// See https://aka.ms/new-console-template for more information\
using System.IO;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Serialization;

string path = @"D:\Alexander's\json1.json"; // Enter Own Path

using (FileStream fstream = File.OpenRead(path)) //1. Десеріалізація
{
    var books = await JsonSerializer.DeserializeAsync<List<Book>>(fstream);
    foreach(var book in books)
    {
        book.Name = book.Title; // 3. об'єкт містить Title з назвою Name
        Console.WriteLine($"{book.PublishingHouseId} - {book.Title} - {book.PublishingHouse.Id} - {book.PublishingHouse.Name} - {book.PublishingHouse.Address}");
    }
}

class Book
{
    public Book(int publishingHouseId, PublishingHouse publishingHouse, string title)
    {
        PublishingHouseId = publishingHouseId;
        PublishingHouse = publishingHouse;
        Title = title;
    }
    [JsonIgnore] //2. Не серіалізуємо поле PublishingHouseId
    public int PublishingHouseId { get; set; }
    public PublishingHouse PublishingHouse { get; set ; }
    public string Title { get; set; }


    // 3. об'єкт містить Title з назвою Name
    public string Name { get; set; }
}
class PublishingHouse
{
    public PublishingHouse(int id, string name, string address)
    {
        Id = id;
        Name = name;
        Address = address;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}

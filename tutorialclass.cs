////////////////////////////////////////////////////// EXAMPLE 1 ///////////////////////////////////////////////////////

// using System;

// namespace OOPConcepts
// {
//     class LibraryItem
//     {
//         private string Title { get; set; }
//         private int YearPublished { get; set; }
//         class Book : LibraryItem
//         {
//             public string Author { get; set; }
//         }
//         class Program
//         {
//             static void Main(string[] args)
//             {
//                 LibraryItem items = new LibraryItem { Title = "The Great Gatsby", YearPublished = 1925 };
//                 Book book = new Book { Author = "F.Scott Fitzgerald" };

//                 Console.WriteLine($"Title: {items.Title}");
//                 Console.WriteLine($"Year Published: {items.YearPublished}");
//                 Console.WriteLine($"Author: {book.Author}");
//             }
//         }
//     }
// }

///////////////////////////////////////////////////////// EXAMPLE 2 ///////////////////////////////////////////////////////

// using System;

// namespace OOPConcepts
// {
//     abstract class RemoteControl
//     {
//         public string Brand { get; set; }

//         public abstract void PressButton();
//     }

//     class TelevisionRemote : RemoteControl
//     {
//         public override void PressButton()
//         {
//             Console.WriteLine($"{Brand} Remote Button Pressed: Turning on {Brand}");    
//         }
//     }

//     class AirconditionerRemote : RemoteControl
//     {
//         public override void PressButton()
//         {
//             Console.WriteLine($"{Brand} Remote Button Pressed: Setting Temperature to 20C");
//         }
//     }

//     class Program
//     {
//         static void Main(string[] args)
//         {
//             RemoteControl myTv = new TelevisionRemote { Brand = "TV" };
//             RemoteControl myAc = new AirconditionerRemote { Brand = "AC" };

//             myTv.PressButton(); 
//             myAc.PressButton();
//         }
//     }
// }

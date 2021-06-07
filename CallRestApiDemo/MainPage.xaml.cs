using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CallRestApiDemo
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }

    }


    public class BookManager
    {
        public static ObservableCollection<Book> GetBooks()
        {
            return new ObservableCollection<Book>() {
                new Book { Id = 1,Name= "Book 1",Author= "Auhtor 1" } 
            };

        }
    }
    public sealed partial class MainPage : Page
    {

        public ObservableCollection<Book> Books;
        public MainPage()
        {
            this.InitializeComponent();
            Books = BookManager.GetBooks();
            this.DataContextChanged += (e, s) => Bindings.Update();

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            
            Books.Add(new Book());
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var book = (Book)button.DataContext;

            Books.Remove(book);
        }
    }
}

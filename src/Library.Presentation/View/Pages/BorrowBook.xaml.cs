using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace ZaverecnyProjekt.View.Pages;

public partial class BorrowBook : Page, INotifyPropertyChanged
{
    private IBookService _bookService { get; set; }
    private ObservableCollection<Book> _books;

    public ObservableCollection<Book> Books
    {
        get => _books;
        set
        {
            _books = value;
            OnPropertyChanged(nameof(Books));
        }

    }
    public BorrowBook(IBookService bookService)
    {
        InitializeComponent();

        _bookService = bookService;

        Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        GetAllBooks();
        DataContext = this;
    }

    public async Task GetAllBooks()
    {
        var _books = await _bookService.GetAllBooks();

        Books = new ObservableCollection<Book>(_books);
    }

    private void RemoveSearchPlaceholder(object sender, RoutedEventArgs e)
    {
        lbl_searchPlaceholder.Visibility = Visibility.Collapsed;
    }

    private void NavigateBack(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }

    private void SelectReader(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void CreateBook(object sender, RoutedEventArgs e)
    {
        _bookService.AddBook(new Book() { Author = "Jakub Adamčík", Pages = 69, Title = tb_searchBox.Text });

        Console.WriteLine("Kniha se asi přidala");

        GetAllBooks();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
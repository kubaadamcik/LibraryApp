using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using ZaverecnyProjekt.View.Dialogs;

namespace ZaverecnyProjekt.View.Pages;

public partial class BorrowBook : Page, INotifyPropertyChanged
{
    private IBookService _bookService { get; set; }
    private IReaderService _readerService { get; set; }
    private ILibraryService _libraryService { get; set; }
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

    public BorrowBook(IBookService bookService, IReaderService readerService, ILibraryService libraryService)
    {
        InitializeComponent();

        _bookService = bookService;
        _readerService = readerService;
        _libraryService = libraryService;

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
        int bookId = _books[DgBooks.SelectedIndex].Id;
        SelectReaderDialog dialog = new SelectReaderDialog(_readerService, _libraryService, bookId, _bookService);

        dialog.ShowDialog();
    }

    private void CreateBook(object sender, RoutedEventArgs e)
    {
        _bookService.AddBook(new Book()
        {
            Author = "Jakub Adamčík", Description = "It's an interesting book!", Pages = 69, Title = tb_searchBox.Text
        });

        GetAllBooks();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
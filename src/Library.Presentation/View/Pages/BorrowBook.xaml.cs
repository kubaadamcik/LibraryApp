using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using ZaverecnyProjekt.View.Dialogs;

namespace ZaverecnyProjekt.View.Pages;

public partial class BorrowBook : Page, INotifyPropertyChanged
{
    private IBookService _bookService;
    private IReaderService _readerService;
    private ILibraryService _libraryService;

    private ObservableCollection<Book> _books;
    private ObservableCollection<Reader> _readers;

    public ObservableCollection<Book> Books
    {
        get => _books;
        set { _books = value; OnPropertyChanged(); }
    }

    public ObservableCollection<Reader> Readers
    {
        get => _readers;
        set { _readers = value; OnPropertyChanged(); }
    }

    public BorrowBook(IBookService bookService, IReaderService readerService, ILibraryService libraryService)
    {
        InitializeComponent();
        _bookService = bookService;
        _readerService = readerService;
        _libraryService = libraryService;

        DataContext = this;       // <- PŘESUNUTO SEM

        Loaded += OnLoaded;
    }

    private async void OnLoaded(object sender, RoutedEventArgs e)
    {
        await LoadData();            // <-- chybělo
        DataContext = this;          // <-- chybělo
    }

    private async Task LoadData()
    {
        var bookList = await _bookService.GetAllBooks();
        Books = new ObservableCollection<Book>(bookList);

        var readerList = await _readerService.GetAllReaders();
        Readers = new ObservableCollection<Reader>(readerList);
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
        if (DgBooks.SelectedIndex == -1 || DgReaders.SelectedIndex == -1) return;

        var selectedBook = Books[DgBooks.SelectedIndex];
        var dialog = new SelectReaderDialog(_readerService, _libraryService, selectedBook.Id, _bookService);
        dialog.ShowDialog();
    }

    private async void CreateBook(object sender, RoutedEventArgs e)
    {
        await _bookService.AddBook(new Book()
        {
            Author = "Jakub Adamčík",
            Description = "It's an interesting book!",
            Pages = 69,
            Title = tb_searchBox.Text
        });

        await LoadData();
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

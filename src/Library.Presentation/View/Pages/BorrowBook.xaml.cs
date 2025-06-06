﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using ZaverecnyProjekt.View.Dialogs;

namespace ZaverecnyProjekt.View.Pages;

public partial class BorrowBook : Page
{
    private IBookService _bookService;
    private IReaderService _readerService;
    private ILibraryService _libraryService;

    private List<Book> _books { get; set; }
    private List<Reader> _readers { get; set; }

    public BorrowBook(IBookService bookService, IReaderService readerService, ILibraryService libraryService)
    {
        InitializeComponent();
        _bookService = bookService;
        _readerService = readerService;
        _libraryService = libraryService;

        UpdateListboxes();
        
    }

    private async void UpdateListboxes()
    {
        _readers = await _readerService.GetAllReaders();
        _books = await _bookService.GetAllBooks();

        LbReaders.Items.Clear();
        LbBooks.Items.Clear();
        
        foreach (var book in _books)
        {
            LbBooks.Items.Add(book.Title);
        }

        foreach (var reader in _readers)
        {
            LbReaders.Items.Add(reader.FullName);
        }
    }

    private void RemoveSearchPlaceholder(object sender, RoutedEventArgs e)
    {
        lbl_searchPlaceholder.Visibility = Visibility.Collapsed;
    }

    private void NavigateBack(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }

    private async void Borrow(object sender, RoutedEventArgs e)
    {
        if (LbReaders.SelectedIndex == -1 || LbReaders.SelectedIndex == -1) return;
        int bookId = _books[LbBooks.SelectedIndex].Id;
        int readerId = _readers[LbReaders.SelectedIndex].Id;
        

        if (await _libraryService.BorrowBook(bookId, readerId))
        {
            var book = await _bookService.GetBookWithId(bookId);
            var reader = await _readerService.GetReaderWithId(readerId);
            
            MessageBox.Show($"Kniha {book.Title} byla zapůjčena čtenáři {reader.FullName}", "Úspěch");
            return;
        }

        MessageBox.Show("Nastala chyba");
    }

    private async void CreateBook(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(tb_searchBox.Text)) return;
        await _bookService.AddBook(new Book()
        {
            Author = "Jakub Adamčík",
            Description = "It's an interesting book!",
            Pages = 69,
            Title = tb_searchBox.Text
        });
        
        UpdateListboxes();
    }
}

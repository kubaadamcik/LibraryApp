using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace ZaverecnyProjekt.View.Pages;

public partial class ShowBooks : Page
{
    private readonly IBookService _bookService;
    private List<Book> _books;

    public ShowBooks(IBookService bookService)
    {
        InitializeComponent();
        _bookService = bookService;
        Loaded += OnLoaded;
    }

    private async void OnLoaded(object sender, RoutedEventArgs e)
    {
        try
        {
            _books = await _bookService.GetAllBooks();
            LbBooks.Items.Clear();
            
            foreach (var book in _books)
            {
                LbBooks.Items.Add($"{book.Title} - {book.Author}");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Chyba při načítání knih: {ex.Message}", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void NavigateBack(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }
}
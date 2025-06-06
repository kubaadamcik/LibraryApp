﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Library.Application.Interfaces;

namespace ZaverecnyProjekt.View.Pages;

public partial class MainPage : Page
{
    private IReaderService _readerService { get; set; }
    private IBookService _bookService { get; set; }
    private ILibraryService _libraryService { get; set; }
    private IBookTransactionService _bookTransactionService { get; set; }
    public MainPage(IReaderService readerService, IBookService bookService, ILibraryService libraryService, IBookTransactionService bookTransactionService)
    {
        InitializeComponent();

        _readerService = readerService;
        _bookService = bookService;
        _libraryService = libraryService;
        _bookTransactionService = bookTransactionService;

        //Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        if (Window.GetWindow(this) is Window window)
        {
            window.Height = this.Height;
            window.Width = this.Width;
        }
    }

    private void ManageReaders(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new ReaderManagement(_readerService, _bookTransactionService, _libraryService));
    }

    private void BorrowBook(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new BorrowBook(_bookService, _readerService, _libraryService));
    }
    
    private void ReturnBook(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new ReturnBook(_readerService, _bookTransactionService, _bookService, _libraryService));
    }
    
    private void ShowBooks(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new ShowBooks(_bookService));
    }
    
    private void ManageUsers(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new ManageUsers(_readerService, _bookTransactionService));
    }
    
    private void ManageBorrows(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new ManageBorrows(_readerService));
    }
    
    private void Settings(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new Settings(_readerService));
    }

    private void About(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new About(_readerService));
    }
}
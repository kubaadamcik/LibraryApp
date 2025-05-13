using System.Windows;
using Library.Application.Interfaces;
using Library.Domain.Entities;

namespace ZaverecnyProjekt.View.Dialogs;

public partial class SelectUserDialog : Window
{
    private IReaderService _readerService { get; set; }
    private List<Reader> _readers { get; set; }
     public SelectUserDialog(IReaderService readerService)
    {
        InitializeComponent();

        _readerService = readerService;

        _ = GetAllReaders();
    }

    private async Task GetAllReaders()
    {
        _readers = await _readerService.GetAllReaders();
    }
}
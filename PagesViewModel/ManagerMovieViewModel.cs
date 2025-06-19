using System.Collections.ObjectModel;
using PagesModel;

namespace PagesViewModel;

public class ManagerMovieViewModel
{
    public ObservableCollection<MovieViewModel> Movies { get; set; } = new();

    private readonly RepositoryMovie _repositoryMovie = new();
    private readonly MapMovieViewModel _mapMovieViewModel = new();
    
    private const int CountElements = 3;
    public ManagerMovieViewModel()
    {
        _currentPage = 1;
        LoadData();
    }

    private int _currentPage;

    public void ToPreviousPage()
    {
        if (_currentPage <= 1)
        {
            return;
        }

        _currentPage--;
        LoadData();
    }
    
    public void ToNextPage()
    {
        var totalCount = (int)Math.Ceiling((double)_repositoryMovie.Count / CountElements);
        if (_currentPage >= totalCount)
        {
            return;
        }
        
        _currentPage++;
        LoadData();
       
    }
    private void LoadData()
    {
        Movies.Clear();
        var movies = _repositoryMovie.LoadMovies(_currentPage, CountElements);
        var moviesViewModel = _mapMovieViewModel.Map(movies);
        foreach (var movieViewModel in moviesViewModel)
        {
            Movies.Add(movieViewModel);
        }
    }
}
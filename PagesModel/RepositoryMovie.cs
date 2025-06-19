namespace PagesModel;

public class RepositoryMovie
{
    private readonly List<Movie> _movies = new()
    {
        new()
        {
            Title = "Крёстный отец",
            Rating = 9.2,
            Genre = "Криминал",
            Year = 1972
        },
        new()
        {
            Title = "Побег из Шоушенка",
            Rating = 9.3,
            Genre = "Драма",
            Year = 1994
        },
        new()
        {
            Title = "Тёмный рыцарь",
            Rating = 9.0,
            Genre = "Боевик",
            Year = 2008
        },
        new()
        {
            Title = "Форрест Гамп",
            Rating = 8.8,
            Genre = "Драма",
            Year = 1994
        },
        new()
        {
            Title = "Начало",
            Rating = 8.8,
            Genre = "Фантастика",
            Year = 2010
        },
        new()
        {
            Title = "Матрица",
            Rating = 8.7,
            Genre = "Фантастика",
            Year = 1999
        },
        new()
        {
            Title = "Паразиты",
            Rating = 8.6,
            Genre = "Триллер",
            Year = 2019
        },
        new()
        {
            Title = "Джокер",
            Rating = 8.4,
            Genre = "Триллер",
            Year = 2019
        },
        new()
        {
            Title = "Аватар",
            Rating = 7.9,
            Genre = "Фантастика",
            Year = 2009
        },
        new()
        {
            Title = "Король Лев",
            Rating = 8.5,
            Genre = "Мультфильм",
            Year = 1994
        }
    };
    
    public int Count=>_movies.Count;
    public List<Movie> LoadMovies(int page,int countElements)
    {
        return _movies.Skip((page-1) * countElements).Take(countElements).ToList();
    }
}
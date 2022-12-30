namespace Psykologkompassen_Umbraco.Articles;
public class ApiResponse
{

    public string? Message { get; set; }
    public List<Article>? Articles { get; set; }
    public int TotalResults { get; set; }
}

public class Article
{
    public Source? Source { get; set; }
    public string? Author { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Url { get; set; }
    public string? UrlToImage { get; set; }
    public DateTime? PublishedAt { get; set; }
}
public class Source
{
    public string? Id { get; set; }
    public string? Name { get; set; }
}

public class BlogClient
{
    public static async Task<ApiResponse?> GetArticlesAsync()
    {
        // Articles-Api fetching top-headline articles in the category health from Sweden and the US. 
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", "C# App");

        try
        {
            var response = await client.GetFromJsonAsync<ApiResponse>("https://newsapi.org/v2/top-headlines?category=health&country=us&country=se&apiKey=3fbfb32ff6a64b1899c22e566a977ce7");
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

        }

        return null;
    }
}
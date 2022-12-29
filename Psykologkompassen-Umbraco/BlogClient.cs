namespace Psykologkompassen_Umbraco.Articles;
public class ApiResponse
{
    public string? status { get; set; }
    public int totalResults { get; set; }
    public List<Article>? articles { get; set; }
}

public class Article
{
    public Source? source { get; set; }
    public string? author { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public string? url { get; set; }
    public string? urlToImage { get; set; }
    public DateTime publishedAt { get; set; }
    public string? content { get; set; }
}
public class Source
{
    public string? id { get; set; }
    public string? name { get; set; }
}

public class BlogClient
{
    public static async Task<ApiResponse?> GetArticlesAsync()
    {
        // Articles-Api fetching top-headline articles in the category health from Sweden and the US. 
        var client = new HttpClient();
        var response = await client.GetFromJsonAsync<ApiResponse>("https://newsapi.org/v2/top-headlines?category=health&country=us&country=se&apiKey=3fbfb32ff6a64b1899c22e566a977ce7");

        return response;

    }
}
namespace homework_7;

public class Song
{
    private string name;
    private string author;
    private Song prev;

    public string Name {get => name; set => name = value;}

    public string Author {get => author; set => author = value;}

    public Song Prev {get => prev; set => prev = value;}
    
    public string Title()
    {
        return $"{name} - {author}";
    }
    
    public override bool Equals(object obj)
    {
        if (obj is Song otherSong)
        {
            return this.name == otherSong.name && this.author == otherSong.author;
        }
        return false;
    }
}
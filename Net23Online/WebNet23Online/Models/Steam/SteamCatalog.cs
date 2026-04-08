namespace WebNet23Online.Models.Steam
{
    //temp class as a database
    public static class SteamCatalog
    {
        public const int SPECIAL_OFFERS_PREVIEW_COUNT = 6;

        public static IList<GameGenre> Genres { get; } = new List<GameGenre>
        {
           GameGenre.All,
           GameGenre.Action,
           GameGenre.RPG,
           GameGenre.Shooter,
           GameGenre.Metroidvania
        };

        public static IList<SteamGameViewModel> All { get; } = new List<SteamGameViewModel>
        {
            new()
            {
                Title = "Baldurs Gate 3",
                ImageUrl = "https://cdn.cloudflare.steamstatic.com//steam/apps/1086940/header.jpg",
                Price = 29.99M,
                Genre = "RPG",
            },
            new()
            {
                Title = "Crysis 3",
                ImageUrl = "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/1282690/header.jpg?t=1694101866",
                Price = 9.99M,
                Genre = "Shooter",
            },
            new()
            {
                Title = "The Witcher 3: Wild Hunt",
                ImageUrl = "https://cdn.cloudflare.steamstatic.com//steam/apps/292030/header_292x136.jpg",
                Price = 20.99M,
                Genre = "RPG",
            },
            new()
            {
                Title = "Hollow Knight",
                ImageUrl = "https://cdn.cloudflare.steamstatic.com//steam/apps/367520/header.jpg",
                Price = 14.99M,
                Genre = "Metroidvania",
            },
            new()
            {
                Title = "Hollow Knight: Silksong",
                ImageUrl = "https://cdn.cloudflare.steamstatic.com//steam/apps/1030300/header.jpg",
                Price = 29.99M,
                Genre = "Metroidvania",
            },
            new()
            {
                Title = "The Last Of Us: Part 1",
                ImageUrl = "https://cdn.cloudflare.steamstatic.com//steam/apps/1888930/header.jpg",
                Price = 60.00M,
                Genre = "Action",
            },

            new()
            {
                Title = "The Last Of Us: Part II",
                ImageUrl = "https://cdn.cloudflare.steamstatic.com//steam/apps/2531310/header.jpg",
                Price = 79.99M,
                Genre = "Action",
                Description = "The Last of Us Part II Remastered on Steam is a third-person, action-adventure survival horror game where Ellie seeks justice in a post-apocalyptic USA five years after the original, featuring intense combat, stealth, and a deeply emotional story."
            },
        };
    }
}

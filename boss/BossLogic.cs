namespace boss
{
    public class BossLogic
    {
        private ILogger<BossLogic> logger;
        private IConfiguration config;
        private HttpClient httpClient;
        private List<Cell> board;

        public BossLogic(ILogger<BossLogic> logger, IConfiguration config) 
        {
            this.logger = logger;
            this.httpClient = new HttpClient();
            this.config = config;
        }
        internal async Task StartRunning(string password)
        {
            logger.LogInformation("BossLogic got call to start running.");


            if (password != config["password"])
            {
                logger.LogWarning("invalid password");
                return;
            }
            var server = config["SERVER"] ?? "https://hungrygame.azurewebsites.net";
            board = await httpClient.GetFromJsonAsync<List<Cell>>($"{server}/board");
            
        }
    }

    public class Cell
    {
        public Location location {get; set;}
        public bool isPillAvaliable {get; set;}
        public object occupiedBY {get; set;}
    }

    public class Location
    {
        public int row {get; set;}
        public int column {get; set;}
    }
}
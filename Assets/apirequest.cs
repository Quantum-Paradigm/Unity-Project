using System.Collections.Generic;

namespace APIRequestClasses
{
    public class UserRequest
    {
        public string name;
        public string password;

        public UserRequest(string username, string password)
        {
            this.name = username;
            this.password = password;
        }
    }

    public class StartGameRequest
    {
        public int mechanism_Id;
        public int gameTypeId;
        public int difficultyId;
        public string rounds;
        public bool ranked;
        public int[] users;

        public StartGameRequest(int mechanism_Id, int gameTypeId, int difficultyId, string rounds, bool ranked, int[] users)
        {
            this.mechanism_Id = mechanism_Id;
            this.gameTypeId = gameTypeId;
            this.difficultyId = difficultyId;
            this.rounds = rounds;
            this.ranked = ranked;
            this.users = users;
        }
    }

    public class GameSessionRequest
    {
        public int GameSessionId;

        public GameSessionRequest(int GameSessionId)
        {
            this.GameSessionId = GameSessionId;
        }
    }

    public class LeaderboardRequest
    {
        public int DifficultyId;
        public int GameTypeId;

        public LeaderboardRequest(int DifficultyId, int GameTypeId)
        {
            this.DifficultyId = DifficultyId;
            this.GameTypeId = GameTypeId;
        }
    }

    public class RoundData
    {
        public int round_id;
        public string image_url;
        public int correct_animal_id; 
        public string icon;

        public RoundData(int round_id, string image_url, int correct_animal_id, string icon)
        {
            this.round_id = round_id;
            this.image_url = image_url;
            this.correct_animal_id = correct_animal_id;
            this.icon = icon;
        }
    }

    public class LeaderBoardData
    {
        public int user_id;
        public int score;
        public string name;

        public LeaderBoardData(int user_id, int score, string name)
        {
            this.user_id = user_id;
            this.score = score;
            this.name = name;
        }
    }

    public class AddGuessRequest
    {
        public int User;
        public int RoundId;
        public int AnimalId;
        public int Score;

        public AddGuessRequest(int User, int RoundId, int guessed_animal_id, int Score)
        {
            this.User = User;
            this.RoundId = RoundId;
            this.AnimalId = guessed_animal_id;
            this.Score = Score;
        }
    }
}

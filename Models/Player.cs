namespace İleri_Veri_tabani.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        public required string PlayerName { get; set; }
        public int PlayerAge { get; set; }
        public string PlayerPosition { get; set; }
        public string PlayerSquad { get; set; }
        public int PlayerMinutesPlayed { get; set; }
        public float PlayerTouches { get; set; }
        public float PlayerTackles { get; set; }
    }
}

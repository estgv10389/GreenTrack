namespace GreenTrack.DTO
{
    public class CarbonGoalsDTO
    {
        #region Properties
        public string? Description { get; set; }
        public DateTime Deadline { get; set; }
        public decimal TargetEmission { get; set; }
        public int UserId { get; set; }
        #endregion
        #region Constructor
        public CarbonGoalsDTO()
        {
        }

        public CarbonGoalsDTO(string? description, DateTime deadline, decimal targetEmission, int userId)
        {
            Description = description;
            Deadline = deadline;
            TargetEmission = targetEmission;
            UserId = userId;
        }
        #endregion

    }
}

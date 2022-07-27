namespace jobPortal.Entities
{
    public record AppliedJob
    {
        public int appliedId { get; set; }
        public Candidate candidate { get; set; }
        public int jobID { get; set; }
    }
}
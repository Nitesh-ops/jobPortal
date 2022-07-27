namespace jobPortal.Entities
{
    public record AppliedJob
    {
        [Key]
        public int appliedId { get; set; }
        public int candidateId { get; set; }
        public int jobId { get; set; }
    }
}
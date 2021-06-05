

namespace NetSystem.Entity
{
    /// <summary>
    /// قعطعات مصرفی درخواست تعمیرات
    /// </summary>
    public class ConsumablePart
    {
        public long ID { get; set; }
        public long RequestID_FK { get; set; }
        public RequestRepair RequestRepair { get; set; }
        public string ConsumablePartTitel { get; set; }
        public int Number { get; set; }
        public int UnitID_FK { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
    }
}

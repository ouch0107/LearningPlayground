namespace LearningPlayground.Models.RandomModel
{
    /// <summary>
    /// 骰子隨機號碼1~6
    /// </summary>
    public class DiscModel : IRandomModel
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }

        public DiscModel()
        {
            Value1 = Random.Shared.Next(1, 7);
            Value2 = Random.Shared.Next(1, 7);
        }
    }
}

namespace LearningPlayground.Models.RandomModel
{
    /// <summary>
    /// 大樂透隨機號碼1~49
    /// </summary>
    public class LotteryModel: IRandomModel
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }

        public LotteryModel()
        {
            Value1 = Random.Shared.Next(1, 50);
            Value2 = Random.Shared.Next(1, 50);
        }
    }
}

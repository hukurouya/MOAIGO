using System.Linq;

/// <summary>
/// エンカウントイベントのファクトリークラス
/// </summary>
public static class EncountEventFactory
{
    private static IEncountEvent[] encounts =
    {
        new EncountGrowup()
    };

    /// <summary>
    /// イベントクラスの列挙
    /// </summary>
    public enum EncountKind
    {
        Growup
    }

    /// <summary>
    /// イベントを生成
    /// </summary>
    /// <param name="kind"></param>
    /// <returns></returns>
    public static IEncountEvent Create(EncountKind kind)
    {
        return encounts.SingleOrDefault(encount => encount.encountKind == kind);
    }

}

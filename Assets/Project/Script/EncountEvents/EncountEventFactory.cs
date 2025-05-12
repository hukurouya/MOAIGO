using System.Linq;

/// <summary>
/// �G���J�E���g�C�x���g�̃t�@�N�g���[�N���X
/// </summary>
public static class EncountEventFactory
{
    private static IEncountEvent[] encounts =
    {
        new EncountGrowup()
    };

    /// <summary>
    /// �C�x���g�N���X�̗�
    /// </summary>
    public enum EncountKind
    {
        Growup
    }

    /// <summary>
    /// �C�x���g�𐶐�
    /// </summary>
    /// <param name="kind"></param>
    /// <returns></returns>
    public static IEncountEvent Create(EncountKind kind)
    {
        return encounts.SingleOrDefault(encount => encount.encountKind == kind);
    }

}

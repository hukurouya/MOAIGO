using System.Collections.Generic;
using System.Linq;


public static class DoubleExtensions
{
    /// <summary>
    /// �P�ʂ�����������ɕϊ����܂��B
    /// 12 -> 12
    /// 1234 -> 1.23k
    /// 123456 -> 123k
    /// 12345678 -> 12.3m
    /// 
    /// �P�ʁFk, m, b, t, A, B, C, ... Z, AA, AB, AC, ...
    /// 
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public static string ToReadableString(this double d)
    {
        //�}�C�i�X�͈����C����
        if (d <= 0) return "0";
        //�\����͐����Ƃ��Č�����̂ŁAsuffix(kmbtABC��)�����Ȃ��ꍇ�͏�������j��
        if (d <= 1000) return ((int)d).ToString();

        //�L�������R���{�w���\�L�ŕ�����
        var s = d.ToString("0.00E000");

        //�L������
        float f = float.Parse(s.Substring(0, 4));

        //10�̎w��
        var e = int.Parse(s.Substring(5, 3));

        //���r���[�Ȏw���͐��l�Ɋ|�����킹�Ă���
        for (var i = 0; i < e % 3; i++)
        {
            f *= 10;
        }

        return f.ToString("###.##") + LevelToSuffix(e / 3);
    }

    /// <summary>
    /// 10^3���Ƃɂ���Suffix�̈ꗗ
    /// </summary>
    private static string[] _suffixes;

    private static string LevelToSuffix(int level)
    {
        if (_suffixes == null)
        {
            const string AtoZ = " ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var list = new List<string>();
            list.Add("");
            list.Add("k");
            list.Add("m");
            list.Add("b");
            list.Add("t");
            for (var x = 0; x < AtoZ.Length; x++)
                for (var y = 1; y < AtoZ.Length; y++)
                {
                    var str = string.Format("{0}{1}", AtoZ[x], AtoZ[y]).Trim();
                    list.Add(str);
                }

            _suffixes = list.Take(308).ToArray(); //double�͎w��308�܂�
        }

        return _suffixes[level];
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD.PersianDateTime.Core;

namespace FuelManagement.Core.Convertors;

public static class DataConvertor
{

    private static readonly string[] Pn = { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
    private static readonly string[] En = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

    public static string ToShamsi(this DateTime? value)
    {
        if (value != null)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear((DateTime)value) + "/" + pc.GetMonth((DateTime)value).ToString("00") + "/" +
                   pc.GetDayOfMonth((DateTime)value).ToString("00");
        }

        return null;
    }

    public static string ToShamsi(this DateTime value)
    {
        PersianCalendar pc = new PersianCalendar();
        return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
               pc.GetDayOfMonth(value).ToString("00");

    }

    public static string ToEnglishNumber(this string strNum)
    {
        var cash = strNum;
        for (var i = 0; i < 10; i++)
            cash = cash.Replace(Pn[i], En[i]);
        return cash;
    }

    public static DateTime? ToEnglish(this string? value)
    {
        if (value != null)
        {
            var split = value.Split('/');
            return new DateTime(int.Parse(split[0]),
                int.Parse(split[1]),
                int.Parse(split[2]),
                new PersianCalendar()
            );
        }

        return null;
    }

    public static DateTime AddToMonth(this DateTime value, int month)
    {
        PersianCalendar pc = new PersianCalendar();
        var s = pc.GetYear(value) + "/" + (pc.GetMonth(value) + month).ToString("00") + "/" +
                pc.GetDayOfMonth(value).ToString("00") + "/" + pc.GetHour(value) + "/" + pc.GetMinute(value) + "/" + pc.GetSecond(value);

        var sd = s.Split('/', StringSplitOptions.RemoveEmptyEntries);
        int yars = Convert.ToInt32(sd[0]);
        int mon = Convert.ToInt32(sd[1]);
        int day = Convert.ToInt32(sd[2]);
        int hour = Convert.ToInt32(sd[3]);
        int minute = Convert.ToInt32(sd[4]);
        int second = Convert.ToInt32(sd[5]);

        DateTime dt = new DateTime(yars, mon, day, hour, minute, second, pc);
        return dt;
    }

    public static DateTime ToGeorgianDateTime(this string persianDate)
    {
        persianDate = persianDate.ToEnglishNumber();
        var split = persianDate.Split('/');

        var year = int.Parse(split[0]);
        var month = int.Parse(split[1]);
        var day = int.Parse(split[2]);
        return new DateTime(year, month, day, new PersianCalendar());
    }


    public static DateTime ToGregorian(this string persianDate)
    {
        if (string.IsNullOrWhiteSpace(persianDate))
            return DateTime.MinValue;

        var parts = persianDate.Split('-');
        if (parts.Length != 3)
            return DateTime.MinValue;

        int year = int.Parse(parts[0]);
        int month = int.Parse(parts[1]);
        int day = int.Parse(parts[2]);

        var persianDateTime = new PersianDateTime(year, month, day);
        return persianDateTime.ToDateTime();
    }


    public static DateTime PersianToGregorian(this string persianDate)
    {
        if (string.IsNullOrWhiteSpace(persianDate))
            throw new ArgumentException("فرمت تاریخ صحیح نیست");

        var parts = persianDate.Split('-', '/');
        if (parts.Length != 3)
            throw new FormatException("فرمت باید yyyy-MM-dd یا yyyy/MM/dd باشد");

        int y = int.Parse(parts[0]);
        int m = int.Parse(parts[1]);
        int d = int.Parse(parts[2]);

        var pc = new PersianCalendar();
        return pc.ToDateTime(y, m, d, 0, 0, 0, 0);
    }
}

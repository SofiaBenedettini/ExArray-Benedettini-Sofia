using BlaisePascal.ExArray_Benedettini_Sofia.Domain;

namespace BlaisePascal.ExArray_Benedettini_Sofia.Tests
{
    public class WeeklyScheduleTest
    {
        [Fact]
        public void Constructor_ValidName_InitializesCorrectly()
        {
            WeeklySchedule schedule = new WeeklySchedule("Mario Rossi");
            Assert.Equal("Mario Rossi", schedule.EmployeeName);
        }

        [Fact]
        public void Constructor_NullName_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new WeeklySchedule(null));
        }

        [Fact]
        public void Constructor_EmptyName_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new WeeklySchedule(""));
        }

        [Fact]
        public void Constructor_WhitespaceName_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new WeeklySchedule("   "));
        }

        [Fact]
        public void SetHoursForDay_ValidHours_UpdatesSuccessfully()
        {
            WeeklySchedule schedule = new WeeklySchedule("Luigi Verdi");
            schedule.SetHoursForDay("Lunedì", 8.0);
            Assert.Equal(8.0, schedule.TotalHoursWorked());
        }

        [Fact]
        public void SetHoursForDay_NegativeHours_ThrowsArgumentException()
        {
            WeeklySchedule schedule = new WeeklySchedule("Anna Neri");
            Assert.Throws<ArgumentException>(() => schedule.SetHoursForDay("Lunedì", -1.0));
        }

        [Fact]
        public void SetHoursForDay_ExceedingMaxHours_ThrowsArgumentException()
        {
            WeeklySchedule schedule = new WeeklySchedule("Anna Neri");
            Assert.Throws<ArgumentException>(() => schedule.SetHoursForDay("Lunedì", 10.5));
        }

        [Fact]
        public void SetHoursForDay_NullDay_ThrowsArgumentException()
        {
            WeeklySchedule schedule = new WeeklySchedule("Anna Neri");
            Assert.Throws<ArgumentException>(() => schedule.SetHoursForDay(null, 8.0));
        }

        [Fact]
        public void SetHoursForDay_EmptyDay_ThrowsArgumentException()
        {
            WeeklySchedule schedule = new WeeklySchedule("Anna Neri");
            Assert.Throws<ArgumentException>(() => schedule.SetHoursForDay("", 8.0));
        }

        [Fact]
        public void SetHoursForDay_WhitespaceDay_ThrowsArgumentException()
        {
            WeeklySchedule schedule = new WeeklySchedule("Anna Neri");
            Assert.Throws<ArgumentException>(() => schedule.SetHoursForDay("   ", 8.0));
        }

        [Fact]
        public void HasOvertime_TotalHoursGreaterThan40_ReturnsTrue()
        {
            WeeklySchedule schedule = new WeeklySchedule("Giorgio Rossi");
            schedule.SetHoursForDay("Lunedì", 9.0);
            schedule.SetHoursForDay("Martedì", 9.0);
            schedule.SetHoursForDay("Mercoledì", 9.0);
            schedule.SetHoursForDay("Giovedì", 9.0);
            schedule.SetHoursForDay("Venerdì", 6.0);

            Assert.True(schedule.HasOvertime());
        }

        [Fact]
        public void HasOvertime_DayWithMoreThan8Hours_ReturnsTrue()
        {
            WeeklySchedule schedule = new WeeklySchedule("Giorgio Rossi");
            schedule.SetHoursForDay("Lunedì", 9.0);

            Assert.True(schedule.HasOvertime());
        }

        [Fact]
        public void HasOvertime_NormalHours_ReturnsFalse()
        {
            WeeklySchedule schedule = new WeeklySchedule("Giorgio Rossi");
            schedule.SetHoursForDay("Lunedì", 8.0);

            Assert.False(schedule.HasOvertime());
        }

        [Fact]
        public void DayWithMostHours_ReturnsCorrectDay()
        {
            WeeklySchedule schedule = new WeeklySchedule("Sara Blu");
            schedule.SetHoursForDay("Mercoledì", 9.5);

            Assert.Equal("mercoledì", schedule.DayWithMostHours());
        }

        [Fact]
        public void SetHoursForDay_UppercaseDay_UpdatesSuccessfully()
        {
            WeeklySchedule schedule = new WeeklySchedule("Mario Rossi");
            schedule.SetHoursForDay("LUNEDÌ", 8.0);
            Assert.Equal(8.0, schedule.TotalHoursWorked());
        }

        [Fact]
        public void SetHoursForDay_MixedCaseDay_UpdatesSuccessfully()
        {
            WeeklySchedule schedule = new WeeklySchedule("Mario Rossi");
            schedule.SetHoursForDay("mErCoLeDì", 7.5);
            Assert.Equal(7.5, schedule.TotalHoursWorked());
        }

        [Fact]
        public void DayWithMostHours_UppercaseInputDay_ReturnsLowercaseDay()
        {
            WeeklySchedule schedule = new WeeklySchedule("Sara Blu");
            schedule.SetHoursForDay("SABATO", 9.0);

            Assert.Equal("sabato", schedule.DayWithMostHours());
        }
    }
}

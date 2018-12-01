using System;

namespace les_desktop.Model
{
    class Appointment: DomainEntity
    {
        private DateTime Date;
        private DateTime MonthAndYear;
        private DateTime MorningEntrance;
        private DateTime MorningOut;
        private DateTime AfternoonEntrance;
        private DateTime AfternoonOut;
        private DateTime NightEntrance;
        private DateTime NightOut;
        private DateTime ParticularExit;
        private DateTime ParticularExitReturn;
        private DateTime Balance;
        private DateTime HoursLeft;
        private DateTime DayOvertime;
        private double PreviousBalanceInserted;
        private bool Calculated;
    }
}
